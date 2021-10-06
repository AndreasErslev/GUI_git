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

namespace DebtBook.Views
{
    /// <summary>
    /// Interaction logic for AddDebtorDialog.xaml
    /// </summary>
    public partial class AddDebtorDialog : Window
    {
        public AddDebtorDialog(ViewModels.AddDebtorViewModel vmDebtor)
        {
            InitializeComponent();
            DataContext = vmDebtor;
        }

        private void BtnSave(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
