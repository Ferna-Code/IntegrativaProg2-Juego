using System.Media;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class Musica
    {
        SoundPlayer perder = new SoundPlayer(Application.StartupPath + @"\audio\risaDiabolica.wav");
        SoundPlayer ganar = new SoundPlayer(Application.StartupPath + @"\audio\cantoAngeles.wav");

        public void sonidoJuego()
        {
            SoundPlayer soundPlayer = new SoundPlayer(Application.StartupPath + @"\audio\espiritu.wav");
            soundPlayer.Play();

        }

        public void sonidoRut()
        {
            SoundPlayer inicio = new SoundPlayer(Application.StartupPath + @"\audio\Sonido-de-miedo-HD.wav");
            inicio.Play();
        }

        public void musicaPerder()
        {

            perder.Play();
        }
        public void perderStop()
        {
            perder.Stop();
        }

        public void ganarPlay()
        {

            ganar.Play();
        }
        public void ganarStop()
        {
            ganar.Stop();
        }
    }
}




