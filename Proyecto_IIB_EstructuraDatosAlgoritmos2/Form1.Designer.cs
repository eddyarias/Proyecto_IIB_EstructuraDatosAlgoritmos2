namespace Proyecto_IIB_EstructuraDatosAlgoritmos2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCalcular = new Button();
            txtOrigen = new TextBox();
            txtDestino = new TextBox();
            lbResultado = new Label();
            lbTarifas = new Label();
            lbRutasOptimas = new Label();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(311, 206);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(94, 29);
            btnCalcular.TabIndex = 0;
            btnCalcular.Text = "button1";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // txtOrigen
            // 
            txtOrigen.Location = new Point(144, 24);
            txtOrigen.Name = "txtOrigen";
            txtOrigen.Size = new Size(125, 27);
            txtOrigen.TabIndex = 1;
            // 
            // txtDestino
            // 
            txtDestino.Location = new Point(144, 72);
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new Size(125, 27);
            txtDestino.TabIndex = 2;
            // 
            // lbResultado
            // 
            lbResultado.AutoSize = true;
            lbResultado.Location = new Point(179, 149);
            lbResultado.Name = "lbResultado";
            lbResultado.Size = new Size(50, 20);
            lbResultado.TabIndex = 3;
            lbResultado.Text = "label1";
            // 
            // lbTarifas
            // 
            lbTarifas.AutoSize = true;
            lbTarifas.Location = new Point(39, 215);
            lbTarifas.Name = "lbTarifas";
            lbTarifas.Size = new Size(51, 20);
            lbTarifas.TabIndex = 4;
            lbTarifas.Text = "Tarifas";
            // 
            // lbRutasOptimas
            // 
            lbRutasOptimas.AutoSize = true;
            lbRutasOptimas.Location = new Point(510, 209);
            lbRutasOptimas.Name = "lbRutasOptimas";
            lbRutasOptimas.Size = new Size(50, 20);
            lbRutasOptimas.TabIndex = 5;
            lbRutasOptimas.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 27);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 6;
            label1.Text = "Origen:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 79);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 7;
            label2.Text = "Destino:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbRutasOptimas);
            Controls.Add(lbTarifas);
            Controls.Add(lbResultado);
            Controls.Add(txtDestino);
            Controls.Add(txtOrigen);
            Controls.Add(btnCalcular);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCalcular;
        private TextBox txtOrigen;
        private TextBox txtDestino;
        private Label lbResultado;
        private Label lbTarifas;
        private Label lbRutasOptimas;
        private Label label1;
        private Label label2;
    }
}
