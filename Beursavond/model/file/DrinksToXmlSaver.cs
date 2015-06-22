﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Beursavond.model.file {
    class DrinksToXmlSaver {
        private ObservableCollection<Drink> drinks;
        private String fileName;
        private XDocument document;

        public DrinksToXmlSaver(ObservableCollection<Drink> drinks, String fileName) {
            this.fileName = fileName;
            this.drinks = drinks;
            document = new XDocument(new XElement("beurs"));
        }

        public DrinksToXmlSaver(string fileName) {
            this.fileName = fileName;
            document = new XDocument(new XElement("beurs"));
        }

        public void writeToXMLDocument() {
            writeToXMLDocument(drinks);
        }

        /// <summary>
        /// Saves the collection of drinks to the file
        /// </summary>
        public void writeToXMLDocument(ObservableCollection<Drink> drinks) {
            XElement drinksNode = new XElement("drinks");
            foreach (Drink drink in drinks) {
                drinksNode.Add(new XElement("drink",
                    new XElement("name", drink.Name),
                    new XElement("maxPrice", drink.MaximumPrice),
                    new XElement("minPrice", drink.PurchasePrice)
                    ));
            }
            IEnumerable<XElement> currentDrinksElements = document.Root.Descendants("drinks");
            if (currentDrinksElements.Count() == 0) {
                document.Root.Add(drinksNode);
            } else {
                document.Root.Descendants("drinks").First().ReplaceWith(drinksNode);
            }
            _saveXML();
        }

        private void _saveXML() {
            document.Save(fileName);
        }

        /// <summary>
        /// Appends attributes to the document
        /// </summary>
        /// <param name="afronding">Number to round</param>
        public void AddAtributes(double afronding) {
            document.Add(new XElement("afronding", afronding));

            _saveXML();
        }

    }
}
