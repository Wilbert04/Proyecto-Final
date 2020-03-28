using Proyecto_MantenimientoVehicular.BLL;
using Proyecto_MantenimientoVehicular.Entidades;
using Proyecto_MantenimientoVehicular.UI.Menu;
using Proyecto_MantenimientoVehicular.UI.Registros;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Proyecto_MantenimientoVehicular
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (usuarioTextBox.Text == "Admin" && contraseñaPasswordBox.Password == "Admin")
            {
                wMenu menuprimcipal = new wMenu();
                menuprimcipal.ShowDialog();
                this.Close();
            }

            //IniciarSesion();

        }

        public void IniciarSesion()
        {

            Expression<Func<Usuarios, bool>> filtro = x => true;
            List<Usuarios> usuario = new List<Usuarios>();

            var username = usuarioTextBox.Text;
            var password = contraseñaPasswordBox.Password;
            filtro = x => x.Usuario.Equals(username);
            usuario = UsuarioBLL.GetList(filtro);



            if (usuario.Exists(x => x.Usuario.Equals(username)))
            {
                if (usuario.Exists(x => x.Contraseña.Equals((password))))
                {
                    List<Usuarios> id = UsuarioBLL.GetList(U => U.Usuario == usuarioTextBox.Text);
                    wMenu menuprincipal = new wMenu();
                    menuprincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nombre de usuarios o contraseñas incorrectos");
                    return;
                }
            }
            else
            {
                if (usuarioTextBox.Text == string.Empty || contraseñaPasswordBox.Password == string.Empty)
                    MessageBox.Show("LLene todos los campos");
                else if (!usuario.Exists(x => x.Usuario.Equals(username)))
                    MessageBox.Show("Nombre de usuarios o contraseñas incorrectos");

            }
        }

        private void salirButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}     
       


