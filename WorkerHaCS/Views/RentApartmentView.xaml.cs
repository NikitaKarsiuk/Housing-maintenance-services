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
    /// Interaction logic for RentApartment.xaml
    /// </summary>
    public partial class RentApartmentView : Window
    {
        private int Id { get; set; }
        public RentApartmentView(int Id = -1)
        {
            this.Id = Id;
            InitializeComponent();

            using (DataContext db = new DataContext())
            {
                TenantComboBox.ItemsSource = db.Tenant.ToList();
                StreetComboBox.ItemsSource = db.Street.ToList();

                if (Id != -1)
                {
                    
                    var RentApartmentItem = db.RentApartment.Find(Id);
                    var HouseInformationItem = db.HouseInformation.Where(x => x.Id == RentApartmentItem.HouseInformationId).First();
                    

                    TenantComboBox.SelectedItem = RentApartmentItem.Tenant;
                    NumberOfResidentsTextBox.Text = RentApartmentItem.NumberOfResidents.ToString();
                    SquareTextBox.Text = RentApartmentItem.Square.ToString();
                    StreetComboBox.SelectedItem = db.Street.Where(x => x.Id == HouseInformationItem.StreetId).First();
                    HouseNumberComboBox.SelectedItem = RentApartmentItem.HouseInformation;
                    ApartmentNumberTextBox.Text = RentApartmentItem.ApartmentNumber.ToString();

                    var StreetId = RentApartmentItem.HouseInformationId;
                    HouseNumberComboBox.ItemsSource = db.HouseInformation.Where(x => x.StreetId == StreetId).ToList();
                }

            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    
                    if (TenantComboBox.Text == "")
                        throw new ArgumentException("Ошибка. Вы не выбрали счет арендатора");
                    var TenantId = (TenantComboBox.SelectedItem as Tenant).Id;
                    if(Id == -1)
                    if (db.RentApartment.Where(x => x.TenantId == TenantId).Count() > 0)
                        throw new ArgumentException("Ошибка. Арендатор уже арендует квартиру");
                    if (Id != -1)
                        if (db.RentApartment.Where(x => x.TenantId == TenantId && x.Id != Id).Count() > 0)
                            throw new ArgumentException("Ошибка. Арендатор уже арендует квартиру");
                    if (!Regex.IsMatch(NumberOfResidentsTextBox.Text, @"[0-9]"))
                        throw new ArgumentException("Ошибка. Поле 'количество проживающих' должно содержать только цифры");
                    if (int.Parse(NumberOfResidentsTextBox.Text) <= 0 && int.Parse(NumberOfResidentsTextBox.Text) >= 11)
                        throw new ArgumentException("Ошибка. Количество проживающих не должно превышать 10");
                    if (!Regex.IsMatch(SquareTextBox.Text, @"[0-9]"))
                        throw new ArgumentException("Ошибка. Поле 'площадь' должно содержать только цифры");
                    if (double.Parse(SquareTextBox.Text) <= 0 && double.Parse(SquareTextBox.Text) >= 250)
                        throw new ArgumentException("Ошибка. Площадь должна быть не больше 250 m^2");
                    if(StreetComboBox.Text == "")
                        throw new ArgumentException("Ошибка. Вы не ввели улицу");
                    if (HouseNumberComboBox.Text == "")
                        throw new ArgumentException("Ошибка. Вы не ввели номер дома");
                    var HouseInformationId = (HouseNumberComboBox.SelectedItem as HouseInformation).Id;
                    var HouseInformationItem = db.HouseInformation.Where(x => x.Id == HouseInformationId).First();
                    if (ApartmentNumberTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Вы не ввели номер квартиры");
                    var ApartmentNumber = int.Parse(ApartmentNumberTextBox.Text);
                    if (Id == -1)
                    {
                        if (db.RentApartment.Where(x => x.HouseInformationId == HouseInformationId && x.ApartmentNumber == ApartmentNumber).Count() > 0)
                            throw new ArgumentException("Ошибка. Данная квартира уже занята");
                    }
                    else
                    if (Id != -1)
                    {
                        if (db.RentApartment.Where(x => x.HouseInformationId == HouseInformationId && x.ApartmentNumber == ApartmentNumber && x.Id != Id).Count() > 0)
                            throw new ArgumentException("Ошибка. Данная квартира уже занята");

                    }
                    if (ApartmentNumber < 0 && ApartmentNumber >= HouseInformationItem.NumberOfApartments)
                        throw new ArgumentException("Ошибка. Номер квартиры не существует");

                    if (Id == -1)
                    {
                        db.RentApartment.Add(new RentApartment()
                        {
                            TenantId = (TenantComboBox.SelectedItem as Tenant).Id,
                            NumberOfResidents = int.Parse(NumberOfResidentsTextBox.Text),
                            Square = double.Parse(SquareTextBox.Text),
                            HouseInformationId = (HouseNumberComboBox.SelectedItem as HouseInformation).Id,
                            ApartmentNumber = int.Parse(ApartmentNumberTextBox.Text)
                        });
                        db.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        var RentApartmentItem = db.RentApartment.Find(Id);
                        RentApartmentItem.TenantId = (TenantComboBox.SelectedItem as Tenant).Id;
                        RentApartmentItem.NumberOfResidents = int.Parse(NumberOfResidentsTextBox.Text);
                        RentApartmentItem.Square = double.Parse(SquareTextBox.Text);
                        RentApartmentItem.HouseInformationId = (HouseNumberComboBox.SelectedItem as HouseInformation).Id;
                        RentApartmentItem.ApartmentNumber = int.Parse(ApartmentNumberTextBox.Text);
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

        private void StreetComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using(DataContext db = new DataContext())
            {
                var StreetId = (StreetComboBox.SelectedItem as Models.Street).Id;
                HouseNumberComboBox.ItemsSource = db.HouseInformation.Where(x => x.StreetId == StreetId).ToList();
            }
        }
    }
}
