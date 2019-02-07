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

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //ERPContext ctx = new ERPContext();
        //Form1 f = new Form1();

        private void btn_onay_Click(object sender, EventArgs e)
        {

            //if (f.sirket_id == 0)
            //{
            //    MessageBox.Show("Sirket secin");
            //}
            //else
            //{
            //    f.sirket_id = Convert.ToInt32(dgv_sirket.CurrentCell.Value);

            //    this.Hide();
            //    f.Show();
            //}
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //var sirket = (from n in ctx.NakliyeSirketleris
            //              select new
            //              {
            //                  id = n.sirket_ID,
            //                  Ad = n.sirket_adi
            //              }

            //    ).ToList();

            //dgv_sirket.DataSource = sirket;


            //var km = (from n in ctx.NakliyeSirketleris
            //          select new
            //          {
            //              Ad = n.sirket_adi,
            //              km = n.km_fiyat
            //          }

            //   ).ToList();

            //dgv_km.DataSource = km;


            //var litre = (from n in ctx.NakliyeSirketleris
            //             select new
            //             {
            //                 Ad = n.sirket_adi,
            //                 litre = n.litre_fiyat
            //             }

            //   ).ToList();

            //dgv_litre.DataSource = litre;


            //var hız = (from n in ctx.NakliyeSirketleris
            //           select new
            //           {
            //               Ad = n.sirket_adi,
            //               hız = n.teslimat_hizi
            //           }

            //   ).ToList();

            //dgv_hız.DataSource = hız;

            //var deger = (from n in ctx.Degers
            //             select new
            //             {
            //                 Ad = n.NakliyeSirketleri.sirket_adi,
            //                 Puan = n.puan
            //             }

            //   ).ToList();

            //Puan.Text = ctx.Degers.Where(d => d.sirket_ID == Convert.ToInt32(dgv_sirket.CurrentCell.Value)).Average(d => d.puan).ToString();

            //dgv_sirket.DataSource = sirket;

            //bayi_adi.Text = ctx.Isteks.Where(i => i.istek_ID.ToString() == f.istek_id.ToString()).FirstOrDefault().bayi_adi.ToString();

            //tb_kucuk.Text = ctx.Isteks.Where(i => i.istek_ID.ToString() == f.istek_id.ToString()).FirstOrDefault().kucuk.ToString();

            //tb_orta.Text = ctx.Isteks.Where(i => i.istek_ID.ToString() == f.istek_id.ToString()).FirstOrDefault().orta.ToString();

            //tb_buyuk.Text = ctx.Isteks.Where(i => i.istek_ID.ToString() == f.istek_id.ToString()).FirstOrDefault().buyuk.ToString();

            //tb_enbuyuk.Text = ctx.Isteks.Where(i => i.istek_ID.ToString() == f.istek_id.ToString()).FirstOrDefault().enbuyuk.ToString();

            //Toplam.Text = " " + (Convert.ToInt32(tb_kucuk.Text) * 0.5 + Convert.ToInt32(tb_orta.Text) * 1.5 + Convert.ToInt32(tb_buyuk.Text) * 5 + Convert.ToInt32(tb_enbuyuk.Text) * 20 + " litre");

            //if (bayi_adi.Text == "Konya")
            //{
            //    Uzaklık.Text = "250 km";
            //}
            //else
            //{
            //    Uzaklık.Text = "500 km";
            //}


        }

        private void dgv_sirket_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //f.sirket_id = Convert.ToInt32(dgv_sirket.CurrentCell.Value);
            //Puan.Text = ctx.Degers.Where(i => i.sirket_ID == Convert.ToInt32(dgv_sirket.CurrentCell.Value)).FirstOrDefault().puan.Value.ToString();
            //ucret.Text = (ctx.NakliyeSirketleris.Where(i => i.sirket_ID == Convert.ToInt32(dgv_sirket.CurrentCell.Value)).FirstOrDefault().km_fiyat.Value * Convert.ToInt32(Uzaklık.Text) +
            //             ctx.NakliyeSirketleris.Where(i => i.sirket_ID == Convert.ToInt32(dgv_sirket.CurrentCell.Value)).FirstOrDefault().litre_fiyat.Value * Convert.ToInt32(Toplam.Text)).ToString();

        }
    }
}
