using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Beursavond.helper;
using Beursavond.view;

using Microsoft.Win32;

namespace Beursavond.viewModel {
    class MainWindowViewModel {        
        /*public ICommand LoadCommand {
            get;
            set;
        }
        public ICommand CreateCommand {
            get;
            set;
        }*/

        public MainWindowViewModel() {
            //LoadCommand = new RelayCommand(c => openLoadDialog());

        }

        public void openLoadDialog() {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open eerder aangemaakt bestand";
            dialog.Filter = "Beurs files (*.xml)|*.xml";
            dialog.FilterIndex = 0;
            dialog.ShowDialog();
        }

        public void createNewFile() {
            NewXmlCreator window = new NewXmlCreator();
            window.DataContext = new NewXmlCreatorViewModel(window);
            window.Show();
        }
    }
}
