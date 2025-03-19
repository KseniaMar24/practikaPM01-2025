using System;
using System.Linq;
using System.Windows;

namespace AvtoSklad
{
    public partial class _2FWindow : Window
    {
        private readonly Пользователь _пользователь;
        private readonly Window _mainWindow;

        public _2FWindow(Пользователь пользователи, Window mainWindow)
        {
            InitializeComponent();
            _пользователь = пользователи;
            _mainWindow = mainWindow;
        }

        private void Author_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SecretWord.Text))
            {
                MessageBox.Show("Введите правильный токен.");
                return;
            }

            // Проверка токена
            if (SecretWord.Text == _пользователь.two_factor_token)
            {
                MessageBox.Show("Успешная авторизация!");
                OpenRoleSpecificWindow(_пользователь.роль);
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
                         new AdminWindow(_пользователь.id_пользователя).Show();
                        break;
                    case "Кладовщик":
                         new StorekeeperWindow(_пользователь.id_пользователя).Show();
                        break;
                    case "Менеджер по продажам":
                         new SalesManagerWindow(_пользователь.id_пользователя).Show();
                        break;
                    case "Бухгалтер":
                        new AccountantWindow(_пользователь.id_пользователя).Show();
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