using System;
using System.Drawing;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace BFKKuTuClient
{
    public partial class GameResultDialog : Form
    {
        public GameResultDialog(JObject res, string id, int level)
        {
            InitializeComponent();

            if(res["result"] != null)
            {
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
                    AppendPanel(rankingPanel, user);
                    rankCount++;
                }
                SetText(gainedExpLabel, me["reward"]["score"].ToString());
                SetText(gainedMoneyLabel, me["reward"]["money"].ToString());
                SetText(levelLabel, level.ToString());
            }
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        delegate void AppendPanelCallback(Panel target, Panel element);
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
        }
    }
}
