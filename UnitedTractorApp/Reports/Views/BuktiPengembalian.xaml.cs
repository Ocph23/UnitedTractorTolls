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

namespace UnitedTractorApp.Reports.Views
{
    /// <summary>
    /// Interaction logic for BuktiPengembalian.xaml
    /// </summary>
    public partial class BuktiPengembalian : Window
    {
        private UnitedTractorLib.Models.Pengembalian pengembalian;
        private UnitedTractorLib.Models.Peminjaman peminjaman;


        public BuktiPengembalian(UnitedTractorLib.Models.Pengembalian pengembalian, UnitedTractorLib.Models.Peminjaman peminjaman)
        {
            InitializeComponent();
            this.pengembalian = pengembalian;
            this.peminjaman = peminjaman;
            reportViewer.Load += reportViewer_Load;
        }

        void reportViewer_Load(object sender, EventArgs e)
        {
            reportViewer.LocalReport.DataSources.Clear();
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1"; // Name of the DataSet we set in .rdlc
            reportDataSource.Value = this.DataSource();
            reportViewer.LocalReport.ReportEmbeddedResource = "UnitedTractorApp.Reports.Layouts.BuktiPengembalian.rdlc";
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.RefreshReport();
        }

        private List<Reports.Models.BuktiPengembalian> DataSource()
        {
            return (from a in this.pengembalian.Details select new Reports.Models.BuktiPengembalian { Status = a.Keadaantolls, KodePerkakas = a.TollKode,
                NamaPeminjam = this.peminjaman.Customer.Nama, KodePeminjaman = peminjaman.Kode, Tanggal = pengembalian.Tglkembali, Denda = this.GetDenda(a.Tollsid) }).ToList();
        }

        private double GetDenda(int tollsid)
        {
            var a = peminjaman.Details.Where(O => O.Tollsid == tollsid).FirstOrDefault();
            var biayadenda = a.HargaSewa.Harga;
            return biayadenda * 7;
        }
    }
}
