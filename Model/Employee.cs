using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OZON.Model
{
    public class Employee : INotifyPropertyChanged
    {
        private int _employeeID;
        private string _firstName;
        private string _lastName;
        private string _username;
        private string _password;
        private string _position;
        private decimal _rating;
        private decimal _salary;
        private int _pickupPointID;

        public int EmployeeID
        {
            get { return _employeeID; }
            set
            {
                if (_employeeID != value)
                {
                    _employeeID = value;
                    OnPropertyChanged();
                }
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Login
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Position
        {
            get { return _position; }
            set
            {
                if (_position != value)
                {
                    _position = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Rating
        {
            get { return _rating; }
            set
            {
                if (_rating != value)
                {
                    _rating = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Salary
        {
            get { return _salary; }
            set
            {
                if (_salary != value)
                {
                    _salary = value;
                    OnPropertyChanged();
                }
            }
        }

        public int PickupPointID
        {
            get { return _pickupPointID; }
            set
            {
                if (_pickupPointID != value)
                {
                    _pickupPointID = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
