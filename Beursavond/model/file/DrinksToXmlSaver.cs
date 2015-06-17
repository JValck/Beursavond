using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Beursavond.model.file {
    class DrinksToXmlSaver {
        private ObservableCollection<Drink> drinks;
        private String fileName;
        private XmlDocument document;

        public DrinksToXmlSaver(ObservableCollection<Drink> drinks, String fileName) {
            this.fileName = fileName;
            this.drinks = drinks;
            document = new XmlDocument
        }


    }
}
