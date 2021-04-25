using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LW_01_02.Registration_and_login
{
    public partial class Form1 : Form
    {
        public static Form1 IS { get; set; }
        public static Users USE { get; set; }
        Model1 db = new Model1();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 RL = new Form2();
            IS = this;
            this.Hide();
            RL.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " " || textBox2.Text == " ")
            {
                MessageBox.Show("Заполните поля для входа!");
                return;
            }
            Users USR = db.Users.Find(textBox1.Text);
            if ((USR != null) && (USR.Password == textBox2.Text))
            {
                USE = USR;
                IS = this;
            }
            if (USR.Role == "Директор")
            {
                Form3 Dir = new Form3();
                Dir.Show();
                this.Hide();
            }
            else if (USR.Role == "Менеджер")
            {
                Form4 Man = new Form4();
                Man.Show();
                this.Hide();
            }
            else if (USR.Role == "Администратор")
            {
                Form5 Adm = new Form5();
                Adm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show($"Роли {USR.Role} в системе нет!");
                return;
            }
        }
    }
}
