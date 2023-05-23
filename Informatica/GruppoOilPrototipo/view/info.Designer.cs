namespace GruppoOilPrototipo.view
{
    partial class info
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Nome = new System.Windows.Forms.TextBox();
            this.Id = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID";
            // 
            // Nome
            // 
            this.Nome.Location = new System.Drawing.Point(227, 107);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(113, 22);
            this.Nome.TabIndex = 2;
            // 
            // Id
            // 
            this.Id.Location = new System.Drawing.Point(227, 199);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(113, 22);
            this.Id.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(227, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Avvia";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 328);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Id);
            this.Controls.Add(this.Nome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "info";
            this.Text = "info";
            this.Load += new System.EventHandler(this.info_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Nome;
        private System.Windows.Forms.TextBox Id;
        private System.Windows.Forms.Button button1;
    }
}