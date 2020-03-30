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
    /// Interaction logic for rArticulo.xaml
    /// </summary>
    public partial class rArticulo : Window
    {
        Articulos articulos = new Articulos();
        public rArticulo()
        {
            InitializeComponent();
            LlenaCombo();
            ListaEntrada();
            idTextBox.Text = "0";


            this.DataContext = articulos;
        }


        private void ListaEntrada()
        {
            List<EntradaArticulos> entradaArticulos = EntradaArticuloBLL.GetList(a => true);
            this.DataContext = entradaArticulos;
        }

        private void LlenaCombo()
        {
            descripcionComboBox.ItemsSource = EntradaArticuloBLL.GetList(a => true);
            descripcionComboBox.DisplayMemberPath = "Descripcion";
            descripcionComboBox.SelectedValuePath = "EntradaArticuloId";

        }


        private void LimpiarCampos()
        {
            idTextBox.Text = string.Empty;
            
            cantidadTextBox.Text = string.Empty;
            precioTextBox.Text = string.Empty;
            existenciaTextBox.Text = string.Empty;
            fechaDatePicker.SelectedDate = DateTime.Now;
        }

        private bool ExisteEnLaBaseDatos()
        {
            Articulos articulos = ArticuloBLL.Buscar((int)Convert.ToInt32(idTextBox.Text));
            return (articulos != null);
        }


        private bool ValidarCampos()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(descripcionComboBox.Text))
            {
                MessageBox.Show("Campo Obligatorio!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(cantidadTextBox.Text))
            {
                MessageBox.Show("Campo Obligatorio!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(precioTextBox.Text))
            {
                MessageBox.Show("Campo Obligatorio!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(existenciaTextBox.Text))
            {
                MessageBox.Show("Campo Obligatorio!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }



            return paso;
        }

        private void Llenar()
        {
            this.DataContext = null;
            this.DataContext = articulos;
        }

        private void guardrButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!ValidarCampos())
                return;

            if (idTextBox.Text == "0")
                paso = ArticuloBLL.Guardar(articulos);

            else
            {
                if (!ExisteEnLaBaseDatos())
                {
                    MessageBox.Show("No se puede modificar, no existe!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                paso = ArticuloBLL.Modificar(articulos);
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
            Articulos articulolocal = ArticuloBLL.Buscar(articulos.ArticuloId);

            if (articulolocal != null)
            {
                articulos = articulolocal;
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
            if (ArticuloBLL.Eliminar(articulos.ArticuloId))
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
