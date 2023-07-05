using System;
using System.Windows.Media;
using System.Windows;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Windows.Controls;
using WpfAppExam.ClientVisual;
using WpfAppExam.Logic;

namespace WpfAppExam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int ImageWidth = 200;
        private const int ImageHeight = 50;
        private const int FontSize = 30;
        private const string FontFamilyName = "Arial";
        private const int LineCount = 6;
        private string captchaText;
        private int loginAttempts;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string pswdOnDatabase = null;
            bool isAdmin = false;
            bool isClient = false;
            bool isManager = false;

            using (var context = new ExamDBEntities())
            {
                try
                {
                    pswdOnDatabase = context.Client
                        .Where(b => b.login == LoginBox.Text)
                        .Select(b => b.password)
                        .Single();

                    if (pswdOnDatabase != null)
                        isClient = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                try
                {
                    pswdOnDatabase = context.Admin
                        .Where(b => b.login == LoginBox.Text)
                        .Select(b => b.password)
                        .Single();

                    if (pswdOnDatabase != null)
                        isAdmin = true;
                }
                catch (Exception ex)
                {   
                }

                try
                {
                    pswdOnDatabase = context.Manager
                        .Where(b => b.login == LoginBox.Text)
                        .Select(b => b.password)
                        .Single();

                    if (pswdOnDatabase != null)
                        isManager = true;
                }
                catch (Exception ex)
                {
                }

                if (!isAdmin && !isClient && !isManager)
                {
                    loginAttempts += 1;
                    ErrorLabel.Content = "Неверный логин или пароль";
                    ActivateCaptcha();
                }    

                if (loginAttempts >= 1)
                {
                    if (pswdOnDatabase == PsswdBox.Password && CaptchaBox != null)
                    {
                        if (CaptchaBox.Text == captchaText)
                        {
                            using (var context1 = new ExamDBEntities())
                            {
                                //Входы
                                if (isClient)
                                {
                                    UserInfo.id = context1.Client
                                        .Where(b => b.login == LoginBox.Text)
                                        .Select(a => a.idClient)
                                        .Single();

                                    UserInfo.type = TypeUserEnum.Client;

                                    ClientMainWindow clientMainWindow = new ClientMainWindow();
                                    clientMainWindow.Show();
                                    this.Close();
                                }
                                if (isAdmin)
                                {
                                    UserInfo.id = context1.Admin
                                        .Where(b => b.login == LoginBox.Text)
                                        .Select(a => a.idAdmin)
                                        .Single();
                                    UserInfo.type = TypeUserEnum.Admin;
                                }
                                if (isManager)
                                {
                                    UserInfo.id = context1.Manager
                                        .Where(b => b.login == LoginBox.Text)
                                        .Select(a => a.idManager)
                                        .Single();
                                    UserInfo.type = TypeUserEnum.Manager;
                                }
                            }
                        }
                        else
                        {
                            ErrorLabel.Content = "Неправильно введена captcha";
                        }
                    }
                    else
                    {
                        ErrorLabel.Content = "Неверный логин или пароль";
                    }
                }
                else
                {
                    if (pswdOnDatabase == PsswdBox.Password && CaptchaBox != null)
                    {
                        using (var context1 = new ExamDBEntities())
                        {
                            //Входы
                            if (isClient)
                            {
                                UserInfo.id = context1.Client
                                    .Where(b => b.login == LoginBox.Text)
                                    .Select(a => a.idClient)
                                    .Single();

                                UserInfo.type = TypeUserEnum.Client;

                                ClientMainWindow clientMainWindow = new ClientMainWindow();
                                clientMainWindow.Show();
                                this.Close();
                            }
                            if (isAdmin)
                            {
                                UserInfo.id = context1.Admin
                                    .Where(b => b.login == LoginBox.Text)
                                    .Select(a => a.idAdmin)
                                    .Single();
                                UserInfo.type = TypeUserEnum.Admin;
                            }
                            if (isManager)
                            {
                                UserInfo.id = context1.Manager
                                    .Where(b => b.login == LoginBox.Text)
                                    .Select(a => a.idManager)
                                    .Single();
                                UserInfo.type = TypeUserEnum.Manager;
                            }
                        }
                    }
                    else
                    {
                        ErrorLabel.Content = "Неверный логин или пароль";
                    }
                
                }
            }
        }

        private void AddNoise(Graphics graphics)
        {
            var random = new Random();

            // Добавляем графический шум
            for (int i = 0; i < 1000; i++) // Установите желаемое количество точек шума
            {
                var point = new System.Windows.Point(random.Next(ImageWidth), random.Next(ImageHeight));

                using (var brush = new SolidBrush(System.Drawing.Color.Black))
                {
                    graphics.FillRectangle(brush, (float)point.X, (float)point.Y, 1, 1);
                }
            }
        }

        public BitmapImage GenerateCaptcha()
        {
            // Создаем новое изображение с белым фоном
            using (var bitmap = new Bitmap(ImageWidth, ImageHeight))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(System.Drawing.Color.White);

                    // Генерируем случайный текст для капчи
                    captchaText = GenerateRandomText();

                    // Создаем новый шрифт для рисования текста
                    using (var font = new System.Drawing.Font(new System.Drawing.FontFamily(FontFamilyName), FontSize, System.Drawing.FontStyle.Bold))
                    {
                        using (var brush = new SolidBrush(System.Drawing.Color.Black))
                        {
                            // Рисуем текст на изображении
                            graphics.DrawString(captchaText, font, brush, 10, 10);

                            // Добавляем перечеркивания к буквам
                            AddLines(graphics, captchaText);

                            // Добавляем графический шум
                            AddNoise(graphics);
                        }
                    }
                }

                // Преобразуем Bitmap в BitmapImage
                var bitmapImage = ConvertBitmapToBitmapImage(bitmap);

                return bitmapImage;
            }
        }

        private string GenerateRandomText()
        {
            // Генерируем случайный текст для капчи
            var random = new Random();
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var captchaText = new char[6];

            for (int i = 0; i < captchaText.Length; i++)
            {
                captchaText[i] = characters[random.Next(characters.Length)];
            }

            return new string(captchaText);
        }

        private void AddLines(Graphics graphics, string captchaText)
        {
            var random = new Random();

            // Добавляем перечеркивания к буквам
            for (int i = 0; i < LineCount; i++)
            {
                var startPoint = new System.Windows.Point(random.Next(ImageWidth), random.Next(ImageHeight));
                var endPoint = new System.Windows.Point(random.Next(ImageWidth), random.Next(ImageHeight));

                using (var pen = new System.Drawing.Pen(System.Drawing.Color.Black, 3)) // Установите желаемую толщину пера
                {
                    graphics.DrawLine(pen, (float)startPoint.X, (float)startPoint.Y, (float)endPoint.X, (float)endPoint.Y);
                }
            }
        }

        private BitmapImage ConvertBitmapToBitmapImage(Bitmap bitmap)
        {
            using (var memoryStream = new MemoryStream())
            {
                // Сохраняем изображение в поток памяти в формате PNG
                bitmap.Save(memoryStream, ImageFormat.Png);
                memoryStream.Position = 0;

                // Создаем новый объект BitmapImage
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

        private void GuesButton_Click(object sender, RoutedEventArgs e)
        {
            //Сюда код менеджера
        }


        private void ActivateCaptcha()
        {
            CaptchaImage.Visibility = Visibility.Visible;
            CaptchaBox.Visibility = Visibility.Visible;
            CaptchaImage.Source = GenerateCaptcha();
        }
    }
}
