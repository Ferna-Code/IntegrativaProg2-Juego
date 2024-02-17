using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class Menu : Form
    {
        private string Rut;
        public Menu(string Rut)
        {
            InitializeComponent();
            this.Rut = Rut;
        }

        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=False;Connect Timeout=30";
        private const string RutaArchivo = @"C:\TXTS\VIGIAFernandoReyes.TXT";
        string conexionMysql = "Server=127.0.0.1; User=root; Database=bddprog2_fernandoreyes;password=''";


        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = Rut;
            string nivelUsuario = "";

            string consulta = "SELECT Nivel FROM PERFILESFernandoReyes WHERE rut = @Usuario";
            using (MySqlConnection conexion = new MySqlConnection(conexionMysql))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Usuario", usuario);
                    nivelUsuario = comando.ExecuteScalar()?.ToString();
                    // En resumen, esta línea de código ejecuta una consulta SQL 
                    //utilizando el comando definido en comando y asigna el resultado a la variable nivelUsuario
                }
            }

            // Verificar el nivel del usuario y permitir el acceso al formulario si es igual a 1
            if (nivelUsuario == "1")
            {
                // Permitir el acceso al formulario
                Perfiles perfiles = new Perfiles();
                perfiles.Show();
            }
            else
            {
                // Mostrar un mensaje de error o redirigir a otra página
                MessageBox.Show("No tienes permisos para acceder a este formulario.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Acciones accion = new Acciones(Rut);
            accion.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Mostramos todo los registros
            MostrarTodo mostrar = new MostrarTodo();
            string[] registro = File.ReadAllLines(RutaArchivo);

            if (registro.Length == 0)
            {
                MessageBox.Show("No hay datos");
            }
            else
            {
                mostrar.label1.Text = "";
                foreach (string indice in registro)
                {
                    string[] datos = indice.Split(',');
                    foreach(string todo in datos)
                    {
                        mostrar.label1.Text += todo + "\n";
                    }
                    mostrar.label1.Text += "\n";
                   
                }
                mostrar.Show();
            }
        }

        //buscar por rut
        private void button4_Click(object sender, EventArgs e)
        {
            if (txtMostrarRut.Text == "")
            {
                MessageBox.Show("Ingrese un R.U.T a buscar");
            }
            else
            {
                // Buscamos el RUT solicitado 
                string[] ruta = File.ReadAllLines(RutaArchivo);
                BuscarRut buscar = new BuscarRut();
                string rutB = txtMostrarRut.Text;
                buscar.label1.Text = "";
                bool encontrado = false;

                foreach (string indice in ruta)
                {
                    string[] datos = indice.Split(',');

                    if (datos[0].Trim() == rutB.Trim())
                    {
                        encontrado = true;

                        foreach (string dato in datos)
                        {
                            buscar.label1.Text += dato + "\n";
                        }

                        buscar.Show();
                    }
                }

                if (!encontrado)
                {
                    MessageBox.Show("Dato no encontrado");
                }
            }
        }
    }
}
