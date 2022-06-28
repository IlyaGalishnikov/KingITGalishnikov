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
    /// Логика взаимодействия для Tenant.xaml
    /// </summary>
    public partial class Tenant : Page
    {
        public Tenant()
        {
            InitializeComponent();
            var currentgridTenant = KingITGalishnikovEntities.GetContext().Arendatory.ToList();
            DGridTenants.ItemsSource = currentgridTenant;
        }
        private void UpdateListSC()
        {
            string str = TBoxSearch.Text.ToLower();
            var currentgridTenant = KingITGalishnikovEntities.GetContext().Arendatory.Where(p => p.Name.ToLower().StartsWith(str)).ToList();
            DGridTenants.ItemsSource = currentgridTenant.OrderBy(p => p.Name).ToList();


        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateListSC();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new Tenant2(null));

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new Tenant2(null));

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var TenantForRemoving = DGridTenants.SelectedItems.Cast<Arendatory>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {TenantForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    KingITGalishnikovEntities.GetContext().Arendatory.RemoveRange(TenantForRemoving);
                    KingITGalishnikovEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridTenants.ItemsSource = KingITGalishnikovEntities.GetContext().Arendatory.ToList();

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
                DGridTenants.ItemsSource = KingITGalishnikovEntities.GetContext().Arendatory.ToList();
            }
        }

    }
}
