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
    /// Interaction logic for Street.xaml
    /// </summary>
    public partial class StreetView : Window
    {
        private int Id { get; }
        public StreetView(int Id = -1)
        {
            InitializeComponent();
            this.Id = Id;

            if (Id != -1)
            {
                using (DataContext db = new DataContext())
                {
                    var streetItem = db.Street.Find(Id);

                    StreetTextBox.Text = streetItem.Name.ToString();
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    if (StreetTextBox.Text == "")
                        throw new ArgumentException("Ошибка. Поле 'Улица' пустое");
                    if (!Regex.IsMatch(StreetTextBox.Text, @"[А-яA-z]"))
                        throw new ArgumentException("Ошибка. Поле 'Улица' должно содержать только символы");

                    if (Id == -1)
                    {
                        if (db.Street.Where(x => x.Name == StreetTextBox.Text).Count() > 0)
                            throw new ArgumentException("Ошибка. Данная улица уже существует в базе данных");
                    }
                    if (Id != -1)
                    {
                        if (db.Street.Where(x => x.Name == StreetTextBox.Text && x.Id != Id).Count() > 0)
                            throw new ArgumentException("Ошибка. Данная улица уже существует в базе данных");
                    }

                    if (Id == -1)
                    {

                        db.Street.Add(new Models.Street()
                        {
                            Name = StreetTextBox.Text
                        });
                        db.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        var streetItem = db.Street.Find(Id);
                        streetItem.Name = StreetTextBox.Text;
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
