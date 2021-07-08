using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace BFKKuTuClient
{
    public partial class CreateRoomDialog : Form
    {
        public static CreateRoomEventHandler CreateRoomEvent;

        public string[] MODE = new string[] { };
        public JObject RULE = JObject.Parse("{}");
        public JObject OPTIONS = JObject.Parse("{}");
        public JObject Lang = JObject.Parse("{}");
        public Form1.ClientData user = new Form1.ClientData();
        public string[] roundTimeArray = new string[]{"5", "10", "30", "60", "90", "120", "150", "200", "300"};
        public CreateRoomDialog(string[] MODE, JObject RULE, JObject OPTIONS, JObject Lang, Form1.ClientData user)
        {
            InitializeComponent();

            this.MODE = MODE;
            this.RULE = RULE;
            this.OPTIONS = OPTIONS;
            this.Lang = Lang;
            this.user = user;

            titleTextBox.Text = user.nickname + "님의 방";
            foreach (string i in MODE) {
                if (i == "MSH") continue;
                modeComboBox.Items.Add(Lang["mode"+i].ToString());
            }
            roundTimeComboBox.SelectedIndex = 4;
        }

        private void modeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear(optsPanel);
            int count = 0;
            foreach (string i in RULE[MODE[modeComboBox.SelectedIndex]]["opts"].ToObject<string[]>()) {
                if (OPTIONS[i].ToString() == "tmnt" && !user.admin) continue;
                CheckBox checkBox = new CheckBox();
                checkBox.AutoSize = true;
                checkBox.Location = new Point((count % 2) * 150, 15 * (int)Math.Round((double)(count / 2)));
                checkBox.Name = i;
                checkBox.Text = Lang["opt"+OPTIONS[i]["name"]].ToString();
                checkBox.Parent = optsPanel;
                count++;
            }
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            int playerLimit = Int32.Parse(playerLimitTextBox.Text);
            int round = Int32.Parse(roundTextBox.Text);
            JObject opts = JObject.Parse(@"{'injpick':[],'manner':false,'injeong':false,'mission':false,'proverb':false,'sami':false,'no2':false,'unlimited':false,'short':false,'randomturn':false,'unknownword':false,'returns':false,'abcmission':false,'ignoreinitial':false,'blockword':false,'eventmode':false,'moremission':false,'rankgame':false,'ogow':false,'selecttheme':false,'bantheme':false,'middletoss':false,'tournament':false,'twenty':false,'bandouble':false,'midmanner':false,'item':false,'joinwhilegaming':false}");
            Dictionary<string, string> roomData = new Dictionary<string, string>();
            if (titleTextBox.Text == String.Empty) {
                MessageBox.Show(Lang["error_431"].ToString());
                return;
            };
            if (playerLimit < 1 || playerLimit > 8) {
                MessageBox.Show(Lang["error_432"].ToString());
                return;
            }
            if (round < 1 || round > 10) {
                MessageBox.Show(Lang["error_433"].ToString());
                return;
            }
            roomData.Add("title", titleTextBox.Text);
            roomData.Add("password", passwordTextBox.Text);
            roomData.Add("playerLimit", playerLimitTextBox.Text);
            roomData.Add("mode", modeComboBox.SelectedIndex.ToString());
            roomData.Add("round", roundTextBox.Text);
            roomData.Add("roundTime", roundTimeArray[roundTimeComboBox.SelectedIndex]);
            foreach (Control control in optsPanel.Controls) {
                if (control is CheckBox) {
                    CheckBox i = control as CheckBox;
                    opts[i.Name] = i.Checked;
                }
            }
            roomData.Add("opts", opts.ToString());
            CreateRoomEvent(roomData);
            this.Close();
        }

        delegate void ClearPanelCallback(Panel panel);

        private void Clear(Panel panel)
        {
            if (panel.InvokeRequired)
            {
                ClearPanelCallback d = new ClearPanelCallback(Clear);
                this.Invoke(d, new object[] { panel });
            }
            else
            {
                panel.Controls.Clear();
            }
        }
    }
}
