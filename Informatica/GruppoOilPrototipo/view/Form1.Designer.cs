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
            this.terminaButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // avviaButton
            // 
            this.avviaButton.BackColor = System.Drawing.Color.White;
            this.avviaButton.Location = new System.Drawing.Point(139, 339);
            this.avviaButton.Name = "avviaButton";
            this.avviaButton.Size = new System.Drawing.Size(137, 45);
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
            this.dataGridView1.Location = new System.Drawing.Point(139, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(514, 308);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // apriCartellaButton
            // 
            this.apriCartellaButton.BackColor = System.Drawing.Color.Azure;
            this.apriCartellaButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.apriCartellaButton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.apriCartellaButton.Location = new System.Drawing.Point(659, 25);
            this.apriCartellaButton.Name = "apriCartellaButton";
            this.apriCartellaButton.Size = new System.Drawing.Size(129, 23);
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(799, 24);
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
            this.opzioni.Size = new System.Drawing.Size(60, 20);
            this.opzioni.Text = "Opzioni";
            // 
            // portaComToolStripMenuItem
            // 
            this.portaComToolStripMenuItem.Name = "portaComToolStripMenuItem";
            this.portaComToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.portaComToolStripMenuItem.Text = "Porta Com";
            this.portaComToolStripMenuItem.Click += new System.EventHandler(this.portaComToolStripMenuItem_Click);
            // 
            // mAXMisurazioniToolStripMenuItem
            // 
            this.mAXMisurazioniToolStripMenuItem.Name = "mAXMisurazioniToolStripMenuItem";
            this.mAXMisurazioniToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.mAXMisurazioniToolStripMenuItem.Text = "MAX. misurazioni";
            this.mAXMisurazioniToolStripMenuItem.Click += new System.EventHandler(this.mAXMisurazioniToolStripMenuItem_Click);
            // 
            // misurazioni
            // 
            this.misurazioni.AutoSize = true;
            this.misurazioni.Location = new System.Drawing.Point(11, 97);
            this.misurazioni.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.misurazioni.Name = "misurazioni";
            this.misurazioni.Size = new System.Drawing.Size(81, 13);
            this.misurazioni.TabIndex = 5;
            this.misurazioni.Text = "Max misuazioni:";
            this.misurazioni.Click += new System.EventHandler(this.label1_Click);
            // 
            // porta
            // 
            this.porta.AutoSize = true;
            this.porta.Location = new System.Drawing.Point(11, 124);
            this.porta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.porta.Name = "porta";
            this.porta.Size = new System.Drawing.Size(38, 13);
            this.porta.TabIndex = 6;
            this.porta.Text = "Porta: ";
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Location = new System.Drawing.Point(14, 150);
            this.id.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(42, 13);
            this.id.TabIndex = 7;
            this.id.Text = "Seriale:";
            this.id.Click += new System.EventHandler(this.id_Click);
            // 
            // terminaButton
            // 
            this.terminaButton.BackColor = System.Drawing.Color.White;
            this.terminaButton.Location = new System.Drawing.Point(515, 339);
            this.terminaButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.terminaButton.Name = "terminaButton";
            this.terminaButton.Size = new System.Drawing.Size(137, 45);
            this.terminaButton.TabIndex = 9;
            this.terminaButton.Text = "Termina misurazione";
            this.terminaButton.UseVisualStyleBackColor = false;
            this.terminaButton.Click += new System.EventHandler(this.terminaButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(799, 405);
            this.Controls.Add(this.terminaButton);
            this.Controls.Add(this.id);
            this.Controls.Add(this.porta);
            this.Controls.Add(this.misurazioni);
            this.Controls.Add(this.apriCartellaButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.avviaButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
        private System.Windows.Forms.Button terminaButton;
    }
}

