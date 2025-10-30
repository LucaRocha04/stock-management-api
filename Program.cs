using SistemaVentas.Data;
using SistemaVentas.Forms;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SistemaVentas
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configura la aplicación para usar estilos visuales modernos
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Inicializar la base de datos SQLite
                using (var context = new VentasContext())
                {
                    context.Database.EnsureCreated();
                    
                    // Agregar datos de prueba si no existen
                    context.InsertSampleData();
                }

                // Ejecutar el formulario principal
                Application.Run(new FormPrincipal());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar la aplicación: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}