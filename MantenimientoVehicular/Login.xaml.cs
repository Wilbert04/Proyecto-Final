using MantenimientoVehicular.UI.Registros;
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

namespace MantenimientoVehicular
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistroUsuario_Click(object sender, RoutedEventArgs e)
        {
            rUsuario registro = new rUsuario();
            registro.ShowDialog();

        }

        private void RegistroCliente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RegistroVehiculo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultaUsuario_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
