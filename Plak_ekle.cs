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
    public partial class Plak_ekle : Form
    {
        public Plak_ekle()
        {
            InitializeComponent();
        }
        //sql connection class tanımlandı.
        connection_sql sql_conn = new connection_sql();
        private void button_ekle_Click(object sender, EventArgs e)
        {
            // alan kontrol uyarı fonksiyonu alan boş obırakıldığında uyarır.
            if (textBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Lütfen bu alanı boş bırakmayınız.");
                return;
            }

            if (textBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Lütfen bu alanı boş bırakmayınız.");
                return;
            }

            if (textBox3.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Lütfen bu alanı boş bırakmayınız.");
                return;
            }

            if (textBox4.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Lütfen bu alanı boş bırakmayınız.");
                return;
            }
            if (textBox5.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Lütfen bu alanı boş bırakmayınız.");
                return;
            }

            try
            {
                //işaretlenmiş olan checkedbox in değerini string e atar.   
                string str = "";
                if (checkedListBox1.CheckedItems.Count > 0)
                {
                    for(int i = 0; i < checkedListBox1.CheckedItems.Count;i ++)
                    {
                        str = checkedListBox1.CheckedItems[i].ToString();
                    }
                    //kullanıcı tarafından girilen veriler sql e insert edildi.
                    SqlCommand sql_comm = new SqlCommand ("insert into plak (album_adi,katalog_num,durum,sanatci_grup_adi,uretim_yeri,yili) values(@album_adi,@katalog_num,@durum,@sanatci_grup_adi,@uretim_yeri,@yili)", sql_conn.conn());
                    sql_comm.Parameters.AddWithValue("@album_adi", textBox1.Text);
                    sql_comm.Parameters.AddWithValue("@katalog_num", textBox2.Text);
                    sql_comm.Parameters.AddWithValue("@durum", str);
                    sql_comm.Parameters.AddWithValue("@sanatci_grup_adi", textBox3.Text);
                    sql_comm.Parameters.AddWithValue("@uretim_yeri", textBox4.Text);
                    sql_comm.Parameters.AddWithValue("@yili", textBox5.Text);
                    sql_comm.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarıyla Gerçekleştirilmiştir");
                    this.Close();
                }                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Daha Sonra Tekrar Deneyiniz");
            }
            
        }
    }
}
