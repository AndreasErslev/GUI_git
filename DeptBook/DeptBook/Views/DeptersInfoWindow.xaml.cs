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

namespace DeptBook.Views
{
    /// <summary>
    /// Interaction logic for DeptersInfoWindow.xaml
    /// </summary>
    public partial class DeptersInfoWindow : Window
    {
        public DeptersInfoWindow(ViewModels.DepterInfoViewModel vmInfo)
        {
            InitializeComponent();
            DataContext = vmInfo;
        }

        private void BtnAddValue(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
