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
using System.Windows.Shapes;
using WorkerHaCS.Models;

namespace WorkerHaCS.Views
{
    /// <summary>
    /// Interaction logic for DeptorView.xaml
    /// </summary>
    /// 
    public partial class DebtorView : Window
    {
        public DebtorView()
        {
            InitializeComponent();
            using(DataContext db = new DataContext())
            {
                var Debtor = new List<Debtor>();
                var PaymentForServiceList = db.PaymentForService.ToList();
                foreach(var service in PaymentForServiceList)
                {
                    var ServiceItem = db.Service.Where(x => x.Id == service.ServiceId).First();
                    if( (service.ActuallySpent - ServiceItem.Rate) < 0)
                    {
                        Debtor.Add(new Debtor()
                        {
                            Id = service.Id,
                            TenantId = service.TenantId,
                            ServiceId = service.ServiceId,
                            ActuallySpent = service.ActuallySpent,
                            Rate = ServiceItem.Rate,
                            Debt = Math.Round(service.ActuallySpent - ServiceItem.Rate, 2),
                            DateOfPayment = service.DateOfPayment,
                            PaymentId = service.PaymentId
                        });
                    }
                }

                DebtDataGrid.ItemsSource = Debtor;
                DebtDataGrid.Items.Refresh();
            }
        }
    }
}
