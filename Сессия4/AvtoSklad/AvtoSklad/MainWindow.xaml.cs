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

namespace AvtoSklad
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

            using (var db = new СкладКEntities())
            {
                var user = db.Пользователь
                    .FirstOrDefault(u => u.email == lg.Text && u.хэш_пароля == pr.Password);

                if (user == null)
                {
                    MessageBox.Show("Неверный логин или пароль.");
                    return;
                }
                var secretWindow = new _2FWindow(user, this);
                secretWindow.Show();
                this.Hide();
            }
        }
    }
}
