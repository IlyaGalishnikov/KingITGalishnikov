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
    /// Логика взаимодействия для ListPavilions.xaml
    /// </summary>
    public partial class ListPavilions : Page
    {
        int currentNumber_SC;
        public ListPavilions(TC CurrentSC)
        {
            InitializeComponent();
            //var currentListPavilions = KingITGalishnikovEntities.GetContext().Pavilioni.ToList();
            //LViewListPavilions.ItemsSource = currentListPavilions;
            
            if (CurrentSC != null)
            {
                currentNumber_SC = CurrentSC.Number_SC;
                LViewListPavilions.ItemsSource = KingITGalishnikovEntities.GetContext().Pavilioni.Where(x => x.Number_SC == CurrentSC.Number_SC).ToList();
            }
            else
            {
                LViewListPavilions.ItemsSource = KingITGalishnikovEntities.GetContext().Pavilioni.Where(x => x.Status != "Удален").ToList();
            }
            ComboFloor.ItemsSource = KingITGalishnikovEntities.GetContext().Pavilioni.Select(x => x.Floor).Distinct().ToList();
            ComboStatus.ItemsSource = KingITGalishnikovEntities.GetContext().Pavilioni.Select(x => x.Status).Distinct().ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var ed = LViewListPavilions.SelectedItem as Pavilioni;
            manager.MainFrame.Navigate(new ListPavilions2(ed));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new ListPavilions2(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var ListPavilionsForRemoving = LViewListPavilions.SelectedItems;

            if (MessageBox.Show($"подтвердите удаление выбранных элементов?", "внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {

                    foreach (var c in ListPavilionsForRemoving)
                    {
                        Pavilioni p = c as Pavilioni;

                        KingITGalishnikovEntities.GetContext().Pavilioni.Remove(p);
                    }
                    KingITGalishnikovEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");


                    LViewListPavilions.ItemsSource = KingITGalishnikovEntities.GetContext().Pavilioni.ToList();

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
                //LViewListPavilions.ItemsSource = KingITGalishnikovEntities.GetContext().Pavilioni.ToList();
            }
        }

        private void ComboFloor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //LViewListPavilions.ItemsSource = KingITGalishnikovEntities.GetContext().Pavilioni.Where(b => b.Floor == ComboFloor.SelectedItem && b.Status != "Удален").ToList();

        }
        private void ComboStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LViewListPavilions.ItemsSource = KingITGalishnikovEntities.GetContext().Pavilioni.Where(b => b.Status == ComboStatus.SelectedItem && b.Status != "Удален").ToList();

        }

        private void BtnPavilions_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new ListSC());
        }

        private void BtnRent_Click(object sender, RoutedEventArgs e)
        {
            var rent = LViewListPavilions.SelectedItems.Cast<Pavilioni>().FirstOrDefault();
            manager.MainFrame.Navigate(new RentPage(rent));
        }
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            ComboStatus.SelectedItem = null;
            
            LViewListPavilions.ItemsSource = KingITGalishnikovEntities.GetContext().Pavilioni.ToList();

        }
    }
}

