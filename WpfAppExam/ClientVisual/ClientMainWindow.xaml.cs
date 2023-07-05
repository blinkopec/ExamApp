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
using WpfAppExam.ClientVisual.Pages;
using WpfAppExam.Logic;

namespace WpfAppExam.ClientVisual
{
    /// <summary>
    /// Логика взаимодействия для ClientMainWindow.xaml
    /// </summary>
    public partial class ClientMainWindow : Window
    {
        public ClientMainWindow()
        {
            InitializeComponent();
        }

        private void userClick(object sender, RoutedEventArgs e)
        {

        }

        private void searchClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainCatalogPage());
        }

        private void quitClick(object sender, RoutedEventArgs e)
        {
            UserInfo.id = 0;
            UserInfo.type =TypeUserEnum.None;

            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();

        }
    }
}
