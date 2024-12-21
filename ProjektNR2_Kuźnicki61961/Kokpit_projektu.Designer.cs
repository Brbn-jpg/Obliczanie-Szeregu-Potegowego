namespace ProjektNR2_Kuźnicki61961
{
    partial class Kokpit_projektu
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSzeregLaboratoryjny = new System.Windows.Forms.Button();
            this.btnSzeregIndywidualny = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSzeregLaboratoryjny
            // 
            this.btnSzeregLaboratoryjny.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.btnSzeregLaboratoryjny.Location = new System.Drawing.Point(39, 144);
            this.btnSzeregLaboratoryjny.Name = "btnSzeregLaboratoryjny";
            this.btnSzeregLaboratoryjny.Size = new System.Drawing.Size(256, 83);
            this.btnSzeregLaboratoryjny.TabIndex = 0;
            this.btnSzeregLaboratoryjny.Text = "labolatorium nr2 (analizator laboratoryjnego szeregu potęgowego)";
            this.btnSzeregLaboratoryjny.UseVisualStyleBackColor = true;
            this.btnSzeregLaboratoryjny.Click += new System.EventHandler(this.btnSzeregLaboratoryjny_Click);
            // 
            // btnSzeregIndywidualny
            // 
            this.btnSzeregIndywidualny.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSzeregIndywidualny.Location = new System.Drawing.Point(471, 144);
            this.btnSzeregIndywidualny.Name = "btnSzeregIndywidualny";
            this.btnSzeregIndywidualny.Size = new System.Drawing.Size(282, 83);
            this.btnSzeregIndywidualny.TabIndex = 1;
            this.btnSzeregIndywidualny.Text = "projekt nr2 (analizator indywidualnego szeregu potegowego)";
            this.btnSzeregIndywidualny.UseVisualStyleBackColor = true;
            this.btnSzeregIndywidualny.Click += new System.EventHandler(this.btnSzeregIndywidualny_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(236, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Analizator szeregów potęgowych";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Kokpit_projektu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSzeregIndywidualny);
            this.Controls.Add(this.btnSzeregLaboratoryjny);
            this.Name = "Kokpit_projektu";
            this.Text = "Kokpit Projektu Nr2 Kuźnicki61961";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Kokpit_projektu_FormClosing_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSzeregLaboratoryjny;
        private System.Windows.Forms.Button btnSzeregIndywidualny;
        private System.Windows.Forms.Label label2;
    }
}

