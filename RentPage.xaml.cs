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
    /// Логика взаимодействия для RentPage.xaml
    /// </summary>
    public partial class RentPage : Page
    {
        private Pavilioni pavilion;
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public List<Arendatory> tenantsCollection { get; set; }
        public Arendatory currentTenants { get; set; }

        public RentPage(Pavilioni pavilion)
        {
            InitializeComponent();
            this.pavilion = pavilion;
            Start = DateTime.Today;
            Stop = DateTime.Today;
            tenantsCollection = KingITGalishnikovEntities.GetContext().Arendatory.ToList();
            DataContext = this;

        }

        private void BtnArenda_Click(object sender, RoutedEventArgs e)
        {
            if (Start <= Stop && Start >= DateTime.Today)
            {
                bool bol = Start == DateTime.Today;
                KingITGalishnikovEntities.GetContext().RentOrBooked(!bol, pavilion.Number_Pavilion, pavilion.Number_SC, Start, Stop, currentTenants.ID_tenant, Authorization.Employee_number);
                MessageBox.Show(bol ? "Арендовано" : "Забронировано");

            }

        }
    }
}
