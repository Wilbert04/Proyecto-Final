using Proyecto_MantenimientoVehicular.UI.Registros;
using System.Windows;

namespace Proyecto_MantenimientoVehicular.UI.Menu
{
    /// <summary>
    /// Interaction logic for wMenu.xaml
    /// </summary>
    public partial class wMenu : Window
    {
        public wMenu()
        {
            InitializeComponent();
        }

        private void registrousuario_Click(object sender, RoutedEventArgs e)
        {
            rUsuarios registro = new rUsuarios();
            registro.ShowDialog();
        }

        private void registrovehiculo_Click(object sender, RoutedEventArgs e)
        {
            rVehiculo registro = new rVehiculo();
            registro.ShowDialog();
        }
    }
}
