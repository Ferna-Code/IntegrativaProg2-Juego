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
    public partial class registrarPerfil : Form
    {
        public registrarPerfil()
        {
            InitializeComponent();
        }

        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=False;Connect Timeout=30";
        string conexionMysql = "Server=127.0.0.1; User=root; Database=bddprog2_fernandoreyes;password=''";


        public void insertarDatos(string rut, string nombre, string paterno, string materno, int nivel)
        {
            DataTable datos = new DataTable();
            string sentencia2 = "insert into PERFILESFernandoReyes(rut,nombre,ApPat,ApMat,Nivel) values" +
                "('" + rut + "','" + nombre + "','" + paterno + "','" + materno + "'," + nivel + ")";

            MySqlDataAdapter codigo = new MySqlDataAdapter(sentencia2, conexionMysql);
            datos.Clear();
            codigo.Fill(datos);
            MessageBox.Show("Datos agregados con exito");

           // return datos;
        }

        Perfiles perfil = new Perfiles();
        private void button1_Click(object sender, EventArgs e)
        {

            if (txtRegistroRut.Text == "" || txtRegistroNombre.Text == "" || txtRegistroApat.Text == "" || txtRegistroAmat.Text == "")
            {
                MessageBox.Show("Ingrese todos los datos para continuar");
            }
            else
            {
                //primero verificamos si se encuentra el rut al cual vamos a modificar los datos dentro de la base de datos
                string verificarDato = "SELECT COUNT(*) FROM PERFILESFernandoReyes WHERE rut = @Dato";
                MySqlConnection myConn = new MySqlConnection(conexionMysql);
                myConn.Open();
                MySqlCommand verifyCommand = new MySqlCommand(verificarDato, myConn);
                verifyCommand.Parameters.AddWithValue("@Dato", txtRegistroRut.Text);


                //int count = (int)verifyCommand.ExecuteScalar();
                int count = Convert.ToInt32(verifyCommand.ExecuteScalar());
                //si el rut se encuentra dentro de la base de datos procedemos a actualizar el dato solicitado
                if (count > 0)
                {
                    MessageBox.Show("Este RUT ya se encuentra registrado \nIntente con otro");
                }
                //si no se encuentra mostramos un mensaje de error para que no se cauga el programa
                else
                {
                    //Al agregar los datos el nivel de usuario por defecto seria 2
                    insertarDatos(txtRegistroRut.Text, txtRegistroNombre.Text, txtRegistroApat.Text, txtRegistroAmat.Text, 2);
                    perfil.crearClave();
                }
                myConn.Close();
            }

            
           
        }
    }
}
