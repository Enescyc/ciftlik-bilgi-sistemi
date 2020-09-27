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
    public partial class ShowVaccines : Form
    {
        bool chose = false;
        public ShowVaccines(bool choose)
        {
            InitializeComponent();
            chose = choose;
        }
        void Vaccines(bool choose)
        {
            if (choose)
            {

                DateTime date = dateTimePicker1.Value;



                var list = from i in ctx.ShipVaccine
                           join a in ctx.Ships
                           on i.ShipId equals a.ShipId
                           where i.VaccineDate.Day == date.Day && i.VaccineDate.Month == date.Month && i.VaccineDate.Year == date.Year
                           select new
                           {

                               AsiAdı = i.VaccineName,
                               AsiTarihi = i.VaccineDate,
                               AsiMaliyet=i.Price,
                               KoyunCiftlikNo = a.CiftlikId,
                               KoyunDevletNo = a.DevletId,
                               Cinsiyet = a.cinsiyet,
                               a.Not,
                           };

                bunifuCustomDataGrid1.DataSource = list.ToList();
                AsiSayisi.Text = "Listedeki Aşı Sayısı:";
                AsiSayisi.Text += bunifuCustomDataGrid1.Rows.Count.ToString();
            }
            else
            {
                 DateTime date = dateTimePicker1.Value;



                var list = from i in ctx.ChildVaccine
                           join a in ctx.Childs
                           on i.ChildId equals a.ShipId
                           where i.VaccineDate.Day == date.Day && i.VaccineDate.Month == date.Month && i.VaccineDate.Year == date.Year
                           select new
                           {
                               AsiAdı = i.VaccineName,
                               AsiTarihi = i.VaccineDate,
                               KoyunCiftlikNo = a.Ciftlikno,
                               KoyunDevletNo = a.Devletno,
                               AsiMaliyeti=i.Price,
                               Cinsiyet = a.kuzu_cinsiyet,
                               Not = a.kuzu_not,
                          
                       };
         
            bunifuCustomDataGrid1.DataSource = list.ToList();
            AsiSayisi.Text = "Listedeki Aşı Sayısı:";
            AsiSayisi.Text += bunifuCustomDataGrid1.Rows.Count.ToString();
            }
        }
        Ciftlik_DbEntities ctx = new Ciftlik_DbEntities();
        private void ShowVaccines_Load(object sender, EventArgs e)
        {

           
        }

        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            Vaccines(chose);
        }

        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (chose)
            {

                DateTime date = dateTimePicker1.Value;
                int no = int.Parse(textBox1.Text);


                var list = from i in ctx.ShipVaccine
                           join a in ctx.Ships
                           on i.ShipId equals a.ShipId
                           where a.CiftlikId == no
                           select new
                           {

                               AsiAdı = i.VaccineName,
                               AsiTarihi = i.VaccineDate,
                               AsiMaliyet = i.Price,
                               KoyunCiftlikNo = a.CiftlikId,
                               KoyunDevletNo = a.DevletId,
                               Cinsiyet = a.cinsiyet,
                               a.Not,
                           };

                bunifuCustomDataGrid1.DataSource = list.ToList();
                AsiSayisi.Text = "Listedeki Aşı Sayısı:";
                AsiSayisi.Text += bunifuCustomDataGrid1.Rows.Count.ToString();
            }
            else
            {
                DateTime date = dateTimePicker1.Value;


                int no = int.Parse(textBox1.Text.ToString());
                var list = from i in ctx.ChildVaccine
                           join a in ctx.Childs
                           on i.ChildId equals a.ShipId
                           where a.Ciftlikno == no
                           select new
                           {
                               AsiAdı = i.VaccineName,
                               AsiTarihi = i.VaccineDate,
                               KoyunCiftlikNo = a.Ciftlikno,
                               KoyunDevletNo = a.Devletno,
                               AsiMaliyeti = i.Price,
                               Cinsiyet = a.kuzu_cinsiyet,
                               Not = a.kuzu_not,

                           };

                bunifuCustomDataGrid1.DataSource = list.ToList();
                AsiSayisi.Text = "Listedeki Aşı Sayısı:";
                AsiSayisi.Text += bunifuCustomDataGrid1.Rows.Count.ToString();
            }

        }
        void BetweenList(DateTime start, DateTime finish)

        {


            if (chose)
            {
                var list = from i in ctx.ShipVaccine
                           join a in ctx.Ships
                           on i.ShipId equals a.ShipId
                           where i.VaccineDate.Day >= start.Day && i.VaccineDate.Month >= start.Month && i.VaccineDate.Year >= start.Year && i.VaccineDate.Day <= finish.Day && i.VaccineDate.Month <= finish.Month && i.VaccineDate.Year <= finish.Year
                           select new
                           {
                               AsiAdı = i.VaccineName,
                               AsiTarihi = i.VaccineDate,
                               KoyunCiftlikNo = a.CiftlikId,
                               Cinsiyet = a.cinsiyet,
                               KoyunDevletNo = a.DevletId,
                               a.Not,
                           };

                bunifuCustomDataGrid1.DataSource = list.ToList();
                AsiSayisi.Text = "Listedeki Aşı Sayısı:";
                AsiSayisi.Text += bunifuCustomDataGrid1.Rows.Count.ToString();

            }
            else
            {
                var list = from i in ctx.ChildVaccine
                           join a in ctx.Childs
                           on i.ChildId equals a.ShipId
                           where i.VaccineDate.Day >= start.Day && i.VaccineDate.Month >= start.Month && i.VaccineDate.Year >= start.Year && i.VaccineDate.Day <= finish.Day && i.VaccineDate.Month <= finish.Month && i.VaccineDate.Year <= finish.Year
                           select new
                           {
                               AsiAdı = i.VaccineName,
                               AsiTarihi = i.VaccineDate,
                               KoyunCiftlikNo = a.Ciftlikno,
                               Cinsiyet = a.kuzu_cinsiyet,
                               KoyunDevletNo = a.Devletno,
                               Not=a.kuzu_not,
                           };

                bunifuCustomDataGrid1.DataSource = list.ToList();
                AsiSayisi.Text = "Listedeki Aşı Sayısı:";
                AsiSayisi.Text += bunifuCustomDataGrid1.Rows.Count.ToString();
            }

           

        }
        private void BunifuThinButton23_Click(object sender, EventArgs e)
        {
            BetweenList(dateTimePicker2.Value, dateTimePicker3.Value);
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
