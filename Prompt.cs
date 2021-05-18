using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BFKKuTuClient
{
    public partial class Prompt : Form
    {
        public static PromptGetEventHandler PromptGetEvent;
        public Prompt(string text)
        {
            InitializeComponent();

            label.Text = text;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            PromptGetEvent(promptInput.Text);
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
