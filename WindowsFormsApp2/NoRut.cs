using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class NoRut : Form
    {
        public NoRut()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ACA VA EL FORM PARA REGISTRARSE EN LA BASE DE DATOS
            registrarPerfil registrar = new registrarPerfil();
            registrar.Show();
        }
    }
}
