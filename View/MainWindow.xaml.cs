using OZON.ViewModel;
using OZON.View;
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

namespace OZON.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var mainViewModel = new MainViewModel();
            DataContext = mainViewModel;

            // Подписка на событие ProductAdded
            //var productAddView = new ProductAddView();
            //productAddView.ProductAdded += mainViewModel.ProductAddView_ProductAdded;
        }
        private void ProductAddView_ProductAdded(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
