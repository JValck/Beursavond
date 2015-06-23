using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beursavond.model {
    class Drink : INotifyPropertyChanged{
        private string _name;
        private double _purchasePrice, _maximumPrice;
        private int _amount;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name {
            get {
                return _name;
            }
            set {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public double PurchasePrice {
            get {
                return _purchasePrice;
            }
            set {
                _purchasePrice = value;
                NotifyPropertyChanged("PurchasePrice");
            }
        }
        public double MaximumPrice {
            get {
                return _maximumPrice;
            }
            set {
                _maximumPrice = value;
                NotifyPropertyChanged("MaximumPrice");
            }
        }
        public int Amount {
            get {
                return _amount;
            }
            set {
                _amount = value;
                NotifyPropertyChanged("Amount");
            }
        }

        private void NotifyPropertyChanged(string name) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
