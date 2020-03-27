using Proyecto_MantenimientoVehicular.BLL;
using Proyecto_MantenimientoVehicular.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_MantenimientoVehicular.UI.Registros
{
    /// <summary>
    /// Interaction logic for rVehiculo.xaml
    /// </summary>
    public partial class rVehiculo : Window
    {
        Vehiculos vehiculos = new Vehiculos();
        public rVehiculo()
        {
            InitializeComponent();
            List<string> clientes = new List<string>
            {
                "Julio","Ericsson"
            };
            clienteComboBox.SelectedItem = clientes ;

            List<string> tipoVehiculo = new List<string>
            {
                "Carros","Camionetas","Jeepetas","Motores","Camiones",
            };
            tipovehiculoComboBox.SelectedItem = tipoVehiculo;

            this.DataContext = vehiculos;
            idTextBox.Text = "0";
        }

        private void LimpiarCampos()
        {
            clienteComboBox.Text = string.Empty;
            descripcionTextBox.Text = string.Empty;
            clienteComboBox.Text = string.Empty;
            añoTextBox.Text = string.Empty;
            tipovehiculoComboBox.Text = string.Empty;
            fechaDatePicker.SelectedDate = DateTime.Now;
        }

        private bool ExisteEnLaBaseDatos()
        {
            Vehiculos vehiculos = VehiculoBLL.Buscar((int)Convert.ToInt32(idTextBox.Text));
                return (vehiculos != null);
        }

        private bool ValidarCampos()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(clienteComboBox.Text))
            {
                MessageBox.Show("Debe Elegir un Cliente!!","Fallo",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(descripcionTextBox.Text))
            {
                MessageBox.Show("Este Campo es Obligatorio!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(placaTextBox.Text))
            {
                MessageBox.Show("Este Campo es Obligatorio!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(añoTextBox.Text))
            {
                MessageBox.Show("Este Campo es Obligatorio!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(tipovehiculoComboBox.Text))
            {
                MessageBox.Show("Este Campo es Obligatorio!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                paso = false;
            }


            return paso;
        }
        

        private void LLenar()
        {
            this.DataContext = null;
            this.DataContext = vehiculos;
        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!ValidarCampos())
                return;

            if (idTextBox.Text == "0")
                paso = VehiculoBLL.Guardar(vehiculos);

            else
            {
                if (!ExisteEnLaBaseDatos())
                {
                    MessageBox.Show("No se puede modificar, no existe!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                paso = VehiculoBLL.Modificar(vehiculos);
            }

            if (paso)
            {
                MessageBox.Show("Guardado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se Guardo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            Vehiculos vehiculolocal = VehiculoBLL.Buscar(vehiculos.VehiculoId);

            if (vehiculolocal != null)
            {
                vehiculos = vehiculolocal;
                LLenar();
            }
            else
            {
                LimpiarCampos();
                MessageBox.Show("No Encontrado", "Salir", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (VehiculoBLL.Eliminar(vehiculos.VehiculoId))
            {
                LimpiarCampos();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("No Eliminado", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void nuevoButton_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void LlenaCombo()
        {
            clienteComboBox.ItemsSource = ClienteBLL.GetList(c => true);
            clienteComboBox.DisplayMemberPath = "Nombre";
            clienteComboBox.SelectedValuePath = "PersonaId";
        }

    }
}
