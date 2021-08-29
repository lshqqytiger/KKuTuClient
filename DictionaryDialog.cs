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
    public partial class DictionaryDialog : Form
    {
        WordRequestDialog WordRequestDialogForm = new WordRequestDialog();

        public DictionaryDialog()
        {
            InitializeComponent();
        }

        private void requestBtn_Click(object sender, EventArgs e)
        {
            WordRequestDialogForm.Close();
            WordRequestDialogForm = new WordRequestDialog();
            WordRequestDialogForm.Owner = this;
            WordRequestDialogForm.Show();
        }
    }
}
