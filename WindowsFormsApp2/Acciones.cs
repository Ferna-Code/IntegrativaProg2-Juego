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
//referencia para poder crear el archivo excel
using ClosedXML.Excel;
//referencia MySql
using MySql.Data.MySqlClient;
//referencias para crear PDF
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class Acciones : Form
    {
        Perfiles perfil = new Perfiles();
        string rut;
        public Acciones(string Rut)
        {
            InitializeComponent();
            perfil.createDataBase();
            this.rut = Rut;
            mostrarAcciones2();
        }

       

        string rutaArchivo = @"C:\TXTS\VIGIAFernandoReyes.TXT";

        //con esta cadena de coneccion estamos trabajando
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=False;Connect Timeout=30";
        static string filePath = @"C:\basesLeones\BDDPROG2_FernandoReyes";
        string conexionMysql = "Server=127.0.0.1; User=root; Database=bddprog2_fernandoreyes;password=''";
        private const string RutaFrecuencia = @"C:\TXTS\FRECUENCIA.TXT";
        static string databaseNameMysql = "bddprog2_fernandoreyes";


        //string de coneccion a la base da datos
        static string connectionDataBase = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=" + filePath + ".mdf;Integrated Security=True;Connect Timeout=30";

        static string databaseName = "BDDPROG2_FernandoReyes";

        //en esta query despues guardamos la sentencia de creacion 
        
        public void pdfFrecuencia()
        {
            //ruta donde se guarda el archivo PDF
            string rutaPdf = @"C:\TXTS\archivo.pdf";
            //creamos el PDF
            Document pdfFrecuencia = new Document();
            //creamos el escritor del PDF
            PdfWriter writer = PdfWriter.GetInstance(pdfFrecuencia, new FileStream(rutaPdf, FileMode.Create));
            //abrimos el documento para trabajar en el
            pdfFrecuencia.Open();
            //leemos el contenido del archivo de texto donde se guarda las frecuencias
            string contenido = File.ReadAllText(RutaFrecuencia);
            //agregamos el contenido 
            pdfFrecuencia.Add(new Paragraph(contenido));
            //cerramos el documento
            pdfFrecuencia.Close();
            //mostramos un mensaje para confirmar la creacion del PDF
            MessageBox.Show("El archivo PDF se ha creado con exito");
        }
        


        public void mostrarAcciones2()
        {
            string usuario = rut;
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
                DataTable datosAcc = new DataTable();
                MySqlDataAdapter sentencia4 = new MySqlDataAdapter("select * from ACCIONESFernandoReyes", conexionMysql);
                sentencia4.Fill(datosAcc);
                dtgAcciones.DataSource = datosAcc;
                dtgAcciones.Columns["num"].HeaderText = "Indice";
                dtgAcciones.Columns["clave"].HeaderText = "R.U.T";
                dtgAcciones.Columns["inicioSesion"].HeaderText = "Inicio de sesion";
                dtgAcciones.Columns["finSesion"].HeaderText = "Fin sesion";
                dtgAcciones.Columns["accion"].HeaderText = "Accion";
                dtgAcciones.Columns["accionF"].HeaderText = "AccionF";
                //Se ajustan las celdas automaticamente
                dtgAcciones.Columns["num"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgAcciones.Columns["accion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgAcciones.Columns["inicioSesion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgAcciones.Columns["finSesion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgAcciones.Columns["accionF"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtgAcciones.Show();
            }
            else
            {
                DataTable datosAcc = new DataTable();
                MySqlDataAdapter sentencia4 = new MySqlDataAdapter("select * from ACCIONESFernandoReyes where clave = '"+ rut +"'", conexionMysql);
                sentencia4.Fill(datosAcc);
                dtgAcciones.DataSource = datosAcc;
                dtgAcciones.Columns["num"].HeaderText = "Indice";
                dtgAcciones.Columns["clave"].HeaderText = "R.U.T";
                dtgAcciones.Columns["inicioSesion"].HeaderText = "Inicio de sesion";
                dtgAcciones.Columns["finSesion"].HeaderText = "Fin sesion";
                dtgAcciones.Columns["accion"].HeaderText = "Accion";
                dtgAcciones.Columns["accionF"].HeaderText = "AccionF";
                //Se ajustan las celdas automaticamente
                dtgAcciones.Columns["num"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgAcciones.Columns["accion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgAcciones.Columns["inicioSesion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgAcciones.Columns["finSesion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgAcciones.Columns["accionF"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtgAcciones.Show();
            }

        }
        
        public void TraspasarTabla()
        {
            string[] swlineas = File.ReadAllLines(rutaArchivo);
            bool result = false;
            List<string> datosTabla = new List<string>();

            foreach (string leerLinea in swlineas)
            {
                string[] lineas = leerLinea.Split(',');
                result = true;

                if (lineas.Length >= 5)
                {
                    // Creamos la sentencia para insertar los datos pedidos a la tabla acciones
                    string query = "INSERT INTO ACCIONESFernandoReyes (clave, inicioSesion, finSesion, accion, accionF) " +
                              "VALUES  ('" + lineas[0] + "', ' " + lineas[1] + "', '" + lineas[2] + "', '" + lineas[3] + "', '" + lineas[4] + "'); ";

                    // MessageBox.Show(query);
                    //Ingresamos los datos a la tabla
                    using (MySqlConnection connection = new MySqlConnection(conexionMysql))
                    {
                        connection.Open();
                        connection.ChangeDatabase(databaseNameMysql);
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {

                            command.ExecuteNonQuery(); // Guardar los cambios
                        }
                    }

                }
                else
                {
                    continue;
                    // La línea no tiene los valores esperados, manejar el error o continuar con el siguiente registro.
                }


            }
            MessageBox.Show("Datos traspasados");
        }

        

        public void TraspasarFrecuencia()
        {
            string[] swlineas = File.ReadAllLines(RutaFrecuencia);
            bool result = false;
            List<string> datosTabla = new List<string>();

            foreach (string leerLinea in swlineas)
            {
                string[] lineas = leerLinea.Split(',');
                result = true;

                if (lineas.Length >= 5)
                {
                    // Creamos la sentencia para insertar los datos pedidos a la tabla acciones
                    string query = "INSERT INTO frecuencia (rut, inicio, rana, olla, fin) " +
                              "VALUES  ('" + lineas[0] + "', ' " + lineas[1] + "', '" + lineas[2] + "', '" + lineas[3] + "', '" + lineas[4] + "'); ";

                    // MessageBox.Show(query);
                    //Ingresamos los datos a la tabla
                    using (MySqlConnection connection = new MySqlConnection(conexionMysql))
                    {
                        connection.Open();
                        connection.ChangeDatabase(databaseNameMysql);
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {

                            command.ExecuteNonQuery(); // Guardar los cambios
                        }
                    }

                }
                else
                {
                    continue;
                    // La línea no tiene los valores esperados, manejar el error o continuar con el siguiente registro.
                }


            }
            MessageBox.Show("Datos traspasados");
        }

        public void mostrarFrecuencias()
        {
            MySqlConnection conex = new MySqlConnection(conexionMysql);
            conex.Open();
            DataTable data = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from frecuencia", conex);
            data.Clear();
            adapter.Fill(data);
            dtgFrecuencia.DataSource = data;
            conex.Close();

            //DataTable datosAcc = new DataTable();
            //SqlDataAdapter sentencia4 = new SqlDataAdapter("select * from ACCIONESFernandoReyes", connectionDataBase);
            //sentencia4.Fill(datosAcc);
            //dtgAcciones.DataSource = datosAcc;
            dtgFrecuencia.Columns["rut"].HeaderText = "RUT";
            dtgFrecuencia.Columns["inicio"].HeaderText = "Inicio sesion";
            dtgFrecuencia.Columns["rana"].HeaderText = "Cantidad de ranas";
            dtgFrecuencia.Columns["olla"].HeaderText = "Cantidad de ollas";
            dtgFrecuencia.Columns["fin"].HeaderText = "Fin sesion";
            
            

        }

        private void btnTraspasar_Click(object sender, EventArgs e)
        {
            TraspasarTabla();
            mostrarAcciones2();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {

            string FechaBuscar = txtBuscarFecha.Text;

            //Creamos la consulta con la cual buscaremos los datos en la tabla
            string consulta = "select * from ACCIONESFernandoReyes where inicioSesion LIKE @Fecha";

            using (MySqlConnection coneccion = new MySqlConnection(conexionMysql))
            {
                coneccion.Open();
                //Creamos el comando en el cual insertaremos la consulta y en donde ralizarla
                using (MySqlCommand comando = new MySqlCommand(consulta, coneccion))
                {
                   
                    comando.Parameters.AddWithValue("@Fecha", "%" + FechaBuscar + "%");//Asignamos el dato al parametro @apellido
                    //Utilizamos el caracter % para indicar que puede haber cualquier cantidad de valores antes y despues de la parte del apellido con el cual vamos a realizar la busqueda
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))//Creamos el adaptador con el cual realizaremos la consulta y obtendremos los resultados
                    {
                        //creamos la tabla y le asignamos los datos encontrados 
                        DataTable resultado = new DataTable();
                        adaptador.Fill(resultado);

                        if (resultado.Rows.Count > 0)
                        {
                            //le asignamos al dataGridView el rogine de datos
                            dtgAcciones.DataSource = resultado;

                            // Crear un nuevo archivo de Excel
                            using (var workbook = new XLWorkbook())
                            {
                                // Agregar una nueva hoja de cálculo al archivo y le asignamos un nombre
                                var worksheet = workbook.Worksheets.Add("DatosAcciones");

                                // Obtener las columnas de la tabla y agregar los encabezados a la hoja de cálculo
                                var columnas = resultado.Columns;
                                for (int i = 0; i < columnas.Count; i++)
                                {
                                    worksheet.Cell(1, i + 1).Value = columnas[i].ColumnName;
                                }

                                // Agregar los datos de la tabla a la hoja de cálculo
                                for (int i = 0; i < resultado.Rows.Count; i++)
                                {
                                    //creamos una variable de tipo var a la cual por cada vuelta del ciclo for le asignado el dato de la tabla
                                    var fila = resultado.Rows[i];
                                    //agregamos los datos al archivo
                                    for (int j = 0; j < columnas.Count; j++)
                                    {
                                        worksheet.Cell(i + 2, j + 1).Value = fila[j].ToString();
                                    }
                                }

                                // Guardar el archivo de Excel
                                var saveFileDialog = new SaveFileDialog();
                                /*creamos una nueva instancia para guardar los archivos, la variable saveFileDialog nos permite
                                 acceder y manipular las propiedades y metodos del cuadro de dialogo*/

                                saveFileDialog.Filter = "Muy bien, guardaste el archivo|*.xlsx";
                                /*establecemos el filtro de archivos del cuadro de dialogo, en este caso se configura para que solo muestre archivos
                                 con la extencion .xlsx*/

                                saveFileDialog.Title = "Guardar archivo de Excel";
                                /*Establecemos el titulo del cuadro de dialogo*/
                                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    workbook.SaveAs(saveFileDialog.FileName);
                                    MessageBox.Show("Archivo de Excel creado exitosamente.");
                                }

                            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            TraspasarFrecuencia();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mostrarFrecuencias();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pdfFrecuencia();
        }
    }
}
