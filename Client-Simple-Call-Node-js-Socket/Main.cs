using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client_Simple_Call_Node_js_Socket
{
    public partial class Main : Form
    {
        // Call Socket
        Node.Socket Socket;

        public static string passingText;

        public Main()
        {
            InitializeComponent();

            Socket = new Node.Socket(Properties.Settings.Default.localhost);

            // cross-thread-operation-not-valid
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;

            if (text == "")
            {
                MessageBox.Show("Please Enter Text", "Alert");
            }
            else
            {

                Socket.Emit("send to server", new { data = text }, fn =>
                {
                    var obj = (Newtonsoft.Json.Linq.JObject)(fn);
                    var status = Convert.ToString(obj["status"]);
                    var data = Convert.ToString(obj["data"]);

                    showData.Text = data;
                    textBox1.Text = "";
                    textBox1.Focus();
                });
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }
    }
}
