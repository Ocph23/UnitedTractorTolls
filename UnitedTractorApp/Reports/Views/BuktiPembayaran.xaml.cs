using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UnitedTractorLib;

namespace UnitedTractorApp.Reports.Views
{
    /// <summary>
    /// Interaction logic for BuktiPembayaran.xaml
    /// </summary>
    public partial class BuktiPembayaran : Window
    {
        private UnitedTractorLib.Models.Peminjaman peminjaman;
        public BuktiPembayaran(UnitedTractorLib.Models.Peminjaman peminjaman)
        {
            InitializeComponent();
            this.peminjaman = peminjaman;
            reportViewer.Load += reportViewer_Load;
        }

        void reportViewer_Load(object sender, EventArgs e)
        {
            reportViewer.LocalReport.DataSources.Clear();
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1"; // Name of the DataSet we set in .rdlc
            List<Reports.Models.MBuktiPemayaran> data = this.ConverPeminjamanDetailsToReportModel();
            reportDataSource.Value = data;
            reportViewer.LocalReport.ReportEmbeddedResource = "UnitedTractorApp.Reports.Layouts.LBuktiPembayaran.rdlc";
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.RefreshReport();
        }

 
        private List<Reports.Models.MBuktiPemayaran> ConverPeminjamanDetailsToReportModel()
        {
            return (from a in peminjaman.Details
                    select new Reports.Models.MBuktiPemayaran
                    {
                        HargaSatuan = a.HargaSewa.Harga,
                        NomorSeri = a.TOllDetails.NomorSeri,
                        KodePerkakas = a.TollKode,
                        NamaPelanggan = peminjaman.Customer.Nama,
                        KodePeminjaman = peminjaman.Kode,
                        Tanggal = peminjaman.Tglmulai
                    }).ToList();
        }


       
    }
}
