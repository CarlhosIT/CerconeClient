using ValkClient.Services;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ValkClient
{
    public partial class ValkMenu : Form
    {
        public ValkMenu()
        {
            InitializeComponent();
        }

        private async void UpdateData_Click(object sender, EventArgs e)
        {
            UpdateData.Enabled = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                var client = new ValkData();
                await client.UpdatePsjDataAsync(label1.Text);
                MessageBox.Show("La actualización se realizó correctamente", "Confirmación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"No se pudo actualizar:\n\n{ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                UpdateData.Enabled = true;
            }
        }

        private void PonerRuta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Dialogo = new FolderBrowserDialog
            {
                Description = "Selecciona una carpeta",
                RootFolder = Environment.SpecialFolder.MyComputer,
                ShowNewFolderButton = false
            };

            DialogResult Resultado = Dialogo.ShowDialog();

            if (Resultado == DialogResult.OK)
            {
                string RutaCarpeta = Dialogo.SelectedPath;
                label1.Text= RutaCarpeta;
            }
        }

        private void ValkMenu_Load(object sender, EventArgs e)
        {
            label1.Text = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
        }
    }
}
