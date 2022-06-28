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
using System.IO;
using Microsoft.Win32;

namespace KingITGalishnikov
{
    /// <summary>
    /// Логика взаимодействия для ListSC2.xaml
    /// </summary>
    public partial class ListSC2 : Page
    {
        private TC _currentTC = new TC();
        public ListSC2(TC SelectedTC)
        {
            InitializeComponent();
            if (SelectedTC != null)
                _currentTC = SelectedTC;
            ComboStatus.ItemsSource = KingITGalishnikovEntities.GetContext().TC.Select(x => x.Status).Distinct().ToList();
            DataContext = _currentTC;
            

        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentTC.Name))
                errors.AppendLine("Укажите название ТЦ");
            if (_currentTC.ValueAddedFactor == null)
                errors.AppendLine("Введите коэффициент добавочной стоимости ТЦ");
            if (string.IsNullOrWhiteSpace(_currentTC.Status))
                errors.AppendLine("Укажите статус");
            if (_currentTC.Price == null)
                errors.AppendLine("Введите затраты на строительство торгового центра");
            if (string.IsNullOrWhiteSpace(_currentTC.City))
                errors.AppendLine("Укажите город");
            if (_currentTC.Floors == null)
                errors.AppendLine("Введите число этажей");
            
            

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentTC.Number_SC == 0)
            {
                _currentTC.Number_SC = KingITGalishnikovEntities.GetContext().TC.Select(x => x.Number_SC).Max() + 1;
                KingITGalishnikovEntities.GetContext().TC.Add(_currentTC);
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

        private void BtnPicSave_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files | *.BMP;*.JPG;*.PNG";
            fileDialog.InitialDirectory = @"C:\Users";

            fileDialog.Title = "Выбор фото ТЦ";

            if (fileDialog.ShowDialog() == true)
            {

                _currentTC.Picture = File.ReadAllBytes(fileDialog.FileName);
            }
            MessageBox.Show(" Файл выбран ");
        }

        private void BtnPavilion_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new ListPavilions(_currentTC));
        }
    }
    }



