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
using UnitedTractorApp.Reports.Models;

namespace UnitedTractorApp.Reports.Views
{
    /// <summary>
    /// Interaction logic for LaporanPerkakas.xaml
    /// </summary>
    public partial class LaporanPerkakas : Page
    {
        public LaporanPerkakas()
        {
            InitializeComponent();
        }

        private void ChangeDate(object sender, SelectionChangedEventArgs e)
        {
            reportViewer.LocalReport.DataSources.Clear();
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1"; // Name of the DataSet we set in .rdlc

            //List<Reports.Models.Perkakas> list = this.GetData();
            reportDataSource.Value =new  List<Reports.Models.Perkakas>();
            reportViewer.LocalReport.ReportEmbeddedResource = "Reports.Layouts.DaftarPerkakas.rdlc";
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.RefreshReport();
        }
        
    }
}
