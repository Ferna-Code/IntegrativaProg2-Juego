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

namespace WindowsFormsApp2
{
    public partial class Recuperar : Form
    {
        public Recuperar()
        {
            InitializeComponent();
        }

        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=False;Connect Timeout=30";
        string conexionMysql = "Server=127.0.0.1; User=root; Database=bddprog2_fernandoreyes;password=''";


        private void button1_Click(object sender, EventArgs e)
        {
            string rutClave = txtBuscarClave.Text;

            string consulta = "select * from PERFILESFernandoReyes where rut = @dato";
            MySqlConnection coneccion = new MySqlConnection(conexionMysql);
            MySqlCommand comando = new MySqlCommand(consulta, coneccion);
            comando.Parameters.AddWithValue("@dato", rutClave);

            coneccion.Open();
            //ejecutamos la consulta
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())//si encuentra el dato
            {
                string infoClave = $"Clave: {reader["Clave"]}";
                string informacion = $"RUT: {reader["rut"]}\nNombre: {reader["nombre"]}\nApellido paterno: {reader["ApPat"]}\nApellido materno: {reader["ApMat"]}\nClave: {reader["Clave"]}\nNivel de usuario: {reader["Nivel"]}";
               // MessageBox.Show(infoClave);
                MessageBox.Show(informacion);
            }
            else
            {
                MessageBox.Show("No se encontro el RUT ingresado");
            }

            reader.Close();
            coneccion.Close();
        }
    }
}
