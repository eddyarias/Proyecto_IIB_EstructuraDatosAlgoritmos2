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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormViajePorRio));
            txtOrigen = new TextBox();
            txtDestino = new TextBox();
            lbResultado = new Label();
            lbRutasOptimas = new Label();
            label1 = new Label();
            label2 = new Label();
            dGVTarifas = new DataGridView();
            Iniciar = new Button();
            PanelRio = new Panel();
            PBBote4 = new PictureBox();
            PBBote3 = new PictureBox();
            PBBote2 = new PictureBox();
            PBBote1 = new PictureBox();
            lbE2 = new Label();
            lbE3 = new Label();
            lbE4 = new Label();
            lbE5 = new Label();
            lbE1 = new Label();
            PBE5 = new PictureBox();
            PBE4 = new PictureBox();
            PBE2 = new PictureBox();
            PBE3 = new PictureBox();
            PBE1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dGVTarifas).BeginInit();
            PanelRio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PBBote4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBBote3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBBote2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBBote1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBE5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBE4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBE2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBE3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBE1).BeginInit();
            SuspendLayout();
            // 
            // txtOrigen
            // 
            txtOrigen.Location = new Point(103, 28);
            txtOrigen.Name = "txtOrigen";
            txtOrigen.Size = new Size(43, 27);
            txtOrigen.TabIndex = 1;
            txtOrigen.TextChanged += txtOrigen_TextChanged;
            // 
            // txtDestino
            // 
            txtDestino.Location = new Point(103, 66);
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new Size(43, 27);
            txtDestino.TabIndex = 2;
            txtDestino.TextChanged += txtDestino_TextChanged;
            // 
            // lbResultado
            // 
            lbResultado.AutoSize = true;
            lbResultado.BackColor = Color.White;
            lbResultado.BorderStyle = BorderStyle.FixedSingle;
            lbResultado.Location = new Point(339, 75);
            lbResultado.Name = "lbResultado";
            lbResultado.Size = new Size(104, 22);
            lbResultado.TabIndex = 3;
            lbResultado.Text = "Costo mínimo";
            // 
            // lbRutasOptimas
            // 
            lbRutasOptimas.AutoSize = true;
            lbRutasOptimas.BackColor = Color.White;
            lbRutasOptimas.BorderStyle = BorderStyle.FixedSingle;
            lbRutasOptimas.Location = new Point(562, 75);
            lbRutasOptimas.Name = "lbRutasOptimas";
            lbRutasOptimas.Size = new Size(93, 22);
            lbRutasOptimas.TabIndex = 5;
            lbRutasOptimas.Text = "Ruta óptima";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 31);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 6;
            label1.Text = "Origen:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 69);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 7;
            label2.Text = "Destino:";
            // 
            // dGVTarifas
            // 
            dGVTarifas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dGVTarifas.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dGVTarifas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dGVTarifas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dGVTarifas.DefaultCellStyle = dataGridViewCellStyle2;
            dGVTarifas.GridColor = Color.DarkGray;
            dGVTarifas.ImeMode = ImeMode.NoControl;
            dGVTarifas.Location = new Point(27, 103);
            dGVTarifas.Name = "dGVTarifas";
            dGVTarifas.ReadOnly = true;
            dGVTarifas.RowHeadersVisible = false;
            dGVTarifas.RowHeadersWidth = 51;
            dGVTarifas.RowTemplate.Height = 29;
            dGVTarifas.Size = new Size(280, 323);
            dGVTarifas.TabIndex = 0;
            // 
            // Iniciar
            // 
            Iniciar.FlatAppearance.BorderColor = Color.Lime;
            Iniciar.FlatAppearance.BorderSize = 3;
            Iniciar.FlatStyle = FlatStyle.Flat;
            Iniciar.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Iniciar.Location = new Point(187, 40);
            Iniciar.Name = "Iniciar";
            Iniciar.Size = new Size(120, 40);
            Iniciar.TabIndex = 9;
            Iniciar.Text = "Iniciar";
            Iniciar.UseVisualStyleBackColor = true;
            Iniciar.Click += IniciarSimulacion_Click;
            // 
            // PanelRio
            // 
            PanelRio.BackColor = Color.Transparent;
            PanelRio.BackgroundImage = (Image)resources.GetObject("PanelRio.BackgroundImage");
            PanelRio.BackgroundImageLayout = ImageLayout.Stretch;
            PanelRio.Controls.Add(PBBote4);
            PanelRio.Controls.Add(PBBote3);
            PanelRio.Controls.Add(PBBote2);
            PanelRio.Controls.Add(PBBote1);
            PanelRio.Controls.Add(lbE2);
            PanelRio.Controls.Add(lbE3);
            PanelRio.Controls.Add(lbE4);
            PanelRio.Controls.Add(lbE5);
            PanelRio.Controls.Add(lbE1);
            PanelRio.Controls.Add(PBE5);
            PanelRio.Controls.Add(PBE4);
            PanelRio.Controls.Add(PBE2);
            PanelRio.Controls.Add(PBE3);
            PanelRio.Controls.Add(PBE1);
            PanelRio.Location = new Point(335, 103);
            PanelRio.Name = "PanelRio";
            PanelRio.Size = new Size(833, 323);
            PanelRio.TabIndex = 11;
            // 
            // PBBote4
            // 
            PBBote4.BackColor = Color.Transparent;
            PBBote4.Image = (Image)resources.GetObject("PBBote4.Image");
            PBBote4.Location = new Point(565, 173);
            PBBote4.Name = "PBBote4";
            PBBote4.Size = new Size(75, 45);
            PBBote4.SizeMode = PictureBoxSizeMode.StretchImage;
            PBBote4.TabIndex = 25;
            PBBote4.TabStop = false;
            // 
            // PBBote3
            // 
            PBBote3.BackColor = Color.Transparent;
            PBBote3.Image = (Image)resources.GetObject("PBBote3.Image");
            PBBote3.Location = new Point(415, 173);
            PBBote3.Name = "PBBote3";
            PBBote3.Size = new Size(75, 45);
            PBBote3.SizeMode = PictureBoxSizeMode.StretchImage;
            PBBote3.TabIndex = 24;
            PBBote3.TabStop = false;
            // 
            // PBBote2
            // 
            PBBote2.BackColor = Color.Transparent;
            PBBote2.Image = (Image)resources.GetObject("PBBote2.Image");
            PBBote2.Location = new Point(265, 173);
            PBBote2.Name = "PBBote2";
            PBBote2.Size = new Size(75, 45);
            PBBote2.SizeMode = PictureBoxSizeMode.StretchImage;
            PBBote2.TabIndex = 23;
            PBBote2.TabStop = false;
            // 
            // PBBote1
            // 
            PBBote1.BackColor = Color.Transparent;
            PBBote1.BackgroundImage = (Image)resources.GetObject("PBBote1.BackgroundImage");
            PBBote1.Image = (Image)resources.GetObject("PBBote1.Image");
            PBBote1.Location = new Point(115, 173);
            PBBote1.Name = "PBBote1";
            PBBote1.Size = new Size(75, 45);
            PBBote1.SizeMode = PictureBoxSizeMode.StretchImage;
            PBBote1.TabIndex = 17;
            PBBote1.TabStop = false;
            // 
            // lbE2
            // 
            lbE2.AutoSize = true;
            lbE2.BackColor = Color.Transparent;
            lbE2.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lbE2.Location = new Point(296, 79);
            lbE2.Name = "lbE2";
            lbE2.Size = new Size(24, 29);
            lbE2.TabIndex = 22;
            lbE2.Text = "2";
            // 
            // lbE3
            // 
            lbE3.AutoSize = true;
            lbE3.BackColor = Color.Transparent;
            lbE3.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lbE3.Location = new Point(441, 79);
            lbE3.Name = "lbE3";
            lbE3.Size = new Size(24, 29);
            lbE3.TabIndex = 21;
            lbE3.Text = "3";
            // 
            // lbE4
            // 
            lbE4.AutoSize = true;
            lbE4.BackColor = Color.Transparent;
            lbE4.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lbE4.Location = new Point(596, 79);
            lbE4.Name = "lbE4";
            lbE4.Size = new Size(26, 29);
            lbE4.TabIndex = 20;
            lbE4.Text = "4";
            // 
            // lbE5
            // 
            lbE5.AutoSize = true;
            lbE5.BackColor = Color.Transparent;
            lbE5.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lbE5.Location = new Point(739, 79);
            lbE5.Name = "lbE5";
            lbE5.Size = new Size(25, 29);
            lbE5.TabIndex = 19;
            lbE5.Text = "5";
            // 
            // lbE1
            // 
            lbE1.AutoSize = true;
            lbE1.BackColor = Color.Transparent;
            lbE1.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lbE1.Location = new Point(143, 79);
            lbE1.Name = "lbE1";
            lbE1.Size = new Size(23, 29);
            lbE1.TabIndex = 18;
            lbE1.Text = "1";
            // 
            // PBE5
            // 
            PBE5.Image = (Image)resources.GetObject("PBE5.Image");
            PBE5.Location = new Point(700, 123);
            PBE5.Name = "PBE5";
            PBE5.Size = new Size(103, 66);
            PBE5.SizeMode = PictureBoxSizeMode.StretchImage;
            PBE5.TabIndex = 16;
            PBE5.TabStop = false;
            // 
            // PBE4
            // 
            PBE4.Image = (Image)resources.GetObject("PBE4.Image");
            PBE4.Location = new Point(550, 123);
            PBE4.Name = "PBE4";
            PBE4.Size = new Size(103, 66);
            PBE4.SizeMode = PictureBoxSizeMode.StretchImage;
            PBE4.TabIndex = 15;
            PBE4.TabStop = false;
            // 
            // PBE2
            // 
            PBE2.BackColor = Color.Transparent;
            PBE2.Image = (Image)resources.GetObject("PBE2.Image");
            PBE2.Location = new Point(250, 123);
            PBE2.Name = "PBE2";
            PBE2.Size = new Size(103, 66);
            PBE2.SizeMode = PictureBoxSizeMode.StretchImage;
            PBE2.TabIndex = 13;
            PBE2.TabStop = false;
            // 
            // PBE3
            // 
            PBE3.Image = (Image)resources.GetObject("PBE3.Image");
            PBE3.Location = new Point(400, 123);
            PBE3.Name = "PBE3";
            PBE3.Size = new Size(103, 66);
            PBE3.SizeMode = PictureBoxSizeMode.StretchImage;
            PBE3.TabIndex = 12;
            PBE3.TabStop = false;
            // 
            // PBE1
            // 
            PBE1.BackColor = Color.Transparent;
            PBE1.BackgroundImage = (Image)resources.GetObject("PBE1.BackgroundImage");
            PBE1.BackgroundImageLayout = ImageLayout.Stretch;
            PBE1.Location = new Point(100, 123);
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
            BackColor = Color.White;
            ClientSize = new Size(1191, 451);
            Controls.Add(PanelRio);
            Controls.Add(Iniciar);
            Controls.Add(dGVTarifas);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbRutasOptimas);
            Controls.Add(lbResultado);
            Controls.Add(txtDestino);
            Controls.Add(txtOrigen);
            Name = "FormViajePorRio";
            Text = "VIAJE MÁS BARATO POR RÍO - GRUPO 6";
            ((System.ComponentModel.ISupportInitialize)dGVTarifas).EndInit();
            PanelRio.ResumeLayout(false);
            PanelRio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PBBote4).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBBote3).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBBote2).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBBote1).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBE5).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBE4).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBE2).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBE3).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBE1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtOrigen;
        private TextBox txtDestino;
        private Label lbResultado;
        private Label lbRutasOptimas;
        private Label label1;
        private Label label2;
        private DataGridView dGVTarifas;
        private Button Iniciar;
        private Panel PanelRio;
        private PictureBox PBE1;
        private PictureBox PBE5;
        private PictureBox PBE4;
        private PictureBox PBE2;
        private PictureBox PBE3;
        private PictureBox PBBote1;
        private Label lbE1;
        private Label lbE2;
        private Label lbE3;
        private Label lbE4;
        private Label lbE5;
        private PictureBox PBBote4;
        private PictureBox PBBote3;
        private PictureBox PBBote2;
    }
}
