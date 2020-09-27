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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Doğum Yok");
            comboBox1.Items.Add("Tek Doğum");
            comboBox1.Items.Add("İkiz");
            comboBox1.Items.Add("Üçüz");

        }
        Ciftlik_DbEntities ctx = new Ciftlik_DbEntities();

        private void BunifuThinButton21_Click(object sender, EventArgs e)//sealships
        {
            var item = from i in ctx.Ships
                       where i.durum == "Satildi"
                       select new
                       {
                           KayıtNumarası = i.ShipId,
                           ÇiftlikNumarası = i.CiftlikId,
                           DevletNumarası = i.DevletId,
                           Cinsiyet = i.cinsiyet,
                           DoğumTarihi = i.DogumTarihi,
                           Durum = i.durum,
                           Not = i.Not,
                           DoğumTipi = i.DogumTipi,
                           SatildiğiMiktar = i.Price,

                       };
            bunifuCustomDataGrid1.DataSource = item.ToList();
        }

        private void Sealchilds_Click(object sender, EventArgs e)
        {
            var item = from i in ctx.Childs
                       where i.kuzu_durum == "Satildi"
                       select new
                       {
                           KayıtNumarası = i.ShipId,
                           ÇiftlikNumarası = i.Ciftlikno,
                           DevletNumarası = i.Devletno,
                           Cinsiyet = i.kuzu_cinsiyet,
                           DoğumTarihi = i.kuzu_date,
                           Durum = i.kuzu_durum,
                           Not = i.kuzu_not,
                           SatildiğiMiktar = i.kuzu_Price,

                       };
            bunifuCustomDataGrid1.DataSource = item.ToList();
        }

        private void Findmom_Click(object sender, EventArgs e)
        {

            if (textBox1.TextLength==0||textBox1.Text== "Anne Çiftlik Numarası")
            {
                MessageBox.Show("Lütfen Anne Çiftlik Numarası Girin", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int anneno = int.Parse(textBox1.Text);
                foreach (var ship in ctx.Ships)
                {
                    if (anneno == ship.CiftlikId)
                    {
                        anneno = ship.ShipId;
                    }

                }
                var item = from i in ctx.Childs
                           join a in ctx.Ships
                           on i.MomId equals a.ShipId
                           where i.MomId == anneno


                           select new
                           {
                               KuzuÇiftlikNo = i.Ciftlikno,
                               KuzuDurum = i.kuzu_durum,
                               KuzuDogumTarihi = i.kuzu_date,
                               AnneCiflikNo = a.CiftlikId,
                               AnneDurum = a.durum,
                               DogumTipi = a.DogumTipi

                           };
                bunifuCustomDataGrid1.DataSource = item.ToList();
            }
           

        }

        private void Birth_Click(object sender, EventArgs e)
        {
            string s = comboBox1.Text;
            var item = from i in ctx.Ships
                       where i.DogumTipi == s
                       select new
                       {
                           KayıtNumarası = i.ShipId,
                           ÇiftlikNumarası = i.CiftlikId,
                           DevletNumarası = i.DevletId,
                           Cinsiyet = i.cinsiyet,
                           DoğumTarihi = i.DogumTarihi,
                           Durum = i.durum,
                           Not = i.Not,
                           DoğumTipi = i.DogumTipi,
                           SatildiğiMiktar = i.Price,

                       };
            bunifuCustomDataGrid1.DataSource = item.ToList();
        }

        private void BunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            var item = from i in ctx.Childs
                       join a in ctx.Ships
                       on i.MomId equals a.ShipId
                       where i.kuzu_durum == "Öldü"
                       select new
                       {
                           KuzuÇiftlikNo = i.Ciftlikno,
                           KuzuDurum = i.kuzu_durum,
                           KuzuDogumTarihi = i.kuzu_date,
                           AnneCiflikNo = a.CiftlikId,
                           AnneDurum = a.durum,
                           DogumTipi = a.DogumTipi
                       };
            bunifuCustomDataGrid1.DataSource = item.ToList();
        }

        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {
            var item = from i in ctx.Ships
                       where i.durum == "Öldü"
                       select new
                       {
                           KayıtNumarası = i.ShipId,
                           ÇiftlikNumarası = i.CiftlikId,
                           DevletNumarası = i.DevletId,
                           Cinsiyet = i.cinsiyet,
                           DoğumTarihi = i.DogumTarihi,
                           Durum = i.durum,
                           Not = i.Not,
                           DoğumTipi = i.DogumTipi,
                           SatildiğiMiktar = i.Price,

                       };
            bunifuCustomDataGrid1.DataSource = item.ToList();

        }
    }
}
