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
    public partial class Kuzular : Form
    {
        public Kuzular()
        {
            InitializeComponent();
        }

        private void BunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {

        }
        Ciftlik_DbEntities ctx = new Ciftlik_DbEntities();
        Childs a = new Childs();
        ChildVaccine asi = new ChildVaccine();
        public class DataGridViewCheckboxCellFilter : DataGridViewCheckBoxCell
        {
            public DataGridViewCheckboxCellFilter() : base()
            {
                this.FalseValue = 0;
                this.TrueValue = 1;
                this.Value = false;
               
            
            }
        }
        void asiekle()
        {
            try
            {
                kuzusayisi.Text = bunifuCustomDataGrid1.Rows[0].Cells[0].Value.ToString();


                for (int i = 0; i < bunifuCustomDataGrid1.Rows.Count; i++)
                    {

                    
                        if (bunifuCustomDataGrid1.Rows[i].Cells[0].Value.ToString()!="False")
                        {
                            asi.ChildId = int.Parse(bunifuCustomDataGrid1.Rows[i].Cells[1].Value.ToString());

                            asi.VaccineName = textBox1.Text;
                            asi.VaccineDate = bunifuDatepicker1.Value;
                            asi.Price = int.Parse(textBox2.Text);

                        ctx.ChildVaccine.Add(asi);
                        ctx.SaveChanges();


                    }
                    else
                    {
                      
                    }

                    }
                    MessageBox.Show("Aşılar Başarıyla Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }

            
            catch (Exception)
            {

                throw;
            }
           
        }
        void asilariekle()
        {
            for (int i = 0; i < bunifuCustomDataGrid1.Rows.Count; i++)
            {

 

                asi.ChildId = int.Parse(bunifuCustomDataGrid1.Rows[i].Cells[1].Value.ToString());

                asi.VaccineName = textBox1.Text;
                asi.VaccineDate = bunifuDatepicker1.Value;
                asi.Price = int.Parse(textBox2.Text);

                ctx.ChildVaccine.Add(asi);
                ctx.SaveChanges();

            }
            MessageBox.Show("Aşılar Başarıyla Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BunifuThinButton23_Click(object sender, EventArgs e)
        {
            ShowVaccines show = new ShowVaccines(false);
            show.Show();
        }

        private void BunifuThinButton24_Click(object sender, EventArgs e)

        {
            try
            {
                if (textBox4.TextLength == 0 && textBox5.TextLength == 0 && bunifuDropdown1.SelectedIndex == -1)
                {

                    MessageBox.Show("Lütfen Alanları Doldurun", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int momid = int.Parse(textBox5.Text.ToString());
                    foreach (var item in ctx.Ships)
                    {
                        if (item.CiftlikId == momid)
                        {
                            a.MomId = item.ShipId;

                        }


                    }
                    a.Ciftlikno = int.Parse(textBox4.Text.ToString());
                    a.Devletno = int.Parse(textBox3.Text.ToString());
                    a.kuzu_date = bunifuDatepicker2.Value;
                    a.kuzu_durum = bunifuDropdown1.SelectedItem.ToString();
                    a.kuzu_cinsiyet = bunifuDropdown2.SelectedItem.ToString();
                    a.kuzu_not = richTextBox1.Text;
                    if (satisfiyati.Visible)
                    {
                        a.kuzu_Price = int.Parse(satisfiyati.Text);
                    }
                    else
                    {
                        a.kuzu_Price = 0;
                    }


                    ctx.Childs.Add(a);
                    ctx.SaveChanges();
                    MessageBox.Show("Kaydedildi");
                }
               




            }
            catch (Exception a)
            {


            }
        }

        public void listele()
        {
            var kuzular = from i in ctx.Childs
                          from a in ctx.Ships
                          where i.kuzu_durum == "Çiftlikte" &&i.MomId==a.ShipId
                          orderby i.ShipId descending
                          select new
                          {
                              KayıtNo=i.ShipId,
                              ÇiftlikNumarası = i.Ciftlikno,
                              DevletNumarası = i.Devletno,
                              Cinsiyet = i.kuzu_cinsiyet,
                              DoğumTarihi = i.kuzu_date,
                              Durum = i.kuzu_durum,
                              Not = i.kuzu_not,
                              AnneCiftlikNumarası = a.CiftlikId
                          };
            bunifuCustomDataGrid1.DataSource = kuzular.ToList();
        }


    


        void asikontrol()
        {
            if (textBox1.TextLength==0&&textBox2.TextLength==0)
            {
                MessageBox.Show("Lütfen Aşı Adını ve Aşı Maliyetini Giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    private void Kuzular_Load(object sender, EventArgs e)
        {
            bunifuDatepicker1.Value = DateTime.Now;
            bunifuDatepicker2.Value = DateTime.Now;
            int toplam = ctx.Childs.Where(x => x.kuzu_durum == "Çiftlikte").Count() + ctx.Ships.Where(x => x.durum == "Çiftlikte").Count();
            kuzusayisi.Text += ctx.Childs.Where(x => x.kuzu_durum == "Çiftlikte").Count().ToString();
            ölenkuzu.Text += ctx.Childs.Where(x => x.kuzu_durum == "Öldü").Count().ToString();
            satilankuzu.Text += ctx.Childs.Where(x => x.kuzu_durum == "Satildi").Count().ToString();
            erkekkuzu.Text += ctx.Childs.Where(x => x.kuzu_cinsiyet == "Erkek").Count().ToString();
            disikuzu.Text += ctx.Childs.Where(x => x.kuzu_cinsiyet == "Dişi").Count().ToString();
            toplamsayi.Text += toplam.ToString();
            bunifuDropdown1.Items.Add("Çiftlikte");
            bunifuDropdown1.Items.Add("Öldü");
            bunifuDropdown1.Items.Add("Satildi");
            bunifuDropdown2.Items.Add("Erkek");
            bunifuDropdown2.Items.Add("Dişi");
            DataGridViewCheckBoxColumn col_chkbox = new DataGridViewCheckBoxColumn();
            {
                col_chkbox.ValueType = typeof(bool);
                col_chkbox.HeaderText = "İşaret";
                col_chkbox.Name = "check";
                col_chkbox.CellTemplate = new DataGridViewCheckboxCellFilter();
            }
            this.bunifuCustomDataGrid1.Columns.Add(col_chkbox);
            listele();
            
        }

        private void BunifuThinButton25_Click(object sender, EventArgs e)
        {
            int ciftlikno = int.Parse(this.ciftlikno.Text.ToString());
            var bul = ctx.Childs.Where(x => x.Ciftlikno == ciftlikno);
            bunifuCustomDataGrid1.DataSource = bul.ToList();
        }

        private void Panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 && textBox2.TextLength == 0)
            {
                MessageBox.Show("Lütfen Aşı Adını ve Aşı Maliyetini Giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                asilariekle();
            }
        

        }

        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 && textBox2.TextLength == 0)
            {
                MessageBox.Show("Lütfen Aşı Adını ve Aşı Maliyetini Giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                asiekle();
            }
         
        }

        private void BunifuThinButton23_Click_1(object sender, EventArgs e)
        {
            ShowVaccines a = new ShowVaccines(false);
            a.Show();
        }

        private void BunifuThinButton25_Click_1(object sender, EventArgs e)
        {
            if (ciftlikno.TextLength==0)

            {
                MessageBox.Show("Lütfen Koyun Çiftlik Numarasını Giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                int ciftlik = int.Parse(ciftlikno.Text);
                var kuzular = from i in ctx.Childs
                              from a in ctx.Ships
                              where  i.MomId == a.ShipId && i.Ciftlikno == ciftlik
                              orderby i.ShipId descending
                              select new
                              {
                                  KayıtNo = i.ShipId,
                                  ÇiftlikNumarası = i.Ciftlikno,
                                  DevletNumarası = i.Devletno,
                                  Cinsiyet = i.kuzu_cinsiyet,
                                  DoğumTarihi = i.kuzu_date,
                                  Durum = i.kuzu_durum,
                                  Not = i.kuzu_not,
                                  AnneCiftlikNumarası = a.CiftlikId
                              };
                bunifuCustomDataGrid1.DataSource = kuzular.ToList();
            }
           
        }

        private void BunifuThinButton27_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BunifuThinButton26_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(textBox4.Text.ToString() + " Çiftlik numaralı kaydı güncellemek istiyor musunuz?" + a.ToString(), "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = int.Parse(bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString());

                    var update = ctx.Childs.Find(id);
                    update.Ciftlikno = int.Parse(textBox4.Text.ToString());
                    update.Devletno = int.Parse(textBox3.Text.ToString());
                    update.kuzu_date = bunifuDatepicker2.Value;
                    update.kuzu_durum = bunifuDropdown1.SelectedItem.ToString();
                    update.kuzu_cinsiyet = bunifuDropdown2.SelectedItem.ToString();
                    update.kuzu_not = richTextBox1.Text;
                    if (satisfiyat.Visible)
                    {
                        update.kuzu_Price = int.Parse(satisfiyati.Text);
                    }


                    ctx.SaveChanges();
                    MessageBox.Show(update.Ciftlikno.ToString() + " Çiftlik numaralı kayıt başarıyla güncellendi" + a.ToString(), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


            }
            catch (Exception a)
            {


            }
        }

        private void BunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void BunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            /*
             * KayıtNo = i.ShipId,
                              ÇiftlikNumarası = i.Ciftlikno,
                              DevletNumarası = i.Devletno,
                              Cinsiyet = i.kuzu_cinsiyet,
                              DoğumTarihi = i.kuzu_date,
                              Durum = i.kuzu_durum,
                              Not = i.kuzu_not,
                              AnneCiftlikNumarası = a.CiftlikId*/
            textBox4.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[8].Value.ToString();
        bunifuDropdown1.Text= bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString();
            bunifuDropdown2.Text=Text= bunifuCustomDataGrid1.SelectedRows[0].Cells[4].Value.ToString();
            richTextBox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[7].Value.ToString();


        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void BunifuThinButton28_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString());
                var update = ctx.Childs.Find(id);

                if (MessageBox.Show(update.Ciftlikno.ToString() + " Çiftlik numaralı kaydı silmek istiyor musunuz?" + a.ToString(), "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ctx.Childs.Remove(update);
                    ctx.SaveChanges();
                    MessageBox.Show(update.Ciftlikno.ToString() + " Çiftlik numaralı kayıt başarıyla silindi" + a.ToString(), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception)
            {


            }

        }

        private void BunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bunifuDropdown1.SelectedItem.ToString()== "Satildi")
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

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Satisfiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Ciftlikno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
    }
