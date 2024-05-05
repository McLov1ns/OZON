using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OZON.Model
{
    public class Order : INotifyPropertyChanged
    {
        private int _orderID;
        private int _clientID;
        private int _pickupPointID;
        private decimal _orderAmount;
        [Key]
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

        public int ClientID
        {
            get { return _clientID; }
            set
            {
                if (_clientID != value)
                {
                    _clientID = value;
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

        public decimal OrderAmount
        {
            get { return _orderAmount; }
            set
            {
                if (_orderAmount != value)
                {
                    _orderAmount = value;
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
