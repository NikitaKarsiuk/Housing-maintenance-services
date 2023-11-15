using System;
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
using WorkerHaCS.Models;
using WorkerHaCS.Views;

namespace WorkerHaCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using(DataContext db = new DataContext())
            {
                if(db.Payment.Count() != 2)
                {
                    db.Payment.RemoveRange(db.Payment.ToList());
                    db.Payment.AddRange(new List<Payment>
                    {
                        new Payment()
                        {
                            Name = "Да"
                        },
                        new Payment()
                        {
                            Name = "Нет"
                        }
                    });
                }
                db.SaveChanges();
            }

            DirectoryFillTabItem("TenantTabItem");
        }

        private void FillTabItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var nameTabItem = (sender as TabItem).Name.ToString(); ;
            DirectoryFillTabItem(nameTabItem);
        }
        private void DirectoryFillTabItem(string tabItemName)
        {
            using (DataContext db = new DataContext())
            {
                if (tabItemName == "TenantTabItem")
                {
                    var items = db.Tenant.ToList();
                    TenantDataGrid.ItemsSource = items;
                    TenantDataGrid.Items.Refresh();
                }
                if (tabItemName == "HouseInformationTabItem")
                {
                    var items = db.HouseInformation.ToList();
                    HouseInformationDataGrid.ItemsSource = items;
                    HouseInformationDataGrid.Items.Refresh();
                }
                if (tabItemName == "StreetTabItem")
                {
                    var items = db.Street.ToList();
                    StreetDataGrid.ItemsSource = items;
                    StreetDataGrid.Items.Refresh();
                }
                if (tabItemName == "RentApartmentTabItem")
                {
                    var items = db.RentApartment.ToList();
                    RentApartmentDataGrid.ItemsSource = items;
                    RentApartmentDataGrid.Items.Refresh();
                }
                if (tabItemName == "ServiceTabItem")
                {
                    var items = db.Service.ToList();
                    ServiceDataGrid.ItemsSource = items;
                    ServiceDataGrid.Items.Refresh();
                }
                if (tabItemName == "PaymentForServiceTabItem")
                {
                    var items = db.PaymentForService.ToList();
                    PaymentForServiceDataGrid.ItemsSource = items;
                    PaymentForServiceDataGrid.Items.Refresh();
                }
            }
        }

        private void StreetAddButton_Click(object sender, RoutedEventArgs e)
        {
            Views.StreetView StreetView = new Views.StreetView();
            StreetView.Closed += new EventHandler((_s, _e) =>
            {
                DirectoryFillTabItem("StreetTabItem");
            });
            StreetView.Show();
        }

        private void StreetChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StreetDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var StreetItems = StreetDataGrid.ItemsSource as List<Models.Street>;
                var StreetItem = StreetDataGrid.SelectedItem as Models.Street;

                Views.StreetView StreetView = new Views.StreetView(StreetItem.Id);
                StreetView.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem("StreetTabItem");
                });
                StreetView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StreetDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StreetDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var StreetItems = StreetDataGrid.ItemsSource as List<Models.Street>;
                var StreetItem = StreetDataGrid.SelectedItem as Models.Street;

                using (DataContext db = new DataContext())
                {
                    if (db.HouseInformation.Where(x => x.StreetId == StreetItem.Id).Count() > 0)
                        throw new ArgumentException("Выбранную вами улицу, удалить нельзя");

                    var StreetItemRemove = db.Street.Find(StreetItem.Id);

                    db.Street.Remove(StreetItemRemove);
                    db.SaveChanges();
                }

                StreetItems.Remove(StreetItem);
                DirectoryFillTabItem("SteetTabItem");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HouseInformationAddButton_Click(object sender, RoutedEventArgs e)
        {
            Views.HouseInformationView HouseInformationView = new Views.HouseInformationView();
            HouseInformationView.Closed += new EventHandler((_s, _e) =>
            {
                DirectoryFillTabItem("HouseInformationTabItem");
            });
            HouseInformationView.Show();
        }

        private void HouseInformationChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (HouseInformationDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var HouseInformationItems = HouseInformationDataGrid.ItemsSource as List<Models.HouseInformation>;
                var HouseInformationItem = HouseInformationDataGrid.SelectedItem as Models.HouseInformation;

                Views.HouseInformationView StreetView = new Views.HouseInformationView(HouseInformationItem.Id);
                StreetView.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem("HouseInformationTabItem");
                });
                StreetView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HouseInformationDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (HouseInformationDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var HouseInformationItems = HouseInformationDataGrid.ItemsSource as List<Models.HouseInformation>;
                var HouseInformationItem = HouseInformationDataGrid.SelectedItem as Models.HouseInformation;

                using (DataContext db = new DataContext())
                {
                    if (db.RentApartment.Where(x => x.HouseInformationId == HouseInformationItem.Id).Count() > 0)
                        throw new ArgumentException("Выбранную вами улицу, удалить нельзя");

                    var HouseInformationItemRemove = db.HouseInformation.Find(HouseInformationItem.Id);

                    db.HouseInformation.Remove(HouseInformationItemRemove);
                    db.SaveChanges();
                }

                HouseInformationItems.Remove(HouseInformationItem);
                DirectoryFillTabItem("HouseInformationTabItem");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TenantAddButton_Click(object sender, RoutedEventArgs e)
        {
            Views.TenantView TenantView = new Views.TenantView();
            TenantView.Closed += new EventHandler((_s, _e) =>
            {
                DirectoryFillTabItem("TenantTabItem");
            });
            TenantView.Show();
        }

        private void TenantChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TenantDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var TenantItems = TenantDataGrid.ItemsSource as List<Models.Tenant>;
                var TenantItem = TenantDataGrid.SelectedItem as Models.Tenant;

                Views.TenantView StreetView = new Views.TenantView(TenantItem.Id);
                StreetView.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem("TenantTabItem");
                });
                StreetView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TenantDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (HouseInformationDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var TenantItems = TenantDataGrid.ItemsSource as List<Models.Tenant>;
                var TenantItem = TenantDataGrid.SelectedItem as Models.Tenant;

                using (DataContext db = new DataContext())
                {
                    if (db.RentApartment.Where(x => x.TenantId == TenantItem.Id).Count() > 0)
                        throw new ArgumentException("Выбранного вами арендатора, удалить нельзя");

                    var HouseInformationItemRemove = db.HouseInformation.Find(TenantItem.Id);

                    db.HouseInformation.Remove(HouseInformationItemRemove);
                    db.SaveChanges();
                }

                TenantItems.Remove(TenantItem);
                DirectoryFillTabItem("TenantTabItem");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ServiceAddButton_Click(object sender, RoutedEventArgs e)
        {
            Views.ServiceView ServiceView = new Views.ServiceView();
            ServiceView.Closed += new EventHandler((_s, _e) =>
            {
                DirectoryFillTabItem("ServiceTabItem");
            });
            ServiceView.Show();
        }

        private void ServiceChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ServiceDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var ServiceItems = ServiceDataGrid.ItemsSource as List<Models.Service>;
                var ServiceItem = ServiceDataGrid.SelectedItem as Models.Service;

                Views.ServiceView ServiceView = new Views.ServiceView(ServiceItem.Id);
                ServiceView.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem("ServiceTabItem");
                });
                ServiceView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ServiceDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ServiceDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var ServiceItems = ServiceDataGrid.ItemsSource as List<Models.Service>;
                var ServiceItem = ServiceDataGrid.SelectedItem as Models.Service;

                using (DataContext db = new DataContext())
                {
                    if (db.PaymentForService.Where(x => x.ServiceId == ServiceItem.Id).Count() > 0)
                        throw new ArgumentException("Выбранную вами услугу, удалить нельзя");

                    var ServiceItemRemove = db.Service.Find(ServiceItem.Id);

                    db.Service.Remove(ServiceItemRemove);
                    db.SaveChanges();
                }

                ServiceItems.Remove(ServiceItem);
                DirectoryFillTabItem("ServiceTabItem");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RentApartmentAddButton_Click(object sender, RoutedEventArgs e)
        {
            Views.RentApartmentView RentApartmentView = new Views.RentApartmentView();
            RentApartmentView.Closed += new EventHandler((_s, _e) =>
            {
                DirectoryFillTabItem("RentApartmentTabItem");
            });
            RentApartmentView.Show();
        }

        private void RentApartmentChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RentApartmentDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var RentApartmentItems = RentApartmentDataGrid.ItemsSource as List<Models.RentApartment>;
                var RentApartmentItem = RentApartmentDataGrid.SelectedItem as Models.RentApartment;

                Views.RentApartmentView RentApartmentView = new Views.RentApartmentView(RentApartmentItem.Id);
                RentApartmentView.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem("RentApartmentTabItem");
                });
                RentApartmentView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RentApartmentDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RentApartmentDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var RentApartmentItems = RentApartmentDataGrid.ItemsSource as List<Models.RentApartment>;
                var RentApartmentItem = RentApartmentDataGrid.SelectedItem as Models.RentApartment;

                using (DataContext db = new DataContext())
                {
                    var RentApartmentItemRemove = db.RentApartment.Find(RentApartmentItem.Id);

                    db.RentApartment.Remove(RentApartmentItemRemove);
                    db.SaveChanges();
                }

                RentApartmentItems.Remove(RentApartmentItem);
                DirectoryFillTabItem("RentApartmentTabItem");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PaymentForServiceAddButton_Click(object sender, RoutedEventArgs e)
        {
            Views.PaymentForServiceView PaymentForServiceView = new Views.PaymentForServiceView();
            PaymentForServiceView.Closed += new EventHandler((_s, _e) =>
            {
                DirectoryFillTabItem("PaymentForServiceTabItem");
            });
            PaymentForServiceView.Show();
        }

        private void PaymentForServiceChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PaymentForServiceDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var PaymentForServiceItems = PaymentForServiceDataGrid.ItemsSource as List<Models.PaymentForService>;
                var PaymentForServiceItem = PaymentForServiceDataGrid.SelectedItem as Models.PaymentForService;

                Views.PaymentForServiceView PaymentForServiceView = new Views.PaymentForServiceView(PaymentForServiceItem.Id);
                PaymentForServiceView.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem("PaymentForServiceTabItem");
                });
                PaymentForServiceView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PaymentForServiceDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PaymentForServiceDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var PaymentForServiceItems = PaymentForServiceDataGrid.ItemsSource as List<Models.PaymentForService>;
                var PaymentForServiceItem = PaymentForServiceDataGrid.SelectedItem as Models.PaymentForService;

                using (DataContext db = new DataContext())
                {
                    var PaymentForServiceItemRemove = db.PaymentForService.Find(PaymentForServiceItem.Id);

                    db.PaymentForService.Remove(PaymentForServiceItemRemove);
                    db.SaveChanges();
                }

                PaymentForServiceItems.Remove(PaymentForServiceItem);
                DirectoryFillTabItem("PaymentForServiceTabItem");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenServicePaymentView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TenantDataGrid.SelectedItem == null)
                    throw new ArgumentException("Выберите строку");

                var TenantItems = TenantDataGrid.ItemsSource as List<Models.Tenant>;
                var TenantItem = TenantDataGrid.SelectedItem as Models.Tenant;

                ServicePaymentView ServicePaymentView = new ServicePaymentView(TenantItem.Id);
                ServicePaymentView.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem("ServicePaymentTabItem");
                });
                ServicePaymentView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenDeptorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DebtorView DeptorView = new DebtorView();
                DeptorView.Closed += new EventHandler((_s, _e) =>
                {
                    DirectoryFillTabItem("PaymentForServiceTabItem");
                });
                DeptorView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
