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

namespace ılceSecım
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = hyigitgunay; Initial Catalog = DBSECİMPROJE; Integrated Security = True");
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnisle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLSECIM (ILCEAD , APARTI , BPARTI , CPARTI , DPARTI , EPARTI) values (@P1 , @P2 , @P3 , @P4 , @P5 , @P6)" , baglanti);
            komut.Parameters.AddWithValue("@P1" , txtilce.Text);
            komut.Parameters.AddWithValue("@P2", txtapartı.Text);
            komut.Parameters.AddWithValue("@P3", txtbpartı.Text);
            komut.Parameters.AddWithValue("@P4", txtcpartı.Text);
            komut.Parameters.AddWithValue("@P5", txtdpartı.Text);
            komut.Parameters.AddWithValue("@P6", txtepartı.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Oyların girişi yapılmıştır!");
        }

        private void txtilce_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnist_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
    }
}
