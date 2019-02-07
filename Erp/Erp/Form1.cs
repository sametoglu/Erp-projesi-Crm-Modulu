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


namespace Erp
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
        Form2 Form2 = new Form2();
        public int sirket_id = 0;
        public int istek_id = 0;
        public double toplam = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            var isteklistesi = (from i in ctx.Isteks
                                select new
                                {
                                    id = i.istek_ID,
                                    bayi_ad = i.bayi_adi,
                                    kucuk = i.kucuk,
                                    orta = i.orta,
                                    buyuk = i.buyuk,
                                    enbuyuk = i.enbuyuk,
                                    istektarihi = i.istektarihi,
                                    durum = i.Durum,
                                }

                ).Where(i => i.durum == "Gonderilmedi").ToList();

            dgv_istek.DataSource = isteklistesi;

             var satis = (from s in ctx.Satis
                         select new
                         {
                             bayi_adi = s.bayi_adi,
                             kucuk = s.kucuk,
                             orta = s.orta,
                             buyuk = s.buyuk,
                             enbuyuk = s.enbuyuk,
                             toplamsatis = s.toplamsatis,
                             tarih = s.tarih
                         }

                ).ToList();

            this.dgv_rapor_satis.DataSource = satis;

            var data3 = ctx.Stoks.ToList();
            this.dgv_stok.DataSource = data3;

            zaman.Text = Convert.ToInt32(DateTime.Now.Month) - Convert.ToInt32(ctx.Isteks.OrderByDescending(i => i.istektarihi).FirstOrDefault().istektarihi.ToString().Substring(4, 1)) + " ay ";

            var sirket = (from n in ctx.NakliyeSirketleris
                          select new
                          {
                              id = n.sirket_ID,
                              Ad = n.sirket_adi
                          }

                ).ToList();

            dgv_sirket.DataSource = sirket;


            var km = (from n in ctx.NakliyeSirketleris
                      select new
                      {
                          Ad = n.sirket_adi,
                          km = n.km_fiyat + "TL"
                      }

               ).ToList();

            dgv_km.DataSource = km;


            var litre = (from n in ctx.NakliyeSirketleris
                         select new
                         {
                             Ad = n.sirket_adi,
                             litre = n.litre_fiyat + "TL"
                         }

               ).ToList();

            dgv_litre.DataSource = litre;


            var hız = (from n in ctx.NakliyeSirketleris
                       select new
                       {
                           Ad = n.sirket_adi,
                           hız = n.teslimat_hizi
                       }

               ).ToList();

            dgv_hız.DataSource = hız;

            var deger = (from n in ctx.Degers
                         select new
                         {
                             Ad = n.NakliyeSirketleri.sirket_adi,
                             Puan = n.puan
                         }

               ).ToList();


            dgv_sirket.DataSource = sirket;



            yenile();
        }

        private void dgv_istek_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var isteklistesi = (from i in ctx.Isteks
                                select new
                                {
                                    id = i.istek_ID,
                                    bayi_ad = i.bayi_adi,
                                    kucuk = i.kucuk,
                                    orta = i.orta,
                                    buyuk = i.buyuk,
                                    enbuyuk = i.enbuyuk,
                                    istektarihi = i.istektarihi,
                                    durum = i.Durum,
                                }

                ).Where(i => i.id.ToString() == dgv_istek.CurrentCell.Value.ToString()).ToList();

            dgv_istek.DataSource = isteklistesi;


            try
            {

                istek_id = ctx.Isteks.Where(i => i.istek_ID.ToString() == dgv_istek.CurrentCell.Value.ToString()).FirstOrDefault().istek_ID;

                bayi_adi.Text = ctx.Isteks.Where(i => i.istek_ID.ToString() == dgv_istek.CurrentCell.Value.ToString()).FirstOrDefault().bayi_adi.ToString();

                tb_kucuk.Text = ctx.Isteks.Where(i => i.istek_ID.ToString() == dgv_istek.CurrentCell.Value.ToString()).FirstOrDefault().kucuk.ToString();

                tb_orta.Text = ctx.Isteks.Where(i => i.istek_ID.ToString() == dgv_istek.CurrentCell.Value.ToString()).FirstOrDefault().orta.ToString();

                tb_buyuk.Text = ctx.Isteks.Where(i => i.istek_ID.ToString() == dgv_istek.CurrentCell.Value.ToString()).FirstOrDefault().buyuk.ToString();

                tb_enbuyuk.Text = ctx.Isteks.Where(i => i.istek_ID.ToString() == dgv_istek.CurrentCell.Value.ToString()).FirstOrDefault().enbuyuk.ToString();

                dgv_istek.DataSource = isteklistesi;

                toplam = (Convert.ToInt32(tb_kucuk.Text) * 0.5 + Convert.ToInt32(tb_orta.Text) * 1.5 + Convert.ToInt32(tb_buyuk.Text) * 5 + Convert.ToInt32(tb_enbuyuk.Text) * 20);
                
                Toplam.Text = " " + toplam.ToString() + " litre";

                tb_buyuk.ReadOnly = true;
                tb_enbuyuk.ReadOnly = true;
                tb_kucuk.ReadOnly = true;
                tb_orta.ReadOnly = true;



                
            }
            catch (Exception)
            {
                MessageBox.Show("lutfen id secin");

                var isteklistesi2 = (from i in ctx.Isteks
                                     select new
                                     {
                                         id = i.istek_ID,
                                         bayi_ad = i.bayi_adi,
                                         kucuk = i.kucuk,
                                         orta = i.orta,
                                         buyuk = i.buyuk,
                                         enbuyuk = i.enbuyuk,
                                         istektarihi = i.istektarihi,
                                         durum = i.Durum,
                                     }

               ).Where(i => i.id.ToString() == dgv_istek.CurrentCell.Value.ToString()).ToList();

                dgv_istek.DataSource = isteklistesi2;
            }

            var Litre = (from i in ctx.Isteks
                         select new
                         {
                             id = i.istek_ID,
                             bayi_ad = i.bayi_adi,
                             kucuk = i.kucuk,
                             orta = i.orta,
                             buyuk = i.buyuk,
                             enbuyuk = i.enbuyuk,
                             istektarihi = i.istektarihi
                         }

                ).Where(i => i.bayi_ad.ToString() == bayi_adi.Text).OrderByDescending(i => i.istektarihi).ToList();

            litre.Text = (Convert.ToInt32(Litre.FirstOrDefault().kucuk.ToString()) * 0.5 +
                                 Convert.ToInt32(Litre.FirstOrDefault().orta.ToString()) * 1.5 +
                                 Convert.ToInt32(Litre.FirstOrDefault().buyuk.ToString()) * 5 +
                                 Convert.ToInt32(Litre.FirstOrDefault().enbuyuk.ToString()) * 20 + " litre");



            bayi_istek.Text = ctx.Isteks.Where(i => i.istek_ID.ToString() == istek_id.ToString()).FirstOrDefault().bayi_adi.ToString();

            kucuk_istek.Text = ctx.Isteks.Where(i => i.istek_ID.ToString() == istek_id.ToString()).FirstOrDefault().kucuk.ToString();

            orta_istek.Text = ctx.Isteks.Where(i => i.istek_ID.ToString() == istek_id.ToString()).FirstOrDefault().orta.ToString();

            buyuk_istek.Text = ctx.Isteks.Where(i => i.istek_ID.ToString() == istek_id.ToString()).FirstOrDefault().buyuk.ToString();

            enbuyuk_istek.Text = ctx.Isteks.Where(i => i.istek_ID.ToString() == istek_id.ToString()).FirstOrDefault().enbuyuk.ToString();

            Toplam_istek.Text = " " + (Convert.ToInt32(tb_kucuk.Text) * 0.5 + Convert.ToInt32(tb_orta.Text) * 1.5 + Convert.ToInt32(tb_buyuk.Text) * 5 + Convert.ToInt32(tb_enbuyuk.Text) * 20 + " litre");

            if (bayi_istek.Text == "Konya")
            {
                Uzaklık.Text = "250 km";
            }
            else
            {
                Uzaklık.Text = "500 km";
            }

        }

        private void btn_gonder_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter istek_ID = new SqlParameter("@istek_ID", istek_id);
                SqlParameter sirket_ID = new SqlParameter("@sirket_ID", sirket_id);

                ctx.Database.ExecuteSqlCommand("proc_teslimatekle @istek_ID,@sirket_ID", istek_ID, sirket_ID);

                MessageBox.Show("İstek Gonderme basarılı");

                btn_Kargo.Text = " Kargo Sec";

                btn_Kargo.Enabled = true;

                btn_Kargo.BackColor = Color.Transparent;

                btn_gonder.BackColor = Color.Transparent;

                buyuk_istek.ReadOnly = false;
                enbuyuk_istek.ReadOnly = false;
                kucuk_istek.ReadOnly = false;
                orta_istek.ReadOnly = false;

                tb_buyuk.Text = "0";
                tb_enbuyuk.Text = "0";
                tb_kucuk.Text = "0";
                tb_orta.Text = "0";

                bayi_adi.Text = "bayi";

                Toplam.Text = "";

                tb_buyuk.ReadOnly = false;
                tb_enbuyuk.ReadOnly = false;
                tb_kucuk.ReadOnly = false;
                tb_orta.ReadOnly = false;

            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("eksik bilgi girisi");
            }

            var data2 = ctx.Satis.ToList();
            this.dgv_rapor_satis.DataSource = data2;

            var data3 = ctx.Stoks.ToList();
            this.dgv_stok.DataSource = data3;

            var data4 = ctx.Isteks.Where(i => i.Durum == "Gonderilmedi").ToList();
            this.dgv_stok.DataSource = data4;
            
            dgv_istek.DataSource = data4;

            btn_Kargo.Text = " Kargo Sec";

            btn_Kargo.Enabled = true;

            btn_Kargo.BackColor = Color.Transparent;

            btn_gonder.BackColor = Color.Transparent;

            buyuk_istek.ReadOnly = false;
            enbuyuk_istek.ReadOnly = false;
            kucuk_istek.ReadOnly = false;
            orta_istek.ReadOnly = false;

            tb_buyuk.Text = "0";
            tb_enbuyuk.Text = "0";
            tb_kucuk.Text = "0";
            tb_orta.Text = "0";

            bayi_adi.Text = "bayi";

            Toplam.Text = "";

            tb_buyuk.ReadOnly = false;
            tb_enbuyuk.ReadOnly = false;
            tb_kucuk.ReadOnly = false;
            tb_orta.ReadOnly = false;

            yenile();

        }

        private void yenile()
        {
            var isteklistesi = (from i in ctx.Isteks
                                select new
                                {
                                    id = i.istek_ID,
                                    bayi_ad = i.bayi_adi,
                                    kucuk = i.kucuk,
                                    orta = i.orta,
                                    buyuk = i.buyuk,
                                    enbuyuk = i.enbuyuk,
                                    istektarihi = i.istektarihi,
                                    durum = i.Durum,
                                }

                ).Where(i => i.durum == "Gonderilmedi").ToList();

            dgv_istek.DataSource = isteklistesi;

            /*SATİS RAPORU*/
            var satis = (from s in ctx.Satis
                         select new
                         {
                             bayi_adi = s.bayi_adi,
                             kucuk = s.kucuk,
                             orta = s.orta,
                             buyuk = s.buyuk,
                             enbuyuk = s.enbuyuk,
                             toplamsatis = s.toplamsatis,
                             tarih = s.tarih
                         }

                ).ToList();

            if (satis.Where(i => i.bayi_adi == "Konya").Sum(i => i.toplamsatis.Value) > satis.Where(i => i.bayi_adi == "İstanbul").Sum(i => i.toplamsatis.Value))
            {
                bayi.Text = "Konya";
                litre.Text = satis.Where(i => i.bayi_adi == "Konya").Sum(i => i.toplamsatis.Value).ToString();
            }
            else
            {
                bayi.Text = "İstanbul";
                litre.Text = satis.Where(i => i.bayi_adi == "İstanbul").Sum(i => i.toplamsatis.Value).ToString();
            }

            kucuk.Text = satis.Sum(i => i.kucuk.Value).ToString();
            orta.Text = satis.Sum(i => i.orta.Value).ToString();
            buyuk.Text = satis.Sum(i => i.buyuk.Value).ToString();
            enbuyuk.Text = satis.Sum(i => i.enbuyuk.Value).ToString();

            //try
            //{
            //    sonbahar.Text = satis.Where(i => Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) >= 9 && Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) <= 11).FirstOrDefault().toplamsatis.Value.ToString() + " litre ";     
            //}
            //catch (System.NullReferenceException)
            //{
            //}
            //try
            //{
            //    kıs.Text = satis.Where(i => Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 2)) >= 12 && Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) <= 2).FirstOrDefault().toplamsatis.Value.ToString() + " litre "; 
            //}
            //catch (System.NullReferenceException)
            //{
            //}
            //try
            //{
            //    ilkbahar.Text = satis.Where(i => Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) >= 3 && Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) <= 5).FirstOrDefault().toplamsatis.Value.ToString() + " litre "; 
            //}
            //catch (System.NullReferenceException)
            //{   
            //}
            //try
            //{
            //    yaz.Text = satis.Where(i => Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) >= 6 && Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) <= 8).FirstOrDefault().toplamsatis.Value.ToString() + " litre ";
            //}
            //catch (System.NullReferenceException)
            //{
            //}


            /*--- stok rapor ---*/


            var stok = (from s in ctx.Stoks
                        select new
                        {
                            kucuk = s.kucuk,
                            orta = s.orta,
                            buyuk = s.buyuk,
                            enbuyuk = s.enbuyuk,
                        }

                ).ToList();

            var istek = (from i in ctx.Isteks
                         select new
                         {
                             id = i.istek_ID,
                             bayi_ad = i.bayi_adi,
                             kucuk = i.kucuk,
                             orta = i.orta,
                             buyuk = i.buyuk,
                             enbuyuk = i.enbuyuk,
                             istektarihi = i.istektarihi,
                             durum = i.Durum,
                         }

               ).OrderByDescending(i => i.istektarihi.ToString()).ToList();

            //Where(i => i.durum.ToString() == "Gonderilmedi")

            //try
            //{
                if (istek.OrderByDescending(i => i.kucuk).FirstOrDefault().kucuk.Value > stok.FirstOrDefault().kucuk.Value)
                {
                    aktif_kucuk.Text = "Yetersiz";
                    aktif_kucuk.ForeColor = Color.Red;
                }
                else
                {
                    aktif_kucuk.Text = stok.FirstOrDefault().kucuk.Value.ToString();
                    aktif_kucuk.ForeColor = Color.Blue;
                }

                if (istek.OrderByDescending(i => i.orta).FirstOrDefault().orta.Value > stok.FirstOrDefault().orta.Value)
                {
                    aktif_orta.Text = "Yetersiz";
                    aktif_orta.ForeColor = Color.Red;
                }
                else
                {
                    aktif_orta.Text = stok.FirstOrDefault().orta.Value.ToString();
                    aktif_orta.ForeColor = Color.Blue;
                }

                if (istek.OrderByDescending(i => i.buyuk).FirstOrDefault().buyuk.Value > stok.FirstOrDefault().buyuk.Value)
                {
                    aktif_buyuk.Text = "Yetersiz";
                    aktif_buyuk.ForeColor = Color.Red;
                }
                else
                {
                    aktif_buyuk.Text = stok.FirstOrDefault().buyuk.Value.ToString();
                    aktif_buyuk.ForeColor = Color.Blue;
                }

                if (istek.OrderByDescending(i => i.enbuyuk).FirstOrDefault().enbuyuk.Value > stok.FirstOrDefault().enbuyuk.Value)
                {
                    aktif_enbuyuk.Text = "Yetersiz";
                    aktif_enbuyuk.ForeColor = Color.Red;
                }
                else
                {
                    aktif_enbuyuk.Text = stok.FirstOrDefault().enbuyuk.Value.ToString();
                    aktif_enbuyuk.ForeColor = Color.Blue;
                }
            //}
            //catch (System.NullReferenceException)
            //{

            //}



            //try
            //{
                /*---emniyet---*/
                if (istek.Average(i => i.kucuk.Value) > stok.FirstOrDefault().kucuk.Value)
                {
                    emniyet_kucuk.Text = "Yetersiz";
                    emniyet_kucuk.ForeColor = Color.Red;
                }
                else
                {
                    emniyet_kucuk.Text = "Yeterli";
                    emniyet_kucuk.ForeColor = Color.Blue;
                }

                if (istek.Average(i => i.orta.Value) > stok.FirstOrDefault().orta.Value)
                {
                    emniyet_orta.Text = "Yetersiz";
                    emniyet_orta.ForeColor = Color.Red;
                }
                else
                {
                    emniyet_orta.Text = "Yeterli";
                    emniyet_orta.ForeColor = Color.Blue;
                }

                if (istek.Average(i => i.buyuk.Value) > stok.FirstOrDefault().buyuk.Value)
                {
                    emniyet_buyuk.Text = "Yetersiz";
                    emniyet_buyuk.ForeColor = Color.Red;
                }
                else
                {
                    emniyet_buyuk.Text = "Yeterli";
                    emniyet_buyuk.ForeColor = Color.Blue;
                }

                if (istek.Average(i => i.enbuyuk.Value) > stok.FirstOrDefault().enbuyuk.Value)
                {
                    emniyet_enbuyuk.Text = "Yetersiz";
                    emniyet_enbuyuk.ForeColor = Color.Red;
                }
                else
                {
                    emniyet_enbuyuk.Text = "Yeterli";
                    emniyet_enbuyuk.ForeColor = Color.Blue;
                }
            //}
            //catch (Exception)
            //{

            //}


            //try
            //{
                /*--- son istek toplam ---*/

                son_kucuk.Text = (istek.Where(i => i.bayi_ad == "İstanbul").OrderByDescending(i => i.istektarihi.Value).FirstOrDefault().kucuk.Value +
                                 istek.Where(i => i.bayi_ad == "Konya").OrderByDescending(i => i.istektarihi.Value).FirstOrDefault().kucuk.Value).ToString();

                son_orta.Text = (istek.Where(i => i.bayi_ad == "İstanbul").OrderByDescending(i => i.istektarihi.Value).FirstOrDefault().orta.Value +
                                 istek.Where(i => i.bayi_ad == "Konya").OrderByDescending(i => i.istektarihi.Value).FirstOrDefault().orta.Value).ToString();

                son_buyuk.Text = (istek.Where(i => i.bayi_ad == "İstanbul").OrderByDescending(i => i.istektarihi.Value).FirstOrDefault().buyuk.Value +
                                 istek.Where(i => i.bayi_ad == "Konya").OrderByDescending(i => i.istektarihi.Value).FirstOrDefault().buyuk.Value).ToString();

                son_enbuyuk.Text = (istek.Where(i => i.bayi_ad == "İstanbul").OrderByDescending(i => i.istektarihi.Value).FirstOrDefault().enbuyuk.Value +
                                 istek.Where(i => i.bayi_ad == "Konya").OrderByDescending(i => i.istektarihi.Value).FirstOrDefault().enbuyuk.Value).ToString();
            //}
            //catch (Exception)
            //{

            //}
        }

        private void rb_ist_CheckedChanged(object sender, EventArgs e)
        {
            sonbahar.Text = "0";
            kıs.Text = "0";
            ilkbahar.Text = "0";
            yaz.Text = "0";

            //try
            //{
                var satislistesi_ist = (from s in ctx.Satis
                                        select new
                                        {
                                            bayi_ad = s.bayi_adi,
                                            kucuk = s.kucuk,
                                            orta = s.orta,
                                            buyuk = s.buyuk,
                                            enbuyuk = s.enbuyuk,
                                            toplamsatis = s.toplamsatis,
                                            tarih = s.tarih
                                        }

                ).Where(s => s.bayi_ad.ToString() == rb_ist.Text.ToString()).OrderBy(s => s.tarih).ToList();

                dgv_rapor_satis.DataSource = satislistesi_ist;

                kucuk.Text = satislistesi_ist.Where(s => s.bayi_ad.ToString() == rb_ist.Text.ToString()).Sum(i => i.kucuk.Value).ToString();
                orta.Text = satislistesi_ist.Where(s => s.bayi_ad.ToString() == rb_ist.Text.ToString()).Sum(i => i.orta.Value).ToString();
                buyuk.Text = satislistesi_ist.Where(s => s.bayi_ad.ToString() == rb_ist.Text.ToString()).Sum(i => i.buyuk.Value).ToString();
                enbuyuk.Text = satislistesi_ist.Where(s => s.bayi_ad.ToString() == rb_ist.Text.ToString()).Sum(i => i.enbuyuk.Value).ToString();

                try
                {
                    sonbahar.Text = satislistesi_ist.Where(i => Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) >= 9 && Convert.ToInt32(i.tarih.Value.ToString().Substring(3, 2)) <= 11).FirstOrDefault().toplamsatis.Value.ToString() + " litre ";
                }
                catch (System.NullReferenceException)
                {
                }
                try
                {
                    kıs.Text = satislistesi_ist.Where(i => Convert.ToInt32(i.tarih.Value.ToString().Substring(3, 2)) >= 12 && Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) <= 2).FirstOrDefault().toplamsatis.Value.ToString() + " litre ";
                }
                catch (System.NullReferenceException)
                {
                }
                try
                {
                    ilkbahar.Text = satislistesi_ist.Where(i => Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) >= 3 && Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) <= 5).FirstOrDefault().toplamsatis.Value.ToString() + " litre ";
                }
                catch (System.NullReferenceException)
                {
                }
                try
                {
                    yaz.Text = satislistesi_ist.Where(i => Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) >= 6 && Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) <= 8).FirstOrDefault().toplamsatis.Value.ToString() + " litre ";
                }
                catch (System.NullReferenceException)
                {
                }
                litre_satis.Text = (satislistesi_ist.Where(s => s.bayi_ad.ToString() == rb_ist.Text.ToString()).Sum(i => i.kucuk.Value)*0.5 + satislistesi_ist.Where(s => s.bayi_ad.ToString() == rb_ist.Text.ToString()).Sum(i => i.orta.Value)*1.5 +
                                    satislistesi_ist.Where(s => s.bayi_ad.ToString() == rb_ist.Text.ToString()).Sum(i => i.buyuk.Value)*5 + satislistesi_ist.Where(s => s.bayi_ad.ToString() == rb_ist.Text.ToString()).Sum(i => i.enbuyuk.Value)*20 ).ToString() + " litre";
             
            //}
            //catch (Exception)
            //{

            //}

            
            

        }

        private void rb_kon_CheckedChanged(object sender, EventArgs e)
        {
            sonbahar.Text = "0";
            kıs.Text = "0";
            ilkbahar.Text = "0";
            yaz.Text = "0";

            //try
            //{
                var satislistesi_kon = (from s in ctx.Satis
                                        select new
                                        {
                                            bayi_ad = s.bayi_adi,
                                            kucuk = s.kucuk,
                                            orta = s.orta,
                                            buyuk = s.buyuk,
                                            enbuyuk = s.enbuyuk,
                                            toplamsatis = s.toplamsatis,
                                            tarih = s.tarih
                                        }

                ).Where(s => s.bayi_ad.ToString() == rb_kon.Text.ToString()).OrderBy(s => s.tarih).ToList();

                dgv_rapor_satis.DataSource = satislistesi_kon;


                kucuk.Text = satislistesi_kon.Where(s => s.bayi_ad.ToString() == rb_kon.Text.ToString()).Sum(i => i.kucuk.Value).ToString();
                orta.Text = satislistesi_kon.Where(s => s.bayi_ad.ToString() == rb_kon.Text.ToString()).Sum(i => i.orta.Value).ToString();
                buyuk.Text = satislistesi_kon.Where(s => s.bayi_ad.ToString() == rb_kon.Text.ToString()).Sum(i => i.buyuk.Value).ToString();
                enbuyuk.Text = satislistesi_kon.Where(s => s.bayi_ad.ToString() == rb_kon.Text.ToString()).Sum(i => i.enbuyuk.Value).ToString();

                try
                {
                    sonbahar.Text = satislistesi_kon.Where(i => Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) >= 9 && Convert.ToInt32(i.tarih.Value.ToString().Substring(3, 2)) <= 11).FirstOrDefault().toplamsatis.Value.ToString() + " litre ";
                }
                catch (System.NullReferenceException)
                {
                }
                try
                {
                    kıs.Text = satislistesi_kon.Where(i => Convert.ToInt32(i.tarih.Value.ToString().Substring(3, 2)) >= 12 && Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) <= 2).FirstOrDefault().toplamsatis.Value.ToString() + " litre ";
                }
                catch (System.NullReferenceException)
                {
                }
                try
                {
                    ilkbahar.Text = satislistesi_kon.Where(i => Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) >= 3 && Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) <= 5).FirstOrDefault().toplamsatis.Value.ToString() + " litre ";
                }
                catch (System.NullReferenceException)
                {
                }
                try
                {
                    yaz.Text = satislistesi_kon.Where(i => Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) >= 6 && Convert.ToInt32(i.tarih.Value.ToString().Substring(4, 1)) <= 8).FirstOrDefault().toplamsatis.Value.ToString() + " litre ";
                }
                catch (System.NullReferenceException)
                {
                }

                litre_satis.Text = (satislistesi_kon.Where(s => s.bayi_ad.ToString() == rb_kon.Text.ToString()).Sum(i => i.kucuk.Value)*0.5 + satislistesi_kon.Where(s => s.bayi_ad.ToString() == rb_kon.Text.ToString()).Sum(i => i.orta.Value)*1.5 +
                                    satislistesi_kon.Where(s => s.bayi_ad.ToString() == rb_kon.Text.ToString()).Sum(i => i.buyuk.Value)*5 + satislistesi_kon.Where(s => s.bayi_ad.ToString() == rb_kon.Text.ToString()).Sum(i => i.enbuyuk.Value)*20 ).ToString() + " litre ";

            //}
            //catch (Exception)
            //{

            //}

        }

        private void btn_Kargo_Click(object sender, EventArgs e)
        {
            //if (istek_id == 0)
            //{
            //    MessageBox.Show("istek secin");
            //}

            //else
            //{
                panel_kargo.Show();

                buyuk_istek.ReadOnly = true;
                enbuyuk_istek.ReadOnly = true;
                kucuk_istek.ReadOnly = true;
                orta_istek.ReadOnly = true;
            //}

        }

        private void btn_onay_Click(object sender, EventArgs e)
        {
            if (sirket_id == 0)
            {
                MessageBox.Show("Sirket secin");
            }
            else
            {
                sirket_id = Convert.ToInt32(dgv_sirket.CurrentCell.Value);

                panel_kargo.Hide();

                btn_Kargo.Text = " Kargo Secildi";

                btn_Kargo.Enabled = false;

                btn_Kargo.BackColor = Color.Blue;

                btn_gonder.BackColor = Color.Red;
            }
        }

        private void dgv_sirket_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            sirket_id = Convert.ToInt32(dgv_sirket.CurrentCell.Value);

            int uz;

            if (bayi_istek.Text == "Konya")
            {
                uz = 250;
            }
            else
            {
                uz = 500;
            }

            int km = Convert.ToInt32(ctx.NakliyeSirketleris.Where(i => i.sirket_ID.ToString() == dgv_sirket.CurrentCell.Value.ToString()).FirstOrDefault().km_fiyat.Value) * uz;
                                
            ucret.Text = (Convert.ToInt32(ctx.NakliyeSirketleris.Where(i => i.sirket_ID.ToString() == dgv_sirket.CurrentCell.Value.ToString()).FirstOrDefault().litre_fiyat.Value) * toplam+km).ToString();

            if (ctx.Degers.Count()==0)
            {
                Puan.Text = "0";
            }
            else
            {
                Puan.Text = ctx.Degers.Where(d => d.sirket_ID.ToString() == dgv_sirket.CurrentCell.Value.ToString()).Average(d => d.puan).ToString();
                Puan.Visible = true;
            }

            

        }

        
    }
}
