using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Drawing;

namespace AvtoSklad
{
    public partial class SalesManagerWindow : Window
    {
        private Пользователь _currentUser;
        private int _currentUserId;

        public SalesManagerWindow(int userId)
        {
            InitializeComponent();
            _currentUserId = userId;
            LoadCurrentUserProfile();
            DisplayUserInfo();
            DisplayUserPhoto();
            LoadProductsToComboBox();
            LoadData();
            LoadClients();
            LoadSuppliers();
            LoadProducts();
        }

        private void LoadProductsToComboBox()
        {
            using (var bd = new СкладКEntities())
            {
                var products = bd.Товар.Select(p => new
                {
                    p.id_товара,
                    p.название
                }).ToList();

                ProductComboBox.ItemsSource = products;
                ProductComboBox.DisplayMemberPath = "название";
                ProductComboBox.SelectedValuePath = "id_товара";
            }
        }

        private void LoadData()
        {
            using (var bd = new СкладКEntities())
            {
                var warehouses = from w in bd.Склады
                                 select new
                                 {
                                     w.id_склада,
                                     w.Название,
                                     w.Адрес,
                                     w.ТипСклада,
                                     w.ЗонаХранения,
                                     w.id_товара,
                                     w.Количество
                                 };

                grid.ItemsSource = warehouses.ToList();
            }
        }

        private void LoadClients()
        {
            using (var bd = new СкладКEntities())
            {
                var clients = from c in bd.Клиент
                              select new
                              {
                                  c.id_клиента,
                                  c.название,
                                  c.контактный_телефон,
                                  c.контактный_email,
                                  c.адрес
                              };

                grid2.ItemsSource = clients.ToList();
            }
        }

        private void LoadSuppliers()
        {
            using (var bd = new СкладКEntities())
            {
                var suppliers = from s in bd.Поставщик
                                select new
                                {
                                    s.id_поставщика,
                                    s.название,
                                    s.инн,
                                    s.кпп,
                                    s.контактный_телефон,
                                    s.контактный_email,
                                    s.адрес
                                };

                grid3.ItemsSource = suppliers.ToList();
            }
        }

        private void LoadCurrentUserProfile()
        {
            using (var bd = new СкладКEntities())
            {
                _currentUser = bd.Пользователь.FirstOrDefault(u => u.id_пользователя == _currentUserId);

                if (_currentUser != null)
                {
                    UserNameTextBox.Text = _currentUser.имя_пользователя;
                    EmailTextBox.Text = _currentUser.email;
                    if (_currentUser.фото != null)
                    {
                        var image = new BitmapImage();
                        using (var stream = new MemoryStream(_currentUser.фото))
                        {
                            image.BeginInit();
                            image.CacheOption = BitmapCacheOption.OnLoad;
                            image.StreamSource = stream;
                            image.EndInit();
                        }
                        UserPhoto.Source = image;
                    }
                }
            }
        }

        private void UploadPhoto_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png",
                Title = "Выберите фотографию"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var imagePath = openFileDialog.FileName;
                var image = new BitmapImage(new Uri(imagePath));
                UserPhoto.Source = image;
                _currentUser.фото = File.ReadAllBytes(imagePath);
            }
        }

        private void SaveProfile_Click(object sender, RoutedEventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Пользователь не найден.");
                return;
            }

            using (var bd = new СкладКEntities())
            {
                var user = bd.Пользователь.FirstOrDefault(u => u.id_пользователя == _currentUserId);
                if (user != null)
                {
                    user.имя_пользователя = UserNameTextBox.Text;
                    user.email = EmailTextBox.Text;
                    if (!string.IsNullOrEmpty(PasswordBox.Password))
                    {
                        user.хэш_пароля = HashPassword(PasswordBox.Password);
                    }
                    if (_currentUser.фото != null)
                    {
                        user.фото = _currentUser.фото;
                    }
                    bd.SaveChanges();
                    MessageBox.Show("Профиль успешно обновлен.");
                }
            }
        }

        private void DisplayUserInfo()
        {
            if (_currentUser != null)
            {
                UserInfoLabel.Text = $"Текущий пользователь: {_currentUser.имя_пользователя} ({_currentUser.роль})";
            }
            else
            {
                UserInfoLabel.Text = "Пользователь не найден.";
            }
        }

        private string HashPassword(string password)
        {
            return password.GetHashCode().ToString();
        }

        private void DisplayUserPhoto()
        {
            if (_currentUser != null && _currentUser.фото != null)
            {
                var image = new BitmapImage();
                using (var stream = new MemoryStream(_currentUser.фото))
                {
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = stream;
                    image.EndInit();
                }
                UserPhoto.Source = image;
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }

        private void LoadProducts()
        {
            using (var bd = new СкладКEntities())
            {
                var prod = from r in bd.Товар
                           select new
                           {
                               r.id_товара,
                               r.название,
                               r.артикул,
                               r.штрихкод,
                               r.категория,
                               r.единица_измерения,
                               r.цена,
                               r.серийный_номер,
                               r.минимальный_запас
                           };

                grid1.ItemsSource = prod.ToList();
            }
        }

        private void Sb_Click(object sender, RoutedEventArgs e)
        {
            string searchText = St.Text.ToLower();

            using (var bd = new СкладКEntities())
            {
                var filteredWarehouses = from w in bd.Склады
                                         where w.Название.ToLower().Contains(searchText) ||
                                               w.Адрес.ToLower().Contains(searchText) ||
                                               w.ТипСклада.ToLower().Contains(searchText) ||
                                               w.ЗонаХранения.ToLower().Contains(searchText)
                                         select new
                                         {
                                             w.id_склада,
                                             w.Название,
                                             w.Адрес,
                                             w.ТипСклада,
                                             w.ЗонаХранения,
                                             w.id_товара,
                                             w.Количество
                                         };

                grid.ItemsSource = filteredWarehouses.ToList();
            }
        }

        private void Sb1_Click(object sender, RoutedEventArgs e)
        {
            string searchText = St1.Text.ToLower();

            using (var bd = new СкладКEntities())
            {
                var filteredProducts = from r in bd.Товар
                                       where r.название.ToLower().Contains(searchText) ||
                                             r.артикул.ToLower().Contains(searchText) ||
                                             r.штрихкод.ToLower().Contains(searchText) ||
                                             r.категория.ToLower().Contains(searchText) ||
                                             r.единица_измерения.ToLower().Contains(searchText) ||
                                             r.серийный_номер.ToLower().Contains(searchText)
                                       select new
                                       {
                                           r.id_товара,
                                           r.название,
                                           r.артикул,
                                           r.штрихкод,
                                           r.категория,
                                           r.единица_измерения,
                                           r.цена,
                                           r.серийный_номер,
                                           r.минимальный_запас
                                       };

                grid1.ItemsSource = filteredProducts.ToList();
            }
        }

        private void Sb2_Click(object sender, RoutedEventArgs e)
        {
            string searchText = St2.Text.ToLower();

            using (var bd = new СкладКEntities())
            {
                var filteredClients = from c in bd.Клиент
                                      where c.название.ToLower().Contains(searchText) ||
                                            c.контактный_телефон.ToLower().Contains(searchText) ||
                                            c.контактный_email.ToLower().Contains(searchText) ||
                                            c.адрес.ToLower().Contains(searchText)
                                      select new
                                      {
                                          c.id_клиента,
                                          c.название,
                                          c.контактный_телефон,
                                          c.контактный_email,
                                          c.адрес
                                      };

                grid2.ItemsSource = filteredClients.ToList();
            }
        }

        private void Sb3_Click(object sender, RoutedEventArgs e)
        {
            string searchText = St3.Text.ToLower();

            using (var bd = new СкладКEntities())
            {
                var filteredSuppliers = from s in bd.Поставщик
                                        where s.название.ToLower().Contains(searchText) ||
                                              s.инн.ToLower().Contains(searchText) ||
                                              s.кпп.ToLower().Contains(searchText) ||
                                              s.контактный_телефон.ToLower().Contains(searchText) ||
                                              s.контактный_email.ToLower().Contains(searchText) ||
                                              s.адрес.ToLower().Contains(searchText)
                                        select new
                                        {
                                            s.id_поставщика,
                                            s.название,
                                            s.инн,
                                            s.кпп,
                                            s.контактный_телефон,
                                            s.контактный_email,
                                            s.адрес
                                        };

                grid3.ItemsSource = filteredSuppliers.ToList();
            }
        }

        private void Add1Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(naz.Text) || string.IsNullOrEmpty(inn.Text) || string.IsNullOrEmpty(kpp.Text) ||
                    string.IsNullOrEmpty(phone.Text) || string.IsNullOrEmpty(emaill.Text) || string.IsNullOrEmpty(adress.Text))
                {
                    MessageBox.Show("Заполните все поля.");
                    return;
                }

                using (var bd = new СкладКEntities())
                {
                    var newSupplier = new Поставщик
                    {
                        название = naz.Text,
                        инн = inn.Text,
                        кпп = kpp.Text,
                        контактный_телефон = phone.Text,
                        контактный_email = emaill.Text,
                        адрес = adress.Text
                    };

                    bd.Поставщик.Add(newSupplier);
                    bd.SaveChanges();

                    grid3.ItemsSource = bd.Поставщик.ToList();

                    naz.Clear();
                    inn.Clear();
                    kpp.Clear();
                    phone.Clear();
                    emaill.Clear();
                    adress.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grid3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedSupplier = grid3.SelectedItem as dynamic;
            if (selectedSupplier != null)
            {
                naz.Text = selectedSupplier.название;
                inn.Text = selectedSupplier.инн;
                kpp.Text = selectedSupplier.кпп;
                phone.Text = selectedSupplier.контактный_телефон;
                emaill.Text = selectedSupplier.контактный_email;
                adress.Text = selectedSupplier.адрес;
            }
            else
            {
                naz.Text = "";
                inn.Text = "";
                kpp.Text = "";
                phone.Text = "";
                emaill.Text = "";
                adress.Text = "";
            }
        }

        private void Edit1Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedSupplier = grid3.SelectedItem as dynamic;
            if (selectedSupplier != null)
            {
                using (var bd = new СкладКEntities())
                {
                    var supplierToUpdate = bd.Поставщик.Find(selectedSupplier.id_поставщика);
                    if (supplierToUpdate != null)
                    {
                        supplierToUpdate.название = naz.Text;
                        supplierToUpdate.инн = inn.Text;
                        supplierToUpdate.кпп = kpp.Text;
                        supplierToUpdate.контактный_телефон = phone.Text;
                        supplierToUpdate.контактный_email = emaill.Text;
                        supplierToUpdate.адрес = adress.Text;

                        bd.SaveChanges();
                        LoadSuppliers();
                        MessageBox.Show("Поставщик успешно отредактирован!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите поставщика для редактирования.");
            }
        }

        private void Delete1Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grid3.SelectedItem != null)
                {
                    var selectedSupplier = (Поставщик)grid3.SelectedItem;
                    using (var bd = new СкладКEntities())
                    {
                        var supplierToDelete = bd.Поставщик.Find(selectedSupplier.id_поставщика);
                        if (supplierToDelete != null)
                        {
                            bd.Поставщик.Remove(supplierToDelete);
                            bd.SaveChanges();
                            grid3.ItemsSource = bd.Поставщик.ToList();
                            MessageBox.Show("Поставщик успешно удален!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите поставщика для удаления");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add2Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nazz.Text) || string.IsNullOrEmpty(adres.Text) ||
                string.IsNullOrEmpty(phonee.Text) || string.IsNullOrEmpty(eemail.Text))
            {
                MessageBox.Show("Заполните все поля.");
                return;
            }

            var newClient = new Клиент
            {
                название = nazz.Text,
                адрес = adres.Text,
                контактный_телефон = phonee.Text,
                контактный_email = eemail.Text
            };

            using (var bd = new СкладКEntities())
            {
                bd.Клиент.Add(newClient);
                bd.SaveChanges();
                grid2.ItemsSource = bd.Клиент.ToList();
            }
        }

        private void grid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedClient = grid2.SelectedItem as dynamic;
            if (selectedClient != null)
            {
                nazz.Text = selectedClient.название;
                adres.Text = selectedClient.адрес;
                phonee.Text = selectedClient.контактный_телефон;
                eemail.Text = selectedClient.контактный_email;
            }
            else
            {
                nazz.Text = "";
                adres.Text = "";
                phonee.Text = "";
                eemail.Text = "";
            }
        }

        private void Edit2Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedClient = grid2.SelectedItem as dynamic;
            if (selectedClient != null)
            {
                using (var bd = new СкладКEntities())
                {
                    var clientToUpdate = bd.Клиент.Find(selectedClient.id_клиента);
                    if (clientToUpdate != null)
                    {
                        clientToUpdate.название = nazz.Text;
                        clientToUpdate.адрес = adres.Text;
                        clientToUpdate.контактный_телефон = phonee.Text;
                        clientToUpdate.контактный_email = eemail.Text;

                        bd.SaveChanges();
                        LoadClients();
                        MessageBox.Show("Клиент успешно отредактирован!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента для редактирования.");
            }
        }

        private void Delete2Button_Click(object sender, RoutedEventArgs e)
        {
            if (grid2.SelectedItem is Клиент selectedClient)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить этого клиента?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    using (var bd = new СкладКEntities())
                    {
                        bd.Клиент.Attach(selectedClient);
                        bd.Клиент.Remove(selectedClient);
                        bd.SaveChanges();
                        grid2.ItemsSource = bd.Клиент.ToList();
                        MessageBox.Show("Клиент успешно удален!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента для удаления.");
            }
        }

        private void Add3Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newProduct = new Товар
                {
                    название = nnaz.Text,
                    артикул = art.Text,
                    штрихкод = strix.Text,
                    категория = kategotia.Text,
                    единица_измерения = ed.Text,
                    цена = decimal.Parse(zena.Text),
                    серийный_номер = nomer.Text,
                    минимальный_запас = int.Parse(minzap.Text)
                };

                using (var bd = new СкладКEntities())
                {
                    bd.Товар.Add(newProduct);
                    bd.SaveChanges();
                }

                LoadProducts();
                MessageBox.Show("Товар успешно добавлен!");
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении товара: {ex.Message}");
            }
        }


        private void grid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedProduct = grid1.SelectedItem as dynamic;
            if (selectedProduct != null)
            {
                // Заполняем текстовые поля данными из выбранного товара
                nnaz.Text = selectedProduct.Название;
                art.Text = selectedProduct.Артикул;
                strix.Text = selectedProduct.Штрихкод;
                kategotia.Text = selectedProduct.Категория;
                ed.Text = selectedProduct.ЕдиницаИзмерения;
                zena.Text = selectedProduct.Цена.ToString();
                nomer.Text = selectedProduct.СерийныйНомер;
                minzap.Text = selectedProduct.МинимальныйЗапас.ToString();
            }
            else
            {
                // Если ничего не выбрано, очищаем поля
                nnaz.Text = "";
                art.Text = "";
                strix.Text = "";
                kategotia.Text = "";
                ed.Text = "";
                zena.Text = "";
                nomer.Text = "";
                minzap.Text = "";
            }
        }

        private void Edit3Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = grid1.SelectedItem as dynamic;
            if (selectedProduct != null)
            {
                using (var bd = new СкладКEntities())
                {
                    var productToUpdate = bd.Товар.Find(selectedProduct.id_товара);
                    if (productToUpdate != null)
                    {
                        productToUpdate.название = nnaz.Text;
                        productToUpdate.артикул = art.Text;
                        productToUpdate.штрихкод = strix.Text;
                        productToUpdate.категория = kategotia.Text;
                        productToUpdate.единица_измерения = ed.Text;
                        productToUpdate.цена = decimal.Parse(zena.Text);
                        productToUpdate.серийный_номер = nomer.Text;
                        productToUpdate.минимальный_запас = int.Parse(minzap.Text);

                        bd.SaveChanges();
                        LoadProducts(); // Обновляем данные в DataGrid
                        MessageBox.Show("Товар успешно отредактирован!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для редактирования.");
            }
        }

        //удаление товаров
        private void Delete3Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedProduct = grid1.SelectedItem as dynamic;
                if (selectedProduct == null)
                {
                    MessageBox.Show("Выберите товар для удаления!");
                    return;
                }

                using (var bd = new СкладКEntities())
                {
                    var productToDelete = bd.Товар.Find(selectedProduct.id_товара);
                    if (productToDelete != null)
                    {
                        bd.Товар.Remove(productToDelete);
                        bd.SaveChanges();
                        LoadProducts(); // Обновляем DataGrid
                        MessageBox.Show("Товар успешно удален!");
                    }
                    else
                    {
                        MessageBox.Show("Товар не найден в базе данных.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении товара: {ex.Message}");
            }
        }

        // Добавление склада
        private void Add4Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(kol.Text, out int количество) || ProductComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Некорректные данные! Убедитесь, что выбраны все поля.");
                    return;
                }

                var newWarehouse = new Склады
                {
                    Название = nas.Text,
                    Адрес = adrezz.Text,
                    ТипСклада = tip.Text,
                    ЗонаХранения = zonaxra.Text,
                    id_товара = (int)ProductComboBox.SelectedValue, // Получаем ID товара из ComboBox
                    Количество = количество
                };

                using (var bd = new СкладКEntities())
                {
                    bd.Склады.Add(newWarehouse);
                    bd.SaveChanges();
                }

                LoadData();
                MessageBox.Show("Склад успешно добавлен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении склада: {ex.Message}");
            }
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedWarehouse = grid.SelectedItem as dynamic;
            if (selectedWarehouse != null)
            {
                nas.Text = selectedWarehouse.Название;
                adrezz.Text = selectedWarehouse.Адрес;
                tip.Text = selectedWarehouse.ТипСклада;
                zonaxra.Text = selectedWarehouse.ЗонаХранения;
                kol.Text = selectedWarehouse.Количество?.ToString() ?? string.Empty;

                // Установка выбранного товара в ComboBox
                ProductComboBox.SelectedValue = selectedWarehouse.id_товара;
            }
            else
            {
                // Если ничего не выбрано, очищаем поля
                nas.Text = "";
                adrezz.Text = "";
                tip.Text = "";
                zonaxra.Text = "";
                kol.Text = "";
                ProductComboBox.SelectedValue = null; // Сбрасываем выбор в ComboBox
            }
        }

        // Редактирование склада
        private void Edit4Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedWarehouse = grid.SelectedItem as dynamic;
            if (selectedWarehouse != null)
            {
                if (!int.TryParse(kol.Text, out int количество))
                {
                    MessageBox.Show("Некорректные данные!");
                    return;
                }

                using (var bd = new СкладКEntities())
                {
                    var warehouseToUpdate = bd.Склады.Find(selectedWarehouse.id_склада);
                    if (warehouseToUpdate != null)
                    {
                        warehouseToUpdate.Название = nas.Text;
                        warehouseToUpdate.Адрес = adrezz.Text;
                        warehouseToUpdate.ТипСклада = tip.Text;
                        warehouseToUpdate.ЗонаХранения = zonaxra.Text;
                        warehouseToUpdate.id_товара = (int)ProductComboBox.SelectedValue; // Получаем ID товара из ComboBox
                        warehouseToUpdate.Количество = количество;

                        bd.SaveChanges();
                        LoadData();
                        MessageBox.Show("Склад успешно отредактирован!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите склад для редактирования.");
            }
        }

        // Удаление склада
        private void Delete4Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedWarehouse = grid.SelectedItem as dynamic;
                if (selectedWarehouse == null)
                {
                    MessageBox.Show("Выберите склад для удаления!");
                    return;
                }

                using (var bd = new СкладКEntities())
                {
                    var warehouseToDelete = bd.Склады.Find(selectedWarehouse.id_склада);
                    if (warehouseToDelete != null)
                    {
                        bd.Склады.Remove(warehouseToDelete);
                        bd.SaveChanges();
                    }
                }

                LoadData();
                MessageBox.Show("Склад успешно удален!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении склада: {ex.Message}");
            }
        }

        //удаление накладных
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedInvoice = grid4.SelectedItem; // Убираем dynamic
            if (selectedInvoice == null)
            {
                MessageBox.Show("Выберите накладную для удаления.");
                return;
            }

            // Получаем тип накладной и ID через рефлексию
            var invoiceType = selectedInvoice.GetType().GetProperty("Тип")?.GetValue(selectedInvoice) as string;
            var invoiceId = (int)selectedInvoice.GetType().GetProperty("id_накладной")?.GetValue(selectedInvoice);

            if (invoiceType == null || invoiceId == 0)
            {
                MessageBox.Show("Ошибка при получении данных накладной.");
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите удалить эту накладную?", "Подтверждение удаления", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new СкладКEntities())
                {
                    try
                    {
                        if (invoiceType == "Приходная")
                        {
                            var invoice = db.ПриходнаяНакладная.Find(invoiceId);
                            if (invoice != null)
                            {
                                // Удаляем связанные элементы накладной
                                var items = db.ЭлементПриходнойНакладной.Where(x => x.id_накладной == invoice.id_накладной).ToList();
                                db.ЭлементПриходнойНакладной.RemoveRange(items);

                                // Удаляем накладную
                                db.ПриходнаяНакладная.Remove(invoice);
                            }
                        }
                        else
                        {
                            var invoice = db.РасходнаяНакладная.Find(invoiceId);
                            if (invoice != null)
                            {
                                // Удаляем связанные элементы накладной
                                var items = db.ЭлементРасходнойНакладной.Where(x => x.id_накладной == invoice.id_накладной).ToList();
                                db.ЭлементРасходнойНакладной.RemoveRange(items);

                                // Удаляем накладную
                                db.РасходнаяНакладная.Remove(invoice);
                            }
                        }

                        db.SaveChanges();

                        // Обновляем DataGrid в зависимости от текущего фильтра
                        if (invoiceType == "Приходная")
                        {
                            Prih_Click(sender, e); // Обновляем приходные накладные
                        }
                        else
                        {
                            Rash_Click(sender, e); // Обновляем расходные накладные
                        }

                        MessageBox.Show("Накладная успешно удалена.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении накладной: {ex.Message}");
                    }
                }
            }
        }

        //поиск накладных
        private void Sb4_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = St4.Text.ToLower(); // Поиск без учета регистра

            using (var db = new СкладКEntities())
            {
                // Проверяем, какие накладные сейчас отображаются
                var currentInvoices = grid4.ItemsSource as IEnumerable<dynamic>;
                if (currentInvoices == null || !currentInvoices.Any())
                {
                    MessageBox.Show("Нет данных для поиска.");
                    return;
                }

                // Определяем тип накладных (приходные или расходные)
                var firstInvoice = currentInvoices.First();
                bool isIncoming = firstInvoice.Тип == "Приходная";

                if (isIncoming)
                {
                    // Поиск приходных накладных
                    var incomingInvoices = db.ПриходнаяНакладная
                        .Where(i => i.номер_накладной.ToLower().Contains(searchTerm) ||
                                     i.дата_поступления.ToString().Contains(searchTerm) ||
                                     i.id_поставщика.ToString().Contains(searchTerm) ||
                                     i.общая_сумма.ToString().Contains(searchTerm))
                        .Select(i => new
                        {
                            i.id_накладной,
                            i.номер_накладной,
                            i.дата_поступления,
                            i.id_поставщика,
                            i.общая_сумма,
                            Тип = "Приходная"
                        }).ToList();

                    grid4.ItemsSource = incomingInvoices;
                }
                else
                {
                    // Поиск расходных накладных
                    var outgoingInvoices = db.РасходнаяНакладная
                        .Where(i => i.номер_накладной.ToLower().Contains(searchTerm) ||
                                     i.дата_отгрузки.ToString().Contains(searchTerm) ||
                                     i.id_клиента.ToString().Contains(searchTerm) ||
                                     i.общая_сумма.ToString().Contains(searchTerm))
                        .Select(i => new
                        {
                            i.id_накладной,
                            i.номер_накладной,
                            i.дата_отгрузки,
                            i.id_клиента,
                            i.общая_сумма,
                            Тип = "Расходная"
                        }).ToList();

                    grid4.ItemsSource = outgoingInvoices;
                }
            }
        }


        //сохранение в excel
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Выберите тип накладных для экспорта:", "Экспорт накладных", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                ExportIncomingInvoices(); // Экспорт приходных накладных
            }
            else if (result == MessageBoxResult.No)
            {
                ExportOutgoingInvoices(); // Экспорт расходных накладных
            }
            else if (result == MessageBoxResult.Cancel)
            {
                // Экспорт всех накладных
                ExportIncomingInvoices();
                ExportOutgoingInvoices();
            }
        }

        private void Prih_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new СкладКEntities())
            {
                var incomingInvoices = db.ПриходнаяНакладная
                    .Select(i => new
                    {
                        i.id_накладной,
                        i.номер_накладной,
                        i.дата_поступления,
                        i.id_поставщика,
                        i.общая_сумма,
                        Тип = "Приходная"
                    }).ToList();

                grid4.ItemsSource = incomingInvoices; // Обновляем DataGrid
            }
        }

        private void Rash_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new СкладКEntities())
            {
                var outgoingInvoices = db.РасходнаяНакладная
                    .Select(i => new
                    {
                        i.id_накладной,
                        i.номер_накладной,
                        i.дата_отгрузки,
                        i.id_клиента,
                        i.общая_сумма,
                        Тип = "Расходная"
                    }).ToList();

                grid4.ItemsSource = outgoingInvoices; // Обновляем DataGrid
            }
        }
        private void ExportIncomingInvoices()
        {
            using (var db = new СкладКEntities())
            {
                var incomingInvoices = db.ПриходнаяНакладная
                    .Select(i => new
                    {
                        i.id_накладной,
                        i.номер_накладной,
                        i.дата_поступления,
                        i.id_поставщика,
                        i.общая_сумма,
                        Тип = "Приходная"
                    }).ToList();

                if (!incomingInvoices.Any())
                {
                    MessageBox.Show("Нет приходных накладных для экспорта.");
                    return;
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Приходные накладные");

                    // Заголовки
                    worksheet.Cells[1, 1].Value = "ID Накладной";
                    worksheet.Cells[1, 2].Value = "Номер Накладной";
                    worksheet.Cells[1, 3].Value = "Дата Поступления";
                    worksheet.Cells[1, 4].Value = "ID Поставщика";
                    worksheet.Cells[1, 5].Value = "Общая Сумма";
                    worksheet.Cells[1, 6].Value = "Тип";

                    // Форматирование заголовков
                    using (var range = worksheet.Cells[1, 1, 1, 6])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    }

                    // Данные
                    int row = 2;
                    foreach (var invoice in incomingInvoices)
                    {
                        worksheet.Cells[row, 1].Value = invoice.id_накладной;
                        worksheet.Cells[row, 2].Value = invoice.номер_накладной;
                        worksheet.Cells[row, 3].Value = invoice.дата_поступления;
                        worksheet.Cells[row, 4].Value = invoice.id_поставщика;
                        worksheet.Cells[row, 5].Value = invoice.общая_сумма;
                        worksheet.Cells[row, 6].Value = invoice.Тип;
                        row++;
                    }

                    worksheet.Cells.AutoFitColumns();

                    var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FileName = "Приходные_накладные.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        FileInfo file = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(file);
                        MessageBox.Show("Приходные накладные успешно экспортированы.");
                    }
                }
            }
        }
        private void ExportOutgoingInvoices()
        {
            using (var db = new СкладКEntities())
            {
                var outgoingInvoices = db.РасходнаяНакладная
                    .Select(i => new
                    {
                        i.id_накладной,
                        i.номер_накладной,
                        i.дата_отгрузки,
                        i.id_клиента,
                        i.общая_сумма,
                        Тип = "Расходная"
                    }).ToList();

                if (!outgoingInvoices.Any())
                {
                    MessageBox.Show("Нет расходных накладных для экспорта.");
                    return;
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Расходные накладные");

                    // Заголовки
                    worksheet.Cells[1, 1].Value = "ID Накладной";
                    worksheet.Cells[1, 2].Value = "Номер Накладной";
                    worksheet.Cells[1, 3].Value = "Дата Отгрузки";
                    worksheet.Cells[1, 4].Value = "ID Клиента";
                    worksheet.Cells[1, 5].Value = "Общая Сумма";
                    worksheet.Cells[1, 6].Value = "Тип";

                    // Форматирование заголовков
                    using (var range = worksheet.Cells[1, 1, 1, 6])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    }

                    // Данные
                    int row = 2;
                    foreach (var invoice in outgoingInvoices)
                    {
                        worksheet.Cells[row, 1].Value = invoice.id_накладной;
                        worksheet.Cells[row, 2].Value = invoice.номер_накладной;
                        worksheet.Cells[row, 3].Value = invoice.дата_отгрузки;
                        worksheet.Cells[row, 4].Value = invoice.id_клиента;
                        worksheet.Cells[row, 5].Value = invoice.общая_сумма;
                        worksheet.Cells[row, 6].Value = invoice.Тип;
                        row++;
                    }

                    worksheet.Cells.AutoFitColumns();

                    var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FileName = "Расходные_накладные.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        FileInfo file = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(file);
                        MessageBox.Show("Расходные накладные успешно экспортированы.");
                    }
                }
            }
        }
        // Окно формирования заказов
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ordWindow = new OrderWindow();
            ordWindow.Show();
            this.Close();
        }

        private void PosOrder_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new СкладКEntities())
            {
                var incomingOrders = db.Заказ
                    .Where(o => o.тип_заказа == "Оптовый") // Заказы поставщику
                    .Select(o => new
                    {
                        o.id_заказа,
                        o.тип_заказа,
                        o.дата_заказа,
                        o.id_поставщика,
                        o.статус_заказа,
                        o.общая_сумма
                    }).ToList();

                gridd.ItemsSource = incomingOrders;
            }
        }

        private void ClOrder_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new СкладКEntities())
            {
                var outgoingOrders = db.Заказ
                    .Where(o => o.тип_заказа == "Розничный") // Заказы клиенту
                    .Select(o => new
                    {
                        o.id_заказа,
                        o.тип_заказа,
                        o.дата_заказа,
                        o.id_клиента,
                        o.статус_заказа,
                        o.общая_сумма
                    }).ToList();
                gridd.ItemsSource = outgoingOrders;
            }
        }

        private void Exc_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Выберите тип заказов для экспорта:", "Экспорт заказов", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                ExportIncomingOrders(); // Экспорт заказов поставщику
            }
            else if (result == MessageBoxResult.No)
            {
                ExportOutgoingOrders(); // Экспорт заказов клиенту
            }
            else if (result == MessageBoxResult.Cancel)
            {
                // Экспорт всех заказов
                ExportIncomingOrders();
                ExportOutgoingOrders();
            }
        }

        private void ExportIncomingOrders()
        {
            using (var db = new СкладКEntities())
            {
                var incomingOrders = db.Заказ
                    .Where(o => o.тип_заказа == "Оптовый") // Заказы поставщику
                    .Select(o => new
                    {
                        o.id_заказа,
                        o.тип_заказа,
                        o.дата_заказа,
                        o.id_поставщика,
                        o.статус_заказа,
                        o.общая_сумма
                    }).ToList();

                if (!incomingOrders.Any())
                {
                    MessageBox.Show("Нет заказов для экспорта.");
                    return;
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Заказы поставщику");

                    // Заголовки
                    worksheet.Cells[1, 1].Value = "ID Заказа";
                    worksheet.Cells[1, 2].Value = "Тип Заказа";
                    worksheet.Cells[1, 3].Value = "Дата Заказа";
                    worksheet.Cells[1, 4].Value = "ID Поставщика";
                    worksheet.Cells[1, 5].Value = "Статус Заказа";
                    worksheet.Cells[1, 6].Value = "Общая Сумма";

                    // Форматирование заголовков
                    using (var range = worksheet.Cells[1, 1, 1, 6])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    }

                    // Данные
                    int row = 2;
                    foreach (var order in incomingOrders)
                    {
                        worksheet.Cells[row, 1].Value = order.id_заказа;
                        worksheet.Cells[row, 2].Value = order.тип_заказа;
                        worksheet.Cells[row, 3].Value = order.дата_заказа;
                        worksheet.Cells[row, 4].Value = order.id_поставщика;
                        worksheet.Cells[row, 5].Value = order.статус_заказа;
                        worksheet.Cells[row, 6].Value = order.общая_сумма;
                        row++;
                    }

                    worksheet.Cells.AutoFitColumns();

                    var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FileName = "Заказы_поставщику.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        FileInfo file = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(file);
                        MessageBox.Show("Заказы поставщику успешно экспортированы.");
                    }
                }
            }
        }

        private void ExportOutgoingOrders()
        {
            using (var db = new СкладКEntities())
            {
                var outgoingOrders = db.Заказ
                    .Where(o => o.тип_заказа == "Розничный") // Заказы клиенту
                    .Select(o => new
                    {
                        o.id_заказа,
                        o.тип_заказа,
                        o.дата_заказа,
                        o.id_клиента,
                        o.статус_заказа,
                        o.общая_сумма
                    }).ToList();

                if (!outgoingOrders.Any())
                {
                    MessageBox.Show("Нет заказов для экспорта.");
                    return;
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Заказы клиенту");

                    // Заголовки
                    worksheet.Cells[1, 1].Value = "ID Заказа";
                    worksheet.Cells[1, 2].Value = "Тип Заказа";
                    worksheet.Cells[1, 3].Value = "Дата Заказа";
                    worksheet.Cells[1, 4].Value = "ID Клиента";
                    worksheet.Cells[1, 5].Value = "Статус Заказа";
                    worksheet.Cells[1, 6].Value = "Общая Сумма";

                    // Форматирование заголовков
                    using (var range = worksheet.Cells[1, 1, 1, 6])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    }

                    // Данные
                    int row = 2;
                    foreach (var order in outgoingOrders)
                    {
                        worksheet.Cells[row, 1].Value = order.id_заказа;
                        worksheet.Cells[row, 2].Value = order.тип_заказа;
                        worksheet.Cells[row, 3].Value = order.дата_заказа;
                        worksheet.Cells[row, 4].Value = order.id_клиента;
                        worksheet.Cells[row, 5].Value = order.статус_заказа;
                        worksheet.Cells[row, 6].Value = order.общая_сумма;
                        row++;
                    }

                    worksheet.Cells.AutoFitColumns();

                    var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FileName = "Заказы_клиенту.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        FileInfo file = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(file);
                        MessageBox.Show("Заказы клиенту успешно экспортированы.");
                    }
                }
            }
        }

        private void Udal_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = gridd.SelectedItem;
            if (selectedOrder == null)
            {
                MessageBox.Show("Выберите заказ для удаления.");
                return;
            }

            // Получаем ID заказа через рефлексию
            var orderId = (int)selectedOrder.GetType().GetProperty("id_заказа")?.GetValue(selectedOrder);

            if (orderId == 0)
            {
                MessageBox.Show("Ошибка при получении данных заказа.");
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите удалить этот заказ?", "Подтверждение удаления", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new СкладКEntities())
                {
                    try
                    {
                        var order = db.Заказ.Find(orderId);
                        if (order != null)
                        {
                            // Удаляем связанные элементы заказа
                            var items = db.ЭлементЗаказа.Where(x => x.id_заказа == order.id_заказа).ToList();
                            db.ЭлементЗаказа.RemoveRange(items);

                            // Удаляем заказ
                            db.Заказ.Remove(order);
                        }

                        db.SaveChanges();

                        MessageBox.Show("Заказ успешно удален.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении заказа: {ex.Message}");
                    }
                }
            }
        }

        private void Z_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = Z1.Text.ToLower(); // Поиск без учета регистра

            using (var db = new СкладКEntities())
            {
                var currentOrders = gridd.ItemsSource as IEnumerable<dynamic>;
                if (currentOrders == null || !currentOrders.Any())
                {
                    MessageBox.Show("Нет данных для поиска.");
                    return;
                }

                // Поиск заказов
                var filteredOrders = db.Заказ
                    .Where(o => o.id_заказа.ToString().Contains(searchTerm) ||
                                 o.дата_заказа.ToString().Contains(searchTerm) ||
                                 o.id_клиента.ToString().Contains(searchTerm) ||
                                 o.общая_сумма.ToString().Contains(searchTerm))
                    .Select(o => new
                    {
                        o.id_заказа,
                        o.тип_заказа,
                        o.дата_заказа,
                        o.id_поставщика,
                        o.id_клиента,
                        o.статус_заказа,
                        o.общая_сумма
                    }).ToList();

                gridd.ItemsSource = filteredOrders;
            }
        }
    }
}