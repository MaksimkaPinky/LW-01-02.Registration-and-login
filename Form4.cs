﻿using System;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = "Добрый день, " + Form1.USE.Name + "!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.IS.Show();
        }
    }
}
