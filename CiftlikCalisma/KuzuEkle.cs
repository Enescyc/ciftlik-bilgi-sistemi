using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xxx
{
    public partial class KuzuEkle : Form
    {
        public KuzuEkle()
        {
            InitializeComponent();
        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        Ciftlik_DbEntities ctx = new Ciftlik_DbEntities();
        Ships ships = new Ships();
        Childs childs = new Childs();

        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {
            childs.CiftlikNo =int.Parse( kuzuciftlikno.Text.ToString());
            childs.DevletNo=int.Parse(kuzudevletno.Text.ToString());
            childs.Kuzu_DoğumTarihi = kuzudate.Value;
            childs.Kuzu_durum = kuzudurum.selectedValue.ToString();
            childs.Kuzu_Not = kuzunot.Text;
            childs.Kuzu_price = 0;
            childs.MomId= int.Parse(anneno.Text.ToString());
            ctx.Childs.Add(childs);
            ctx.SaveChanges();
        }

        private void KuzuEkle_Load(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            ships.CiftlikId = int.Parse(koyunciftlikno.Text.ToString());
            ships.DevletId = int.Parse(koyundevletno.Text.ToString());
            ships.DogumTarihi = koyundate.Value;
            ships.durum = koyundurum.selectedValue.ToString();
            ships.Not = koyunnot.Text;
            ships.Price = 0;
            ctx.Ships.Add(ships);
            ctx.SaveChanges();

        }
    }
}
