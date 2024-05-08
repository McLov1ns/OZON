using OZON.ViewModel;
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

namespace OZON.View
{
    public partial class ProductAddView : Window
    {
        public event EventHandler ProductAdded;
        public ProductAddView()
        {
            InitializeComponent();
            DataContext = new ProductAddViewModel();
        }
    }
}
