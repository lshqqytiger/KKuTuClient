using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace BFKKuTuClient
{
    public partial class Login : Form
    {
        public static LoginGetEventHandler LoginGetEvent;
        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string url = "https://bfkkutu.kr/login/local?id=" + id.Text + "&pw=" + pw.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var responseReader = new StreamReader(webStream);
            var response = responseReader.ReadToEnd();
            responseReader.Close();
            if (response.IndexOf("로그인 실패") != -1) MessageBox.Show("로그인 실패");
            else
            {
                url = "https://bfkkutu.kr/client/data?id=" + id.Text + "&pw=" + pw.Text;
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                webResponse = request.GetResponse();
                webStream = webResponse.GetResponseStream();
                responseReader = new StreamReader(webStream);
                response = responseReader.ReadToEnd();
                responseReader.Close();
                MessageBox.Show("로그인 성공");
                id.Enabled = false;
                pw.Enabled = false;
                loginBtn.Enabled = false;
                LoginGetEvent(id.Text, pw.Text, response.Split('|'));
                this.Close();
            }
        }
    }
}
