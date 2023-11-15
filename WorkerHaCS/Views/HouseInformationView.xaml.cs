using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorkerHaCS.Models;

namespace WorkerHaCS.Views
{
    /// <summary>
    /// Interaction logic for HouseInformationView.xaml
    /// </summary>
    public partial class HouseInformationView : Window
    {
        private int Id { get; set; }
        public HouseInformationView(int Id = -1)
        {
            this.Id = Id;
            InitializeComponent();

            using (DataContext db = new DataContext())
            {
                StreetComboBox.ItemsSource = db.Street.ToList();

                if (Id != -1)
                {
                    var item = db.HouseInformation.Find(Id);

                    HouseNumberTextBox.Text = item.HouseNumber.ToString();
                    NumberOfApartmentsTextBox.Text = item.NumberOfApartments.ToString();
                    StreetComboBox.SelectedItem = item.Street;
                }

            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    if (StreetComboBox.Text == "")
                        throw new ArgumentException("Ошибка. Вы не выбрали улицу");
                    if (HouseNumberTextBox.Text == "" || !Regex.IsMatch(HouseNumberTextBox.Text, @"[0-9]"))
                        throw new ArgumentException("Ошибка. Вы не ввели номер дома");
                    if (NumberOfApartmentsTextBox.Text == "" || !Regex.IsMatch(NumberOfApartmentsTextBox.Text, @"[0-9]"))
                        throw new ArgumentException("Ошибка. Вы не ввели количество квартир");

                    var StreetId = (StreetComboBox.SelectedItem as Models.Street).Id;

                    if (Id == -1)
                    {
                        if (db.HouseInformation.Where(x => x.StreetId == StreetId && HouseNumberTextBox.Text == x.HouseNumber).Count() > 0)
                            throw new ArgumentException("Ошибка. Данный номер дома уже существует на этой улице");
                    }

                    if (db.HouseInformation.Where(x => x.StreetId == StreetId && HouseNumberTextBox.Text == x.HouseNumber && x.Id != Id).Count() > 0)
                        throw new ArgumentException("Ошибка. Данный номер дома уже существует на этой улице");

                    if (Id == -1)
                    {
                        db.HouseInformation.Add(new HouseInformation()
                        {
                            HouseNumber = HouseNumberTextBox.Text,
                            NumberOfApartments = int.Parse(NumberOfApartmentsTextBox.Text),
                            StreetId = (StreetComboBox.SelectedItem as Models.Street).Id
                        });
                        db.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        var HouseInformationItem = db.HouseInformation.Find(Id);
                        HouseInformationItem.HouseNumber = HouseNumberTextBox.Text;
                        HouseInformationItem.NumberOfApartments = int.Parse(NumberOfApartmentsTextBox.Text);
                        HouseInformationItem.StreetId = (StreetComboBox.SelectedItem as Models.Street).Id;
                        db.SaveChanges();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
