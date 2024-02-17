
namespace WindowsFormsApp2
{
    partial class Juego
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Juego));
            this.txtPuntuacion = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtVida3 = new System.Windows.Forms.TextBox();
            this.txtVida2 = new System.Windows.Forms.TextBox();
            this.txtVida1 = new System.Windows.Forms.TextBox();
            this.txtVida4 = new System.Windows.Forms.TextBox();
            this.txtVida5 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lblPuntaje = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPuntuacion
            // 
            this.txtPuntuacion.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtPuntuacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPuntuacion.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtPuntuacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPuntuacion.ForeColor = System.Drawing.Color.Red;
            this.txtPuntuacion.Location = new System.Drawing.Point(12, 12);
            this.txtPuntuacion.Multiline = true;
            this.txtPuntuacion.Name = "txtPuntuacion";
            this.txtPuntuacion.ReadOnly = true;
            this.txtPuntuacion.Size = new System.Drawing.Size(42, 40);
            this.txtPuntuacion.TabIndex = 0;
            this.txtPuntuacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("Chiller", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(12, 697);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 56);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::WindowsFormsApp2.Properties.Resources.ranaSatanica;
            this.pictureBox1.Location = new System.Drawing.Point(381, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(381, 664);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(97, 89);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // txtVida3
            // 
            this.txtVida3.Location = new System.Drawing.Point(148, 32);
            this.txtVida3.Name = "txtVida3";
            this.txtVida3.ReadOnly = true;
            this.txtVida3.Size = new System.Drawing.Size(38, 20);
            this.txtVida3.TabIndex = 4;
            // 
            // txtVida2
            // 
            this.txtVida2.Location = new System.Drawing.Point(192, 32);
            this.txtVida2.Name = "txtVida2";
            this.txtVida2.ReadOnly = true;
            this.txtVida2.Size = new System.Drawing.Size(38, 20);
            this.txtVida2.TabIndex = 5;
            // 
            // txtVida1
            // 
            this.txtVida1.Location = new System.Drawing.Point(236, 32);
            this.txtVida1.Name = "txtVida1";
            this.txtVida1.ReadOnly = true;
            this.txtVida1.Size = new System.Drawing.Size(38, 20);
            this.txtVida1.TabIndex = 6;
            // 
            // txtVida4
            // 
            this.txtVida4.Location = new System.Drawing.Point(104, 32);
            this.txtVida4.Name = "txtVida4";
            this.txtVida4.ReadOnly = true;
            this.txtVida4.Size = new System.Drawing.Size(38, 20);
            this.txtVida4.TabIndex = 8;
            // 
            // txtVida5
            // 
            this.txtVida5.Location = new System.Drawing.Point(60, 32);
            this.txtVida5.Name = "txtVida5";
            this.txtVida5.ReadOnly = true;
            this.txtVida5.Size = new System.Drawing.Size(38, 20);
            this.txtVida5.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlText;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Font = new System.Drawing.Font("Chiller", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(94, 697);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 56);
            this.button2.TabIndex = 9;
            this.button2.Text = "Reiniciar juego";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblPuntaje
            // 
            this.lblPuntaje.AutoSize = true;
            this.lblPuntaje.BackColor = System.Drawing.Color.Transparent;
            this.lblPuntaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntaje.ForeColor = System.Drawing.Color.Red;
            this.lblPuntaje.Location = new System.Drawing.Point(122, 68);
            this.lblPuntaje.Name = "lblPuntaje";
            this.lblPuntaje.Size = new System.Drawing.Size(41, 15);
            this.lblPuntaje.TabIndex = 10;
            this.lblPuntaje.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Puntuacion total : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Chiller", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(688, 652);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 100);
            this.label5.TabIndex = 52;
            this.label5.Text = "Nombre: Fernando Reyes Luengo\r\nCarrera: Analista programador\r\nAsignatura: Program" +
    "acion 2\r\nProfesor: Luis Yañez Carreño\r\nEVAPROG4_FernandoReyes\r\n";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ControlText;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Font = new System.Drawing.Font("Chiller", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Red;
            this.button5.Location = new System.Drawing.Point(182, 697);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 56);
            this.button5.TabIndex = 54;
            this.button5.Text = "Menu";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.portadaJuego;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(858, 761);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPuntaje);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtVida4);
            this.Controls.Add(this.txtVida5);
            this.Controls.Add(this.txtVida1);
            this.Controls.Add(this.txtVida2);
            this.Controls.Add(this.txtVida3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPuntuacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Juego";
            this.Text = "Juego";
            this.Load += new System.EventHandler(this.Juego_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.TextBox txtPuntuacion;
        private System.Windows.Forms.TextBox txtVida3;
        private System.Windows.Forms.TextBox txtVida2;
        private System.Windows.Forms.TextBox txtVida1;
        private System.Windows.Forms.TextBox txtVida4;
        private System.Windows.Forms.TextBox txtVida5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblPuntaje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
    }
}