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
        }

        private void LimpiarCampos()
        {
            idTextBox.Text = "0";
            nombreTextBox.Text = string.Empty;
            telefonoTextBox.Text = string.Empty;
            provinciaTextBox.Text = string.Empty;
            ciudadTextBox.Text = string.Empty;
            calleTextBox.Text = string.Empty;
            fechaDatePicker.SelectedDate = DateTime.Now;
        }


        private bool ExisteEnLaBaseDatos()
        {
            Proveedores proveedores = ProveedoresBLL.Buscar((int)Convert.ToInt32(idTextBox.Text));
            return (proveedores != null);
        }

        private bool ValidarCampos()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(nombreTextBox.Text))
            {
                MessageBox.Show("Este Campo es Obligatorio");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(telefonoTextBox.Text))
            {
                MessageBox.Show("Este Campo es Obligatorio");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(provinciaTextBox.Text))
            {
                MessageBox.Show("Este Campo es Obligatorio");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ciudadTextBox.Text))
            {
                MessageBox.Show("Este Campo es Obligatorio");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(calleTextBox.Text))
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

            if (idTextBox.Text == "0")
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
            }
            else
            {
                MessageBox.Show("No se Guardo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proveedores proveedorlocal = ProveedoresBLL.Buscar(proveedores.ProveedoresId);

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

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProveedoresBLL.Eliminar(proveedores.ProveedoresId))
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

    }
}
