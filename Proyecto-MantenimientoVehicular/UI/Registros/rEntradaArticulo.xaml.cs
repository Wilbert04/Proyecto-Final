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
    /// Interaction logic for rEntradaArticulo.xaml
    /// </summary>
    public partial class rEntradaArticulo : Window
    {
        EntradaArticulos entradaArticulos = new EntradaArticulos();

        public rEntradaArticulo()
        {
            InitializeComponent();
            this.DataContext = entradaArticulos;
        }

        private void LimpiarCampos()
        {
            IdTextbox.Text = string.Empty;
            descripcionTextBox.Text = string.Empty;
            CantidadTextbox.Text = string.Empty;
            FechaPicker.SelectedDate = DateTime.Now;
        }


        private bool ExisteEnLaBaseDatos()
        {
            EntradaArticulos entradaArticulos = EntradaArticuloBLL.Buscar((int)Convert.ToInt32(IdTextbox.Text));
            return (entradaArticulos != null);
        }


        private bool ValidarCampos()
        {
            bool paso = true;

           

            if (string.IsNullOrWhiteSpace(descripcionTextBox.Text))
            {
                MessageBox.Show("Campo Obligatorio!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CantidadTextbox.Text))
            {
                MessageBox.Show("Campo Obligatorio!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

           



            return paso;
        }

        private void Llenar()
        {
            this.DataContext = null;
            this.DataContext = entradaArticulos;
        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {

            bool paso = false;

            if (!ValidarCampos())
                return;

            if (IdTextbox.Text == "0")
                paso = EntradaArticuloBLL.Guardar(entradaArticulos);

            else
            {
                if (!ExisteEnLaBaseDatos())
                {
                    MessageBox.Show("No se puede modificar, no existe!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                paso = EntradaArticuloBLL.Modificar(entradaArticulos);
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
            EntradaArticulos entradalocal = EntradaArticuloBLL.Buscar(entradaArticulos.EntradaArticuloId);

            if (entradalocal != null)
            {
                entradaArticulos = entradalocal;
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
            if (EntradaArticuloBLL.Eliminar(entradaArticulos.EntradaArticuloId))
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
