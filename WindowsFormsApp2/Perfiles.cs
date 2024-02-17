using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class Perfiles : Form
    {
        
        public Perfiles()
        {
            InitializeComponent();
            createDataBase();
            crearTablas();
            //alterTable();
            //agregarDatos();
            //mostrarPerfiles();
            dtgMostrar.RowHeadersVisible = false;
            

        }

        string rutaArchivo = @"C:\TXTS\VIGIAFernandoReyes.TXT";

        //con esta cadena de coneccion estamos trabajando
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=False;Connect Timeout=30";
        static string filePath = @"C:\basesLeones\BDDPROG2_FernandoReyes";
        SqlConnection coneccion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=False;Connect Timeout=30");

        string conexionMysql = "Server=127.0.0.1; User=root; Database=bddprog2_fernandoreyes;password=''";
        static string databaseNameMysql = "bddprog2_fernandoreyes";
        static string filePathMysql = @"C:\xampp\mysql\data\bddprog2_fernandoreyes";
        MySqlConnection coneccionMysql = new MySqlConnection("Server=127.0.0.1; User=root; Database=bddprog2_fernandoreyes;password=''");


        //string de coneccion a la base da datos
        static string connectionDataBase = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=" + filePath + ".mdf;Integrated Security=True;Connect Timeout=30";

        static string databaseName = "BDDPROG2_FernandoReyes";

        //en esta query despues guardamos la sentencia de creacion 
        string query = "";

        

        public bool DatabaseExists(MySqlConnection connection, string databaseName)
        {
            string query = $"SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '{databaseName}';";

            using (var command = new MySqlCommand(query, connection))
            {
                //connection.Open();
                var result = command.ExecuteScalar();
                //connection.Close();

                return (result != null && result.ToString().Equals(databaseName, StringComparison.OrdinalIgnoreCase));
            }
        }

        //Metodo para crear la base de datos con las tablas, update y insert correspondientes
        public void createDataBase()
        {
            query = "CREATE DATABASE " + databaseNameMysql + " ON PRIMARY " +
          "(NAME = MyDatabase_Data, " +
           "FILENAME = '" + filePathMysql + ".mdf', " +
          "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)" +
          "LOG ON (NAME = MyDatabase_Log, " +
          "FILENAME = '" + filePathMysql + ".ldf', " +
          "SIZE = 1MB, " +
          "MAXSIZE = 5MB, " +
          "FILEGROWTH = 10%)";

            MySqlConnection conex = new MySqlConnection(conexionMysql);
            conex.Open();

            //comparamos los nombres de las bases de datos con las ya existentes

            if (File.Exists(filePathMysql + ".mdf"))
            {
                MessageBox.Show($"El archivo '{filePathMysql}' existe.");
            }
            else
            {
                MySqlCommand myCommand = new MySqlCommand(query, conex);
                if (!DatabaseExists(conex, databaseNameMysql))
                {
                    //el execute no me acuerdo para que era xD
                    myCommand.ExecuteNonQuery();
                    crearTablas();
                    alterTable();
                    agregarDatos();

                    MessageBox.Show("Base de datos creada");
                }
            }

        }



        // ejecuta las inserciones o modificaciones
        public object ExecuteScalarQuery(string query)
        {
            object result = null;

            using (MySqlConnection connection = new MySqlConnection(conexionMysql))
            {
                connection.Open();
                connection.ChangeDatabase(databaseNameMysql);

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    result = command.ExecuteScalar();
                }
            }

            return result;
        }

        //Creamos las tablas dentro de la base de datos pero antes comprobamos si es que ya existen
        public void crearTablas()
        {
            //Recorremos la carpeta de origen buscando si es que hay alguna base de datos creada con el mismo nombre
            string checkTableQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PERFILESFernandoReyes'";
            object result = ExecuteScalarQuery(checkTableQuery);
            int tableCount = Convert.ToInt32(result);

            //si el conteo de la busqueda da igual a 0 osea no existe ninguna base de datos con el mismo nombre
            if (tableCount == 0)
            {
                //creamos la base de datos por medio de una sentencia
                string createTableQuery = "CREATE TABLE PERFILESFernandoReyes (rut VARCHAR(10) PRIMARY KEY, nombre VARCHAR(30) NOT NULL, apPat VARCHAR(30) NOT NULL, apMat VARCHAR(30) NOT NULL, clave VARCHAR(13) NOT NULL DEFAULT '');";
                ExecuteQuery(createTableQuery);
            }

            string checkTableQuery2 = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ACCIONESFernandoReyes'";
            object result2 = ExecuteScalarQuery(checkTableQuery2);
            int tableCount2 = Convert.ToInt32(result2);

            if (tableCount2 == 0)
            {
                string createTableQuery2 = "create table ACCIONESFernandoReyes(num int(3) primary key AUTO_INCREMENT,clave varchar(13) null, inicioSesion varchar(255) not null,finSesion varchar(255) not null,accion varchar(255) not null,accionF varchar(255) not null); ";
                ExecuteQuery(createTableQuery2);
            }

            string checkTableQuery3 = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'frecuencia'";
            object result3 = ExecuteScalarQuery(checkTableQuery3);
            int tableCount3 = Convert.ToInt32(result3);

            if (tableCount3 == 0)
            {
                string createTableQuery2 = "create table frecuencia(rut varchar(10)not null,inicio varchar(50)not null, rana varchar(50)not null,olla varchar(50)not null,fin varchar(50)not null); ";
                ExecuteQuery(createTableQuery2);
            }
        }

        //Agregamos el campo Nivel a la tabla Perfiles
        public void alterTable()
        {
            string query = "Alter table PERFILESFernandoReyes add Nivel int not null default 1;";
            ExecuteQuery(query);

        }

       

        //ingresamos los datos a la tabla Perfiles
        public void agregarDatos()
        {
            string query =
                "INSERT INTO PERFILESFernandoReyes (rut, nombre, apPat, apMat, Nivel)" +
                "VALUES ('11111111-1','Fernando','Reyes','Luengo',1);" +
                "INSERT INTO PERFILESFernandoReyes (rut, nombre, apPat, apMat, Nivel)" +
                "VALUES ('22222222-2','Juan','perez','cotapos',2);";

            ExecuteQuery(query);
        }


        public void ExecuteQuery(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(conexionMysql))
            {
                connection.Open();
                connection.ChangeDatabase(databaseNameMysql);

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        //insertamos datos a la tabla Perfiles
        public DataTable insertarDatos(string rut, string nombre, string paterno, string materno, int nivel)
        {
            DataTable datos = new DataTable();
            string sentencia2 = "insert into PERFILESFernandoReyes(rut,nombre,ApPat,ApMat,Nivel) values" +
                "('" + rut + "','" + nombre + "','" + paterno + "','" + materno + "'," + nivel + ")";

            MySqlDataAdapter codigo = new MySqlDataAdapter(sentencia2, conexionMysql);
            datos.Clear();
            codigo.Fill(datos);
            MessageBox.Show("Datos agregados con exito");

            return datos;
        }

        //creamos la clave tomando las primeras letras de nombre,ApPat,ApMat y el rut sin guion 
        public void crearClave()
        {
            DataTable clave = new DataTable();
            string actualizacion = "UPDATE PERFILESFernandoReyes " +
                                   "SET clave = CONCAT(LEFT(nombre, 1), LEFT(ApPat, 1), LEFT(ApMat, 1), REPLACE(rut, '-', ''));";

            MySqlDataAdapter codigo = new MySqlDataAdapter(actualizacion, conexionMysql);
            clave.Clear();
            codigo.Fill(clave);

           // return clave;
        }

        //Mostramos la tabla Perfiles en el dataGridView
        public void mostrarPerfiles()
        {
            DataTable datos = new DataTable();
            MySqlDataAdapter sentencia = new MySqlDataAdapter("select * from PERFILESFernandoReyes", conexionMysql);
            sentencia.Fill(datos);
            dtgMostrar.DataSource = datos;
            //Modifico el ancho de la celda segun la informacion
            //dtgMostrar.Columns["Nivel"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgMostrar.Show();
           
        }

        //Metodo para buscar datos segun el apellido y muestra los datos en un dataGrid
        private DataTable BuscarApellido(string apellido)
        {
            DataTable buscar = new DataTable();
            string buscador = "SELECT * FROM PERFILESFernandoReyes WHERE apPat = '" + apellido + "'";
            MySqlDataAdapter buscando = new MySqlDataAdapter(buscador, conexionMysql);
            buscando.Fill(buscar);

            return buscar;
        }

        //Metodo para borrar un registo de la tabla perfiles segun la clave
        private DataTable EliminarClave(string clave)
        {
            DataTable eliminemos = new DataTable();
            string eliminador = "DELETE FROM PERFILESFernandoReyes WHERE clave = '" + clave + "'";
            MySqlDataAdapter eliminado = new MySqlDataAdapter(eliminador, conexionMysql);
            eliminado.Fill(eliminemos);

            return eliminemos;
        }

        //Metodo para traspasar la informacion del archivo .txt a la tabla Acciones
        

        //Agregamos a la tabla Acciones los registros del archivo .txt segun el rut
       
        //Verificamos si existe una tabla en especifico
        private void sp_help_Click(object sender, EventArgs e)
        {
            string tableName = "ACCIONESFernandoReyes";
            string spName = "sp_help";

            using (MySqlConnection connection = new MySqlConnection(conexionMysql))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(spName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@objname", tableName);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Aquí puedes procesar los datos devueltos por el procedimiento almacenado
                            // Puedes mostrarlos en un MessageBox, asignarlos a un DataGridView, etc.
                            string columnValue = reader.GetString(0);

                            MessageBox.Show(columnValue);
                        }
                    }
                }

                connection.Close();
            }
        }


        double suma = 0;
        double div = 0.0;
        int numPost = 0;
        double resta = 0.0;
        double paso1 = 0.0;
        double paso2 = 0.0;
        public bool cerrar = false;//booleano para cerrar Form1
        string Rut;

        double result = 0;
        char digitoVerificador = 'K';
        int[] resultados = new int[8];
        int[] numeros = new int[] { 3, 2, 7, 6, 5, 4, 3, 2 };

        //Botones


        private void MostrarPerfiles_Click(object sender, EventArgs e)
        {
            mostrarPerfiles();
            crearClave();
        }

        private void mostrarActualizados()
        {
            //guardamos los nuevos datos en variables para hacer mas facil su uso
            string rutBuscado = txtNuevoRut.Text;
            string nombreBuscado = txtNuevoNombre.Text;
            string paternoBuscado = txtNuevoPaterno.Text;
            string maternoBuscado = txtNuevoMaterno.Text;
            string nivelBuscado = txtNuevoNivel.Text;

            //se crea la consuta SQL para buscar los datos
            string consulta = "SELECT * FROM PERFILESFernandoReyes WHERE nombre = @Nombre and rut = @Rut and ApPat = @Paterno and ApMat = @Materno and Nivel = @nivel";

            using (MySqlConnection conexion = new MySqlConnection(conexionMysql))
            {
                //abrimos la conexion
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    //asignamos a cada parametro de la busqueda su valor
                    comando.Parameters.AddWithValue("@Nombre", nombreBuscado);
                    comando.Parameters.AddWithValue("@Rut", rutBuscado);
                    comando.Parameters.AddWithValue("@Paterno", paternoBuscado);
                    comando.Parameters.AddWithValue("@Materno", maternoBuscado);
                    comando.Parameters.AddWithValue("@nivel", nivelBuscado);

                    //ejecutamos la consulta
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Si se encontró el dato en la tabla
                            string nombreActualizado = reader["nombre"].ToString();
                            string rutActualizado = reader["rut"].ToString();
                            string paternoActualizado = reader["ApPat"].ToString();
                            string maternoActualizado = reader["ApMat"].ToString();
                            string nivelActualizado = reader["Nivel"].ToString();

                            //asignamos los nuevos valores a los textBox
                            txtNombreModificado.Text = nombreActualizado;
                            txtRutModificado.Text = rutActualizado;
                            txtPaternoModificado.Text = paternoActualizado;
                            txtMaternoModificado.Text = maternoActualizado;
                            txtNivelModificado.Text = nivelActualizado;
                        }
                        else
                        {
                            
                            // Si no se encontró el dato en la tabla le asignamos el valor null como defecto
                            txtNombreModificado.Text = "NULL";
                            txtRutModificado.Text = "NULL";
                            txtPaternoModificado.Text = "NULL";
                            txtMaternoModificado.Text = "NULL";
                            txtNivelModificado.Text = "NULL";
                        }
                    }
                }
            }
        }


        private void agregarPerfil_Click(object sender, EventArgs e)
        {

            


            if (txtRut.Text == "" || txtNombre.Text == "" || txtPaterno.Text == "" || txtMaterno.Text == "" || txtNivel.Text == "")
            {
                MessageBox.Show("Datos incorrectos \nIntente otra vez");
            }
            else if (Int32.Parse(txtNivel.Text) > 2)
            {
                MessageBox.Show(" Se encuentran disponible solo los niveles 1 y 2 \nIntente de nuevo");

            }
            else
            {
                string rut = txtRut.Text;
                bool validacion = false;

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

                    coneccionMysql.Open();
                    //primero verificamos si se encuentra el rut al cual vamos a modificar los datos dentro de la base de datos
                    string verificarDato = "SELECT COUNT(*) FROM PERFILESFernandoReyes WHERE rut = @Dato";
                    MySqlCommand verifyCommand = new MySqlCommand(verificarDato, coneccionMysql);
                    verifyCommand.Parameters.AddWithValue("@Dato", txtRut.Text);

                    int count = Convert.ToInt32(verifyCommand.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("El RUT ingresado ya se encuentra registrado");
                    }
                    else
                    {
                        suma = 0;
                        result = 0;
                        digitoVerificador = '0';



                        //comprobamos el largo del rut
                        for (int i = rut.Length; i < 10; i++)
                        {
                            rut = 0 + rut;
                        }

                        for (int i = 0; i < numeros.Length; i++)
                        {
                            resultados[i] = numeros[i] * Int32.Parse(rut[i].ToString());
                            suma += resultados[i];
                        }



                        div = suma / 11.0;
                        numPost = Convert.ToInt32(Math.Floor(div));
                        resta = div - numPost;
                        paso1 = (11 * resta);
                        paso2 = 11 - paso1;
                        result = Math.Round(paso2, 1);

                        //Asignamos digito segun resultado

                        if (result == 10)
                        {
                            digitoVerificador = 'K';
                        }
                        else if (result == 11)
                        {
                            digitoVerificador = '0';
                        }
                        else
                        {
                            string dv = result.ToString();
                            char dgv = Convert.ToChar(dv);
                            digitoVerificador = dgv;
                        }
                        if (rut[0] == 'k' || rut[0] == 'K' ||
                           rut[1] == 'k' || rut[1] == 'K' ||
                           rut[2] == 'k' || rut[2] == 'K' ||
                           rut[3] == 'k' || rut[3] == 'K' ||
                           rut[4] == 'k' || rut[4] == 'K' ||
                           rut[5] == 'k' || rut[5] == 'K' ||
                           rut[6] == 'k' || rut[6] == 'K' ||
                           rut[7] == 'k' || rut[7] == 'K')
                        {
                            MessageBox.Show("Rut Invalido");
                            Form1 form = new Form1();
                            form.txtRut.Text = "";
                            form.txtRut.Focus();

                        }
                        if (result.ToString() != rut[9].ToString() || rut[8] != '-')
                        {
                            MessageBox.Show("rut ingresado incorrecto, intente denuevo");
                        }
                        else
                        {
                            MessageBox.Show("Rut correcto \n" + rut.ToString());
                            Rut = rut;
                            insertarDatos(txtRut.Text, txtNombre.Text, txtPaterno.Text, txtMaterno.Text, Int32.Parse(txtNivel.Text));
                            crearClave();
                            mostrarPerfiles();
                            txtRut.Clear();
                            txtNombre.Clear();
                            txtPaterno.Clear();
                            txtMaterno.Clear();
                            txtNivel.Clear();
                            txtRut.Focus();
                        }
                    }

                    coneccionMysql.Close();
                }

               
            }
        }

        private void buscarApellido_Click(object sender, EventArgs e)
        {
            DataTable busco = BuscarApellido(txtBuscar.Text);
            dtgMostrar.DataSource = busco;
            
            dtgMostrar.Show();
        }

        private void eliminarClave_Click(object sender, EventArgs e)
        {
            EliminarClave(txtEliminar.Text);
            mostrarPerfiles();
        }

        

       
        //Actualizamos las datos de un registro de la tabla segun su rut
        private void button1_Click_1(object sender, EventArgs e)
        {
            //int nivel = Int32.Parse(txtNuevoNivel.Text);
            if (txtNuevoRut.Text == "" || txtNuevoNombre.Text == "" || txtNuevoPaterno.Text == "" || txtNuevoMaterno.Text == "" || txtNuevoNivel.Text == "")
            {
                MessageBox.Show("Ingrese todos los datos");
            }
            else if (Int32.Parse(txtNuevoNivel.Text) > 2)
            {
                MessageBox.Show("Solo estan disponibles los niveles 1 y 2");
            }
            else
            {
                
                coneccionMysql.Open();
                //primero verificamos si se encuentra el rut al cual vamos a modificar los datos dentro de la base de datos
                string verificarDato = "SELECT COUNT(*) FROM PERFILESFernandoReyes WHERE rut = @Dato";
                MySqlCommand verifyCommand = new MySqlCommand(verificarDato, coneccionMysql);
                verifyCommand.Parameters.AddWithValue("@Dato", txtRutPk.Text);

                int count = Convert.ToInt32(verifyCommand.ExecuteScalar());
                
                //si el rut se encuentra dentro de la base de datos procedemos a actualizar el dato solicitado
                if (count > 0)
                {
                    string sentencia = "UPDATE PERFILESFernandoReyes SET rut = '" + txtNuevoRut.Text + "', nombre = '" + txtNuevoNombre.Text + "', ApPat = '" + txtNuevoPaterno.Text + "', ApMat = '" + txtNuevoMaterno.Text + "', Nivel = '" + txtNuevoNivel.Text + "' WHERE rut = '" + txtRutPk.Text + "'";

                    // Crear el comando SQL
                    MySqlCommand update = new MySqlCommand(sentencia, coneccionMysql);

                    // Ejecutar la actualizacion del dato
                    update.ExecuteNonQuery();
                    Perfiles perfil = new Perfiles();

                    DataTable informacion2 = new DataTable();
                    MySqlDataAdapter senten = new MySqlDataAdapter("select * from perfilesfernandoreyes", conexionMysql);
                    //llenamos la tabla datos con la informacion de la base de datos
                    senten.Fill(informacion2);
                    perfil.dtgMostrar.DataSource = informacion2;
                    mostrarActualizados();

                    // Muestra un mensaje si el dato es actualizado con exito
                    MessageBox.Show("Actualización exitosa.");
                }
                //si no se encuentra mostramos un mensaje de error para que no se carga el programa
                else
                {
                    MessageBox.Show("El dato no se encuentra en la base de datos.");
                }
                coneccionMysql.Close();
            }
            //Actualizamos la clave del registro
            crearClave();
            //Actualizamos el dataGrid con los nuevos datos
            mostrarPerfiles();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string claveBuscar = txtClaveB.Text;
            string parteApellido = txtParteApat.Text;

            //Creamos la consulta con la cual buscaremos los datos en la tabla
            string consulta = "select * from PERFILESFernandoReyes where Clave = @clave and ApPat LIKE @apellido";

            using (MySqlConnection coneccion = new MySqlConnection(conexionMysql))
            {
                coneccion.Open();
                //Creamos el comando en el cual insertaremos la consulta y en donde ralizarla
                using(MySqlCommand comando = new MySqlCommand(consulta, coneccion))
                {
                    comando.Parameters.AddWithValue("@clave", claveBuscar);//le asignamos el dato al parametro @clave
                    comando.Parameters.AddWithValue("@apellido", "%" + parteApellido + "%");//Asignamos el dato al parametro @apellido
                    //Utilizamos el caracter % para indicar que puede haber cualquier cantidad de valores antes y despues de la parte del apellido con el cual vamos a realizar la busqueda
                    using(MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))//Creamos el adaptador con el cual realizaremos la consulta y obtendremos los resultados
                    {
                        //creamos la tabla y le asignamos los datos encontrados 
                        DataTable resultado = new DataTable();
                        adaptador.Fill(resultado);

                        if(resultado.Rows.Count > 0)
                        {
                            //le asignamos al dataGridView el rogine de datos
                            dtgMostrar.DataSource = resultado;
                        }
                        else
                        {
                            //si no se encuentran resultados similares en la tabla
                            MessageBox.Show("No se encontrados datos");
                        }
                    }
                }
            }
            

        }
    }
}
