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
    /// Interaction logic for PaymentForServiceView.xaml
    /// </summary>
    public partial class PaymentForServiceView : Window
    {
        private int Id { get; set; }
        public PaymentForServiceView(int Id = -1)
        {
            InitializeComponent();
            this.Id = Id;

            using (DataContext db = new DataContext())
            {
                TenantComboBox.ItemsSource = db.Tenant.ToList();
                ServiceComboBox.ItemsSource = db.Service.ToList();


                if (Id != -1)
                {

                    var PaymentForServiceItem = db.PaymentForService.Find(Id);
                    TenantComboBox.SelectedItem = PaymentForServiceItem.Tenant;
                    ServiceComboBox.SelectedItem = PaymentForServiceItem.Service;
                    ActuallySpentTextBox.Text = PaymentForServiceItem.ActuallySpent.ToString();
                    DatePickerTextBox.Text = PaymentForServiceItem.DateOfPayment.ToString();
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
                    if (DatePickerTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Выберите дату");
                    if (DateTime.Parse(DatePickerTextBox.Text) > DateTime.Now)
                        throw new ArgumentException("Ошибка. Выбранная вами дата еще не наступила");
                    if (ServiceComboBox.Text == "")
                    {
                        throw new ArgumentException("Ошибка. Вы не выбрали услугу");
                    }
                    var TenantId = (TenantComboBox.SelectedItem as Tenant).Id;
                    var ServiceId = (ServiceComboBox.SelectedItem as Service).Id;
                    var PaymetForServiceTenant = db.PaymentForService.Where(x => x.TenantId == TenantId && x.ServiceId == ServiceId).ToList();
                    if (Id == -1)
                    {
                        foreach (var service in PaymetForServiceTenant)
                        {
                            if (service.DateOfPayment.Month == DateTime.Parse(DatePickerTextBox.Text).Month && service.DateOfPayment.Year == DateTime.Parse(DatePickerTextBox.Text).Year)
                            {
                                throw new ArgumentException($"Данный арендатор уже оплачивал '{ServiceComboBox.Name}' в этом месяце");
                            }
                        }
                    }
                    else
                    {
                        foreach (var service in PaymetForServiceTenant)
                        {
                            if (service.DateOfPayment.Month == DateTime.Parse(DatePickerTextBox.Text).Month && service.DateOfPayment.Year == DateTime.Parse(DatePickerTextBox.Text).Year && service.Id != Id)
                            {
                                throw new ArgumentException($"Данный арендатор уже оплачивал '{ServiceComboBox.Text}' в этом месяце");
                            }
                        }
                    }
                    if (ActuallySpentTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Поле 'сумма оплаты' не содержит информацию");
                    if (!Regex.IsMatch(ActuallySpentTextBox.Text, @"[0-9]"))
                        throw new ArgumentException("Ошибка. Поле 'сумма оплаты' должно содержать только цифры");

                    var PaymentId = 0;
                    if (DateTime.Parse(DatePickerTextBox.Text).Day <= 25)
                        PaymentId = db.Payment.Where(x => x.Name == "Да").First().Id;
                    else
                        PaymentId = db.Payment.Where(x => x.Name == "Нет").First().Id;

                    if (Id == -1)
                    {
                        db.PaymentForService.Add(new PaymentForService()
                        {
                            TenantId = (TenantComboBox.SelectedItem as Tenant).Id,
                            ServiceId = (ServiceComboBox.SelectedItem as Service).Id,
                            ActuallySpent = double.Parse(ActuallySpentTextBox.Text),
                            DateOfPayment = DateTime.Parse(DatePickerTextBox.Text),
                            PaymentId = PaymentId
                        });
                        db.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        var PaymentForServiceItem = db.PaymentForService.Find(Id);
                        PaymentForServiceItem.TenantId = (TenantComboBox.SelectedItem as Tenant).Id;
                        PaymentForServiceItem.ServiceId = (ServiceComboBox.SelectedItem as Service).Id;
                        PaymentForServiceItem.ActuallySpent = double.Parse(ActuallySpentTextBox.Text);
                        PaymentForServiceItem.DateOfPayment = DateTime.Parse(DatePickerTextBox.Text);
                        PaymentForServiceItem.PaymentId = PaymentId;
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
