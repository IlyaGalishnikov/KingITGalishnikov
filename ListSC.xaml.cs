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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KingITGalishnikov
{
    /// <summary>
    /// Логика взаимодействия для ListSC.xaml
    /// </summary>
    public partial class ListSC : Page
    {
        public ListSC()
        {
            InitializeComponent();
            var currentListSC = KingITGalishnikovEntities.GetContext().TC.ToList();
            LViewListSC.ItemsSource = currentListSC;
            ComboCity.ItemsSource = KingITGalishnikovEntities.GetContext().TC.Select(x => x.City).Distinct().ToList();
            ComboStatus.ItemsSource = KingITGalishnikovEntities.GetContext().TC.Select(x => x.Status).Distinct().ToList();

        }
        private void UpdateListSC()
        {
            string str = TBoxSearch.Text.ToLower();
            var currentListSC = KingITGalishnikovEntities.GetContext().TC.Where(p => p.Name.ToLower().StartsWith(str)).ToList();
            LViewListSC.ItemsSource = currentListSC.OrderBy(p => p.Name).ToList();


        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateListSC();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var upd = LViewListSC.SelectedItem as TC;
            manager.MainFrame.Navigate(new ListSC2(upd));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new ListSC2(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var ListSCForRemoving = LViewListSC.SelectedItems;

            if (MessageBox.Show($"Подтвердите удаление выбранных элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try

                {

                    foreach (var c in ListSCForRemoving)
                    {
                        TC p = c as TC;

                        KingITGalishnikovEntities.GetContext().TC.Remove(p);
                    }
                    KingITGalishnikovEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");


                    LViewListSC.ItemsSource = KingITGalishnikovEntities.GetContext().TC.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                KingITGalishnikovEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LViewListSC.ItemsSource = KingITGalishnikovEntities.GetContext().TC.ToList();
            }
        }

        private void BtnPavilions_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new ListPavilions(null));
        }

        private void ComboCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LViewListSC.ItemsSource = KingITGalishnikovEntities.GetContext().TC.Where(b => b.City == ComboCity.SelectedItem && b.Status != "Удален").ToList();
        }

        private void ComboStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LViewListSC.ItemsSource = KingITGalishnikovEntities.GetContext().TC.Where(b => b.Status == ComboStatus.SelectedItem && b.Status != "Удален").ToList();

        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            ComboCity.SelectedItem = null;
            ComboStatus.SelectedItem = null;
            LViewListSC.ItemsSource = KingITGalishnikovEntities.GetContext().TC.ToList();

        }
    }
}
