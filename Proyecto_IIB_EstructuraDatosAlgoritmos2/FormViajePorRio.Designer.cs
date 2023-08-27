namespace Proyecto_IIB_EstructuraDatosAlgoritmos2
{
    partial class FormViajePorRio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormViajePorRio));
            btnCalcular = new Button();
            txtOrigen = new TextBox();
            txtDestino = new TextBox();
            lbResultado = new Label();
            lbRutasOptimas = new Label();
            label1 = new Label();
            label2 = new Label();
            dGVTarifas = new DataGridView();
            IniciarSimulacion = new Button();
            PanelRio = new Panel();
            PBBote = new PictureBox();
            PBE5 = new PictureBox();
            PBE4 = new PictureBox();
            PBE2 = new PictureBox();
            PBE3 = new PictureBox();
            PBE1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dGVTarifas).BeginInit();
            PanelRio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PBBote).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBE5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBE4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBE2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBE3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBE1).BeginInit();
            SuspendLayout();
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(257, 51);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(94, 29);
            btnCalcular.TabIndex = 0;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // txtOrigen
            // 
            txtOrigen.Location = new Point(98, 24);
            txtOrigen.Name = "txtOrigen";
            txtOrigen.Size = new Size(125, 27);
            txtOrigen.TabIndex = 1;
            // 
            // txtDestino
            // 
            txtDestino.Location = new Point(98, 72);
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new Size(125, 27);
            txtDestino.TabIndex = 2;
            // 
            // lbResultado
            // 
            lbResultado.AutoSize = true;
            lbResultado.Location = new Point(371, 27);
            lbResultado.Name = "lbResultado";
            lbResultado.Size = new Size(50, 20);
            lbResultado.TabIndex = 3;
            lbResultado.Text = "label1";
            // 
            // lbRutasOptimas
            // 
            lbRutasOptimas.AutoSize = true;
            lbRutasOptimas.Location = new Point(371, 62);
            lbRutasOptimas.Name = "lbRutasOptimas";
            lbRutasOptimas.Size = new Size(50, 20);
            lbRutasOptimas.TabIndex = 5;
            lbRutasOptimas.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 27);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 6;
            label1.Text = "Origen:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 79);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 7;
            label2.Text = "Destino:";
            // 
            // dGVTarifas
            // 
            dGVTarifas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGVTarifas.Location = new Point(12, 142);
            dGVTarifas.Name = "dGVTarifas";
            dGVTarifas.RowHeadersWidth = 51;
            dGVTarifas.RowTemplate.Height = 29;
            dGVTarifas.Size = new Size(450, 340);
            dGVTarifas.TabIndex = 8;
            // 
            // IniciarSimulacion
            // 
            IniciarSimulacion.Location = new Point(534, 58);
            IniciarSimulacion.Name = "IniciarSimulacion";
            IniciarSimulacion.Size = new Size(155, 29);
            IniciarSimulacion.TabIndex = 9;
            IniciarSimulacion.Text = "Iniciar simulación";
            IniciarSimulacion.UseVisualStyleBackColor = true;
            IniciarSimulacion.Click += IniciarSimulacion_Click;
            // 
            // PanelRio
            // 
            PanelRio.BackgroundImage = (Image)resources.GetObject("PanelRio.BackgroundImage");
            PanelRio.BackgroundImageLayout = ImageLayout.Stretch;
            PanelRio.Controls.Add(PBBote);
            PanelRio.Controls.Add(PBE5);
            PanelRio.Controls.Add(PBE4);
            PanelRio.Controls.Add(PBE2);
            PanelRio.Controls.Add(PBE3);
            PanelRio.Controls.Add(PBE1);
            PanelRio.Location = new Point(490, 142);
            PanelRio.Name = "PanelRio";
            PanelRio.Size = new Size(833, 340);
            PanelRio.TabIndex = 11;
            // 
            // PBBote
            // 
            PBBote.BackColor = Color.Transparent;
            PBBote.Image = (Image)resources.GetObject("PBBote.Image");
            PBBote.Location = new Point(0, 161);
            PBBote.Name = "PBBote";
            PBBote.Size = new Size(64, 46);
            PBBote.SizeMode = PictureBoxSizeMode.StretchImage;
            PBBote.TabIndex = 17;
            PBBote.TabStop = false;
            // 
            // PBE5
            // 
            PBE5.Image = (Image)resources.GetObject("PBE5.Image");
            PBE5.Location = new Point(700, 130);
            PBE5.Name = "PBE5";
            PBE5.Size = new Size(103, 66);
            PBE5.SizeMode = PictureBoxSizeMode.StretchImage;
            PBE5.TabIndex = 16;
            PBE5.TabStop = false;
            // 
            // PBE4
            // 
            PBE4.Image = (Image)resources.GetObject("PBE4.Image");
            PBE4.Location = new Point(550, 130);
            PBE4.Name = "PBE4";
            PBE4.Size = new Size(103, 66);
            PBE4.SizeMode = PictureBoxSizeMode.StretchImage;
            PBE4.TabIndex = 15;
            PBE4.TabStop = false;
            // 
            // PBE2
            // 
            PBE2.Image = (Image)resources.GetObject("PBE2.Image");
            PBE2.Location = new Point(250, 130);
            PBE2.Name = "PBE2";
            PBE2.Size = new Size(103, 66);
            PBE2.SizeMode = PictureBoxSizeMode.StretchImage;
            PBE2.TabIndex = 13;
            PBE2.TabStop = false;
            // 
            // PBE3
            // 
            PBE3.Image = (Image)resources.GetObject("PBE3.Image");
            PBE3.Location = new Point(400, 130);
            PBE3.Name = "PBE3";
            PBE3.Size = new Size(103, 66);
            PBE3.SizeMode = PictureBoxSizeMode.StretchImage;
            PBE3.TabIndex = 12;
            PBE3.TabStop = false;
            // 
            // PBE1
            // 
            PBE1.Image = (Image)resources.GetObject("PBE1.Image");
            PBE1.Location = new Point(100, 130);
            PBE1.Name = "PBE1";
            PBE1.Size = new Size(103, 66);
            PBE1.SizeMode = PictureBoxSizeMode.StretchImage;
            PBE1.TabIndex = 11;
            PBE1.TabStop = false;
            // 
            // FormViajePorRio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1354, 526);
            Controls.Add(PanelRio);
            Controls.Add(IniciarSimulacion);
            Controls.Add(dGVTarifas);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbRutasOptimas);
            Controls.Add(lbResultado);
            Controls.Add(txtDestino);
            Controls.Add(txtOrigen);
            Controls.Add(btnCalcular);
            Name = "FormViajePorRio";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dGVTarifas).EndInit();
            PanelRio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PBBote).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBE5).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBE4).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBE2).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBE3).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBE1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCalcular;
        private TextBox txtOrigen;
        private TextBox txtDestino;
        private Label lbResultado;
        private Label lbRutasOptimas;
        private Label label1;
        private Label label2;
        private DataGridView dGVTarifas;
        private Button IniciarSimulacion;
        private Panel PanelRio;
        private PictureBox PBE1;
        private PictureBox PBE5;
        private PictureBox PBE4;
        private PictureBox PBE2;
        private PictureBox PBE3;
        private PictureBox PBBote;
    }
}
