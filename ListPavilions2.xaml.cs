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
    /// Логика взаимодействия для ListPavilions2.xaml
    /// </summary>
    public partial class ListPavilions2 : Page
    {
        private Pavilioni _currentListPavilions2 = new Pavilioni();
        public ListPavilions2(Pavilioni SelectedListPavilions2)
        {
            InitializeComponent();
            if (SelectedListPavilions2 != null)
                _currentListPavilions2 = SelectedListPavilions2;
            DataContext = _currentListPavilions2;
            ComboStatPavilion.ItemsSource = KingITGalishnikovEntities.GetContext().Pavilioni.Select(x => x.Status).Distinct().ToList();
            ComboTCName.ItemsSource = KingITGalishnikovEntities.GetContext().TC.ToList();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentListPavilions2.Status))
                errors.AppendLine("Укажите статус ТЦ");
            if (_currentListPavilions2.Number_Pavilion == null)
                errors.AppendLine("Введите коэффициент добавочной стоимости ТЦ");
            if (_currentListPavilions2.Floor == null)
                errors.AppendLine("Укажите этаж");
            if (string.IsNullOrWhiteSpace(_currentListPavilions2.Number_Pavilion))
                errors.AppendLine("Введите номер павильона");
            if (_currentListPavilions2.Square == null)
                errors.AppendLine("Укажите площадь");
            if (string.IsNullOrWhiteSpace(_currentListPavilions2.Status))
                errors.AppendLine("Укажите статус павильона");
            if (_currentListPavilions2.ValueAddedFactor == null)
                errors.AppendLine("Введите коэффициент добавочной стоимости павильона");
            if (_currentListPavilions2.CoastPerSquare == null)
                errors.AppendLine("Укажите стоимость кв.м");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentListPavilions2.Number_SC == 0)
            {
                //_currentListPavilions2.Number_Pavilion = KingITGalishnikovEntities.GetContext().Pavilioni.Select(x => x.Number_Pavilion).Max() + 1;
                KingITGalishnikovEntities.GetContext().Pavilioni.Add(_currentListPavilions2);
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
    


