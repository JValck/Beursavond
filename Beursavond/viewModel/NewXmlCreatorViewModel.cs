using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Beursavond.model;
using System.Windows.Input;

namespace Beursavond.viewModel {
    class NewXmlCreatorViewModel : INotifyPropertyChanged{
        private view.NewXmlCreator window;
        public ICommand SaveCommand{get; set;}
        private string fileDirectory;
        private string fileName;
        private string _fileNameDescription;
        public string FileNameDescription {
            get {
                return _fileNameDescription;
            }
            set {
                _fileNameDescription = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Drink> Drinks { get; set; }

        public NewXmlCreatorViewModel(view.NewXmlCreator window) {
            this.window = window;
            SaveCommand = new helper.RelayCommand(c => saveXml());
            askUserForDirectory();
            generateDefaultFileName();
            addLeftMouseUpListenerAddRow(window.FindName("NewProductButton"));
            addLeftMouseUpListenerRemoveRow(window.FindName("DeleteProductButton"));
            

            initRows();
        }

        private void saveXml() {

        }

        private void initRows() {
            Drinks = new ObservableCollection<Drink>();
        }
        
        private void generateDefaultFileName() {
            fileName = "beursavond_" + DateTime.Now.ToString("ddd_d_MMM_yyyy") + ".xml";
            int fileIndex = 1; //increased when file exists
            string completeFilePath = fileDirectory + Path.DirectorySeparatorChar + fileName;
            while (File.Exists(fileDirectory + Path.DirectorySeparatorChar + fileName)) {
                fileName = Regex.Replace(fileName, @"(_[0-9]+)(_[0-9]+)\.xml$", "$1"); //remove fileIndex numbers
                fileName = fileName.Replace(".xml", ""); // remove file extension
                fileName += "_" + fileIndex + ".xml"; //remake file name
                fileIndex++;
            }
            FileNameDescription = "Bestand: " + fileName;
        }

        private void askUserForDirectory() {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Kies de map waarin het bestand dient opgeslagen te worden:";
            dialog.ShowDialog();
            fileDirectory = dialog.SelectedPath;

        }

        private void addLeftMouseUpListenerAddRow(Object p) {
            StackPanel button = (StackPanel)p;
            button.MouseLeftButtonUp += AddNewRow;
        }

        private void addLeftMouseUpListenerRemoveRow(Object o) {
            StackPanel button = (StackPanel)o;
            button.MouseLeftButtonUp += RemoveLastRow;
        }

        private void RemoveLastRow(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            if (Drinks.Count > 0) {
                Drinks.RemoveAt(Drinks.Count - 1);
            }
        }

        private void AddNewRow(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            Drinks.Insert(Drinks.Count, new Drink { Name = "", MaximumPrice = 0, PurchasePrice = 0 });            
        }

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
