using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ZXing;
using System.Drawing;

namespace AvtoSklad
{
    public partial class StorekeeperWindow : Window
    {
        private Пользователь _currentUser;
        private int _currentUserId;

        public StorekeeperWindow(int userId)
        {
            InitializeComponent();
            _currentUserId = userId;
            LoadCurrentUserProfile();
            DisplayUserInfo();
            DisplayUserPhoto();
            LoadData();
            LoadInventoryReport();
        }

        private void LoadData()
        {
            using (var bd = new СкладКEntities())
            {
                cbProductIncoming.ItemsSource = bd.Товар.ToList();
                cbProductOutgoing.ItemsSource = bd.Товар.ToList();
                cbProductBarcode.ItemsSource = bd.Товар.ToList();
                cbSupplier.ItemsSource = bd.Поставщик.ToList();
                cbClient.ItemsSource = bd.Клиент.ToList();
            }
        }

        private void CreateIncomingInvoice_Click(object sender, RoutedEventArgs e)
        {
            using (var bd = new СкладКEntities())
            {
                if (cbProductIncoming.SelectedItem == null || cbSupplier.SelectedItem == null || string.IsNullOrWhiteSpace(txtQuantityIncoming.Text))
                {
                    MessageBox.Show("Заполните все поля.");
                    return;
                }

                var selectedProduct = cbProductIncoming.SelectedItem as Товар;
                var selectedSupplier = cbSupplier.SelectedItem as Поставщик;
                int quantity = int.Parse(txtQuantityIncoming.Text);
                DateTime date = dpDateIncoming.SelectedDate ?? DateTime.Now;

                var invoice = new ПриходнаяНакладная
                {
                    номер_накладной = Guid.NewGuid().ToString("N").Substring(0, 10), // Генерация уникального номера
                    дата_поступления = date,
                    id_поставщика = selectedSupplier.id_поставщика,
                    общая_сумма = selectedProduct.цена * quantity
                };
                bd.ПриходнаяНакладная.Add(invoice);
                bd.SaveChanges();

                var invoiceItem = new ЭлементПриходнойНакладной
                {
                    id_накладной = invoice.id_накладной,
                    id_товара = selectedProduct.id_товара,
                    количество = quantity,
                    цена = selectedProduct.цена
                };
                bd.ЭлементПриходнойНакладной.Add(invoiceItem);
                bd.SaveChanges();

                MessageBox.Show("Приходная накладная оформлена.");
            }
        }

        private void CreateOutgoingInvoice_Click(object sender, RoutedEventArgs e)
        {
            using (var bd = new СкладКEntities())
            {
                if (cbProductOutgoing.SelectedItem == null || cbClient.SelectedItem == null || string.IsNullOrWhiteSpace(txtQuantityOutgoing.Text))
                {
                    MessageBox.Show("Заполните все поля.");
                    return;
                }

                var selectedProduct = cbProductOutgoing.SelectedItem as Товар;
                var selectedClient = cbClient.SelectedItem as Клиент;
                int quantity = int.Parse(txtQuantityOutgoing.Text);
                DateTime date = dpDateOutgoing.SelectedDate ?? DateTime.Now;

                var invoice = new РасходнаяНакладная
                {
                    номер_накладной = Guid.NewGuid().ToString("N").Substring(0, 10), // Генерация уникального номера
                    дата_отгрузки = date,
                    id_клиента = selectedClient.id_клиента,
                    общая_сумма = selectedProduct.цена * quantity
                };
                bd.РасходнаяНакладная.Add(invoice);
                bd.SaveChanges();

                var invoiceItem = new ЭлементРасходнойНакладной
                {
                    id_накладной = invoice.id_накладной,
                    id_товара = selectedProduct.id_товара,
                    количество = quantity,
                    цена = selectedProduct.цена
                };
                bd.ЭлементРасходнойНакладной.Add(invoiceItem);
                bd.SaveChanges();

                MessageBox.Show("Расходная накладная оформлена.");
            }
        }

        private void GenerateBarcode_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = cbProductBarcode.SelectedItem as Товар;
            if (selectedProduct == null)
            {
                MessageBox.Show("Выберите товар.");
                return;
            }
            var barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 200,
                    Height = 100
                }
            };
            var barcodeBitmap = barcodeWriter.Write(selectedProduct.штрихкод);
            imgBarcode.Source = barcodeBitmap.ToBitmapImage();
        }

        private void PrintBarcode_Click(object sender, RoutedEventArgs e)
        {
            if (imgBarcode.Source == null)
            {
                MessageBox.Show("Сначала сгенерируйте штрихкод.");
                return;
            }
            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(imgBarcode, "Печать штрихкода");
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

                dgInventoryReport.ItemsSource = report.ToList();
            }
        }

        private void ExportInventoryReport_Click(object sender, RoutedEventArgs e)
        {
            var report = dgInventoryReport.ItemsSource as System.Collections.IEnumerable;
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