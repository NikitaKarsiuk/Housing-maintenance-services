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
    /// Interaction logic for ServiceView.xaml
    /// </summary>
    public partial class ServiceView : Window
    {
        private int Id { get; set; }
        public ServiceView(int Id = -1)
        {
            InitializeComponent();
            this.Id = Id;

            using (DataContext db = new DataContext())
            {
                if (Id != -1)
                {
                    var item = db.Service.Find(Id);

                    CodeTextBox.Text = item.Code.ToString();
                    NameTextBox.Text = item.Name.ToString();
                    UnitTextBox.Text = item.Unit.ToString();
                    RateTextBox.Text = item.Rate.ToString();
                }

            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    if (CodeTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Вы не заполнили поле код");
                    if (!Regex.IsMatch(CodeTextBox.Text, @"[\d{9}]"))
                        throw new ArgumentException("Ошибка. Вы поле код должно иметь следующий вид '000000000'");
                    if(NameTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Вы не заполнили поле название услуги");
                    if(db.Service.Where(x => x.Name == NameTextBox.Text).Count() > 0)
                        throw new ArgumentException("Ошибка. Данная услуга уже существует");
                    if (UnitTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Вы не заполнили поле единицу измерения");
                    if (RateTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Вы не заполнили поле тариф");
                    if (!Regex.IsMatch(CodeTextBox.Text, @"[0-9]"))
                        throw new ArgumentException("Ошибка. Вы не заполнили поле тариф");

                    if (Id == -1)
                    {
                        db.Service.Add(new Models.Service()
                        {
                            Code = int.Parse(CodeTextBox.Text),
                            Name = NameTextBox.Text,
                            Unit = UnitTextBox.Text,
                            Rate = double.Parse(RateTextBox.Text)
                        });
                        db.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        var SerivceItem = db.Service.Find(Id);
                        SerivceItem.Code = int.Parse(CodeTextBox.Text);
                        SerivceItem.Name = NameTextBox.Text;
                        SerivceItem.Unit = UnitTextBox.Text;
                        SerivceItem.Rate = double.Parse(RateTextBox.Text);
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
