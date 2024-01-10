using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Parametro.Desings;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Parametro.Class
{
    public class ConexionDB
    {
        public static string direccionIP { get; set; }
        public static string puertoSql { get; set; }
        public static string baseDatos { get; set; }
        public static string numeroCierre { get; set; }
        public static string connectionPass { get; set; }
        public static string equipoLinkedServer { get; set; }
        public static string puertoLinkedServer { get; set; }
        public static string usuarioBase { get; set; }
        public static string baseLikedServer { get; set; }

        bool isSucess = false;

        public ConexionDB() { }

        #region String Conexión Base
        public string StringConexion()
        {
            var stringCadenaConexion = $"Data Source = {direccionIP},{puertoSql}; " +
                $"Initial Catalog = {baseDatos}; " +
                $"User ID = sa; Password={connectionPass};" +
                "Connect Timeout = 2; Encrypt=False;" +
                "TrustServerCertificate=False;ApplicationIntent = ReadWrite;" +
                "MultiSubnetFailover=False";

            return stringCadenaConexion;
        }
        #endregion

        #region String Conexion Master
        public string StringConexionMaster()
        {
            var stringCadenaMaster = $"Data Source={direccionIP},{puertoSql};Initial Catalog=master;" +
                $"User Id=sa;Password={connectionPass};Connect Timeout = 2;";

            return stringCadenaMaster;
        }
        #endregion

        #region Cargar Nombre de Bases
        public void CargarNombresBasesDeDatos(ComboBox comboBox)
        {
            // Obtiene la cadena de conexión maestra
            string cadenaConexion = StringConexionMaster();

            // Limpia los elementos existentes en el ComboBox
            comboBox.Items.Clear();

            // Consulta para obtener los nombres de bases de datos específicas en estado 'ONLINE'
            string consulta = "SELECT name FROM sys.databases " +
                "WHERE state_desc = 'ONLINE' " +
                "AND name IN('Backoffice','Comanda','Empresa','Cinet_PDV','Cinet_PDV_Totem','Cinet_PDV_Auto') OR name LIKE '%PDV%'";

            try
            {
                // Establece la conexión a la base de datos
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    // Abre la conexión
                    conexion.Open();
                    // Ejecuta la consulta SQL
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        // Lee los resultados de la consulta
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Agrega el nombre de la base de datos al ComboBox en minúsculas
                                comboBox.Items.Add(reader["name"].ToString().ToLower());
                            }
                        }
                    }

                    if (UsuarioExiste(conexion, comboBox))
                    {
                        // Registra la consulta SQL en el log
                        Log.Information("SQL Query: \n" + consulta);

                        // Muestra un mensaje indicando que la conexión fue exitosa
                        MessageBox.Show("Conexion Exitosa.");
                    }
                    else
                    {
                        // Manejo en caso de que el usuario no exista
                        MessageBox.Show("El usuario no existe o no está habilitado.");

                        // Limpia los elementos del ComboBox si el usuario no existe
                        comboBox.Items.Clear();
                    }

                    // Cierra la conexión a la base de datos
                    conexion.Close();
                }
            }
            // Captura excepciones específicas de SQL Server
            catch (SqlException ex)
            {
                // Registra el error en el log
                Log.Error("ERROR QUERY: " + ex.Message);
                // Muestra un mensaje de error al usuario
                MessageBox.Show("No se logro la conexión con la base de datos, verifique los datos ingresados. \nVer Error: " + ex.Message);
            }
        }
        #endregion

        #region Traer Bases de Linked Server
        public void CargarNombresBasesDeDatos(ComboBox comboBox, string equipoLoginLinkedServer, string puertoLoginLinkedServer)
        {
            // Obtiene la cadena de conexión maestra
            string cadenaConexion = StringConexionMaster();

            // Limpia los elementos existentes en el ComboBox
            comboBox.Items.Clear();
            // Consulta para obtener los nombres de bases de datos específicas en estado 'ONLINE'
            string queryAddLinkedServer = $"exec sp_addlinkedserver  [{equipoLinkedServer},{puertoLinkedServer}];";
            string consulta = $"SELECT name FROM OPENQUERY([{equipoLoginLinkedServer},{puertoLoginLinkedServer}], 'SELECT name FROM sys.databases WHERE state_desc = ''ONLINE'' AND name IN (''Backoffice'', ''Comanda'', ''Empresa'', ''Cinet_PDV'', ''Cinet_PDV_Totem'', ''Cinet_PDV_Auto'') OR name LIKE ''%PDV%'' ');";

            try
            {
                // Establece la conexión a la base de datos
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    // Abre la conexión
                    conexion.Open();
                    // Ejecuta la consulta SQL
                    try
                    {
                        // Intenta ejecutar el primer SqlCommand para agregar el linked server
                        using (SqlCommand comandoAddLinkedServer = new SqlCommand(queryAddLinkedServer, conexion))
                        {
                            comandoAddLinkedServer.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Registra el error en el log y muestra un mensaje de advertencia
                        Log.Warning("ADVERTENCIA QUERY (Linked Server): \n" + ex.ToString());
                        MessageBox.Show(ex.Message);
                    }
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        // Lee los resultados de la consulta
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Agrega el nombre de la base de datos al ComboBox en minúsculas
                                comboBox.Items.Add(reader["name"].ToString().ToLower());
                            }
                        }
                    }
                    // Registra la consulta SQL en el log
                    Log.Information("SQL Query: \n" + consulta);

                    // Muestra un mensaje indicando que la conexión fue exitosa
                    MessageBox.Show("Conexion Exitosa.");
                    // Cierra la conexión a la base de datos
                    conexion.Close();
                }
            }
            // Captura excepciones específicas de SQL Server
            catch (SqlException ex)
            {
                // Registra el error en el log
                Log.Error("ERROR QUERY: n" + ex.ToString());
                // Muestra un mensaje de error al usuario
                MessageBox.Show("No se logro la conexión con la base de datos, verifique los datos ingresados. \nVer Error: " + ex.Message);
            }
        }
        #endregion

        #region Verificar Linked Server
        public string VerificarLinkedServer()
        {
            if(LoginForm.checkLinkedServer is true)
            {
                return $"[{equipoLinkedServer},{puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.";
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region Usuario Existe
        public bool UsuarioExiste(SqlConnection conexion, ComboBox comboBoxBases)
        {
            foreach (string bases in comboBoxBases.Items)
            {
                string sqlQuery = $"SELECT COUNT(*) FROM [{bases}].dbo.USUARIOS WHERE USUARIO = '{usuarioBase}' AND USU_CATEGORIA = 'ADMIN'";

                using (SqlCommand comando = new SqlCommand(sqlQuery, conexion))
                {
                    int count = (int)comando.ExecuteScalar();

                    if (count > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region Obtener Valores de Parametros
        public string ObtenerValorDesdeBD(string consulta)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(StringConexion()))
                {
                    sqlConnection.Open();

                    using (SqlCommand comando = new SqlCommand(consulta, sqlConnection))
                    {
                        SqlDataReader reader = comando.ExecuteReader();
                        if (reader.Read())
                        {
                            return reader["para_valor"].ToString();
                        }
                        return "NE";

                    }
                    sqlConnection.Close();
                }

            }
            catch (Exception ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                return string.Empty;
            }
        }
        #endregion

        #region Obtener Valores de Comercio
        public string ObtenerValorComercioDesdeBD(string consulta)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(StringConexion()))
                {
                    sqlConnection.Open();

                    using (SqlCommand comando = new SqlCommand(consulta, sqlConnection))
                    {
                        SqlDataReader reader = comando.ExecuteReader();
                        if (reader.Read())
                        {
                            return reader["lpo_numcomercio"].ToString();
                        }
                        return "NE";

                    }
                    sqlConnection.Close();
                }

            }
            catch (Exception ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                return string.Empty;
            }
        }
        #endregion

        #region Traer Datos de Equipo
        public string TraerDatosEquipo(string form, string nombreBaseDatos, string nombreEquipo)
        {
            return form + " - " + nombreBaseDatos + " - " + nombreEquipo;
        }
        #endregion
    }
}
