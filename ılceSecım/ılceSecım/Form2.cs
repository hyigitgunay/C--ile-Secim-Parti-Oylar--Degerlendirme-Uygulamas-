using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ılceSecım
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = hyigitgunay; Initial Catalog = DBSECİMPROJE; Integrated Security = True");

        private void Form2_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select ILCEAD from TBLSECIM",baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select SUM(APARTI),SUM(BPARTI),SUM(CPARTI),SUM(DPARTI),SUM(EPARTI) from TBLSECIM", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["PARTİLER"].Points.AddXY("APARTİ", dr2[0]);
                chart1.Series["PARTİLER"].Points.AddXY("BPARTİ", dr2[1]);
                chart1.Series["PARTİLER"].Points.AddXY("CPARTİ", dr2[2]); 
                chart1.Series["PARTİLER"].Points.AddXY("DPARTİ", dr2[3]);
                chart1.Series["PARTİLER"].Points.AddXY("EPARTİ", dr2[4]);
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLSECIM Where ILCEAD = @P1", baglanti);
            komut.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            { 
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());

                label7.Text = dr[2].ToString();
                label8.Text = dr[3].ToString();
                label9.Text = dr[4].ToString();
                label10.Text = dr[5].ToString();
                label11.Text = dr[6].ToString();    
            }
            baglanti.Close();

        }
    }
}
