using Beursavond.model.file;
using Beursavond.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Beursavond.viewModel {
    class BeursPropertiesViewModel {
        private model.file.DrinksToXmlSaver fileSaver;
        private NewXmlCreatorViewModel newXmlCreatorViewModel;
        private view.BeursProperties beursPropertiesWindow;

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
            throw new NotImplementedException();
        }
        #endregion
    }
}
