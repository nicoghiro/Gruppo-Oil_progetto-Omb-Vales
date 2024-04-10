namespace GruppoOilPrototipo
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.avviaButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.apriCartellaButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opzioni = new System.Windows.Forms.ToolStripMenuItem();
            this.portaComToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mAXMisurazioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.misurazioni = new System.Windows.Forms.Label();
            this.porta = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.Label();
            this.nome = new System.Windows.Forms.Label();
            this.terminaButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // avviaButton
            // 
            this.avviaButton.BackColor = System.Drawing.Color.White;
            this.avviaButton.Location = new System.Drawing.Point(185, 417);
            this.avviaButton.Margin = new System.Windows.Forms.Padding(4);
            this.avviaButton.Name = "avviaButton";
            this.avviaButton.Size = new System.Drawing.Size(183, 55);
            this.avviaButton.TabIndex = 0;
            this.avviaButton.Text = "Avvia misurazione";
            this.avviaButton.UseVisualStyleBackColor = false;
            this.avviaButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(185, 31);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(685, 379);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // apriCartellaButton
            // 
            this.apriCartellaButton.BackColor = System.Drawing.Color.Azure;
            this.apriCartellaButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.apriCartellaButton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.apriCartellaButton.Location = new System.Drawing.Point(879, 31);
            this.apriCartellaButton.Margin = new System.Windows.Forms.Padding(4);
            this.apriCartellaButton.Name = "apriCartellaButton";
            this.apriCartellaButton.Size = new System.Drawing.Size(172, 28);
            this.apriCartellaButton.TabIndex = 3;
            this.apriCartellaButton.Text = "Apri cartella";
            this.apriCartellaButton.UseVisualStyleBackColor = false;
            this.apriCartellaButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opzioni});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1065, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opzioni
            // 
            this.opzioni.BackColor = System.Drawing.Color.Azure;
            this.opzioni.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portaComToolStripMenuItem,
            this.mAXMisurazioniToolStripMenuItem});
            this.opzioni.Name = "opzioni";
            this.opzioni.Size = new System.Drawing.Size(75, 24);
            this.opzioni.Text = "Opzioni";
            // 
            // portaComToolStripMenuItem
            // 
            this.portaComToolStripMenuItem.Name = "portaComToolStripMenuItem";
            this.portaComToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.portaComToolStripMenuItem.Text = "Porta Com";
            this.portaComToolStripMenuItem.Click += new System.EventHandler(this.portaComToolStripMenuItem_Click);
            // 
            // mAXMisurazioniToolStripMenuItem
            // 
            this.mAXMisurazioniToolStripMenuItem.Name = "mAXMisurazioniToolStripMenuItem";
            this.mAXMisurazioniToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.mAXMisurazioniToolStripMenuItem.Text = "MAX. misurazioni";
            this.mAXMisurazioniToolStripMenuItem.Click += new System.EventHandler(this.mAXMisurazioniToolStripMenuItem_Click);
            // 
            // misurazioni
            // 
            this.misurazioni.AutoSize = true;
            this.misurazioni.Location = new System.Drawing.Point(15, 119);
            this.misurazioni.Name = "misurazioni";
            this.misurazioni.Size = new System.Drawing.Size(101, 16);
            this.misurazioni.TabIndex = 5;
            this.misurazioni.Text = "Max misuazioni:";
            this.misurazioni.Click += new System.EventHandler(this.label1_Click);
            // 
            // porta
            // 
            this.porta.AutoSize = true;
            this.porta.Location = new System.Drawing.Point(15, 153);
            this.porta.Name = "porta";
            this.porta.Size = new System.Drawing.Size(45, 16);
            this.porta.TabIndex = 6;
            this.porta.Text = "Porta: ";
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Location = new System.Drawing.Point(18, 184);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(26, 16);
            this.id.TabIndex = 7;
            this.id.Text = "ID: ";
            // 
            // nome
            // 
            this.nome.AutoSize = true;
            this.nome.Location = new System.Drawing.Point(18, 216);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(47, 16);
            this.nome.TabIndex = 8;
            this.nome.Text = "Nome:";
            // 
            // terminaButton
            // 
            this.terminaButton.BackColor = System.Drawing.Color.White;
            this.terminaButton.Location = new System.Drawing.Point(687, 417);
            this.terminaButton.Name = "terminaButton";
            this.terminaButton.Size = new System.Drawing.Size(183, 55);
            this.terminaButton.TabIndex = 9;
            this.terminaButton.Text = "Termina misurazione";
            this.terminaButton.UseVisualStyleBackColor = false;
            this.terminaButton.Click += new System.EventHandler(this.terminaButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1065, 499);
            this.Controls.Add(this.terminaButton);
            this.Controls.Add(this.nome);
            this.Controls.Add(this.id);
            this.Controls.Add(this.porta);
            this.Controls.Add(this.misurazioni);
            this.Controls.Add(this.apriCartellaButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.avviaButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button avviaButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button apriCartellaButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opzioni;
        private System.Windows.Forms.ToolStripMenuItem portaComToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mAXMisurazioniToolStripMenuItem;
        private System.Windows.Forms.Label misurazioni;
        private System.Windows.Forms.Label porta;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.Label nome;
        private System.Windows.Forms.Button terminaButton;
    }
}

