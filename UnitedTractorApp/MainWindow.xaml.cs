
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using UnitedTractorLib.Contexts.User;
using MahApps.Metro.Controls;

namespace UnitedTractorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Load();
        }


        void Load()
        {
            this.Content = new Pages.Login(this);

        }

        public UnitedTractorLib.Models.User UserIsLogin { get; set; }
    }
}
