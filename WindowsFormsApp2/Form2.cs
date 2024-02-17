using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        Musica musica = new Musica();


        public Form2()
        {
            InitializeComponent();

            //centramos el forms en la pantalla
            this.CenterToScreen();
        }






        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            musica.perderStop();
            musica.sonidoJuego();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            musica.musicaPerder();
        }
    }


}
