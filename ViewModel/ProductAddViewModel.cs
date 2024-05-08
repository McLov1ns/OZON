using OZON.Model;
using OZON.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OZON.ViewModel
{
    public class ProductAddViewModel : INotifyPropertyChanged
    {
        public event EventHandler ProductAdded;
        private readonly DBContext _context;
        private string _name;
        private decimal _price;
        private decimal _rating;
        private int _sellerID;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public decimal Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                OnPropertyChanged(nameof(Rating));
            }
        }

        public int SellerID
        {
            get { return _sellerID; }
            set
            {
                _sellerID = value;
                OnPropertyChanged(nameof(SellerID));
            }
        }

        public ICommand AddProductCommand { get; }

        public ProductAddViewModel()
        {
            _context = new DBContext();
            AddProductCommand = new RelayCommand(AddProduct);
        }

        private void AddProduct(object parameter)
        {
            if (string.IsNullOrEmpty(Name) || Price <= 0 || SellerID <= 0)
            {
                return;
            }

            Product newProduct = new Product
            {
                Name = this.Name,
                Price = this.Price,
                Rating = this.Rating,
                SellerID = this.SellerID
            };

            _context.Product.Add(newProduct); // Добавление нового продукта в контекст базы данных
            _context.SaveChanges(); // Сохранение изменений в базе данных

            // Вызываем событие ProductAdded
            /*ProductAdded?.Invoke(this, EventArgs.Empty)*/;
            //var mainWindow = new MainWindow();
            //mainWindow.ShowDialog();

            Console.WriteLine($"New product added: {newProduct.Name}, Price: {newProduct.Price}, Rating: {newProduct.Rating}, Seller ID: {newProduct.SellerID}");
            ClearFields();
        }


        private void ClearFields()
        {
            Name = "";
            Price = 0;
            Rating = 0;
            SellerID = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
