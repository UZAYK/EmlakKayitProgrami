using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace EmlakKayıtProgrami
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-39JJ5DA\\SQLSERVER;Initial Catalog=siteler;Integrated Security=True");

        
        private void verilerigöster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From sitebilgi", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["site"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                ekle.SubItems.Add(oku["metre"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());
                ekle.SubItems.Add(oku["no"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["notlar"].ToString());
                ekle.SubItems.Add(oku["satkira"].ToString());

                listView1.Items.Add(ekle);



            }
            baglan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text== "TEK Sitesi")
            {
                btnTekno.BackColor = Color.Yellow;
                btnTekno.ForeColor = Color.Black;

                btnAsk.BackColor = Color.Black;
                btnTarim.BackColor = Color.Black;
                btnSanayi.BackColor = Color.Black;

                btnAsk.ForeColor = Color.White;
                btnTarim.ForeColor = Color.White;
                btnSanayi.ForeColor = Color.White;
                
            }
            if (comboBox1.Text == "UM Sitesi")
            {
                btnTarim.BackColor = Color.Yellow;
                btnTarim.ForeColor = Color.Black;

                btnAsk.BackColor = Color.Black;
                btnSanayi.BackColor = Color.Black;
                btnTekno.BackColor = Color.Black;

                btnAsk.ForeColor = Color.White;
                btnTekno.ForeColor = Color.White;
                btnSanayi.ForeColor = Color.White;
            }
            if (comboBox1.Text == "AL Sitesi")
            {
                btnSanayi.BackColor = Color.Yellow;
                btnSanayi.ForeColor = Color.Black;

                btnAsk.BackColor = Color.Black;
                btnTarim.BackColor = Color.Black;
                btnTekno.BackColor = Color.Black;

                btnAsk.ForeColor = Color.White;
                btnTarim.ForeColor = Color.White;
                btnTekno.ForeColor = Color.White;
            }
            if (comboBox1.Text == "AŞK Sitesi")
            {
                btnAsk.BackColor = Color.Yellow;
                btnAsk.ForeColor = Color.Black;

                btnSanayi.BackColor = Color.Black;
                btnTarim.BackColor = Color.Black;
                btnTekno.BackColor = Color.Black;

                
                btnTarim.ForeColor = Color.White;
                btnTekno.ForeColor = Color.White;
                btnSanayi.ForeColor = Color.White;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut= new SqlCommand("update sitebilgi set id='" + textBox4.Text.ToString() + "',site='" + comboBox1.Text.ToString() + "',oda='" + comboBox3.Text.ToString() + "',metre='" + textBox1.Text.ToString() + "',fiyat='" + textBox2.Text.ToString() + "',blok='" + comboBox5.Text.ToString() + "',no='" + textBox4.Text.ToString() + "',adsoyad='" + textBox7.Text.ToString() + "',telefon='" + textBox8.Text.ToString() + "',notlar='" + textBox3.Text.ToString() + "',satkira='" + comboBox2.Text.ToString() + "'where id="+id+"", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigöster();
        }

        private void btngoruntule_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into sitebilgi (id,site,oda,metre,fiyat,blok,no,adsoyad,telefon,notlar,satkira)values ('" + textBox4.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox5.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox2.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigöster();
        }
        int id = 0;
        private void btnsil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            var komut = new SqlCommand("Delete from sitebilgi where id = (" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigöster();

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox4.Text=listView1.SelectedItems[0].SubItems[0].Text;
            comboBox1.Text=listView1.SelectedItems[0].SubItems[1].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox5.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox8.Text = listView1.SelectedItems[0].SubItems[8].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[9].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[10].Text;

        }
    }
}
