using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class Form1 : Form
    {
        private Clock clock;
        public Form1()
        {
            InitializeComponent();
            clock = new Clock();
            clock.SecondTick += Clock_SecondTick;
        }

        private void Clock_SecondTick(Clock sender)
        {
            txtBxMoscow.Text = clock.GetLocalTime("Москва").ToLongTimeString();
            txtBxLondon.Text = clock.GetLocalTime("Лондон").ToLongTimeString();
            txtBxVladivostock.Text = clock.GetLocalTime("Владивосток").ToLongTimeString();
        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clock.Start();
        }

        private void стопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clock.Stop();
        }
    }
}
