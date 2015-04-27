using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Beursavond.viewModel {
    class NewXmlCreatorViewModel {
        private view.NewXmlCreator window;
        private string fileDirectory;
        private string fileName;

        public NewXmlCreatorViewModel(view.NewXmlCreator window) {
            this.window = window;
            askUserForDirectory();
        }

        private void askUserForDirectory() {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Kies de map waarin het bestand dient opgeslagen te worden:";
            dialog.ShowDialog();
            fileDirectory = dialog.SelectedPath;

        }

    }
}
