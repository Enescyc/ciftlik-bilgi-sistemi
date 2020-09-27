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
    public partial class Koyunlar : Form
    {
        public Koyunlar()
        {
            InitializeComponent();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
        Ciftlik_DbEntities ctx = new Ciftlik_DbEntities();
        Ships a = new Ships();
        public class DataGridViewCheckboxCellFilter : DataGridViewCheckBoxCell
        {
            public DataGridViewCheckboxCellFilter() : base()
            {
                this.FalseValue = 0;
                this.TrueValue = 1;
                this.Value = false;
            }
        }
        public void listele()
        {
            var kuzular = from i in ctx.Ships
                          where i.durum == "Çiftlikte"
                          orderby i.ShipId descending
                          select new
                          {
                              KayıtNumarası=i.ShipId,
                              ÇiftlikNumarası = i.CiftlikId,
                              DevletNumarası = i.DevletId,
                              Cinsiyet = i.cinsiyet,
                              DoğumTarihi = i.DogumTarihi,
                              Durum = i.durum,
                              
                              Not = i.Not,
                              DoğumSayisi = i.DogumTipi,



                          };
            bunifuCustomDataGrid1.DataSource = kuzular.ToList();
        }
        private void BunifuThinButton23_Click(object sender, EventArgs e)
        {
            ShowVaccines a = new ShowVaccines(true);
            a.Show();
        }

        private void BunifuThinButton24_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.TextLength==0&&textBox5.TextLength==0&&bunifuDropdown1.SelectedIndex==-1)
                    {

                    MessageBox.Show("Lütfen Alanları Doldurun", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    a.CiftlikId = int.Parse(textBox4.Text.ToString());
                    a.DevletId = int.Parse(textBox5.Text.ToString());
                    a.DogumTarihi = bunifuDatepicker2.Value;
                    a.durum = bunifuDropdown1.SelectedItem.ToString();
                    a.cinsiyet = bunifuDropdown2.SelectedItem.ToString();
                    a.Not = richTextBox1.Text;
                    a.Price = 0;
                    a.DogumTipi = comboBox1.SelectedItem.ToString();
                    ctx.Ships.Add(a);
                    ctx.SaveChanges();
                    MessageBox.Show("Koyun Kaydı Başarıyla Tamamlandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               

            }
            catch (Exception a)
            {

                
            }
          
        }

        private void Koyunlar_Load(object sender, EventArgs e)
        {
            bunifuDatepicker1.Value = DateTime.Now;
            bunifuDatepicker2.Value = DateTime.Now;
            int toplam = ctx.Childs.Where(x => x.kuzu_durum == "Çiftlikte").Count() + ctx.Ships.Where(x => x.durum == "Çiftlikte").Count();
            koyunsayisi.Text += ctx.Ships.Where(x => x.durum == "Çiftlikte").Count().ToString();
            olenkoyun.Text += ctx.Ships.Where(x => x.durum == "Öldü").Count().ToString();
            satilankoyun.Text += ctx.Ships.Where(x => x.durum == "Satildi").Count().ToString();
            erkekkoyun.Text += ctx.Ships.Where(x => x.cinsiyet == "Erkek").Count().ToString();
            disikoyun.Text += ctx.Ships.Where(x => x.cinsiyet == "Dişi").Count().ToString();
            toplamsayi.Text += toplam.ToString();
            bunifuDropdown1.Items.Add("Çiftlikte");
            bunifuDropdown1.Items.Add("Öldü");
            bunifuDropdown1.Items.Add("Satildi");
            bunifuDropdown2.Items.Add("Erkek");
            bunifuDropdown2.Items.Add("Dişi");
            comboBox1.Items.Add("Doğum Yok");
            comboBox1.Items.Add("Tek Doğum");
            comboBox1.Items.Add("İkiz");
            comboBox1.Items.Add("Üçüz");


            DataGridViewCheckBoxColumn col_chkbox = new DataGridViewCheckBoxColumn();
            {
                col_chkbox.HeaderText = "İşaretle";
                col_chkbox.Name = "checked";
                col_chkbox.CellTemplate = new DataGridViewCheckboxCellFilter();
            }
            this.bunifuCustomDataGrid1.Columns.Add(col_chkbox);
            listele();

        }

        private void BunifuThinButton25_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(textBox4.Text.ToString() + " Çiftlik numaralı kaydı güncellemek istiyor musunuz?" + a.ToString(), "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = int.Parse(bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString());

                    var update = ctx.Ships.Find(id);
                    update.CiftlikId = int.Parse(textBox4.Text.ToString());
                    update.DevletId = int.Parse(textBox5.Text.ToString());

                    update.durum = bunifuDropdown1.SelectedItem.ToString();
                    update.cinsiyet = bunifuDropdown2.SelectedItem.ToString();
                    update.Not = richTextBox1.Text;
                    update.DogumTipi = comboBox1.SelectedItem.ToString();
                    if (satisfiyat.Visible)
                    {
                        update.Price = int.Parse(satisfiyati.Text);
                    }
                    ctx.SaveChanges();
                    MessageBox.Show("Kayıt Başarıyla Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    



            }
            catch (Exception a)
            {
                MessageBox.Show("Güncelleme Sırasında Hata Oluştu"+a.ToString(), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information) ;

            }
        }

        private void BunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
            textBox4.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            textBox5.Text= bunifuCustomDataGrid1.SelectedRows[0].Cells[3].Value.ToString();
            bunifuDropdown2.Text = Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[4].Value.ToString();
            bunifuDropdown1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString();
            richTextBox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[7].Value.ToString();
            comboBox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void BunifuThinButton27_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BunifuThinButton26_Click(object sender, EventArgs e)
        {

            try
            {
                int id = int.Parse(bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString());
                var update = ctx.Ships.Find(id);

                if (MessageBox.Show(update.CiftlikId.ToString() + " Çiftlik numaralı kaydı silmek istiyor musunuz?" , "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ctx.Ships.Remove(update);
                    ctx.SaveChanges();
                    MessageBox.Show(update.CiftlikId.ToString() + " Çiftlik numaralı kayıt başarıyla silindi" , "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              

            }
            catch (Exception)
            {

              
            }
          
            
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }
        ShipVaccine asi = new ShipVaccine();
        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 && textBox2.TextLength == 0)
            {
                MessageBox.Show("Lütfen Aşı Adını ve Aşı Maliyetini Giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                for (int i = 0; i < bunifuCustomDataGrid1.Rows.Count; i++)
                {



                    asi.ShipId = int.Parse(bunifuCustomDataGrid1.Rows[i].Cells[1].Value.ToString());

                    asi.VaccineName = textBox1.Text;
                    asi.VaccineDate = bunifuDatepicker1.Value;
                    asi.Price = int.Parse(textBox2.Text);

                    ctx.ShipVaccine.Add(asi);
                    ctx.SaveChanges();

                }
                MessageBox.Show("Aşılar Başarıyla Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.TextLength == 0 && textBox2.TextLength == 0)
                {
                    MessageBox.Show("Lütfen Aşı Adını ve Aşı Maliyetini Giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    for (int i = 0; i < bunifuCustomDataGrid1.Rows.Count; i++)
                    {


                        if (bunifuCustomDataGrid1.Rows[i].Cells[0].Value.ToString() != "False")
                        {
                            asi.ShipId = int.Parse(bunifuCustomDataGrid1.Rows[i].Cells[1].Value.ToString());

                            asi.VaccineName = textBox1.Text;
                            asi.VaccineDate = bunifuDatepicker1.Value;
                            asi.Price = int.Parse(textBox2.Text);

                            ctx.ShipVaccine.Add(asi);
                            ctx.SaveChanges();


                        }


                    }
                    MessageBox.Show("Aşılar Başarıyla Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }




            }


            catch (Exception)
            {

                throw;
            }
        }

        private void BunifuThinButton28_Click(object sender, EventArgs e)
        {

            if (textBox3.TextLength == 0)

            {
                MessageBox.Show("Lütfen Koyun Çiftlik Numarasını Giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                int ciftlik = int.Parse(textBox3.Text);
                var kuzular = from i in ctx.Ships

                              where i.CiftlikId == ciftlik
                              orderby i.ShipId descending
                              select new
                              {
                                  KayıtNumarası = i.ShipId,
                                  ÇiftlikNumarası = i.CiftlikId,
                                  DevletNumarası = i.DevletId,
                                  Cinsiyet = i.cinsiyet,
                                  DoğumTarihi = i.DogumTarihi,
                                  Durum = i.durum,
                                  Not = i.Not,
                              };
                bunifuCustomDataGrid1.DataSource = kuzular.ToList();
            }
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {


           
        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void BunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bunifuDropdown1.SelectedItem.ToString() == "Satildi")
            {
                satisfiyat.Visible = true;
                satisfiyati.Visible = true;
            }
            else
            {
                satisfiyat.Visible = false;
                satisfiyati.Visible = false;
            }
        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Label15_Click(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void Label13_Click(object sender, EventArgs e)
        {

        }

        private void BunifuDropdown2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BunifuDatepicker2_onValueChanged(object sender, EventArgs e)
        {

        }
    }
}
