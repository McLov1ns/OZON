using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OZON.Model
{
    public class Product : INotifyPropertyChanged
    {
        private int _productID;
        private string _name;
        private decimal _price;
        private decimal _rating;
        private int _sellerID;

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

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
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

        public int SellerID
        {
            get { return _sellerID; }
            set
            {
                if (_sellerID != value)
                {
                    _sellerID = value;
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
