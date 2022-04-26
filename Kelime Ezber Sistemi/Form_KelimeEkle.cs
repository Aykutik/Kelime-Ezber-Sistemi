using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kelime_Ezber_Sistemi
{
    public partial class Form_KelimeEkle : DevExpress.XtraEditors.XtraForm
    {
        public Form_KelimeEkle()
        {
            InitializeComponent();
        }

        public string bağlantıadresi = "server=loyaz.net;user id=u477970783_kelimeezber; database=u477970783_kelimeezber; Pwd=aykuT18092007; Charset = utf8";

        private void btn_gözat_Click(object sender, EventArgs e)
        {
            string yol = "";
            openFileDialog1.Filter = "EXCEL (*.xlsx) | *.xlsx";
            openFileDialog1.FileName = "Dosya";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Bir Excel Dosyas Seçiniz";
            string cmd = "Select * from [Sayfa1$]";

            //openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                yol = openFileDialog1.FileName;
                lbl_dosyaİsmi.Text = openFileDialog1.SafeFileName;
                OleDbConnection bağlantı = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + yol + ";Extended Properties=Excel 12.0;");


                OleDbDataAdapter adp = new OleDbDataAdapter(cmd, bağlantı);
                DataTable ds = new DataTable();
                adp.Fill(ds);
                gridControl_kelimeEkle.DataSource = ds;
            }
        }

        private void kelimeYükle()
        {
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                //Yeni Eklenecek Kayıt
                string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +     
                " values " +
                "(@TR,@EN,@tür,@alan)"; 
                MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                bağlantı.Open();
                komut.ExecuteNonQuery();
                bağlantı.Close();
            }
        }

        private void btn_yükle_Click(object sender, EventArgs e)
        {
            kelimeYükle();
        }
    }
}