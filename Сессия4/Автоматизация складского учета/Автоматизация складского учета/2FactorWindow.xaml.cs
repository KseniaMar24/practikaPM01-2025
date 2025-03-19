using System;
using System.Windows;

namespace Автоматизация_складского_учета
{
    /// <summary>
    /// Логика взаимодействия для _2FactorWindow.xaml
    /// </summary>
    public partial class _2FactorWindow : Window
    {
        private readonly Пользователи _user;
        private readonly Window _mainWindow;

        public _2FactorWindow(Пользователи user, Window mainWindow)
        {
            InitializeComponent();
            _user = user;
            _mainWindow = mainWindow;
        }

        private void Author_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SecretWord.Text))
            {
                MessageBox.Show("Введите правильный токен.");
                return;
            }
            if (SecretWord.Text == _user.TwoFactorToken) 
            {
                MessageBox.Show("Успешная авторизация!");
                OpenRoleSpecificWindow(_user.Роль);
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Неверный токен.");
            }
        }

        private void OpenRoleSpecificWindow(string роль)
        {
            try
            {
                switch (роль)
                {
                    case "Администратор":
                        new Admin(_user.IDПользователя).Show();
                        break;
                    case "Кладовщик":
                        new Storekeeper(_user.IDПользователя).Show();
                        break;
                    case "Менеджер по продажам":
                        new Sales_Manager(_user.IDПользователя).Show();
                        break;
                    case "Бухгалтер":
                        new Accountant(_user.IDПользователя).Show();
                        break;
                    default:
                        MessageBox.Show("Роль не определена.");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии окна: {ex.Message}");
            }
        }
    }
}