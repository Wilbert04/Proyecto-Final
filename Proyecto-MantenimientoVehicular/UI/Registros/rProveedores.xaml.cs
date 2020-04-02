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
    /// Interaction logic for rProveedores.xaml
    /// </summary>
    public partial class rProveedores : Window
    {
        Proveedores proveedores = new Proveedores();
        public rProveedores()
        {
            InitializeComponent();
            IdTextBox.Text = "0";

            this.DataContext = proveedores;

        }

        private void LimpiarCampos()
        {
            IdTextBox.Text = "0";

            nombreTextBox1.Text = string.Empty;
            telefonoTextBox1.Text = string.Empty;
            provinciaTextBox1.Text = string.Empty;
            ciudadTextBox1.Text = string.Empty;
            calleTextBox1.Text = string.Empty;
            fechaDatePicker.SelectedDate = DateTime.Now;
        }

        private bool ExisteEnLaBaseDatos()
        {
            Proveedores proveedores = ProveedoresBLL.Buscar((int)Convert.ToInt32(IdTextBox.Text));
            return (proveedores != null);
        }


        private bool ValidarCampos()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(nombreTextBox1.Text))
            {
                MessageBox.Show("Este Campo es Obligatorio");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(telefonoTextBox1.Text))
            {
                MessageBox.Show("Este Campo es Obligatorio");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(provinciaTextBox1.Text))
            {
                MessageBox.Show("Este Campo es Obligatorio");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ciudadTextBox1.Text))
            {
                MessageBox.Show("Este Campo es Obligatorio");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(calleTextBox1.Text))
            {
                MessageBox.Show("Este Campo es Obligatorio");
                paso = false;
            }

            return paso;
        }

        private void Llenar()
        {
            this.DataContext = null;
            this.DataContext = proveedores;
        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!ValidarCampos())
                return;

            if (IdTextBox.Text == "0")
                paso = ProveedoresBLL.Guardar(proveedores);

            else
            {
                if (!ExisteEnLaBaseDatos())
                {
                    MessageBox.Show("No se puede modificar, no existe!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                paso = ProveedoresBLL.Modificar(proveedores);
            }

            if (paso)
            {
                MessageBox.Show("Guardado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se Guardo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proveedores proveedorlocal = ProveedoresBLL.Buscar(proveedores.ProveedorId);

            if (proveedorlocal != null)
            {
                proveedores = proveedorlocal;
                Llenar();
            }
            else
            {
                LimpiarCampos();
                MessageBox.Show("No Encontrado", "Salir", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void nuevoButton_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProveedoresBLL.Eliminar(proveedores.ProveedorId))
            {
                LimpiarCampos();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("No Eliminado", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
