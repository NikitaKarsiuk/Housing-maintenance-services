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
    /// Interaction logic for TenantView.xaml
    /// </summary>
    public partial class TenantView : Window
    {
        private int Id { get; set; }
        public TenantView(int Id = -1)
        {
            this.Id = Id;
            InitializeComponent();

            using (DataContext db = new DataContext())
            {
                if (Id != -1)
                {
                    var item = db.Tenant.Find(Id);

                    NameTextBox.Text = item.Name.ToString();
                    SurnameTextBox.Text = item.Surname.ToString();
                    PatronymicTextBox.Text = item.Patronymic.ToString();
                    PhoneNumberTextBox.Text = item.PhoneNumber.ToString();
                    BankBookTextBox.Text = item.BankBook.ToString();
                }

            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    if (NameTextBox.Text == "" || !Regex.IsMatch(NameTextBox.Text, @"[А-яA-z]"))
                        throw new ArgumentException("Ошибка. Вы не заполнили поле имя");
                    if (SurnameTextBox.Text == "" || !Regex.IsMatch(SurnameTextBox.Text, @"[А-яA-z]"))
                        throw new ArgumentException("Ошибка. Вы не заполнили поле фамилия");
                    if (PatronymicTextBox.Text == "" || !Regex.IsMatch(PatronymicTextBox.Text, @"[А-яA-z]"))
                        throw new ArgumentException("Ошибка. Вы не заполнили поле отчество");
                    if (PhoneNumberTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Поле 'Телефон' пустое");
                    if (!Regex.IsMatch(PhoneNumberTextBox.Text, @"^[+]375[(]((29)|(44)|(33)|(25)|(17))[)]\d{3}[-]\d{2}[-]\d{2}$"))
                        throw new ArgumentException("Ошибка. Поле 'Телефон' должно иметь следующий вид '+375(29)111-11-11'");
                    if(db.Tenant.Where(x => x.PhoneNumber == PhoneNumberTextBox.Text).Count() > 0)
                        throw new ArgumentException("Ошибка. Данный номер телефона у другого арендодателя");
                    if (BankBookTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Вы не ввели лицовей счет");
                    if (!Regex.IsMatch(BankBookTextBox.Text, @"^[A-z]{3}\d{6}$"))
                        throw new ArgumentException("Ошибка. Поле 'Лицевой счет' должно иметь следующий вид 'AAA000000'");
                    if (db.Tenant.Where(x => x.BankBook == BankBookTextBox.Text).Count() > 0)
                        throw new ArgumentException("Ошибка. Данный лицевой счет у другого арендодателя");

                    if (Id == -1)
                    {
                        db.Tenant.Add(new Models.Tenant()
                        {
                            Name = NameTextBox.Text,
                            Surname = SurnameTextBox.Text,
                            Patronymic = PatronymicTextBox.Text,
                            PhoneNumber = PhoneNumberTextBox.Text,
                            BankBook = BankBookTextBox.Text
                        });
                        db.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        var TenantItem = db.Tenant.Find(Id);
                        TenantItem.Name = NameTextBox.Text;
                        TenantItem.Surname = SurnameTextBox.Text;
                        TenantItem.Patronymic = PatronymicTextBox.Text;
                        TenantItem.PhoneNumber = PhoneNumberTextBox.Text;
                        TenantItem.BankBook = BankBookTextBox.Text;
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
