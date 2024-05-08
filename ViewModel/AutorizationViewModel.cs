using OZON.Model;
using OZON.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OZON.ViewModel
{
    public class AutorizationViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;

        public string LoginCommand
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(LoginCommand));
                    ((RelayCommand)EntranceCommand).RaiseCanExecuteChanged(); // Вызываем RaiseCanExecuteChanged при изменении LoginCommand
                }
            }
        }

        public string PasswordCommand
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(PasswordCommand));
                    ((RelayCommand)EntranceCommand).RaiseCanExecuteChanged(); // Вызываем RaiseCanExecuteChanged при изменении PasswordCommand
                }
            }
        }

        public ICommand EntranceCommand { get; }

        public AutorizationViewModel()
        {
            EntranceCommand = new RelayCommand(Login, CanLogin);
        }

        private void Login(object parameter)
        {
            // Реализация аутентификации
            Employee authenticatedEmployee = Authenticate(LoginCommand, PasswordCommand);

            if (authenticatedEmployee != null)
            {
                // Получаем должность аутентифицированного сотрудника
                string position = authenticatedEmployee.Position;

                // Открываем главное окно в зависимости от должности
                OpenMainWindow(position);
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }

        private bool CanLogin(object parameter)
        {
            return !string.IsNullOrEmpty(LoginCommand) && !string.IsNullOrEmpty(PasswordCommand);
        }

        private Employee Authenticate(string login, string password)
        {
            using (var dbContext = new DBContext())
            {
                return dbContext.Employee.FirstOrDefault(e => e.Login == login && e.Password == password);
            }
        }

        private void OpenMainWindow(string position)
        {
            // Открываем главное окно с учетом должности сотрудника
            MainWindow mainWindow = new MainWindow();

            // Устанавливаем DataContext
            if (mainWindow.DataContext is MainViewModel mainViewModel)
            {
                mainViewModel.UpdateProducts(); // Обновляем данные

                // Устанавливаем доступность кнопок в зависимости от должности
                switch (position)
                {
                    case "Курьер":
                        mainViewModel.CanEdit = false;
                        mainViewModel.CanDelete = false;
                        mainViewModel.CanAddProduct = false;
                        mainViewModel.CanSee = false;
                        break;
                    case "Кассир":
                        mainViewModel.CanEdit = true;
                        mainViewModel.CanDelete = true;
                        mainViewModel.CanAddProduct = true;
                        mainViewModel.CanSee = false;
                        break;
                    case "Менеджер":
                        mainViewModel.CanEdit = true;
                        mainViewModel.CanDelete = true;
                        mainViewModel.CanAddProduct = true;
                        mainViewModel.CanSee = true;
                        break;
                    default:
                        break;
                }
            }

            mainWindow.Show();

            (Application.Current.MainWindow as Window)?.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}