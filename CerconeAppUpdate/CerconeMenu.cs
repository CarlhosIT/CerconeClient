using CerconeClient.Services;
using System;
using System.Windows.Forms;

namespace CerconeAppUpdate
{
    public partial class CerconeMenu : Form
    {
        public CerconeMenu()
        {
            InitializeComponent();
        }

        private void UpdateData_Click(object sender, EventArgs e)
        {
            var client = new CerconeData();
            client.UpdatePsjData();
            MostrarMensaje(sender, e);
        }
        private void MostrarMensaje(object sender, EventArgs e)
        {
            MessageBox.Show("La actualizacion se realizo correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
