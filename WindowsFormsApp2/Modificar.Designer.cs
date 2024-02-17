
namespace WindowsFormsApp2
{
    partial class Modificar
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
            this.txtNuevoRut = new System.Windows.Forms.TextBox();
            this.txtNuevoNombre = new System.Windows.Forms.TextBox();
            this.txtNuevoPaterno = new System.Windows.Forms.TextBox();
            this.txtNuevoMaterno = new System.Windows.Forms.TextBox();
            this.txtNuevoNivel = new System.Windows.Forms.TextBox();
            this.txtRutPk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNuevoRut
            // 
            this.txtNuevoRut.Location = new System.Drawing.Point(35, 153);
            this.txtNuevoRut.Name = "txtNuevoRut";
            this.txtNuevoRut.Size = new System.Drawing.Size(114, 20);
            this.txtNuevoRut.TabIndex = 0;
            // 
            // txtNuevoNombre
            // 
            this.txtNuevoNombre.Location = new System.Drawing.Point(226, 153);
            this.txtNuevoNombre.Name = "txtNuevoNombre";
            this.txtNuevoNombre.Size = new System.Drawing.Size(116, 20);
            this.txtNuevoNombre.TabIndex = 1;
            // 
            // txtNuevoPaterno
            // 
            this.txtNuevoPaterno.Location = new System.Drawing.Point(35, 210);
            this.txtNuevoPaterno.Name = "txtNuevoPaterno";
            this.txtNuevoPaterno.Size = new System.Drawing.Size(116, 20);
            this.txtNuevoPaterno.TabIndex = 2;
            // 
            // txtNuevoMaterno
            // 
            this.txtNuevoMaterno.Location = new System.Drawing.Point(226, 210);
            this.txtNuevoMaterno.Name = "txtNuevoMaterno";
            this.txtNuevoMaterno.Size = new System.Drawing.Size(116, 20);
            this.txtNuevoMaterno.TabIndex = 3;
            // 
            // txtNuevoNivel
            // 
            this.txtNuevoNivel.Location = new System.Drawing.Point(417, 210);
            this.txtNuevoNivel.Name = "txtNuevoNivel";
            this.txtNuevoNivel.Size = new System.Drawing.Size(61, 20);
            this.txtNuevoNivel.TabIndex = 4;
            // 
            // txtRutPk
            // 
            this.txtRutPk.Location = new System.Drawing.Point(35, 94);
            this.txtRutPk.Name = "txtRutPk";
            this.txtRutPk.Size = new System.Drawing.Size(100, 20);
            this.txtRutPk.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ingrese el RUT al cual le realizara las modificaciones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nuevo RUT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nuevo nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nuevo apellido paterno";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nuevo apellido materno";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(414, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Nuevo nivel";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Modificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRutPk);
            this.Controls.Add(this.txtNuevoNivel);
            this.Controls.Add(this.txtNuevoMaterno);
            this.Controls.Add(this.txtNuevoPaterno);
            this.Controls.Add(this.txtNuevoNombre);
            this.Controls.Add(this.txtNuevoRut);
            this.Name = "Modificar";
            this.Text = "Modificar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNuevoRut;
        private System.Windows.Forms.TextBox txtNuevoNombre;
        private System.Windows.Forms.TextBox txtNuevoPaterno;
        private System.Windows.Forms.TextBox txtNuevoMaterno;
        private System.Windows.Forms.TextBox txtNuevoNivel;
        private System.Windows.Forms.TextBox txtRutPk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}