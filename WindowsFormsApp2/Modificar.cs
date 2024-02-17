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

namespace WindowsFormsApp2
{
    public partial class Modificar : Form
    {
        public Modificar()
        {
            InitializeComponent();
        }

        public void crearClave()
        {
            DataTable clave = new DataTable();
            string actualizacion = "UPDATE PERFILESFernandoReyes " +
                                   "SET clave = SUBSTRING(nombre, 1, 1) + SUBSTRING(apPat, 1, 1) + SUBSTRING(apMat, 1, 1) + REPLACE(rut, '-', '')";

            SqlDataAdapter codigo = new SqlDataAdapter(actualizacion, connectionString);
            clave.Clear();
            codigo.Fill(clave);

            // return clave;
        }

        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=False;Connect Timeout=30";
        SqlConnection coneccion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=False;Connect Timeout=30");


        private void button1_Click(object sender, EventArgs e)
        {
            string nivel = txtNuevoNivel.Text;
            if (txtNuevoRut.Text == "" || txtNuevoNombre.Text == "" || txtNuevoPaterno.Text == ""||txtNuevoMaterno.Text == ""||txtNuevoNivel.Text == "")
            {
                MessageBox.Show("Ingrese todos los datos");
            }
            else if (Int32.Parse(txtNuevoNivel.Text) > 2)
            {
                MessageBox.Show("Solo estan disponibles los niveles 1 y 2");
            }
            else
            {
                coneccion.Open();
                //primero verificamos si se encuentra el rut al cual vamos a modificar los datos dentro de la base de datos
                string verificarDato = "SELECT COUNT(*) FROM PERFILESFernandoReyes WHERE rut = @Dato";
                SqlCommand verifyCommand = new SqlCommand(verificarDato, coneccion);
                verifyCommand.Parameters.AddWithValue("@Dato", txtRutPk.Text);

                int count = (int)verifyCommand.ExecuteScalar();
                //si el rut se encuentra dentro de la base de datos procedemos a actualizar el dato solicitado
                if (count > 0)
                {
                    string sentencia = "UPDATE PERFILESFernandoReyes SET rut = '" + txtNuevoRut.Text + "', nombre = '" + txtNuevoNombre.Text + "', ApPat = '"+ txtNuevoPaterno.Text +"', ApMat = '"+ txtNuevoMaterno.Text +"', Nivel = '"+ txtNuevoNivel.Text +"' WHERE rut = '" + txtRutPk.Text + "'";

                    // Crear el comando SQL
                    SqlCommand update = new SqlCommand(sentencia, coneccion);

                    // Ejecutar la actualizacion del dato
                    update.ExecuteNonQuery();
                    Perfiles perfil = new Perfiles();

                    DataTable informacion2 = new DataTable();
                    SqlDataAdapter senten = new SqlDataAdapter("select * from Salud", connectionString);
                    //llenamos la tabla datos con la informacion de la base de datos
                    senten.Fill(informacion2);
                    perfil.dtgMostrar.DataSource = informacion2;

                    // Muestra un mensaje si el dato es actualizado con exito
                    MessageBox.Show("Actualización exitosa.");
                }
                //si no se encuentra mostramos un mensaje de error para que no se cauga el programa
                else
                {
                    MessageBox.Show("El dato no se encuentra en la base de datos.");
                }
            }

            crearClave();
        }
    }
}
