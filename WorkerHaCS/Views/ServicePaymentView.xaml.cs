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
    /// Interaction logic for ServicePaymentView.xaml
    /// </summary>
    public partial class ServicePaymentView : Window
    {
        private int Id { get; set; }
        public ServicePaymentView(int Id = -1)
        {
            InitializeComponent();
            this.Id = Id;

            using (DataContext db = new DataContext())
            {
                var PaymentForServiceItems = db.PaymentForService.Where(x => x.TenantId == Id).ToList();
                PaymentForServiceDataGrid.ItemsSource = PaymentForServiceItems;
                PaymentForServiceDataGrid.Items.Refresh();
            }
        }
    }
}
