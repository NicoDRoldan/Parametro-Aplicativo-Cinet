using Parametro.Desings;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parametro.Class
{
    internal class Functions
    {

        public static void HacerBackup()
        {
            ConexionDB conexionDB = new ConexionDB();

            // Ruta del backup
            string backupPath = @"C:\Cinet\";

            // Si la ruta del backup no existe, la crea
            if(!Directory.Exists(backupPath)) Directory.CreateDirectory(backupPath);

            //string dateBackup = DateTime.Today.ToString("ddMMyy");
            string dateBackup = DateTime.Now.ToString("ddMMyyHHmmss");
            
            string backupFileName = ConexionDB.baseDatos + "-" + dateBackup + ".bak";

            if (LoginForm.checkLinkedServer is true)
                backupFileName = ConexionDB.baseLikedServer + "-" + dateBackup + ".bak";

            string backupFile = Path.Combine(backupPath, backupFileName);

            if(File.Exists(backupFile)) File.Delete(backupFile);

            string queryBackup = "BACKUP DATABASE @dataBase TO DISK = @backupPath";

            if (LoginForm.checkLinkedServer is true) 
                queryBackup = $"EXEC ('BACKUP DATABASE {ConexionDB.baseLikedServer} TO DISK = ''{backupFile}''') AT [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}]";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryBackup, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@dataBase", ConexionDB.baseDatos);
                        sqlCommand.Parameters.AddWithValue("@backupPath", backupFile);
                        sqlCommand.CommandTimeout = 600; // 10 minutos en segundos

                        sqlCommand.ExecuteNonQuery();
                    }

                    sqlConnection.Close();
                }
                Log.Information("SQL Query: \n" + queryBackup);
                MessageBox.Show($"Backup realizado con éxito en la ruta: {backupFile}", "Backup Éxitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                if(ex.ErrorCode == -2146232060)
                    MessageBox.Show("Error al realizar el Backup. No se encontró la ruta para realizar el Backup.", "Error al hacer el Backup.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Error al realizar el backup. " + ex.Message, "Error al hacer el Backup.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Log.Error("Error al realizar el backup.\n" + ex.Message + "\nSQL Query: \n" + queryBackup);
            }
        }
    }
}
