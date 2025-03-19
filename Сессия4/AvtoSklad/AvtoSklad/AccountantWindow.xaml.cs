using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
namespace AvtoSklad
{
    public partial class AccountantWindow : Window
    {
        private Пользователь _currentUser;
        private int _currentUserId;

        public AccountantWindow(int userId)
        {
            InitializeComponent();
            _currentUserId = userId;
            DisplayUserInfo();
            LoadCurrentUserProfile();
            DisplayUserPhoto();
            LoadInventoryReport();
            LoadWarehouseReport();
            LoadTurnoverReport();
            LoadRemainingReport();
            DisplayUserInfo();
            LoadCurrentUserProfile();
            DisplayUserPhoto();

        }

        private void LoadRemainingReport()
        {
            using (var bd = new СкладКEntities())
            {
                var report = from s in bd.Склады
                             join t in bd.Товар on s.id_товара equals t.id_товара
                             select new
                             {
                                 Склад = s.Название,
                                 Товар = t.название,
                                 Остаток = s.Количество,
                                 Цена_одного_товара = t.цена,
                                 ОбщаяСтоимость = s.Количество * t.цена
                             };

                RemainingReportDataGrid.ItemsSource = report.ToList();
            }
        }

        private void LoadTurnoverReport()
        {
            using (var bd = new СкладКEntities())
            {
                var report = from t in bd.Товар
                             join p in bd.ЭлементПриходнойНакладной on t.id_товара equals p.id_товара
                             join r in bd.ЭлементРасходнойНакладной on t.id_товара equals r.id_товара
                             select new
                             {
                                 Товар = t.название,
                                 Приход = p.количество,
                                 Расход = r.количество,
                                 ОбщаяСуммаПрихода = p.количество * p.цена,
                                 ОбщаяСуммаРасхода = r.количество * r.цена
                             };

                TurnoverReportDataGrid.ItemsSource = report.ToList();
            }
        }

        private void LoadWarehouseReport()
        {
            using (var bd = new СкладКEntities())
            {
                var report = from s in bd.Склады
                             join t in bd.Товар on s.id_товара equals t.id_товара
                             select new
                             {
                                 Склад = s.Название,
                                 Категория_товара = t.категория,
                                 ОбщееКоличество = s.Количество,
                                 ОбщаяСумма = s.Количество * t.цена
                             };

                WarehouseReportDataGrid.ItemsSource = report.ToList();
            }
        }

        private void LoadInventoryReport()
        {
            using (var bd = new СкладКEntities())
            {
                var report = from i in bd.Инвентаризация
                             join e in bd.ЭлементИнвентаризации on i.id_инвентаризации equals e.id_инвентаризации
                             join t in bd.Товар on e.id_товара equals t.id_товара
                             select new
                             {
                                 i.дата_инвентаризации,
                                 i.ответственное_лицо,
                                 t.название,
                                 e.фактическое_количество,
                                 e.учетное_количество,
                                 Расхождение = e.фактическое_количество - e.учетное_количество
                             };

                InventoryDataGrid.ItemsSource = report.ToList();
            }
        }

        private void SaveInventoryReportToExcel(object sender, RoutedEventArgs e)
        {
            var report = InventoryDataGrid.ItemsSource as System.Collections.IEnumerable;
            if (report == null)
            {
                MessageBox.Show("Нет данных для экспорта.");
                return;
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Отчет по инвентаризации");
                worksheet.Cells[1, 1].Value = "Дата инвентаризации";
                worksheet.Cells[1, 2].Value = "Ответственное лицо";
                worksheet.Cells[1, 3].Value = "Товар";
                worksheet.Cells[1, 4].Value = "Фактическое количество";
                worksheet.Cells[1, 5].Value = "Учетное количество";
                worksheet.Cells[1, 6].Value = "Расхождение";
                int row = 2;
                foreach (dynamic item in report)
                {
                    worksheet.Cells[row, 1].Value = item.дата_инвентаризации;
                    worksheet.Cells[row, 2].Value = item.ответственное_лицо;
                    worksheet.Cells[row, 3].Value = item.название;
                    worksheet.Cells[row, 4].Value = item.фактическое_количество;
                    worksheet.Cells[row, 5].Value = item.учетное_количество;
                    worksheet.Cells[row, 6].Value = item.Расхождение;
                    row++;
                }

                worksheet.Cells.AutoFitColumns();

                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "Отчет_по_инвентаризации.xlsx"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);
                    package.SaveAs(file);
                    MessageBox.Show("Отчет успешно экспортирован.");
                }
            }
        }

        private void SaveWarehouseReportToExcel(object sender, RoutedEventArgs e)
        {
            var report = WarehouseReportDataGrid.ItemsSource as System.Collections.IEnumerable;
            if (report == null)
            {
                MessageBox.Show("Нет данных для экспорта.");
                return;
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Отчет по складам");
                worksheet.Cells[1, 1].Value = "Склад";
                worksheet.Cells[1, 2].Value = "Категория";
                worksheet.Cells[1, 3].Value = "Общее количество";
                worksheet.Cells[1, 4].Value = "Общая сумма";
                int row = 2;
                foreach (dynamic item in report)
                {
                    worksheet.Cells[row, 1].Value = item.Склад;
                    worksheet.Cells[row, 2].Value = item.Категория_товара;
                    worksheet.Cells[row, 3].Value = item.ОбщееКоличество;
                    worksheet.Cells[row, 4].Value = item.ОбщаяСумма;
                    row++;
                }

                worksheet.Cells.AutoFitColumns();

                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "Отчет_по_складам.xlsx"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);
                    package.SaveAs(file);
                    MessageBox.Show("Отчет успешно экспортирован.");
                }
            }
        }

        private void SaveTurnoverReportToExcel(object sender, RoutedEventArgs e)
        {
            var report = TurnoverReportDataGrid.ItemsSource as System.Collections.IEnumerable;
            if (report == null)
            {
                MessageBox.Show("Нет данных для экспорта.");
                return;
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Отчет по оборотам");
                worksheet.Cells[1, 1].Value = "Товар";
                worksheet.Cells[1, 2].Value = "Приход";
                worksheet.Cells[1, 3].Value = "Расход";
                worksheet.Cells[1, 4].Value = "Общая сумма прихода";
                worksheet.Cells[1, 5].Value = "Общая сумма расхода";
                int row = 2;
                foreach (dynamic item in report)
                {
                    worksheet.Cells[row, 1].Value = item.Товар;
                    worksheet.Cells[row, 2].Value = item.Приход;
                    worksheet.Cells[row, 3].Value = item.Расход;
                    worksheet.Cells[row, 4].Value = item.ОбщаяСуммаПрихода;
                    worksheet.Cells[row, 5].Value = item.ОбщаяСуммаРасхода;
                    row++;
                }

                worksheet.Cells.AutoFitColumns();

                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "Отчет_по_оборотам.xlsx"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);
                    package.SaveAs(file);
                    MessageBox.Show("Отчет успешно экспортирован.");
                }
            }
        }

        private void SaveRemainingReportToExcel(object sender, RoutedEventArgs e)
        {
            var report = RemainingReportDataGrid.ItemsSource as System.Collections.IEnumerable;
            if (report == null)
            {
                MessageBox.Show("Нет данных для экспорта.");
                return;
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Отчет по остаткам");
                worksheet.Cells[1, 1].Value = "Склад";
                worksheet.Cells[1, 2].Value = "Товар";
                worksheet.Cells[1, 3].Value = "Остаток";
                worksheet.Cells[1, 4].Value = "Цена";
                worksheet.Cells[1, 5].Value = "Общая стоимость";
                int row = 2;
                foreach (dynamic item in report)
                {
                    worksheet.Cells[row, 1].Value = item.Склад;
                    worksheet.Cells[row, 2].Value = item.Товар;
                    worksheet.Cells[row, 3].Value = item.Остаток;
                    worksheet.Cells[row, 4].Value = item.Цена_одного_товара;
                    worksheet.Cells[row, 5].Value = item.ОбщаяСтоимость;
                    row++;
                }

                worksheet.Cells.AutoFitColumns();

                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "Отчет_по_остаткам.xlsx"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);
                    package.SaveAs(file);
                    MessageBox.Show("Отчет успешно экспортирован.");
                }
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
    }
}