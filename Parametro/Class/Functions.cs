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
            string backupPath = @"C:\Cinet\Backup";

            // Si la ruta del backup no existe, la crea
            if(!Directory.Exists(backupPath)) Directory.CreateDirectory(backupPath);

            //string dateBackup = DateTime.Today.ToString("ddMMyy");
            string dateBackup = DateTime.Now.ToString("ddMMyyHHmmss");
            string backupFileName = ConexionDB.baseDatos + "-" + dateBackup + ".bak";
            string backupFile = Path.Combine(backupPath, backupFileName);

            if(File.Exists(backupFile)) File.Delete(backupFile);

            string queryBackup = "BACKUP DATABASE @dataBase TO DISK = @backupPath";

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
            
            MessageBox.Show("Backup realizado con éxito", "Backup Éxitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
