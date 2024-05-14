using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;

namespace WpfApp12._05
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _statusMessage;
        private DBManager _dbManager;

        public string StatusMessage
        {
            get { return _statusMessage; }
            set
            {
                _statusMessage = value;
                OnPropertyChanged("StatusMessage");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            _dbManager = new DBManager();
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _dbManager.OpenConnection();
                StatusMessage = "Connected to the database.";
            }
            catch (Exception ex)
            {
                StatusMessage = "Error connecting to the database: " + ex.Message;
            }
        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _dbManager.CloseConnection();
                StatusMessage = "Disconnected from the database.";
            }
            catch (Exception ex)
            {
                StatusMessage = "Error disconnecting from the database: " + ex.Message;
            }
        }

        private void ShowAllStationeryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable stationeryTable = _dbManager.GetAllStationery();
                StatusMessage = "Displayed all stationery.";
            }
            catch (Exception ex)
            {
                StatusMessage = "Error displaying stationery: " + ex.Message;
            }
        }

        private void ShowAllTypesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> types = _dbManager.GetAllStationeryTypes();
                StatusMessage = "Displayed all types of stationery.";
            }
            catch (Exception ex)
            {
                StatusMessage = "Error displaying types of stationery: " + ex.Message;
            }
        }

        // Додайте решту функцій тут

        // Task 4 functionalities
        private void ShowStationeryByTypeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedType = "";
                DataTable stationeryByType = _dbManager.GetStationeryByType(selectedType);
                StatusMessage = $"Displayed stationery of type: {selectedType}.";
            }
            catch (Exception ex)
            {
                StatusMessage = "Error displaying stationery by type: " + ex.Message;
            }
        }

        private void ShowStationeryByManagerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedManager = "";
                DataTable stationeryByManager = _dbManager.GetStationeryByManager(selectedManager);
                StatusMessage = $"Displayed stationery sold by manager: {selectedManager}.";
            }
            catch (Exception ex)
            {
                StatusMessage = "Error displaying stationery by manager: " + ex.Message;
            }
        }

        private void ShowStationeryByBuyerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedBuyer = "";
                DataTable stationeryByBuyer = _dbManager.GetStationeryByBuyer(selectedBuyer);
                StatusMessage = $"Displayed stationery purchased by buyer: {selectedBuyer}.";
            }
            catch (Exception ex)
            {
                StatusMessage = "Error displaying stationery by buyer: " + ex.Message;
            }
        }

        private void ShowRecentSaleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRow recentSale = _dbManager.GetRecentSale();
                StatusMessage = "Displayed information about recent sale.";
            }
            catch (Exception ex)
            {
                StatusMessage = "Error displaying information about recent sale: " + ex.Message;
            }
        }

        private void ShowAverageItemsPerTypeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dictionary<string, double> averageItemsPerType = _dbManager.GetAverageItemsPerType();
                StatusMessage = "Displayed average number of items for each type of stationery.";
            }
            catch (Exception ex)
            {
                StatusMessage = "Error displaying average items per type: " + ex.Message;
            }
        }
    }
}
