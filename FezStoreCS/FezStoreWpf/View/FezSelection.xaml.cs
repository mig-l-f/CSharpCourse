﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using FezStore.Model;

namespace FezStore.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FezSelection : Window
    {
        private BasketList shopping_basket;

        public FezSelection(BasketList shopping_basket)
        {
            this.shopping_basket = shopping_basket;

            InitializeComponent();

            this.comboBoxStyle.SelectionChanged += new SelectionChangedEventHandler(UpdateOnStyleSelectionChanged);
            this.comboBoxSize.SelectionChanged += new SelectionChangedEventHandler(UpdateOnSizeSelectionChanged);

            CalculatePrice();
        }

        private void UpdateOnSizeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculatePrice();
        }

        private void UpdateOnStyleSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            XmlElement fezStyleSelectedElement = (sender as ComboBox).SelectedItem as XmlElement;
            this.styleDescriptionTextBox.Text = fezStyleSelectedElement.Attributes["LongDescription"].Value;
            CalculatePrice();
        }

        private void CalculatePrice()
        {
            XmlElement fezStyleSelectedElement = this.comboBoxStyle.SelectedItem as XmlElement;
            XmlElement fezSizeSelectedElement = this.comboBoxSize.SelectedItem as XmlElement;
            try
            {
                double price = Convert.ToDouble(fezStyleSelectedElement.Attributes["BasePrice"].Value as String)
                                * Convert.ToDouble(fezSizeSelectedElement.Attributes["PriceModifier"].Value as String);
                this.priceTextLabel.Text = String.Format("{0,2:C}", price);
            }
            catch(FormatException){}
            catch (NullReferenceException) { }
        }

        private void viewReceiptButton_Click(object sender, RoutedEventArgs e)
        {
            ReceiptView rv = new ReceiptView(shopping_basket);
            rv.Show();
        }

        private void addItemButton_Click(object sender, RoutedEventArgs e)
        {
            XmlElement fezStyleSelectedElement = this.comboBoxStyle.SelectedItem as XmlElement;
            XmlElement fezSizeSelectedElement = this.comboBoxSize.SelectedItem as XmlElement;
            try{
                shopping_basket.Add(
                    new FezSize(fezSizeSelectedElement.Attributes["Label"].Value as String,
                                Convert.ToDouble(fezSizeSelectedElement.Attributes["PriceModifier"].Value as String)),
                    new FezStyle(fezStyleSelectedElement.Attributes["LongDescription"].Value as String,
                                fezStyleSelectedElement.Attributes["ShortDescription"].Value as String,
                                Convert.ToDecimal(fezStyleSelectedElement.Attributes["BasePrice"].Value as String),
                                Convert.ToBoolean(fezStyleSelectedElement.Attributes["SupportsTassels"].Value as String)));
            }
            catch (NullReferenceException) { }
        }

        private void xmlExportButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog toXMLDialog = new SaveFileDialog();
            toXMLDialog.AddExtension = true;
            toXMLDialog.DefaultExt = "xml";
            toXMLDialog.Filter =
            "XML files (*.xml)|*.xml|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (toXMLDialog.ShowDialog(this) == true)
            {
                StreamWriter fileStream;
                fileStream = new StreamWriter(toXMLDialog.OpenFile());

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(BasketList));
                xmlSerializer.Serialize(fileStream, shopping_basket);
                fileStream.Close();
            }            
        }

        private void xmlImportButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fromXMLDialog = new OpenFileDialog();
            fromXMLDialog.AddExtension = true;
            fromXMLDialog.DefaultExt = "xml";
            fromXMLDialog.Filter = "XML files (*.xml)|*.xml|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (fromXMLDialog.ShowDialog(this) == true)
            {
                StreamReader fileStream;
                fileStream = new StreamReader(fromXMLDialog.OpenFile());

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(BasketList));
                shopping_basket = (BasketList)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
            }
        }
    }
}
