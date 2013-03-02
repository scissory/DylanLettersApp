using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Sockets;

namespace TesterApp
{
    public partial class FormSender : Form
    {
        TcpClient client = null;
        public FormSender()
        {
            InitializeComponent();
        }

        private void FormSender_Load(object sender, EventArgs e)
        {

            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                IPEndPoint iep = new IPEndPoint(localAddr, port);



                // Perform a blocking call to accept requests. 
                // You could also user server.AcceptSocket() here.
                client = new TcpClient();
                client.Connect(iep);




            }
            catch (Exception ex)
            {
                string exc = ex.Message;
            }
            
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {

                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();
                byte[] toSendByte;
                if(e.KeyCode == System.Windows.Forms.Keys.Back)
                    toSendByte = System.Text.Encoding.Unicode.GetBytes("\b");
                else
                    toSendByte = System.Text.Encoding.Unicode.GetBytes(richTextBox1.Text.Substring(richTextBox1.Text.Length - 1, 1));

                stream.Write(toSendByte, 0, toSendByte.Length);
            }
            catch { }
        }
    }
}
