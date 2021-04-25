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
    public partial class Form2 : Form
    {
        Model1 db = new Model1();
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.IS.Show();
        }

        private void button1_Click(object sender, EventArgs e) //Проверка заполнения данных в регистрационной форме
        {
            if (textBox1.Text == " " || textBox2.Text == " " || textBox3.Text == " " || textBox4.Text == " " || textBox5.Text == " ")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }
            if ((textBox4.Text != "Менеджер") && (textBox4.Text != "Администратор") && (textBox4.Text != "Директор") && (textBox4.Text != "Заказчик"))
            {
                MessageBox.Show("Введена неверная роль!");
                return;
            }
            Users USR = db.Users.Find(textBox1.Text);
            if (USR != null)
            {
                MessageBox.Show("Пользователь с таким логином уже существует!");
                return;
            }
            USR = new Users();
            USR.Login = textBox1.Text;
            USR.Password = textBox2.Text;
            USR.Role = textBox4.Text;
            USR.Name = textBox5.Text;
            db.Users.Add(USR);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Пользователь " + USR.Login + " зарегистрирован!");
            Form1.IS.Show();
            this.Close();
            return;
        }
    }
}
