using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class ValidarRut
    {
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
        public char validadorRut(string rut)
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
                Juego juego = new Juego(Rut);
                juego.Show();
                cerrar = true;
            }
            return digitoVerificador;
        }

        
    }
}
