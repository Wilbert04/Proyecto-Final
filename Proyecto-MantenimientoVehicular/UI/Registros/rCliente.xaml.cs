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
    /// Interaction logic for rCliente.xaml
    /// </summary>
    public partial class rCliente : Window
    {
        Clientes clientes = new Clientes();
        public rCliente()
        {
            InitializeComponent();
            this.DataContext = clientes;
        }

        private void LimpiarCampos()
        {
            idTextBox.Text = string.Empty;
            nombreTextBox.Text = string.Empty;
            telefonoTextBox.Text = string.Empty;
            cedulaTextBox.Text = string.Empty;
            direccionTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
        }


        private bool ExisteEnLaBaseDatos()
        {
            Clientes clientes = ClienteBLL.Buscar((int)Convert.ToInt32(idTextBox.Text));
            return (clientes != null);
        }

        private bool ValidarCampos()
        {
            bool paso = false;

           
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text))
            {
                MessageBox.Show("Campo Obligatorio!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(telefonoTextBox.Text))
            {
                MessageBox.Show("Campo Obligatorio!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(cedulaTextBox.Text))
            {
                MessageBox.Show("Campo Obligatorio!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(direccionTextBox.Text))
            {
                MessageBox.Show("Campo Obligatorio!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show("Campo Obligatorio!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            return paso;
        }

        private void Llenar()
        {
            this.DataContext = null;
            this.DataContext = clientes;
        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!ValidarCampos())
                return;

            if (idTextBox.Text == "0")
                paso = ClienteBLL.Guardar(clientes);

            else
            {
                if (!ExisteEnLaBaseDatos())
                {
                    MessageBox.Show("No se puede modificar, no existe!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                paso = ClienteBLL.Modificar(clientes);
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
            Clientes clientelocal = ClienteBLL.Buscar(clientes.ClienteId);

            if (clientelocal != null)
            {
                clientes = clientelocal;
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
            if (ClienteBLL.Eliminar(clientes.ClienteId))
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
