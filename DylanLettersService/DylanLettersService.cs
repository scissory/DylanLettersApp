using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Sockets;


namespace DylanLettersService
{
    public partial class DylanLettersService : ServiceBase
    {
        public DylanLettersService()
        {
            InitializeComponent();
        }
        private const string DYLANLETTERSSOURCE = "DylanLettersListnerSource";
        TcpListener server = null;
        private bool stopPending = false;


        private void Log(string input)
        {
            if (Properties.Settings.Default.LogEvents)
            {
                if (!EventLog.SourceExists(DYLANLETTERSSOURCE))
                    EventLog.CreateEventSource(DYLANLETTERSSOURCE, "Application");

                EventLog.WriteEntry(DYLANLETTERSSOURCE, input, EventLogEntryType.Information);
            }
        }

        private void DoWork()
        {
            // Set the TcpListener on port 13000.
            Int32 port = 13000;

            IPAddress localAddr = null;
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localAddr = ip;
                }
            }

            try
            {

                //IPAddress localAddr = IPAddress.Parse("172.25.172.55");
                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];


                // Enter the listening loop.
                while (!stopPending)
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
                        string result = System.Text.UnicodeEncoding.Default.GetString(bytes);
                        SendKeys.Send(result);
                    }

                    // Shutdown and end connection
                    client.Close();

                }
            }
            catch (Exception e)
            {
                Log("Socket Exception, Message: " + e.Message);
                Log("Socket Exception, Stack Trace: " + e.StackTrace);
            }

        }

        protected override void OnStart(string[] args)
        {
            ThreadPool.QueueUserWorkItem(
        }

        protected override void OnStop()
        {
            stopPending = true;
            if (server != null)
            {
                try
                {
                    server.Stop();
                }
                catch { };
            }

        }
    }
}
