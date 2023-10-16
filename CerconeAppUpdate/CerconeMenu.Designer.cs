namespace CerconeAppUpdate
{
    partial class CerconeMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CerconeMenu));
            this.UpdateData = new System.Windows.Forms.Button();
            this.PonerRuta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UpdateData
            // 
            this.UpdateData.BackColor = System.Drawing.Color.Crimson;
            this.UpdateData.BackgroundImage = global::CerconeAppUpdate.Properties.Resources.Boton_Actualizar;
            this.UpdateData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpdateData.Location = new System.Drawing.Point(403, 12);
            this.UpdateData.Name = "UpdateData";
            this.UpdateData.Size = new System.Drawing.Size(174, 105);
            this.UpdateData.TabIndex = 0;
            this.UpdateData.UseVisualStyleBackColor = false;
            this.UpdateData.Click += new System.EventHandler(this.UpdateData_Click);
            // 
            // PonerRuta
            // 
            this.PonerRuta.Enabled = false;
            this.PonerRuta.Location = new System.Drawing.Point(60, 193);
            this.PonerRuta.Name = "PonerRuta";
            this.PonerRuta.Size = new System.Drawing.Size(94, 33);
            this.PonerRuta.TabIndex = 2;
            this.PonerRuta.Text = "Seleccionar";
            this.PonerRuta.UseVisualStyleBackColor = true;
            this.PonerRuta.Click += new System.EventHandler(this.PonerRuta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(60, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(674, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "C:\\Users\\carlh\\OneDrive\\Documents\\Elder Scrolls Online\\live\\AddOns\\CerconeAddon\\C" +
    "erconeClient";
            // 
            // CerconeMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.BackgroundImage = global::CerconeAppUpdate.Properties.Resources.Sin_titulo_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(976, 277);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PonerRuta);
            this.Controls.Add(this.UpdateData);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CerconeMenu";
            this.Text = "Cercone Menu";
            this.Load += new System.EventHandler(this.CerconeMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UpdateData;
        private System.Windows.Forms.Button PonerRuta;
        private System.Windows.Forms.Label label1;
    }
}