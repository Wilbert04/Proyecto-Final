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
            ListaCliente();
            ListaVehiculo();
            idTextBox1.Text = "0";

            List<string> servicios = new List<string>
            {
                "Limpieza y ajuste de frenos","Ajuste de freno de estacionamiento","Rotación y balanceo de ruedas","Alineamiento de ruedas",
                "Afinamiento de motor", "Lubricación y engrase general","Limpieza y ajuste de frenos","Ajuste de freno de estacionamiento",
                "Cambio de Aceite de Transmision CVT y Filtro","Cambio de Aceite de Transmision Automatica y Filtro","Cambio de Filtro de Gasolina",
                "Cambio de Bujías","Limpieza de Inyectores"
            };
            this.serviciosComboBox.ItemsSource = servicios;


            this.DataContext = mantenimiento;
        }

        private void ProximoMantenimiento()
        {

            proxmantDatePicker.DisplayDate = Convert.ToDateTime(fechaDatePicker.SelectedDate).AddMonths(3);

        }


        private void LimpiarCampos()
        {
            clienteComboBox.Text = " ";
            descripcionTextBox.Text = string.Empty;
            vehiculoComboBox.Text = " ";
            articuloComboBox.Text = " ";
            serviciosComboBox.Text = " ";
            cantidadTextBox.Text = "0";
            disponibleTextBox.Text = "0";
            precioTextBox.Text = "0";
            importeTextBox1.Text = "0";
            
            itebisTextBox.Text = "0";
            totalTextBox.Text = "0";
            fechaDatePicker.SelectedDate = DateTime.Now;
            proxmantDatePicker.SelectedDate = DateTime.Now;
            detalleDataGrid.ItemsSource = string.Empty;

        }


        private bool ExisteEnLaBaseDatos()
        {
            Mantenimiento mantenimiento = MantenimientoBLL.Buscar((int)Convert.ToInt32(idTextBox1.Text));
            return (mantenimiento != null);
        }

        private bool ValidarCampos()
        {
            bool paso = true;


            if (string.IsNullOrWhiteSpace(clienteComboBox.Text))
            {
                MessageBox.Show("Debe elegir un Cliente", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            //if (string.IsNullOrWhiteSpace(descripcionTextBox.Text))
            //{
            //    MessageBox.Show("Este campo es Obligatorio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            //    paso = false;
            //}

            //if (string.IsNullOrWhiteSpace(vehiculoComboBox.Text))
            //{
            //    MessageBox.Show("Campo Obligatorio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            //    paso = false;
            //}

            return paso;
        }

            private void Llenar()
        {
            this.DataContext = null;
            this.DataContext = mantenimiento;
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
                MessageBox.Show("No Encontrado", "Salir", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (MantenimientoBLL.Eliminar(mantenimiento.MantenimientoId))
            {
                LimpiarCampos();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("No Eliminado", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
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


            if (disponibleTextBox.Text == "0.0")
            {
                MessageBox.Show("¡¡Articulo Agotado!!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }


            if (cantidadTextBox.Text == "0")
            {
                MessageBox.Show("Debe elegir una Cantidad!!", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }

            else
            {

                mantenimiento.DMantenimiento.Add(new DetalleMantenimiento(
                id: 0,
                mantenimientoId: Convert.ToInt32(idTextBox1.Text),
                articuloId: Convert.ToInt32(articuloComboBox.SelectedValue),
                descripcion: descripcionTextBox.Text,
                cantidad: Convert.ToInt32(cantidadTextBox.Text),
                precio: Convert.ToDecimal(precioTextBox.Text),
                importe: Convert.ToDecimal(importeTextBox1.Text)


                    ));
                Llenar();

                articuloComboBox.Text = " ";
                disponibleTextBox.Text = "0";
                cantidadTextBox.Text = "0";
                precioTextBox.Text = "0";
                

            }

        }

        private void LlenaComboBox()
        {
            ArticuloBLL articulos = new ArticuloBLL();
            ClienteBLL cliente = new ClienteBLL();
            VehiculoBLL vehiculos = new VehiculoBLL();

            articuloComboBox.ItemsSource = ArticuloBLL.GetList(a => true);
            articuloComboBox.DisplayMemberPath = "Articulo";
            articuloComboBox.SelectedValuePath = "ArticuloId";

            vehiculoComboBox.ItemsSource = VehiculoBLL.GetList(t => true);
            vehiculoComboBox.DisplayMemberPath = "Descripcion";
            vehiculoComboBox.SelectedValuePath = "VehiculoId";

            clienteComboBox.ItemsSource = ClienteBLL.GetList(v => true);
            clienteComboBox.DisplayMemberPath = "Nombre";
            clienteComboBox.SelectedValuePath = "ClienteId";


        }

        private void ListaCliente()       //Lista para llenar ComboBox Cliente
        {
            List<Clientes> listacliente = ClienteBLL.GetList(a => true);
            this.DataContext = listacliente;
        }

        private void ListaVehiculo()     //Lista para llenar ComboBox Vehiculo
        {
            List<Clientes> listavehiculo = ClienteBLL.GetList(a => true);
            this.DataContext = listavehiculo;
        }

        private void articuloComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Articulos buscarArt = articuloComboBox.SelectedItem as Articulos;

            if (buscarArt != null)
            {
                precioTextBox.Text = Convert.ToString(buscarArt.Precio);
                disponibleTextBox.Text = Convert.ToString(buscarArt.Existencia);
            }
        }

        private decimal ToDecimal(object valor)
        {
            decimal retorno = 0;
            decimal.TryParse(valor.ToString(), out retorno);

            return Convert.ToDecimal(retorno);
        }

        private void cantidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cantidadTextBox.Text != string.Empty)
            {
                CalcularImporte();
                CalcularSubtotal();
                CalcularItbis();
                CalcularTotal();

            }
        }


        private void CalcularImporte()      //   Calculo de Importe
        {

            ArticuloBLL BLL = new ArticuloBLL();

            decimal cantidad, precio;
            cantidad = ToDecimal(cantidadTextBox.Text);
            precio = ToDecimal(precioTextBox.Text);
            importeTextBox1.Text = ArticuloBLL.CalcularImporte(cantidad, precio).ToString("0.##");


        }

        private void CalcularSubtotal()   // Calculo de Subtotal
        {
            ArticuloBLL bll = new ArticuloBLL();

            decimal importe = ToDecimal(importeTextBox1.Text);

            subtotal2TextBox.Text = ArticuloBLL.CalcularSubtotal(importe).ToString("0.##");

        }

        private void CalcularItbis()          // Calculo de Itebis
        {

            decimal subtotal = ToDecimal(subtotal2TextBox.Text);

            itebisTextBox.Text = ArticuloBLL.CalcularItbis(subtotal).ToString("0.##");
        }

        private void CalcularTotal()           // Calculo de Total
        {
            decimal subtotal, itbis;
            subtotal = ToDecimal(subtotal2TextBox.Text);
            itbis = ToDecimal(itebisTextBox.Text);

            totalTextBox.Text = ArticuloBLL.CalcularTotal(subtotal, itbis).ToString("0.##");

        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {

            bool paso = false;

            if (!ValidarCampos())
                return;

            


            if (idTextBox1.Text == "0")
                paso = MantenimientoBLL.Guardar(mantenimiento);

            else
            {
                if (!ExisteEnLaBaseDatos())
                {
                    MessageBox.Show("No se puede modificar, no existe!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                paso = MantenimientoBLL.Modificar(mantenimiento);
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

        private void nuevoButton_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void agregararticuloButton_Click(object sender, RoutedEventArgs e)
        {
            rArticulo registro = new rArticulo();
            registro.ShowDialog(); 
        }
    }
}
