using CerconeClient.Services;
using System;
using System.Reflection;
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
            client.UpdatePsjData(label1.Text);
            MostrarMensaje(sender, e);
        }
        private void MostrarMensaje(object sender, EventArgs e)
        {
            MessageBox.Show("La actualizacion se realizo correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PonerRuta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialogo = new FolderBrowserDialog();

            dialogo.Description = "Selecciona una carpeta";
            dialogo.RootFolder = Environment.SpecialFolder.MyComputer;
            dialogo.ShowNewFolderButton = false;

            DialogResult resultado = dialogo.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                string rutaCarpeta = dialogo.SelectedPath;
                label1.Text= rutaCarpeta;
            }
        }

        private void CerconeMenu_Load(object sender, EventArgs e)
        {
            var path=Assembly.GetExecutingAssembly().Location;
            label1.Text = path;
        }
    }
}
