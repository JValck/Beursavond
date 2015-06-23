using Beursavond.model.file;
using Beursavond.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Beursavond.viewModel {
    class BeursPropertiesViewModel : INotifyPropertyChanged {
        private double _round;
        private model.file.DrinksToXmlSaver fileSaver;
        private NewXmlCreatorViewModel newXmlCreatorViewModel;
        private view.BeursProperties beursPropertiesWindow;

        public double Round {
            get {
                return _round;
            }
            set {
                _round = value;
                NotifyPropertyChanged("Round");
            }
        }

        public BeursPropertiesViewModel(DrinksToXmlSaver fileSaver, NewXmlCreatorViewModel newXmlCreatorViewModel, BeursProperties beursPropertiesWindow) {
            this.fileSaver = fileSaver;
            this.newXmlCreatorViewModel = newXmlCreatorViewModel;
            this.beursPropertiesWindow = beursPropertiesWindow;
            addLeftMouseUpListenerCancelButton(beursPropertiesWindow.FindName("CancelButton"));
            addLeftMouseUpListenerOKButton(beursPropertiesWindow.FindName("OKButton"));
        }

        #region Button handling
        private void addLeftMouseUpListenerOKButton(object p) {
            StackPanel panel = (StackPanel)p;
            panel.MouseLeftButtonUp += okButtonClicked;
        }

        private void addLeftMouseUpListenerCancelButton(object p) {
            StackPanel panel = (StackPanel)p;
            panel.MouseLeftButtonUp += cancelButtonClicked;
        }

        private void cancelButtonClicked(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            beursPropertiesWindow.Close();
        }

        private void okButtonClicked(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            fileSaver.AddAtributes(Round);
            beursPropertiesWindow.Close();            
        }
        #endregion

        #region propertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(
           [CallerMemberName] String propertyName = "") {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion propertyChanged
    }
}
