using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatRoom
{
    public partial class Room : Form
    {
        private string username;
        public Room(string username)
        {
            this.username = username;
            InitializeComponent();
            this.label1.Text = this.username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserController.Leave(this.username);
            this.Hide();
            Authentification form = new Authentification();
            form.Show();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void RefreshMessages()
        {
            string result = "";
            foreach (Message message in MessageController.getMessages())
            {
                string row = ""; 
                if (message.message.Equals("__joined__"))
                {
                    row = "User " + message.user.username + " a rejoint la discussion. ╰(*°▽°*)╯";
                }else if (message.message.Equals("__left__"))
                {
                    row = "User " + message.user.username + " a quitté la discussion ┻━┻ ︵ヽ(`Д´)ﾉ︵ ┻━┻";
                }
                else
                {
                    row = message.user.username + ":" + message.message;
                }

                result += row + "\n";
            }

            if (!this.label3.Text.Equals(result)) this.label3.Text = result;
        }

        public void RefreshActiveList()
        {
            string result = "";
            foreach (User user in UserController.getActiveUsers())
            {
                result += "OwO " + user.username + "\n";
            }

            if (!result.Equals(this.activeLabel.Text)) this.activeLabel.Text = result;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.RefreshActiveList();

            this.RefreshMessages();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageController.Send(this.richTextBox1.Text, this.username);
            this.richTextBox1.Text = "";
            this.RefreshMessages();
        }

        private void Room_Load(object sender, EventArgs e)
        {
            this.RefreshActiveList();
            this.RefreshMessages();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
