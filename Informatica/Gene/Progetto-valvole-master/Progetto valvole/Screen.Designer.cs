namespace Progetto_valvole
{
    partial class Screen
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
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.buttonSTART = new System.Windows.Forms.Button();
            this.buttonSTOP = new System.Windows.Forms.Button();
            this.timerCiclo = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(476, 258);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // buttonSTART
            // 
            this.buttonSTART.BackColor = System.Drawing.Color.LawnGreen;
            this.buttonSTART.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSTART.Location = new System.Drawing.Point(12, 276);
            this.buttonSTART.Name = "buttonSTART";
            this.buttonSTART.Size = new System.Drawing.Size(145, 72);
            this.buttonSTART.TabIndex = 1;
            this.buttonSTART.Text = "START";
            this.buttonSTART.UseVisualStyleBackColor = false;
            this.buttonSTART.Click += new System.EventHandler(this.buttonSTART_Click);
            // 
            // buttonSTOP
            // 
            this.buttonSTOP.BackColor = System.Drawing.Color.Tomato;
            this.buttonSTOP.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSTOP.Location = new System.Drawing.Point(343, 276);
            this.buttonSTOP.Name = "buttonSTOP";
            this.buttonSTOP.Size = new System.Drawing.Size(145, 72);
            this.buttonSTOP.TabIndex = 2;
            this.buttonSTOP.Text = "STOP";
            this.buttonSTOP.UseVisualStyleBackColor = false;
            this.buttonSTOP.Click += new System.EventHandler(this.buttonSTOP_Click);
            // 
            // timerCiclo
            // 
            this.timerCiclo.Interval = 5000;
            this.timerCiclo.Tick += new System.EventHandler(this.timerCiclo_Tick);
            // 
            // Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 361);
            this.Controls.Add(this.buttonSTOP);
            this.Controls.Add(this.buttonSTART);
            this.Controls.Add(this.listView1);
            this.Name = "Screen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Screen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView listView1;
        private Button buttonSTART;
        private Button buttonSTOP;
        private System.Windows.Forms.Timer timerCiclo;
    }
}