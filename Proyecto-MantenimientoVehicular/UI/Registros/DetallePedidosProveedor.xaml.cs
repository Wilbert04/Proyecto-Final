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
    /// Interaction logic for DetallePedidosProveedor.xaml
    /// </summary>
    public partial class DetallePedidosProveedor : Window
    {
        PedidosProveedor Pedidos = new PedidosProveedor();

        public DetallePedidosProveedor()
        {
            InitializeComponent();
            this.DataContext = Pedidos;
        }

        private void Limpiar()
        {
            IdTextbox.Text = "0";
            ProveedorCombobox.Text = string.Empty;
            ArticuloTextbox.Text = string.Empty;
            CantidadTextbox.Text = "0";

        }

        private bool ExisteEnBaseDatos()
        {
            PedidosProveedor pedidosProveedores = PedidosProveedorBLL.Buscar(Convert.ToInt32(IdTextbox.Text));
            return (pedidosProveedores != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(ProveedorCombobox.Text))
            {
                MessageBox.Show("No se puede dejar campos vacios!!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            return paso;

        }

        private void Llenar()
        {
            this.DataContext = null;
            this.DataContext = Pedidos;

        }

        private void Button_Nuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();

        }

        private void Button_Guardar(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            if (IdTextbox.Text == "0")
            {
                 paso = PedidosProveedorBLL.Guardar(Pedidos);
            }
            else
            {
                if (!ExisteEnBaseDatos())
                {
                    MessageBox.Show("Pedido Proveedor No Existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                paso = PedidosProveedorBLL.Modificar(Pedidos);
            }

            if (paso)
            {
                MessageBox.Show("¡¡Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("¡¡No se pudo Guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Button_Eliminar(object sender, RoutedEventArgs e)
        {
            if (PedidosProveedorBLL.Eliminar(Pedidos.PedidoId))
            {
                Limpiar();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No Eliminado!!");
            }
        }

        private void Button_Buscar(object sender, RoutedEventArgs e)
        {
            PedidosProveedor pedidosProveedor = PedidosProveedorBLL.Buscar(Pedidos.PedidoId);

            if (pedidosProveedor != null)
            {
                Pedidos = pedidosProveedor;
                Llenar();

            }
            else
            {
                Limpiar();
                MessageBox.Show("Llamada no Encontrada!!");
            }
        }
          
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pedidos.DPedidos.Add(new DetallePedidos (Pedidos.PedidoId, Convert.ToInt32(IdTextbox.Text), Convert.ToInt32(ArticuloTextbox.Text), Convert.ToDecimal( CantidadTextbox.Text)));
            Llenar();
                        
            ArticuloTextbox.Clear();
            CantidadTextbox.Clear();
        }

        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Columns.Count > 0 && DataGrid.SelectedCells != null)
            {
                Pedidos.DPedidos.RemoveAt(DataGrid.SelectedIndex);
                Llenar();
            }
        }
    }
}
