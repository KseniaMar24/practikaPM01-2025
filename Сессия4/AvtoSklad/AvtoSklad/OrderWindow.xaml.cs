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

namespace AvtoSklad
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        private readonly Пользователь пользователь;
        public OrderWindow()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            using (var bd = new СкладКEntities())
            {
                cbProductOrder.ItemsSource = bd.Товар.ToList();
                cbProductOrder1.ItemsSource = bd.Товар.ToList();
                cbProductOrder.DisplayMemberPath = "Название";
                cbProductOrder.SelectedValuePath = "IDТовара";
                cbProductOrder1.DisplayMemberPath = "Название";
                cbProductOrder1.SelectedValuePath = "IDТовара";
                cbPostav.ItemsSource = bd.Поставщик.ToList();
                cbPostav.DisplayMemberPath = "Название";
                cbPostav.SelectedValuePath = "IDПоставщика";
                cbClient.ItemsSource = bd.Клиент.ToList();
                cbClient.DisplayMemberPath = "Название";
                cbClient.SelectedValuePath = "IDКлиента";
            }
        }
        //заказ клиенту
        private void ClientOrder_Click(object sender, RoutedEventArgs e)
        {
            using (var bd = new СкладКEntities())
            {
                // Проверка заполненности полей
                if (cbProductOrder1.SelectedItem == null || cbClient.SelectedItem == null || string.IsNullOrWhiteSpace(txtQuantityOrder.Text))
                {
                    MessageBox.Show("Заполните все поля.");
                    return;
                }

                // Получение выбранных данных
                var selectedProduct1 = cbProductOrder1.SelectedItem as Товар;
                var selectedClient1 = cbClient.SelectedItem as Клиент;
                int quantity1 = int.Parse(txtQuantityOrder1.Text);
                DateTime date1 = dpDateOrder1.SelectedDate ?? DateTime.Now;

                // Получение типа заказа
                string orderType1 = (cbOrderType1.SelectedItem as ComboBoxItem)?.Content.ToString();

                // Создание нового заказа
                var order1 = new Заказ
                {
                    тип_заказа = orderType1,
                    дата_заказа = date1,
                    id_поставщика = selectedClient1.id_клиента,
                    статус_заказа = "В процессе", // Начальный статус заказа
                    общая_сумма = selectedProduct1.цена * quantity1
                };

                // Добавление заказа в контекст
                bd.Заказ.Add(order1);
                bd.SaveChanges(); // Сохранение изменений в базе данных

                // Создание элемента заказа
                var orderItem = new ЭлементЗаказа
                {
                    id_заказа = order1.id_заказа, // Связываем элемент с только что созданным заказом
                     id_товара = selectedProduct1.id_товара,
                    количество = quantity1,
                    цена = selectedProduct1.цена
                };

                // Добавление элемента заказа в контекст
                bd.ЭлементЗаказа.Add(orderItem);
                bd.SaveChanges(); // Сохранение изменений в базе данных

                MessageBox.Show("Заказ клиенту оформлен.");
            }
        }
        //заказ поставщику
        private void btnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            using (var bd = new СкладКEntities())
            {
                // Проверка заполненности полей
                if (cbProductOrder.SelectedItem == null || cbPostav.SelectedItem == null || string.IsNullOrWhiteSpace(txtQuantityOrder.Text))
                {
                    MessageBox.Show("Заполните все поля.");
                    return;
                }

                // Получение выбранных данных
                var selectedProduct = cbProductOrder.SelectedItem as Товар;
                var selectedPostav = cbPostav.SelectedItem as Поставщик;
                int quantity = int.Parse(txtQuantityOrder.Text);
                DateTime date = dpDateOrder.SelectedDate ?? DateTime.Now;

                // Получение типа заказа
                string orderType = (cbOrderType.SelectedItem as ComboBoxItem)?.Content.ToString();

                // Создание нового заказа
                var order = new Заказ
                {
                    тип_заказа = orderType,
                    дата_заказа = date,
                    id_поставщика = selectedPostav.id_поставщика,
                    статус_заказа = "В процессе", // Начальный статус заказа
                    общая_сумма = selectedProduct.цена * quantity
                };

                // Добавление заказа в контекст
                bd.Заказ.Add(order);
                bd.SaveChanges(); // Сохранение изменений в базе данных

                // Создание элемента заказа
                var orderItem = new ЭлементЗаказа
                {
                    id_заказа = order.id_заказа, // Связываем элемент с только что созданным заказом
                    id_товара = selectedProduct.id_товара,
                    количество = quantity,
                    цена = selectedProduct.цена
                };

                // Добавление элемента заказа в контекст
                bd.ЭлементЗаказа.Add(orderItem);
                bd.SaveChanges(); // Сохранение изменений в базе данных

                MessageBox.Show("Заказ поставщику оформлен.");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var qwWindow = new SalesManagerWindow(пользователь.id_пользователя);
            qwWindow.Show();
            this.Close();
        }

        private void Exit1_Click(object sender, RoutedEventArgs e)
        {
            var qwWindow = new SalesManagerWindow(пользователь.id_пользователя);
            qwWindow.Show();
            this.Close();
        }
    }
}