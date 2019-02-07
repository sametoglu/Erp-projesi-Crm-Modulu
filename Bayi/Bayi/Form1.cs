using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Entity;

namespace Bayi
{

    using Models;
    using System.Data.SqlClient;

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        ERPContext ctx = new ERPContext();
        int puan = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            var data = ctx.Isteks.ToList();
            tb_kucuk_alım.Text = "0";
            tb_orta_alım.Text= "0";
            tb_buyuk_alım.Text= "0";
            tb_enbuyuk_alım.Text= "0";

            tb_kucuk_satım.Text = "0";
            tb_orta_satım.Text = "0";
            tb_buyuk_satım.Text = "0";
            tb_enbuyuk_satım.Text = "0";


            cb_bayi_satım.DataSource = ctx.Isteks.ToList();
            cb_bayi_satım.DisplayMember = "bayi_adi";
            cb_bayi_satım.ValueMember = "bayi_adi";

            cb_bayi_alım.DataSource = ctx.Isteks.ToList();
            cb_bayi_alım.DisplayMember = "bayi_adi";
            cb_bayi_alım.ValueMember = "bayi_adi";

            var bayi = (from i in ctx.Isteks
                          select new
                          {
                              istek = i.istek_ID,
                              bayi_adi = i.bayi_adi,
                              Durum = i.Durum,
                              deger = i.deger
                          }

               ).ToList();

            cb_bayi_deger.DataSource = bayi.Where(i => i.Durum == "Gonderildi" && i.deger == false ).ToList();
            cb_bayi_deger.ValueMember = "istek";
            cb_bayi_deger.DisplayMember = "bayi_adi";




            


        }

        private void btn_istekyap_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter bayi_ad = new SqlParameter("@bayi_adi", cb_bayi_alım.Text);

                SqlParameter kucuk = new SqlParameter("@kucuk", Convert.ToInt32( tb_kucuk_alım.Text));

                SqlParameter orta = new SqlParameter("@orta", Convert.ToInt32(tb_orta_alım.Text));

                SqlParameter buyuk = new SqlParameter("@buyuk", Convert.ToInt32(tb_buyuk_alım.Text));

                SqlParameter enbuyuk = new SqlParameter("@enbuyuk", Convert.ToInt32(tb_enbuyuk_alım.Text));

                ctx.Database.ExecuteSqlCommand("proc_istekekle @bayi_adi ,@kucuk ,@orta ,@buyuk ,@enbuyuk ", bayi_ad, kucuk, orta, buyuk, enbuyuk);

                MessageBox.Show("İsteginiz Alındı");
            
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("eksik bilgi girisi");
            }


            tb_kucuk_alım.Text = "0";
            tb_orta_alım.Text = "0";
            tb_buyuk_alım.Text = "0";
            tb_enbuyuk_alım.Text = "0";

            tb_kucuk_satım.Text = "0";
            tb_orta_satım.Text = "0";
            tb_buyuk_satım.Text = "0";
            tb_enbuyuk_satım.Text = "0";

        }

        private void btn_sat_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter bayi_ad = new SqlParameter("@bayi_adi", cb_bayi_satım.Text);

                SqlParameter kucuk = new SqlParameter("@kucuk", Convert.ToInt32(tb_kucuk_satım.Text));

                SqlParameter orta = new SqlParameter("@orta", Convert.ToInt32(tb_orta_satım.Text));

                SqlParameter buyuk = new SqlParameter("@buyuk", Convert.ToInt32(tb_buyuk_satım.Text));

                SqlParameter enbuyuk = new SqlParameter("@enbuyuk", Convert.ToInt32(tb_enbuyuk_satım.Text));

                ctx.Database.ExecuteSqlCommand("proc_satisekle @bayi_adi ,@kucuk ,@orta ,@buyuk ,@enbuyuk ", bayi_ad, kucuk, orta, buyuk, enbuyuk);

                MessageBox.Show("Satıs Basarılı");

            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("eksik bilgi girisi");
            }

            var istek = (from i in ctx.Isteks
                         select new
                         {
                             bayi_adi = i.bayi_adi,
                             kucuk = i.kucuk,
                             orta = i.orta,
                             buyuk = i.buyuk,
                             enbuyuk = i.enbuyuk,
                             durum = i.Durum
                         }

               ).Where(i => i.durum == "Gonderildi" && i.bayi_adi.ToString() == cb_bayi_alım.SelectedValue.ToString()).ToList();



            var satis = (from i in ctx.Satis
                         select new
                         {
                             bayi_adi = i.bayi_adi,
                             kucuk = i.kucuk,
                             orta = i.orta,
                             buyuk = i.buyuk,
                             enbuyuk = i.enbuyuk,
                         }

               ).Where(i => i.bayi_adi.ToString() == cb_bayi_alım.SelectedValue.ToString()).ToList();

            alım_kucuk.Text = (Convert.ToInt32(istek.Sum(i => i.kucuk.Value)) - Convert.ToInt32(satis.Sum(i => i.kucuk.Value))).ToString();
            alım_orta.Text = (Convert.ToInt32(istek.Sum(i => i.orta.Value)) - Convert.ToInt32(satis.Sum(i => i.orta.Value))).ToString();
            alım_buyuk.Text = (Convert.ToInt32(istek.Sum(i => i.buyuk.Value)) - Convert.ToInt32(satis.Sum(i => i.buyuk.Value))).ToString();
            alım_enbuyuk.Text = (Convert.ToInt32(istek.Sum(i => i.enbuyuk.Value)) - Convert.ToInt32(satis.Sum(i => i.enbuyuk.Value))).ToString();


            var istek2 = (from i in ctx.Isteks
                         select new
                         {
                             bayi_adi = i.bayi_adi,
                             kucuk = i.kucuk,
                             orta = i.orta,
                             buyuk = i.buyuk,
                             enbuyuk = i.enbuyuk,
                             durum = i.Durum
                         }

               ).Where(i => i.durum == "Gonderildi" && i.bayi_adi.ToString() == cb_bayi_satım.SelectedValue.ToString()).ToList();

            var satis2 = (from i in ctx.Satis
                         select new
                         {
                             bayi_adi = i.bayi_adi,
                             kucuk = i.kucuk,
                             orta = i.orta,
                             buyuk = i.buyuk,
                             enbuyuk = i.enbuyuk,
                         }

               ).Where(i => i.bayi_adi.ToString() == cb_bayi_satım.SelectedValue.ToString()).ToList();

            satım_kucuk.Text = (Convert.ToInt32(istek2.Sum(i => i.kucuk.Value)) - Convert.ToInt32(satis2.Sum(i => i.kucuk.Value))).ToString();
            satım_orta.Text = (Convert.ToInt32(istek2.Sum(i => i.orta.Value)) - Convert.ToInt32(satis2.Sum(i => i.orta.Value))).ToString();
            satım_buyuk.Text = (Convert.ToInt32(istek2.Sum(i => i.buyuk.Value)) - Convert.ToInt32(satis2.Sum(i => i.buyuk.Value))).ToString();
            satım_enbuyuk.Text = (Convert.ToInt32(istek2.Sum(i => i.enbuyuk.Value)) - Convert.ToInt32(satis2.Sum(i => i.enbuyuk.Value))).ToString();


            tb_kucuk_alım.Text = "0";
            tb_orta_alım.Text = "0";
            tb_buyuk_alım.Text = "0";
            tb_enbuyuk_alım.Text = "0";

            tb_kucuk_satım.Text = "0";
            tb_orta_satım.Text = "0";
            tb_buyuk_satım.Text = "0";
            tb_enbuyuk_satım.Text = "0";

            if (satım_buyuk.Text=="0" || satım_orta.Text=="0" || satım_buyuk.Text=="0" || satım_enbuyuk.Text=="0")
            {
                btn_sat.Enabled = false;
            }

        }

        private void btn_degerlendir_Click(object sender, EventArgs e)
        {
            if (rb_1.Checked || rb_2.Checked || rb_3.Checked || rb_4.Checked || rb_5.Checked)
            {
                try
                {
                    SqlParameter deger = new SqlParameter("@puan", puan);

                    SqlParameter sirket_ID = new SqlParameter("@sirket_ID", cb_sirket_deger.SelectedValue.ToString());

                    SqlParameter istek_ID = new SqlParameter("@istek_ID", cb_bayi_deger.SelectedValue.ToString());

                    ctx.Database.ExecuteSqlCommand("proc_degerekle @sirket_ID ,@puan,@istek_ID ", sirket_ID, deger, istek_ID);

                    MessageBox.Show("Puan Girme Basarılı");

                    var bayi = (from i in ctx.Isteks
                                select new
                                {
                                    istek = i.istek_ID,
                                    bayi_adi = i.bayi_adi,
                                    Durum = i.Durum,
                                    deger = i.deger
                                }

               ).ToList();

                    //dataGridView1.DataSource = bayi;

                    cb_bayi_deger.DataSource = bayi.Where(i => i.Durum == "Gonderildi" && i.deger == false).ToList();
                    cb_bayi_deger.ValueMember = "istek";
                    cb_bayi_deger.DisplayMember = "bayi_adi";

                    var sirket = (from i in ctx.Teslimats
                                  select new
                                  {
                                      bayi_adi = i.bayi_adi,
                                      id = i.sirket_ID,
                                      ad = i.NakliyeSirketleri.sirket_adi,
                                      deger = i.Istek.deger
                                  }

               ).ToList();

                    //dataGridView1.DataSource = sirket;

                    cb_sirket_deger.DataSource = sirket.Where(i => i.bayi_adi.ToString() == cb_bayi_deger.SelectedValue.ToString() && i.deger == false).ToList();
                    cb_sirket_deger.ValueMember = "id";
                    cb_sirket_deger.DisplayMember = "ad";

                    


                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("eksik bilgi girisi");
                }
                catch (System.NullReferenceException)
                {
                    MessageBox.Show("puan verecek teslimat kalmadı");
                }
            }
            else
            {
                MessageBox.Show("Puan Verin");
            }
        }

        private void rb_1_CheckedChanged(object sender, EventArgs e)
        {
            puan = Convert.ToInt32(rb_1.Text);
        }

        private void rb_2_CheckedChanged(object sender, EventArgs e)
        {
            puan = Convert.ToInt32(rb_2.Text);
        }

        private void rb_3_CheckedChanged(object sender, EventArgs e)
        {
            puan = Convert.ToInt32(rb_3.Text);
        }

        private void rb_4_CheckedChanged(object sender, EventArgs e)
        {
            puan = Convert.ToInt32(rb_4.Text);
        }

        private void rb_5_CheckedChanged(object sender, EventArgs e)
        {
            puan = Convert.ToInt32(rb_5.Text);
        }

        private void cb_bayi_deger_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sirket = (from i in ctx.Teslimats
                          select new
                          {
                              istek = i.istek_ID,
                              id = i.sirket_ID,
                              ad = i.NakliyeSirketleri.sirket_adi,
                              deger = i.Istek.deger
                          }

               ).ToList();

            cb_sirket_deger.DataSource = sirket.Where(i => i.istek.ToString() == cb_bayi_deger.SelectedValue.ToString() && i.deger == false).ToList();
            cb_sirket_deger.ValueMember = "id";
            cb_sirket_deger.DisplayMember = "ad";
        }




        private void cb_bayi_alım_SelectionChangeCommitted(object sender, EventArgs e)
        {

            tb_buyuk_satım.Text = "";
            tb_enbuyuk_satım.Text = "";
            tb_orta_satım.Text = "";
            tb_kucuk_satım.Text = "";

            var istek = (from i in ctx.Isteks
                         select new
                         {
                             bayi_adi = i.bayi_adi,
                             kucuk = i.kucuk,
                             orta = i.orta,
                             buyuk = i.buyuk,
                             enbuyuk = i.enbuyuk,
                             durum = i.Durum
                         }

               ).Where(i => i.durum == "Gonderildi" && i.bayi_adi.ToString() == cb_bayi_alım.SelectedValue.ToString()).ToList();



            var satis = (from i in ctx.Satis
                         select new
                         {
                             bayi_adi = i.bayi_adi,
                             kucuk = i.kucuk,
                             orta = i.orta,
                             buyuk = i.buyuk,
                             enbuyuk = i.enbuyuk,
                         }

               ).Where(i => i.bayi_adi.ToString() == cb_bayi_alım.SelectedValue.ToString()).ToList();

            alım_kucuk.Text = (Convert.ToInt32(istek.Sum(i => i.kucuk.Value)) - Convert.ToInt32(satis.Sum(i => i.kucuk.Value))).ToString();
            alım_orta.Text = (Convert.ToInt32(istek.Sum(i => i.orta.Value)) - Convert.ToInt32(satis.Sum(i => i.orta.Value))).ToString();
            alım_buyuk.Text = (Convert.ToInt32(istek.Sum(i => i.buyuk.Value)) - Convert.ToInt32(satis.Sum(i => i.buyuk.Value))).ToString();
            alım_enbuyuk.Text = (Convert.ToInt32(istek.Sum(i => i.enbuyuk.Value)) - Convert.ToInt32(satis.Sum(i => i.enbuyuk.Value))).ToString();


        }

        private void cb_bayi_satım_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tb_buyuk_alım.Text = "";
            tb_enbuyuk_alım.Text = "";
            tb_orta_alım.Text = "";
            tb_kucuk_alım.Text = "";

            var istek = (from i in ctx.Isteks
                         select new
                         {
                             bayi_adi = i.bayi_adi,
                             kucuk = i.kucuk,
                             orta = i.orta,
                             buyuk = i.buyuk,
                             enbuyuk = i.enbuyuk,
                             durum = i.Durum
                         }

               ).Where(i => i.durum == "Gonderildi" && i.bayi_adi.ToString() == cb_bayi_satım.SelectedValue.ToString()).ToList();

            var satis = (from i in ctx.Satis
                         select new
                         {
                             bayi_adi = i.bayi_adi,
                             kucuk = i.kucuk,
                             orta = i.orta,
                             buyuk = i.buyuk,
                             enbuyuk = i.enbuyuk,
                         }

               ).Where(i => i.bayi_adi.ToString() == cb_bayi_satım.SelectedValue.ToString()).ToList();

            satım_kucuk.Text = (Convert.ToInt32(istek.Sum(i => i.kucuk.Value)) - Convert.ToInt32(satis.Sum(i => i.kucuk.Value))).ToString();
            satım_orta.Text = (Convert.ToInt32(istek.Sum(i => i.orta.Value)) - Convert.ToInt32(satis.Sum(i => i.orta.Value))).ToString();
            satım_buyuk.Text = (Convert.ToInt32(istek.Sum(i => i.buyuk.Value)) - Convert.ToInt32(satis.Sum(i => i.buyuk.Value))).ToString();
            satım_enbuyuk.Text = (Convert.ToInt32(istek.Sum(i => i.enbuyuk.Value)) - Convert.ToInt32(satis.Sum(i => i.enbuyuk.Value))).ToString();

            if (satım_buyuk.Text == "0" || satım_orta.Text == "0" || satım_buyuk.Text == "0" || satım_enbuyuk.Text == "0")
            {
                btn_sat.Enabled = false;
            }

        }


     
    }
}
