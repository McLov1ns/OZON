using OZON.Model;
using OZON.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace OZON.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly DBContext _context;
        public ObservableCollection<Seller> Sellers { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
        public ObservableCollection<OrderItem> OrderItems { get; set; }
        public ObservableCollection<OrderAssignment> OrderAssignments { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<PickupPoint> PickupPoints { get; set; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand OpenAuthorizationCommand { get; }
        public ICommand OpenProductAddCommand { get; }
        public ICommand ExitCommand { get; }

        private Product _selectedProduct;

        public MainViewModel()
        {
            _context = new DBContext();
            OpenProductAddCommand = new RelayCommand(OpenProductAdd);
            OpenAuthorizationCommand = new RelayCommand(OpenAuthorization);
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);
            Sellers = new ObservableCollection<Seller>(_context.Seller.ToList());
            Clients = new ObservableCollection<Client>(_context.Client.ToList());
            Products = new ObservableCollection<Product>(_context.Product.ToList());
            Orders = new ObservableCollection<Order>(_context.Orders.ToList());
            OrderItems = new ObservableCollection<OrderItem>(_context.OrderItem.ToList());
            OrderAssignments = new ObservableCollection<OrderAssignment>(_context.OrderAssignment.ToList());
            Employees = new ObservableCollection<Employee>(_context.Employee.ToList());
            PickupPoints = new ObservableCollection<PickupPoint>(_context.PickupPoint.ToList());
            ExitCommand = new RelayCommand(Exit);
        }

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
        private bool _isEditing;
        public bool IsEditing
        {
            get { return _isEditing; }
            set
            {
                _isEditing = value;
                OnPropertyChanged(nameof(IsEditing));
            }
        }
        private bool _canEdit;
        public bool CanEdit
        {
            get { return _canEdit; }
            set
            {
                _canEdit = value;
                OnPropertyChanged(nameof(CanEdit));
            }
        }

        private bool _canDelete;
        public bool CanDelete
        {
            get { return _canDelete; }
            set
            {
                _canDelete = value;
                OnPropertyChanged(nameof(CanDelete));
            }
        }

        private bool _canAddProduct;
        public bool CanAddProduct
        {
            get { return _canAddProduct; }
            set
            {
                _canAddProduct = value;
                OnPropertyChanged(nameof(CanAddProduct));
            }
        }
        private bool _canSee;
        public bool CanSee
        {
            get { return _canSee; }
            set
            {
                _canSee = value;
                OnPropertyChanged(nameof(CanSee));
            }
        }

        private void Edit(object parameter)
        {
            IsEditing = true;
            _context.SaveChanges();
            IsEditing = false;
        }
        private void OpenAuthorization(object parameter)
        {
            var authorization = new Autorization();
            authorization.ShowDialog();
        }
        public void UpdateProducts()
        {
            Products.Clear();
            foreach (var product in _context.Product.ToList())
            {
                Products.Add(product);
            }
        }

        private void OpenProductAdd(object parameter)
        {
            var productAddView = new ProductAddView();
            //productAddView.ProductAdded += ProductAddView_ProductAdded;
            productAddView.ShowDialog();

        }
        private void Exit(object parameter)
        {
            (Application.Current.MainWindow as Window)?.Close();
            var autorizationView = new Autorization();
            autorizationView.ShowDialog();
        }
        //public void ProductAddView_ProductAdded(object sender, EventArgs e)
        //{
        //    UpdateProducts(); // Обновляем список продуктов после добавления нового продукта
        //    OnPropertyChanged(nameof(Products)); // Обновляем привязку к свойству Products

        //    // Проверяем, существует ли экземпляр главного окна
        //    foreach (Window window in Application.Current.Windows)
        //    {
        //        if (window is MainWindow mainWindow)
        //        {
        //            mainWindow.DataContext = null; // Очищаем DataContext
        //            mainWindow.DataContext = this; // Присваиваем DataContext заново
        //            break;
        //        }
        //    }
        //}

        private void Delete(object parameter)
        {
            if (SelectedProduct != null)
            {
                // Удалить выбранный продукт из базы данных
                _context.Product.Remove(SelectedProduct);
                _context.SaveChanges(); // Сохранить изменения в базе данных

                // Удалить продукт из коллекции
                Products.Remove(SelectedProduct);
                SelectedProduct = null; // Сбросить выбранный продукт
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
