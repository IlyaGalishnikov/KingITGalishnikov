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
    /// Логика взаимодействия для Tenant2.xaml
    /// </summary>
    public partial class Tenant2 : Page
    {
        private Arendatory _currentTenant2 = new Arendatory();
        public Tenant2(Arendatory SelectedTenant2)
        {
            InitializeComponent();
            if (SelectedTenant2 != null)
                _currentTenant2 = SelectedTenant2;
            
            DataContext = _currentTenant2;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentTenant2.Name))
                errors.AppendLine("Укажите название компании");
            if (string.IsNullOrWhiteSpace(_currentTenant2.Adress))
                errors.AppendLine("Укажите адрес");
            if (string.IsNullOrWhiteSpace(_currentTenant2.Number))
                errors.AppendLine("Укажите Номер телефона");
            



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentTenant2.ID_tenant == 0)
            {
                _currentTenant2.ID_tenant = KingITGalishnikovEntities.GetContext().Arendatory.Select(x => x.ID_tenant).Max() + 1;
                KingITGalishnikovEntities.GetContext().Arendatory.Add(_currentTenant2);
            }

            try
            {
                KingITGalishnikovEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
