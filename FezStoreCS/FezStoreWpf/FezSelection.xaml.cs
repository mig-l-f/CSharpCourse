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
using System.Xml;
using FezStoreCS;

namespace FezStoreWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FezSelection : Window
    {
        public FezSelection()
        {
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
                this.priceTextLabel.Content = String.Format("{0,2:C}", price);
            }
            catch(FormatException e){}
            catch (NullReferenceException e1) { }
        }
    }
}
