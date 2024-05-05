using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OZON.Model
{
    public class OrderItem : INotifyPropertyChanged
    {
        private int _orderItemID;
        private int _orderID;
        private int _productID;
        private int _quantity;

        public int OrderItemID
        {
            get { return _orderItemID; }
            set
            {
                if (_orderItemID != value)
                {
                    _orderItemID = value;
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

        public int ProductID
        {
            get { return _productID; }
            set
            {
                if (_productID != value)
                {
                    _productID = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
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
