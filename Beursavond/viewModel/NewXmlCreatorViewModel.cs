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

namespace Beursavond.viewModel {
    class NewXmlCreatorViewModel : INotifyPropertyChanged{
        private view.NewXmlCreator window;
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

        public NewXmlCreatorViewModel(view.NewXmlCreator window) {
            this.window = window;
            askUserForDirectory();
            generateDefaultFileName();
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
