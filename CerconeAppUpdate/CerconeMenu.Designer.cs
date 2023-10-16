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
            this.SuspendLayout();
            // 
            // UpdateData
            // 
            this.UpdateData.BackColor = System.Drawing.Color.Crimson;
            this.UpdateData.BackgroundImage = global::CerconeAppUpdate.Properties.Resources.Boton_Actualizar;
            this.UpdateData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpdateData.Location = new System.Drawing.Point(243, 12);
            this.UpdateData.Name = "UpdateData";
            this.UpdateData.Size = new System.Drawing.Size(192, 117);
            this.UpdateData.TabIndex = 0;
            this.UpdateData.UseVisualStyleBackColor = false;
            this.UpdateData.Click += new System.EventHandler(this.UpdateData_Click);
            // 
            // CerconeMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.BackgroundImage = global::CerconeAppUpdate.Properties.Resources.Sin_titulo_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(684, 143);
            this.Controls.Add(this.UpdateData);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CerconeMenu";
            this.Text = "Cercone Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UpdateData;
    }
}