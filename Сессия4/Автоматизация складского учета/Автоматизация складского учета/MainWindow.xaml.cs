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

namespace Автоматизация_складского_учета
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (lg.Text == "" || pr.Password == "")
            {
                MessageBox.Show("Заполните поля");
                return;
            }

            using (var db = new СкладыEntities())
            {
                var user = db.Пользователи
                    .FirstOrDefault(u => u.Email == lg.Text && u.ХэшПароля == pr.Password);

                if (user == null)
                {
                    MessageBox.Show("Неверный логин или пароль.");
                    return;
                }
                var secretWindow = new _2FactorWindow(user, this);
                secretWindow.Show();
                this.Hide();
            }
        }
    }
}
