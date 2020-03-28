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
            this.DataContext = proveedores;
        }

        private void Limpiar()
        {
            IdTextbox.Text = "0";
            NombreTextbox.Text = string.Empty;
            TelefonoTextbox.Text = string.Empty;
            ProvinciaTextbox.Text = string.Empty;
            CiudadTextbox.Text = string.Empty;
            CalleTextbox.Text = string.Empty;
            FechaPicker.SelectedDate = DateTime.Now;
        }

        private bool ExisteEnBaseDato()
        {
            Proveedores proveedor = ProveedoresBLL.Buscar(Convert.ToInt32(IdTextbox.Text));
            return (proveedor != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(NombreTextbox.Text))
            {
                MessageBox.Show("No se puede deja el campo NOMBRE vacìo", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            if (String.IsNullOrWhiteSpace(TelefonoTextbox.Text))
            {
                MessageBox.Show("No se puede deja el campo TELEFONO vacìo", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            if (String.IsNullOrWhiteSpace(CiudadTextbox.Text))
            {
                MessageBox.Show("No se puede deja el campo CUIDAD vacìo", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            if (String.IsNullOrWhiteSpace(ProvinciaTextbox.Text))
            {
                MessageBox.Show("No se puede deja el campo PROVINCIA vacìo", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            if (String.IsNullOrWhiteSpace(CalleTextbox.Text))
            {
                MessageBox.Show("No se puede deja el campo CALLE vacìo", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            return paso;
        }

        private void LLenar()
        {
            this.DataContext = null;
            this.DataContext = proveedores;
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

            if(IdTextbox.Text == "0")
            {
                paso = ProveedoresBLL.Guardar(proveedores);
            }
            else
            {
                if (!ExisteEnBaseDato())
                {
                    MessageBox.Show("No se puede modificar un proveedor que no exista", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                paso = ProveedoresBLL.Modificar(proveedores);
                MessageBox.Show("Proveedor modificar!!!");
            }

            if (paso)
            {
                MessageBox.Show("Guardado correctamente!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar!!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void Button_Eliminar(object sender, RoutedEventArgs e)
        {
            if (ProveedoresBLL.Eliminar(proveedores.ProveedoresId))
            {
                Limpiar();
                MessageBox.Show("El proveedor a sido eliminado!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo Eliminar!!");
            }
        }

        private void Buscar(object sender, RoutedEventArgs e)
        {
            Proveedores proveedor = ProveedoresBLL.Buscar(proveedores.ProveedoresId);

            if (proveedor != null)
            {
                proveedores = proveedor;
                MessageBox.Show("Proveedor encontrado!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
                LLenar();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
