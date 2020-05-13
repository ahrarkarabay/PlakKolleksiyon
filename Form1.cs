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

namespace b161200020_PlakKolleksiyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //sql connection classı değişkene atandı.
        connection_sql sql_conn = new connection_sql();
        private void showData(string sql_select)
        {
            //sql data adaptor ve data grid tanımları yapıldı.
            SqlDataAdapter da = new SqlDataAdapter(sql_select, sql_conn.conn());
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void plakEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //plak ekleme sayfası çağırıldı.
            Plak_ekle ekle = new Plak_ekle();
            ekle.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sql sorgusu çalıştırıldı veriler alındı
            showData("Select * From plak");
            //id gizlendi.
            this.dataGridView1.Columns["id"].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try 
            { 
                //Kullanıcının DataGrid üzerinden seçtiği satırlardaki değerler atandı.
                string id, album_adi, katalog_num, durum, sanatci_grup_adi, uretim_yeri, yili;
                id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                album_adi = dataGridView1.CurrentRow.Cells["album_adi"].Value.ToString();
                katalog_num = dataGridView1.CurrentRow.Cells["katalog_num"].Value.ToString();
                durum = dataGridView1.CurrentRow.Cells["durum"].Value.ToString();
                sanatci_grup_adi = dataGridView1.CurrentRow.Cells["sanatci_grup_adi"].Value.ToString();
                uretim_yeri = dataGridView1.CurrentRow.Cells["uretim_yeri"].Value.ToString();
                yili = dataGridView1.CurrentRow.Cells["yili"].Value.ToString();

                //Seçilen verinin id değerine göre veri güncelleme yordamları yapıldı.
                SqlCommand sql_comm = new SqlCommand("update plak set album_adi='" + album_adi + "',katalog_num='" + katalog_num+ "',durum='" + durum + "',sanatci_grup_adi='" + sanatci_grup_adi + "',uretim_yeri='"+uretim_yeri+ "',yili='"+yili+ "'where id=" + id, sql_conn.conn());
                sql_comm.ExecuteNonQuery();
                showData("Select * From plak");
                //cıktılda idler gizlendi.
                this.dataGridView1.Columns["id"].Visible = false;
                MessageBox.Show("Kayıt Güncellenmiştir.");
            }
            catch
            {
                MessageBox.Show("Güncelleme İşlemi için Lütfen Plakları Görüntüleyiniz.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            { 
                //datagrid üzerinden seçilen satırın id si ile silme işlemi yapıldı.
                int del_id = dataGridView1.CurrentCell.RowIndex+1;
                SqlCommand sql_comm = new SqlCommand ("delete from plak where id="+del_id,sql_conn.conn());
                sql_comm.ExecuteNonQuery();
                //sql sorgusu çalıştırıldı veriler alındı
                showData("Select * From plak");
                //cıktılda idler gizlendi.
                this.dataGridView1.Columns["id"].Visible = false;
                MessageBox.Show("Silme İşlemi Başarılı");
            }
            catch
            {
                MessageBox.Show("Silme İşlemi için Lütfen Plakları Görüntüleyiniz.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // alan kontrol uyarı fonksiyonu alan boş obırakıldığında uyarır. 
            if (textBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Lütfen bu alanı boş bırakmayınız.");
                return;
            }

            //veri arama ve filitreleme
            SqlCommand sql_comm = new SqlCommand("SELECT * FROM plak WHERE album_adi LIKE '%" + textBox1.Text + "%' OR katalog_num LIKE '%" + textBox1.Text + "%' OR durum LIKE '%" + textBox1.Text + "%' OR sanatci_grup_adi LIKE '%" + textBox1.Text + "%' OR yili LIKE '%" + textBox1.Text + "%'", sql_conn.conn());
            SqlDataAdapter da = new SqlDataAdapter(sql_comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            this.dataGridView1.Columns["id"].Visible = false;

        }
    }
}
