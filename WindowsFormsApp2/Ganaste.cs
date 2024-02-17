using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Ganaste : Form
    {
        Musica musica = new Musica();
        public Ganaste()
        {
            InitializeComponent();
            //centramos el forms en la pantalla
            this.CenterToScreen();
            musica.ganarPlay();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            musica.ganarStop();
            this.Hide();
            musica.sonidoJuego();
        }
    }
}
