using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OZON.Model
{
    public class OrderAssignment : INotifyPropertyChanged
    {
        private int _orderAssignmentID;
        private int _employeeID;
        private int _orderID;
        private DateTime _date;

        public int OrderAssignmentID
        {
            get { return _orderAssignmentID; }
            set
            {
                if (_orderAssignmentID != value)
                {
                    _orderAssignmentID = value;
                    OnPropertyChanged();
                }
            }
        }

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

        public int OrderID
        {
            get { return _orderID; }
            set
            {
                if (_orderID != value)
                {
                    _orderID = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
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
