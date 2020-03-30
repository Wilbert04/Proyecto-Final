using Proyecto_MantenimientoVehicular.BLL;
using Proyecto_MantenimientoVehicular.DAL;
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
    /// Interaction logic for rMantenimiento.xaml
    /// </summary>
    public partial class rMantenimiento : Window
    {
        Mantenimiento mantenimiento = new Mantenimiento();
        public rMantenimiento()
        {
            InitializeComponent();
            ProximoMantenimiento();
            LlenaComboBox();


            List<string> cliente = new List<string>
            {
                "Julio","Martin","Pedro","Guillen"
            };
            this.clienteComboBox.ItemsSource = cliente;

            List<string> Vehiculo = new List<string>
            {
                "Nissan Frotier","Toyota Hilux","Hyundai Tucson"
            };
            this.vehiculoComboBox.ItemsSource = Vehiculo;

            //List<string> articulo = new List<string>
            //{
            //    "Neumarico","Filtro/Aire","Correa"
            //};
            //this.articuloComboBox.ItemsSource = articulo;


            ProximoMantenimiento();
            idTextBox1.Text = "0";
            this.DataContext = mantenimiento;
        }

        private void LimpiarCampos()
        {
            clienteComboBox.Text = string.Empty;
            descripcionTextBox.Text = string.Empty;
            vehiculoComboBox.Text = string.Empty;
            articuloComboBox.Text = string.Empty;
            cantidadTextBox.Text = string.Empty;
            precioTextBox.Text = "0";
            importeTextBox1.Text = "0";
            subtotalTextBox.Text = "0";
            itebisTextBox.Text = "0";
            totalTextBox.Text = "0";
            fechaDatePicker.SelectedDate = DateTime.Now;
            proxmantDatePicker.SelectedDate = DateTime.Now;
                
        }



        private void ProximoMantenimiento()
        {

            DateTime ProximoMant = fechaDatePicker.DisplayDate;

            proxmantDatePicker.SelectedDate = ProximoMant.AddMonths(3);
        }


        private bool ExisteEnBaseDatos()
        {
            Mantenimiento mantenimiento = MantenimientoBLL.Buscar((int)Convert.ToInt32(idTextBox1.Text));
            return (mantenimiento != null);

        }


        private bool ValidarCampos()
        {
            bool paso = false;


            if (string.IsNullOrWhiteSpace(clienteComboBox.Text))
            {
                MessageBox.Show("Debe elegir un Cliente", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(descripcionTextBox.Text))
            {
                MessageBox.Show("Este campo es Obligatorio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(vehiculoComboBox.Text))
            {
                MessageBox.Show("Campo Obligatorio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(descripcionTextBox.Text))
            {
                MessageBox.Show("Campo Obligatorio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(descripcionTextBox.Text))
            {
                MessageBox.Show("Campo Obligatorio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            return paso;
        }


        private void Llenar()
        {
            this.DataContext = null;
            this.DataContext = mantenimiento;
        }

        private void guadarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!ValidarCampos())
                return;

            if (idTextBox1.Text == "0")
                paso = MantenimientoBLL.Guardar(mantenimiento);

            else
            {
                if (!ExisteEnBaseDatos())
                {
                    MessageBox.Show("Llmada No Existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                paso = MantenimientoBLL.Modificar(mantenimiento);
            }

            if (paso)
            {
                MessageBox.Show("¡¡Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("¡¡No Guardado!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            Mantenimiento mantenimientolocal = MantenimientoBLL.Buscar(mantenimiento.MantenimientoId);

            if (mantenimientolocal != null)
            {
                mantenimiento = mantenimientolocal;
                Llenar();

            }
            else
            {
                LimpiarCampos();
                MessageBox.Show("Llamada no Encontrada!!");


            }
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (MantenimientoBLL.Eliminar(mantenimiento.MantenimientoId))
            {
                LimpiarCampos();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No Eliminado!!");
            }
        }

        private void removerButton_Click(object sender, RoutedEventArgs e)
        {
            if (detalleDataGrid.Columns.Count > 0 && detalleDataGrid.SelectedCells != null)
            {
                mantenimiento.DMantenimiento.RemoveAt(detalleDataGrid.SelectedIndex);
                Llenar();
            }
        }

        private void agregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (cantidadTextBox.Text == "0")
            {
                MessageBox.Show("Debe elegir una Cantidad!!", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {


                mantenimiento.DMantenimiento.Add(new DetalleMantenimiento(
                    mantenimiento.MantenimientoId, Convert.ToInt32(idTextBox1.Text),
                   articuloComboBox.Text, descripcionTextBox.Text, Convert.ToDecimal(cantidadTextBox.Text), Convert.ToDecimal(precioTextBox.Text),
                   Convert.ToDecimal(importeTextBox1.Text)));
                Llenar();

                articuloComboBox.Text = " ";
                descripcionTextBox.Text = " ";
                cantidadTextBox.Clear();
                precioTextBox.Clear();
                importeTextBox1.Clear();

            }

        }


        private void LlenaComboBox()
        {
            ArticuloBLL articulos = new ArticuloBLL();
            //ClienteBLL cliente = new ClienteBLL();
            //VehiculoBLL vehiculos = new VehiculoBLL();

            articuloComboBox.ItemsSource = ArticuloBLL.GetList(a => true);
            articuloComboBox.DisplayMemberPath = "Descripcion";
            articuloComboBox.SelectedValuePath = "Descripcion";

            //vehiculoComboBox.ItemsSource = VehiculoBLL.GetList(t => true);
            //vehiculoComboBox.DisplayMemberPath = "VehiculoId";
            //vehiculoComboBox.SelectedValuePath = "Descripcion";

            //clienteComboBox.ItemsSource = ClienteBLL.GetList(v => true);
            //clienteComboBox.DisplayMemberPath = "ClienteId";
            //clienteComboBox.SelectedValuePath = "Nombre";


        }

        private void articuloComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Articulos articulos = (Articulos)articuloComboBox.SelectedItem;
            precioTextBox.Text = Convert.ToString(articulos.Precio);
        }

        private void cantidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcularImporte();
            CalcularItbis();
            CalcularTotal();
            CalcularSubtotal();
        }

        private void CalcularImporte()      //   Calculo de Importe
        {
            if (cantidadTextBox.Text != "0")
            {
                importeTextBox1.Text = Convert.ToString(ArticuloBLL.CalcularImporte(Convert.ToDecimal(cantidadTextBox.Text), Convert.ToDecimal(precioTextBox.Text)));
            }
            else
                importeTextBox1.Text = "0";
        }

        private void CalcularItbis()
        {
            {
                itebisTextBox.Text = Convert.ToString(ArticuloBLL.CalcularItbis(Convert.ToDecimal(subtotalTextBox.Text)));
            }
        }

        private void CalcularSubtotal()
        {
            if (importeTextBox1.Text != "0")
            {
                subtotalTextBox.Text = Convert.ToString(ArticuloBLL.CalcularSubtotal(Convert.ToDecimal(importeTextBox1.Text)));
            }
        }

        private void CalcularTotal()
        {
            if (subtotalTextBox.Text != "0"  && itebisTextBox.Text != "0")
            {
                totalTextBox.Text = Convert.ToString(ArticuloBLL.CalcularTotal(Convert.ToDecimal(subtotalTextBox.Text), Convert.ToDecimal(itebisTextBox.Text)));
            }
        }

        private void Total()
        {
            List<DetalleMantenimiento> detalles = (List<DetalleMantenimiento>)detalleDataGrid.ItemsSource;

            decimal Total = 0;
            //decimal Itebis;

            //Itebis = 0.18M;

            foreach (var item in detalles)
            {
                Total += item.Importe;
            }

            //TotalnumericUpDown.Value;
        }


    }
}
