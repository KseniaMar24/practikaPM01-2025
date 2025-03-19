using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace AvtoSklad
{
    public partial class AdminWindow : Window
    {
        private Пользователь _currentUser;
        private int _currentUserId;
        public AdminWindow(int userId)
        {
            InitializeComponent();
            _currentUserId = userId;
            LoadCurrentUserProfile();
            DisplayUserInfo();
            DisplayUserPhoto();
            LoadData();
            LoadProducts();
            LoadClients();
            LoadSuppliers();
            LoadUsers();
            LoadProductsToComboBox();


        }
        private void LoadProducts()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке товаров: {ex.Message}");
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
        private void LoadUsers()
        {
            using (var bd = new СкладКEntities())
            {
                var polz = from r in bd.Пользователь
                           select new
                           {
                               r.id_пользователя,
                               r.имя_пользователя,
                               r.email,
                               r.хэш_пароля,
                               r.роль

                           };

                grid4.ItemsSource = polz.ToList();
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
        private void Sb4_Click(object sender, RoutedEventArgs e)
        {
            string searchText = St4.Text.ToLower();

            using (var bd = new СкладКEntities())
            {
                var filteredUsers = from u in bd.Пользователь
                                    where u.имя_пользователя.ToLower().Contains(searchText) ||
                                          u.email.ToLower().Contains(searchText) ||
                                          u.роль.ToLower().Contains(searchText)
                                    select new
                                    {
                                        u.id_пользователя,
                                        u.имя_пользователя,
                                        u.email,
                                        u.хэш_пароля,
                                        u.роль
                                    };

                grid4.ItemsSource = filteredUsers.ToList();
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
        // Добавление пользователя 
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ima.Text) || string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(par.Text) || role.SelectedItem == null)
                {
                    MessageBox.Show("Заполните все поля и выберите роль.");
                    return;
                }

                using (var bd = new СкладКEntities())
                {
                    var newUser = new Пользователь
                    {
                        имя_пользователя = ima.Text,
                        email = email.Text,
                        хэш_пароля = par.Text,
                        роль = ((ComboBoxItem)role.SelectedItem).Content.ToString()
                    };

                    bd.Пользователь.Add(newUser);
                    bd.SaveChanges();

                    // Обновляем DataGrid
                    LoadUsers();

                    // Очищаем поля
                    ima.Clear();
                    email.Clear();
                    par.Clear();
                    role.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grid4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grid4.SelectedItem != null)
            {
                var selectedUser = grid4.SelectedItem as dynamic;
                ima.Text = selectedUser.ИмяПользователя;
                email.Text = selectedUser.Email;
                par.Text = selectedUser.ХэшПароля;

                // Установка выбранного элемента в ComboBox
                foreach (ComboBoxItem item in role.Items)
                {
                    if (item.Content.ToString() == selectedUser.Роль)
                    {
                        role.SelectedItem = item;
                        break;
                    }
                }
            }
            else
            {
                // Если ничего не выбрано, очищаем поля
                ima.Text = "";
                email.Text = "";
                par.Text = "";
                role.SelectedItem = null;
            }
        }

        // Редактирование пользователя 
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grid4.SelectedItem != null)
                {
                    var selectedUser = grid4.SelectedItem as dynamic;

                    using (var bd = new СкладКEntities())
                    {
                        var userToEdit = bd.Пользователь.Find(selectedUser.IDПользователя);
                        if (userToEdit != null)
                        {
                            userToEdit.ИмяПользователя = ima.Text;
                            userToEdit.Email = email.Text;
                            userToEdit.ХэшПароля = par.Text;
                            userToEdit.Роль = ((ComboBoxItem)role.SelectedItem).Content.ToString();
                            bd.SaveChanges();

                            // Обновляем DataGrid
                            LoadUsers();

                            // Очищаем поля
                            ima.Clear();
                            email.Clear();
                            par.Clear();
                            role.SelectedItem = null;
                            MessageBox.Show("Пользователь успешно отредактирован!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите пользователя для редактирования");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Удаление пользователя 
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grid4.SelectedItem != null)
                {
                    var selectedUser = grid4.SelectedItem as dynamic;

                    using (var bd = new СкладКEntities())
                    {
                        var userToDelete = bd.Пользователь.Find(selectedUser.IDПользователя);
                        if (userToDelete != null)
                        {
                            bd.Пользователь.Remove(userToDelete);
                            bd.SaveChanges();

                            // Обновляем DataGrid
                            LoadUsers();
                            MessageBox.Show("Пользователь успешно удален!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите пользователя для удаления");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        //добавление поставщика
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

                    // Обновляем DataGrid
                    grid3.ItemsSource = bd.Поставщик.ToList();

                    // Очищаем поля
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
                naz.Text = selectedSupplier.Название;
                inn.Text = selectedSupplier.ИНН;
                kpp.Text = selectedSupplier.КПП;
                phone.Text = selectedSupplier.КонтактныйТелефон;
                emaill.Text = selectedSupplier.КонтактныйEmail;
                adress.Text = selectedSupplier.Адрес;
            }
            else
            {
                // Если ничего не выбрано, очищаем поля
                naz.Text = "";
                inn.Text = "";
                kpp.Text = "";
                phone.Text = "";
                emaill.Text = "";
                adress.Text = "";
            }
        }

        // Редактирование поставщика
        private void Edit1Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedSupplier = grid3.SelectedItem as dynamic;
            if (selectedSupplier != null)
            {
                using (var bd = new СкладКEntities())
                {
                    var supplierToUpdate = bd.Поставщик.Find(selectedSupplier.IDПоставщика);
                    if (supplierToUpdate != null)
                    {
                        supplierToUpdate.Название = naz.Text;
                        supplierToUpdate.ИНН = inn.Text;
                        supplierToUpdate.КПП = kpp.Text;
                        supplierToUpdate.КонтактныйТелефон = phone.Text;
                        supplierToUpdate.КонтактныйEmail = emaill.Text;
                        supplierToUpdate.Адрес = adress.Text;

                        bd.SaveChanges();
                        LoadSuppliers(); // Обновляем данные в DataGrid
                        MessageBox.Show("Поставщик успешно отредактирован!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите поставщика для редактирования.");
            }
        }

        //удаление поставщика
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
        //Добавление клиента
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
                // Заполняем текстовые поля данными из выбранного клиента
                nazz.Text = selectedClient.Название;
                adres.Text = selectedClient.Адрес;
                phonee.Text = selectedClient.КонтактныйТелефон;
                eemail.Text = selectedClient.КонтактныйEmail;
            }
            else
            {
                // Если ничего не выбрано, очищаем поля
                nazz.Text = "";
                adres.Text = "";
                phonee.Text = "";
                eemail.Text = "";
            }
        }
        //редактирование клиента 
        private void Edit2Button_Click(object sender, RoutedEventArgs e)
        {

            var selectedClient = grid2.SelectedItem as dynamic;
            if (selectedClient != null)
            {
                using (var bd = new СкладКEntities())
                {
                    var supplierToUpdate = bd.Клиент.Find(selectedClient.IDКлиента);
                    if (supplierToUpdate != null)
                    {
                        supplierToUpdate.Название = nazz.Text;
                        supplierToUpdate.Адрес = adres.Text;
                        supplierToUpdate.КонтактныйТелефон = phonee.Text;
                        supplierToUpdate.КонтактныйEmail = eemail.Text;

                        bd.SaveChanges();
                        LoadClients(); // Обновляем данные в DataGrid
                        MessageBox.Show("Клиент успешно отредактирован!");
                    }
                }
            }

            else
            {
                MessageBox.Show("Выберите клиента для редактирования.");
            }
        }
        //удаление клиента
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

        // добавление товаров
        private void Add3Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Создаем новый объект товара
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

                // Добавляем товар в базу данных
                using (var bd = new СкладКEntities())
                {
                    bd.Товар.Add(newProduct);
                    bd.SaveChanges();
                }

                // Обновляем DataGrid
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
                    var supplierToUpdate = bd.Товар.Find(selectedProduct.IDТовара);
                    if (supplierToUpdate != null)
                    {
                        supplierToUpdate.Название = nnaz.Text;
                        supplierToUpdate.Артикул = art.Text;
                        supplierToUpdate.Штрихкод = strix.Text;
                        supplierToUpdate.Категория = kategotia.Text;
                        supplierToUpdate.ЕдиницаИзмерения = ed.Text;
                        supplierToUpdate.Цена = decimal.Parse(zena.Text);
                        supplierToUpdate.СерийныйНомер = nomer.Text;
                        supplierToUpdate.МинимальныйЗапас = int.Parse(minzap.Text);

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
                    // Найдем товар по ID
                    var productToDelete = bd.Товар.Find(selectedProduct.IDТовара);
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
                ProductComboBox.SelectedValue = selectedWarehouse.IDТовара;
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
                    var warehouseToUpdate = bd.Склады.Find(selectedWarehouse.IDСклада);
                    if (warehouseToUpdate != null)
                    {
                        warehouseToUpdate.Название = nas.Text;
                        warehouseToUpdate.Адрес = adrezz.Text;
                        warehouseToUpdate.ТипСклада = tip.Text;
                        warehouseToUpdate.ЗонаХранения = zonaxra.Text;
                        warehouseToUpdate.IDТовара = (int)ProductComboBox.SelectedValue; // Получаем ID товара из ComboBox
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
                    var warehouseToDelete = bd.Склады.Find(selectedWarehouse.IDСклада);
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
                ProductComboBox.DisplayMemberPath = "Название"; // Отображаем название товара
                ProductComboBox.SelectedValuePath = "IDТовара"; // Устанавливаем ID товара как значение
            }
        }
    }
}

