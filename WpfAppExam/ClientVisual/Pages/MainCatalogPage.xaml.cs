using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

namespace WpfAppExam.ClientVisual.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainCatalogPage.xaml
    /// </summary>
    public partial class MainCatalogPage : Page
    {
        private List<Product> products;
        bool isSortMinus;
        bool isSortPlus;

        public MainCatalogPage()
        {
            InitializeComponent();
            products = new List<Product>();
            productsItems.ItemsSource = ExamDBEntities.GetContext().Product.ToList();
            RefreshList();
            InsertComboBox();
            isSortPlus = false;
            isSortMinus = false;
        }

        private void plusSortClick(object sender, RoutedEventArgs e)
        {
            if (!isSortPlus && !isSortMinus)
            {
                isSortPlus = true;
                plusBorder.BorderBrush = Brushes.Blue;
                productsItems.ItemsSource = ExamDBEntities.GetContext().Product.OrderBy(p => p.price).ToList();
                doneLabel.Content = productsItems.Items.Count + "/" + ExamDBEntities.GetContext().Product.ToList().Count;
                return;
            }

            if (isSortPlus)
            {
                isSortPlus = false;
                plusBorder.BorderBrush = Brushes.Transparent;
                productsItems.ItemsSource = ExamDBEntities.GetContext().Product.ToList();
                doneLabel.Content = productsItems.Items.Count + "/" + ExamDBEntities.GetContext().Product.ToList().Count;
                return;
            }
            if (isSortMinus)
            {
                isSortMinus = false;
                minusBorder.BorderBrush = Brushes.Transparent;
                productsItems.ItemsSource = ExamDBEntities.GetContext().Product.ToList();
                doneLabel.Content = productsItems.Items.Count + "/" + ExamDBEntities.GetContext().Product.ToList().Count;
                return;
            }
        }

        private void minusSortClick(object sender, RoutedEventArgs e)
        {
            if (!isSortPlus && !isSortMinus)
            {
                isSortMinus = true;
                minusBorder.BorderBrush = Brushes.Blue;
                productsItems.ItemsSource = ExamDBEntities.GetContext().Product.OrderByDescending(p => p.price).ToList();

                doneLabel.Content = productsItems.Items.Count + "/" + ExamDBEntities.GetContext().Product.ToList().Count;
                return;
            }
            if (isSortMinus)
            {
                minusBorder.BorderBrush = Brushes.Transparent;
                isSortMinus = false;
                productsItems.ItemsSource = ExamDBEntities.GetContext().Product.ToList();
                doneLabel.Content = productsItems.Items.Count + "/" + ExamDBEntities.GetContext().Product.ToList().Count;
                return;
            }

            if (isSortPlus)
            {
                isSortPlus = false;
                plusBorder.BorderBrush = Brushes.Transparent;
                productsItems.ItemsSource = ExamDBEntities.GetContext().Product.ToList();
                doneLabel.Content = productsItems.Items.Count + "/" + ExamDBEntities.GetContext().Product.ToList().Count;
                return;
            }
        }


        private void RefreshList()
        {
            try
            {
                using (var context = new ExamDBEntities())
                {
                    products = context.Product
                        .ToList();
                }
            }
            catch { }

            doneLabel.Content = productsItems.Items.Count + "/" + ExamDBEntities.GetContext().Product.ToList().Count;
        }

        private void manafacturerCombo_Selected(object sender, RoutedEventArgs e)
        {
            if (manafacturerCombo.SelectedItem != "Все производители")
            {
                using (var context = new ExamDBEntities())
                {
                    var s = context.Product
                        .Where(b => b.manufacturer == (string)manafacturerCombo.SelectedItem)
                        .ToList();

                    bool truefalse = false;
                    if (isSortMinus)
                    {
                        productsItems.ItemsSource = s.OrderByDescending(b => b.price);
                    }
                    if (isSortMinus)
                    {
                        productsItems.ItemsSource = s.OrderBy(b => b.price);
                    }
                    if (!truefalse)
                        productsItems.ItemsSource = s;

                    doneLabel.Content = productsItems.Items.Count + "/" + ExamDBEntities.GetContext().Product.ToList().Count;
                }
            }
            else
            {
                bool truefalse = false;
                if (isSortMinus)
                {
                    productsItems.ItemsSource = ExamDBEntities.GetContext().Product.ToList().OrderByDescending(p => p.price);
                    truefalse = true;
                }

                if (isSortPlus)
                {
                    productsItems.ItemsSource = ExamDBEntities.GetContext().Product.ToList().OrderBy(p => p.price);
                    truefalse = true;
                }
                if (!truefalse)
                    productsItems.ItemsSource = ExamDBEntities.GetContext().Product.ToList();

                doneLabel.Content = productsItems.Items.Count + "/" + ExamDBEntities.GetContext().Product.ToList().Count;
            }
        }

            private void InsertComboBox()
            {
                using (var context = new ExamDBEntities())
                {
                    List<string> ss2 = new List<string>();
                    ss2.Add("Все производители");

                    var tmp = context.Product
                        .Select(b => b.manufacturer)
                        .ToList();

                    ss2.AddRange(tmp);

                    manafacturerCombo.ItemsSource = ss2;
                    manafacturerCombo.SelectedIndex = 0;
                }
            }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            using (var context = new ExamDBEntities())
            {
                var s = context.Product
                    .Where(b => b.name == searchBox.Text)
                    .ToList();

                if (s.Count > 0)
                {
                    if (isSortMinus)
                        productsItems.ItemsSource = s.OrderByDescending(p => p.price);
                    else
                        if (isSortPlus)
                        productsItems.ItemsSource = s.OrderBy(p => p.price);
                    else
                        productsItems.ItemsSource = s;

                    doneLabel.Content = productsItems.Items.Count + "/" + ExamDBEntities.GetContext().Product.ToList().Count;
                }
                else
                {
                    string tmp = "";
                    int tmp2 = 0;
                    foreach (char ch in searchBox.Text)
                    {
                        if (Char.IsDigit(ch))
                        {
                            tmp += ch;
                        }
                    }

                    if (tmp.Length > 0 && int.TryParse(tmp, out tmp2))
                    {
                        var s2 = context.Product
                            .Where(b => b.price == tmp2)
                            .ToList();

                        if (s2.Count > 0)
                        {
                            if (isSortMinus)
                                productsItems.ItemsSource = s2.OrderByDescending(p => p.price);
                            else
                                 if (isSortPlus)
                                productsItems.ItemsSource = s2.OrderBy(p => p.price);
                            else
                                productsItems.ItemsSource = s2;

                            doneLabel.Content = productsItems.Items.Count + "/" + ExamDBEntities.GetContext().Product.ToList().Count;
                        }
                    }
                    else
                    {
                        bool truefalse = false;
                        if (isSortMinus)
                        {
                            productsItems.ItemsSource = ExamDBEntities.GetContext().Product.ToList().OrderByDescending(p => p.price);
                            truefalse = true;
                        }

                        if (isSortPlus)
                        {
                            productsItems.ItemsSource = ExamDBEntities.GetContext().Product.ToList().OrderBy(p => p.price);
                            truefalse = true;
                        }
                        if (!truefalse)
                            productsItems.ItemsSource = ExamDBEntities.GetContext().Product.ToList();


                        doneLabel.Content = productsItems.Items.Count + "/" + ExamDBEntities.GetContext().Product.ToList().Count;
                    }
                }
            }



        }
    }
}
