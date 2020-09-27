using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiftlikCalisma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Ciftlik_DbEntities ctx = new Ciftlik_DbEntities();
        private void Form1_Load(object sender, EventArgs e)
        {

            int koyun = ctx.Ships.Count();
            int kuzu = ctx.Childs.Count();
          int  toplam = koyun + kuzu;






        }

        private void Panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            Koyunlar a = new Koyunlar();
            a.Show();

        }

        private void BunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            Kuzular a = new Kuzular();
            a.Show();
        }

        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {
            Settings a = new Settings();
            a.Show();
        }
    }
}
