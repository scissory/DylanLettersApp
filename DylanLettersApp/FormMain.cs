using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;


namespace DylanLettersApp
{
    public partial class FormMain : Form
    {
        private const string DYLANLETTERSSOURCE = "DylanLettersListnerSource";
        private static TcpListener server = null;
        private static bool cancelPending = false;
        private static Object lockObject = new Object();
        private static AutoResetEvent resetEvent = new AutoResetEvent(false);
        private static string IPAdd = string.Empty;
        private static int IPPort = 13000;
        private static String errorFromThreadMessage = string.Empty;



        public FormMain()
        {
            InitializeComponent();
        }

        private void Log(string input)
        {
            if (Properties.Settings.Default.LogEvents)
            {
                if (!EventLog.SourceExists(DYLANLETTERSSOURCE))
                    EventLog.CreateEventSource(DYLANLETTERSSOURCE, "Application");

                EventLog.WriteEntry(DYLANLETTERSSOURCE, input, EventLogEntryType.Information);
            }
        }
        
        private void FormMain_Load(object sender, EventArgs e)
        {
            lblComputerName.Text = Dns.GetHostName();
            IPAddress[] localAddrArray = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress add in localAddrArray)
            {
                if (add.IsIPv6LinkLocal || add.IsIPv6Multicast || add.IsIPv6SiteLocal || add.IsIPv6Teredo)
                    continue;
                else
                    cboIPAddresses.Items.Add(add.ToString());
            }

            if (cboIPAddresses.Items.Count > 0)
                FormMain.IPAdd = cboIPAddresses.SelectedText;
            else
                cboIPAddresses.SelectedText = "No IP Address found!";

            
        }




        static void StartListener(Object state)
        {
      
            
            try
            {
                IPAddress localAddr = IPAddress.Parse(IPAdd);
                server = new TcpListener(localAddr, IPPort);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[8];


              
                // Enter the listening loop.
                while (!cancelPending)
                {
                    
                    // Perform a blocking call to accept requests. 
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();


                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;
                                   
                    
                    // Loop to receive all the data sent by the client. 
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        //data = System.Text.Encoding.Unicode.GetString .GetChars(bytes, 0, i);
                        string result = System.Text.UTF8Encoding.Default.GetString(bytes);
                        IntPtr hWnd = GetForegroundWindow();
                        switch(result[0])
                        {
                            case ' ':
                                SendKeysLocal(" ", hWnd);
                                break;
                            case '\n':
                                SendKeysLocal("{ENTER}", hWnd);
                                break;
                            case '+':
                                SendKeysLocal("{+}", hWnd);
                                break;
                            case '%':
                                SendKeysLocal("{%}", hWnd);
                                break;
                            default:
                                SendKeysLocal(result[0].ToString(), hWnd);
                                break;
                        }
                    }

                    // Shutdown and end connection
                    client.Close();

                }
                server.Stop();
                
            }
            catch (Exception e)
            {
                FormMain.errorFromThreadMessage = e.Message;
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
                resetEvent.Set();
                
            }

        }

        
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            SetCancel(false);
            SetErrorString(string.Empty);
            timer1.Start();
            if (cboIPAddresses.Text.Length == 0)
            {
                errorProvider1.SetError(cboIPAddresses, "Please select an IP address to use before starting");
                return;
            }
            else
                errorProvider1.SetError(cboIPAddresses, "");

            try
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(StartListener));
                lblStatus.Text = "Service is: Running";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            catch { };

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            SetCancel(true);
            timer1.Stop();
            lblStatus.Text = "Service is: NOT RUNNING";
            lblStatus.ForeColor = System.Drawing.Color.Maroon;


        }

        private void SetCancel(bool value)
        {
            Monitor.Enter(lockObject);
            try
            {
                FormMain.cancelPending = value;
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }

        private void SetErrorString(string value)
        {
            Monitor.Enter(lockObject);
            try
            {
                FormMain.errorFromThreadMessage = value;
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }

        private string GetErrorString()
        {
            Monitor.Enter(lockObject);
            try
            {
                return FormMain.errorFromThreadMessage;
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }

        private static void SendKeysLocal(string input, IntPtr hWnd)
        {
            Monitor.Enter(lockObject);
            try
            {
                SetForegroundWindow(hWnd);
                SendKeys.SendWait(input);

            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }


        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern IntPtr GetForegroundWindow();

        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            int port;
            if (!Int32.TryParse(txtPort.Text, out port))
                errorProvider1.SetError(txtPort, "Port must be a whole number and cannot be blank");
            else
            {
                errorProvider1.SetError(txtPort, "");
                FormMain.IPPort = port;
            }
        }

        private void cboIPAddresses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboIPAddresses.SelectedItem.ToString().Length > 0)
            {
                FormMain.IPAdd = cboIPAddresses.SelectedItem.ToString();
                errorProvider1.SetError(cboIPAddresses, "");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Monitor.Enter(lockObject);
            try
            {
                if (!String.IsNullOrEmpty(FormMain.errorFromThreadMessage))
                {
                    txtError.Visible = true;
                    txtError.Text = FormMain.errorFromThreadMessage;
                    lblStatus.Text = "Service is: NOT RUNNING";
                    lblStatus.ForeColor = System.Drawing.Color.Maroon;
                }

            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }

        



    }
}
