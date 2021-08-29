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
    public partial class GameResultDialog : Form
    {
        public GameResultDialog(JObject res, string id, int level)
        {
            if (res["result"] == null) return;

            InitializeComponent();

            JToken me = new JObject();

            int rankCount = 0;
            foreach (JToken i in res["result"])
            {
                if (i["id"].ToString() == id) me = i;
                Panel user = new Panel();
                Label rank = new Label();
                Label nickname = new Label();
                Label score = new Label();
                rank.Text = (rankCount + 1).ToString();
                rank.Location = new Point(0, 0);
                rank.Parent = user;
                nickname.Text = res["users"][i["id"].ToString()]["profile"]["name"].ToString();
                nickname.Location = new Point(40, 0);
                nickname.Parent = user;
                score.Text = i["score"].ToString();
                score.Location = new Point(80, 0);
                score.Parent = user;
                user.Location = new Point(0, 20 * rankCount);
                user.Parent = rankingPanel;
                //AppendPanel(rankingPanel, user);
                rankCount++;
            }
            gainedExpLabel.Text = me["reward"]["score"].ToString();
            gainedMoneyLabel.Text = me["reward"]["money"].ToString();
            levelLabel.Text = level.ToString();
            /*SetText(gainedExpLabel, me["reward"]["score"].ToString());
            SetText(gainedMoneyLabel, me["reward"]["money"].ToString());
            SetText(levelLabel, level.ToString());*/
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*delegate void AppendPanelCallback(Panel target, Panel element);
        delegate void SetTextCallback(dynamic label, string text);

        private void AppendPanel(Panel target, Panel element)
        {
            if (target.InvokeRequired)
            {
                AppendPanelCallback d = new AppendPanelCallback(AppendPanel);
                Invoke(d, new object[] { target, element });
            }
            else
            {
                element.Parent = target;
            }
        }

        private void SetText(dynamic label, string text)
        {
            if (label.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                Invoke(d, new object[] { label, text });
            }
            else
            {
                label.Text = text;
            }
        }*/
    }
}
