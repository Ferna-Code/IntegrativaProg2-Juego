using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

//Proporciona propiedades y métodos de instancia para crear,
//copiar, eliminar, mover y abrir archivos y contribuye a la creación de objetos FileStream.

namespace WindowsFormsApp2
{

    public partial class Juego : Form
    {
        private const string RutaArchivo = @"C:\TXTS\VIGIAFernandoReyes.TXT";
        
        //asignamos el numero de filas y columnas
        public const int filaMatriz = 5;
        public const int columnaMatriz = 3;
        //creamos la matriz con los botones
        Button[,] picture = new Button[filaMatriz, columnaMatriz];
        //metodo random
        private Random random = new Random();
        //Guardamos la ubicacion de la imagen por defecto 
        Image image = Properties.Resources.iconoHoja;
        //arreglo que contiene la lista de imagenes
        string[] imageList;
        //asignamos el metodo random a la lista de imagenes
        string randomImage;
        //contador puntaje
        public int acumulador = 0;
        public int puntuacion = 0;
        //llamamos a la clase que contiene los audios
        Musica musica = new Musica();
        //largo del arreglo textBox 
        int largoVida = 4;
        //boleano para cambiar el color de los txtVida
        public bool cambiarColor = true;
        //variable donde se guarda el rut del usurio
        private string Rut;

        //iniciamos el contructor del Form entregandole una variable de tipo STRING  la cual 
        //contiene el rut del usuario el cual es recibido desde la clase ValidarRut
        public Juego(string Rut)
        {
            InitializeComponent();
            this.Rut = Rut;
            
            //centramos el forms en la pantalla
            this.CenterToScreen();

            //calculamos la posicion del primer picturebox
            int start_x = (this.ClientSize.Width - (3 * 100)) / 2;
            int start_y = (this.ClientSize.Height - (5 * 95)) / 2;

            //asignamos el color por defecto de los txtVida
            txtVida1.BackColor = Color.Red;
            txtVida2.BackColor = Color.Red;
            txtVida3.BackColor = Color.Red;
            txtVida4.BackColor = Color.Red;
            txtVida5.BackColor = Color.Red;
            //iniciamos la puntacion en 0
            txtPuntuacion.Text = "0";
            //creamos la matriz con los botones y sus atributos
            for (int fila = 0; fila < 5; fila++)
            {
                for (int columna = 0; columna < 3; columna++)
                {
                    //se crean los botones y se les asignan las imagenes por defecto
                    Button pictureBox = new Button();
                    pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
                    pictureBox.BackgroundImage = image;

                    pictureBox.Anchor = AnchorStyles.None;//desancla el picture

                    //dimensiones botonos
                    pictureBox.Width = 100;
                    pictureBox.Height = 100;

                    //ubicacion de los botones en el form
                    pictureBox.Top = start_y + (fila * 100);
                    pictureBox.Left = start_x + (columna * 100);

                    //establecemos el FlatStyle y el color de fondo de los botones
                    //el FlatFtyle Obtiene o establece la apariencia de estilo plano del control de botón.
                    pictureBox.FlatStyle = FlatStyle.Flat;
                    pictureBox.BackColor = Color.Transparent;
                    pictureBox.FlatAppearance.BorderSize = 0;//cambiamos el ancho de los bordes

                    this.Controls.Add(pictureBox);//agregamos los botones en el for
                    picture[fila, columna] = pictureBox;//asignamos las imagenes a la matriz


                    //asigna un evento click al boton
                    pictureBox.Click += new EventHandler(Form1_Load);
                    //pictureBox.Click += new EventHandler(Boton_Click);


                }
            }
        }

        int salioRana = 0;
        int salioOlla = 0;
        

        private DateTime fecha = DateTime.Now;
        
        List<CLASEEVALUA2FernandoReyes> lista = new List<CLASEEVALUA2FernandoReyes>();
        CLASEEVALUA2FernandoReyes clase = new CLASEEVALUA2FernandoReyes();
        private void Form1_Load(object sender, EventArgs e)
        {
           
            
            Button button = (Button)sender;
            TextBox[] vida = new TextBox[5] { txtVida1, txtVida2, txtVida3, txtVida4, txtVida5 };
            Form1 principal = new Form1();
            //rut = principal.txtRut.Text;
            clase.GetSetRut = Rut;
            clase.GetSetInicio = fecha;

            lista.Add(new CLASEEVALUA2FernandoReyes(this.Rut, this.fecha, fecha, clase.GetSetAccion, fecha));

            for (int fila = 0; fila < 5; fila++)
            {
                for (int columna = 0; columna < 3; columna++)
                {

                    //guardamos la ubicacion de las imagenes en una variable de tipo string
                    string imageFolder = Application.StartupPath + @"\Imagenes";

                    //en la variable imageList guardamos el contenido del directorio guardado en la variable 
                    //imageFolder mientra que la extencion de estos sean .jpg, .jpeg, .png, .gif
                    //GetFiles devuelve un objeto File correspondiente al archivo en una ruta de acceso especificada.
                    imageList = Directory.GetFiles(imageFolder)
                                                  .Where(file => file.EndsWith(".jpg") ||
                                                                 file.EndsWith(".jpeg") ||
                                                                 file.EndsWith(".png") ||
                                                                 file.EndsWith(".gif"))
                                                  .ToArray();
                    randomImage = imageList[random.Next(imageList.Length)];//creamos una lista random con las imagenes 

                    button.BackgroundImageLayout = ImageLayout.Zoom;//determinamos las proporciones de la imagen dentro del boton
                    button.BackgroundImage = Image.FromFile(randomImage);//asignamos las imagenes a los botones



                    //LISTO NO TOCAR
                    for (int a = 0; a < 5; a++)
                    {


                        for (int o = 0; o < 3; o++)
                        {
                            //si la imagen del boton es ranaSatanica
                            if (Path.GetFileName(randomImage) == "ranaSatanica.jpg")
                            {
                                acumulador++;
                                puntuacion++;
                                txtPuntuacion.Text = acumulador.ToString();
                                lblPuntaje.Text = puntuacion.ToString();
                                salioRana += 1;

                                clase.GetSetAccion = "Encontro rana";
                                clase.GetSeAccionF = fecha;

                                lista.Add(new CLASEEVALUA2FernandoReyes(this.Rut, this.fecha, fecha, clase.GetSetAccion, fecha));


                                //verificamos si es la ultima imagen de la matriz
                                if (acumulador == 5)
                                {

                                    Ganaste ganar = new Ganaste();
                                    ganar.Show();
                                    ganar.label2.Text = "Tu puntaje fue de: " + acumulador.ToString();
                                    acumulador = 0;//reiniciamos contador
                                    txtPuntuacion.Text = acumulador.ToString();
                                    puntuacion = 0;
                                    largoVida = 4;//reiniciamos el largo de la variable
                                    lblPuntaje.Text = puntuacion.ToString();

                                    //Agregamos a la lista que el jugador gano la partida y a la hora que gano
                                    clase.GetSetAccion = "Partida ganada";
                                    clase.GetSeAccionF = fecha;

                                    lista.Add(new CLASEEVALUA2FernandoReyes(this.Rut, this.fecha, fecha, clase.GetSetAccion, fecha));

                                    //le volvemos a asignar el color rojo a los txtVida 
                                    for (int i = 0; i < 5; i++)
                                    {
                                        vida[i].BackColor = Color.Red;
                                    }


                                    for (int f = 0; f < 5; f++)
                                    {

                                        for (int c = 0; c < 3; c++)
                                        {
                                            //le volvemos a asignar la imagen por defecto a los botones
                                            picture[f, c].BackgroundImage = image;

                                        }
                                    }

                                }



                            }//verificamos si la imagen se llama "ollaHirviendo.png"
                            else if (Path.GetFileName(randomImage) == "ollaHirviendo.png")
                            {


                                acumulador = 0;//reiniciamos contador
                                txtPuntuacion.Text = acumulador.ToString();

                                clase.GetSetAccion = "Salio olla";
                                clase.GetSeAccionF = fecha;
                                salioOlla += 1;
                            
                                lista.Add(new CLASEEVALUA2FernandoReyes(this.Rut, this.fecha, fecha, clase.GetSetAccion, fecha));

                               
                                cambiarColor = false;
                                if (cambiarColor == false)
                                {
                                    vida[largoVida].BackColor = Color.White;//cambiamos el color de txtVida
                                    largoVida--;//disminuimos en 1 el la variable largoVida
                                }

                                //Cada ves que sale olla la matriz se reinicia 
                                for (int f = 0; f < 5; f++)
                                {

                                    for (int c = 0; c < 3; c++)
                                    {
                                        cambiarColor = true;
                                        //le volvemos a asignar la imagen por defecto a los botones
                                        picture[f, c].BackgroundImage = image;

                                    }
                                }

                                if (largoVida == -1)
                                {
                                    Form2 perder = new Form2();
                                    perder.Show();

                                    clase.GetSetAccion = "Perdio partida con un puntaje de " + puntuacion.ToString();
                                    clase.GetSeAccionF = fecha;
                                    
                                    lista.Add(new CLASEEVALUA2FernandoReyes(this.Rut, this.fecha, fecha, clase.GetSetAccion, fecha));
                                   

                                    if (puntuacion == 0)
                                    {
                                        perder.label2.Text = "Tu puntaje fue de " + puntuacion.ToString() + "\nPatetico";
                                        puntuacion = 0;
                                        lblPuntaje.Text = puntuacion.ToString();
                                    }
                                    else if (puntuacion >= 1 && puntuacion <= 5)
                                    {
                                        perder.label2.Text = "Con un puntaje de " + puntuacion.ToString() + "\nSigues dando venguenza xD";
                                        puntuacion = 0;
                                        lblPuntaje.Text = puntuacion.ToString();
                                    }
                                    else if (puntuacion >= 6)
                                    {
                                        perder.label2.Text = "tu puntaje fue de " + puntuacion.ToString() + "\nPara la proxima";
                                        puntuacion = 0;
                                        lblPuntaje.Text = puntuacion.ToString();
                                    }


                                    largoVida = 4;//reiniciamos el largo de la variable

                                    //le asignamos el color rojo a todos los txtVida
                                    for (int i = 0; i < 5; i++)
                                    {
                                        vida[i].BackColor = Color.Red;
                                    }

                                }
                                acumulador = 0;

                            }
                            return;
                        }


                    }
                }

            }
        }

        private const string RutaFrecuencia = @"C:\TXTS\FRECUENCIA.TXT";
        //Boton cerrar
        private void button1_Click(object sender, EventArgs e)
        {
            //Al cerrar secion se crea un archivo de texto en C:\TXTS el cual lleva por nombre VIGIANOMBREAPELLIDO.TXT
            //guardando todas las acciones que hacemos dentro del juego
            DateTime fecha = DateTime.Now;
            clase.GetSetFin = fecha;
            clase.GetSetAccion = "Se cerro el juego";
            

            lista.Add(new CLASEEVALUA2FernandoReyes(clase.GetSetRut, clase.GetSetInicio, clase.GetSetFin, clase.GetSetAccion, clase.GetSeAccionF));
            using (StreamWriter sw = File.AppendText(RutaArchivo))//BUENA PRACTICA
            {
                foreach (CLASEEVALUA2FernandoReyes datos in lista)
                {

                    sw.WriteLine($"{datos.GetSetRut},{ datos.GetSetInicio},{datos.GetSetFin},{datos.GetSetAccion},{datos.GetSeAccionF}");

                }
                 sw.WriteLine("\n");
            }

            using(StreamWriter fr = File.AppendText(RutaFrecuencia))
            {
                fr.Write($"{clase.GetSetRut},{clase.GetSetInicio},{salioRana},{salioOlla},{clase.GetSetFin}");
                fr.Write("\n");
            }
            
            
            Form1 Inicio = new Form1();
            Inicio.Visible = true;
            this.Close();
        }

        private void Juego_Load(object sender, EventArgs e)
        {
            Form1 principal2 = new Form1();
            musica.sonidoJuego();
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBox[] vida = new TextBox[5] { txtVida1, txtVida2, txtVida3, txtVida4, txtVida5 };

            for (int fila = 0; fila < 5; fila++)
            {
                for (int columna = 0; columna < 3; columna++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        vida[i].BackColor = Color.Red;
                        acumulador = 0;
                        puntuacion = 0;
                        txtPuntuacion.Text = acumulador.ToString();
                        largoVida = 4;
                        lblPuntaje.Text = "0";
                        cambiarColor = true;
                        for (int f = 0; f < 5; f++)
                        {

                            for (int c = 0; c < 3; c++)
                            {

                                //le volvemos a asignar la imagen por defecto a los botones
                                picture[f, c].BackgroundImage = image;

                            }
                        }

                    }
                }
            }
        }
        
        
       
        private void button5_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(Rut);
            menu.Show();
        }
    }
}
    





//DIFICULTADES
//NO SE GUARDABAN LOS DATOS DE MANERA CORRECTA, SE REPETIA LA MISMA LINEA
//LO RESOLVI CREANDO UN SEGUNDO CONTRUCTOR DENTRO DE LA CLASE Y A LA LISTA LE AGREGABA NUEVOS CONTRUCTORES CON LOS PARAMETROS REQUERIDOS