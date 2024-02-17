using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Musica musica = new Musica();
        public Form1()
        {
            InitializeComponent();           
            this.CenterToScreen();
        }

        static string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=false;Connect Timeout=30";
        string conexionMysql = "Server=127.0.0.1; User=root; Database=bddprog2_fernandoreyes;password=''";

        //aca debes poner la ruta y el nombre de la base de datos, no se por que pero asi es la wea
        static string filePath = @"C:\basesLeones\BDDPROGFernandoReyes";

        //string de coneccion a la base da datos
        static string connectionDataBase = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=" + filePath + ".mdf;Integrated Security=True;Connect Timeout=30";


        //--------------------------------------------------//
        public string rut;
        DateTime fecha = DateTime.Now;
        ValidarRut validar = new ValidarRut();

        CLASEEVALUA2FernandoReyes clase = new CLASEEVALUA2FernandoReyes();

       

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            musica.sonidoRut();

        }

        private void txtRut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 00 && e.KeyChar <= 07) || (e.KeyChar >= 09 && e.KeyChar <= 31) ||
                (e.KeyChar >= 33 && e.KeyChar <= 44) || (e.KeyChar >= 46 && e.KeyChar <= 47) ||
                (e.KeyChar >= 58 && e.KeyChar <= 74) || (e.KeyChar >= 76 && e.KeyChar <= 106) ||
                (e.KeyChar >= 108 && e.KeyChar <= 126) || (e.KeyChar >= 128 && e.KeyChar <= 255))
            {
                MessageBox.Show("Ingrese solo numeros,'-','K','k' ");
                e.Handled = true;
            }          
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Instrucciones intruccion = new Instrucciones();
            intruccion.Show();
        }

        private void btnCreditos_Click(object sender, EventArgs e)
        {
            Creditos credito = new Creditos();
            credito.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            rut = txtRut.Text;
            bool validacion = false;

            if (txtRut.Text == "" || txtClave.Text == "")
            {
                MessageBox.Show("Ingrese todos los datos para continuar");
            }

            else
            {
                for (int i = 0; i < 8; i++)
                {
                    if (rut[i] == 'K' || rut[i] == 'k')
                    {
                        validacion = true;

                    }
                }
                if (validacion)
                {
                    MessageBox.Show("rut invalido");
                }
                else
                {
                    

                    //primero verificamos si se encuentra el rut al cual vamos a modificar los datos dentro de la base de datos
                    string verificarDato = "SELECT COUNT(*) FROM PERFILESFernandoReyes WHERE rut = @Dato and Clave = @Dclave" ;
                    MySqlConnection myConn = new MySqlConnection(conexionMysql);
                    myConn.Open();
                    MySqlCommand verifyCommand = new MySqlCommand(verificarDato, myConn);
                    verifyCommand.Parameters.AddWithValue("@Dato", txtRut.Text);
                    verifyCommand.Parameters.AddWithValue("@Dclave", txtClave.Text);

                    //int count = (int)verifyCommand.ExecuteScalar();
                    int count = Convert.ToInt32(verifyCommand.ExecuteScalar());
                    //si el rut se encuentra dentro de la base de datos procedemos a actualizar el dato solicitado
                    if (count > 0)
                    {
                        validar.validadorRut(rut);
                    }
                    //si no se encuentra mostramos un mensaje de error para que no se cauga el programa
                    else
                    {
                        NoRut noRut = new NoRut();
                        noRut.Show();
                    }
                }
            }
            if (validar.cerrar == true)//cierra el Form1
            {

                this.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            registrarPerfil registrar = new registrarPerfil();
            registrar.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recuperar recup = new Recuperar();
            recup.Show();
        }
    }
}
