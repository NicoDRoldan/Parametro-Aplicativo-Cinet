using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
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
        public static string pais { get; set; }

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

        #region Traer bases de datos

        public void TraerBasesDeDatos(ComboBox bases, bool linkedServer)
        {
            // Limpiar elementos existentes
            bases.Items.Clear();

            string query = "SELECT name FROM sys.databases " +
                "WHERE state_desc = 'ONLINE' " +
                "AND name IN('Backoffice','Comanda','Empresa','Cinet_PDV','Cinet_PDV_Totem','Cinet_PDV_Auto') OR (name LIKE '%PDV%'" +
                "and state_desc = 'ONLINE') OR (name LIKE '%Backoffice%'" +
                "and state_desc = 'ONLINE')";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(StringConexionMaster()))
                {
                    sqlConnection.Open();
                    if (linkedServer)
                    {
                        AddLinkedServer();
                        query = $"SELECT name FROM OPENQUERY([{equipoLinkedServer},{puertoLinkedServer}], 'SELECT name " +
                        $"FROM sys.databases WHERE state_desc = ''ONLINE'' " +
                        $"AND name IN (''Backoffice'', ''Comanda'', ''Empresa'', ''Cinet_PDV'', ''Cinet_PDV_Totem'', ''Cinet_PDV_Auto'') OR name LIKE ''%PDV%'' ');";
                    }

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                bases.Items.Add(sqlDataReader["name"].ToString().ToLower());
                            }
                        }
                    }
                    Log.Information($"Function TraerBasesDeDatos(...)\nQuery\n: {query}");
                    MessageBox.Show("Conexion Exitosa.");
                    sqlConnection.Close();
                }
            }
            catch( SqlException ex)
            {
                MessageBox.Show("No se logro la conexión con la base de datos, verifique los datos ingresados. \nVer Error: " + ex.Message);
                Log.Error($"Error - Function TraerBasesDeDatos(...)\nQuery\n: {query}\nMessage Error: {ex.Message}");
            }
        }

        public void AddLinkedServer()
        {
            string query = $"exec sp_addlinkedserver [{equipoLinkedServer},{puertoLinkedServer}];";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(StringConexionMaster()))
                {
                    sqlConnection.Open();

                    if (!VerificarExistenciaDeLinkedServer(sqlConnection))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error($"Error - Function VerificarExistenciaDeLinkedServer(...)\nQuery\n: {query}\nMessage Error: {ex.Message}");
            }
        }

        public bool VerificarExistenciaDeLinkedServer(SqlConnection sqlConnection)
        {
            string query = $"SELECT COUNT(*) FROM sys.servers WHERE is_lined = 1 and name = '{equipoLinkedServer},{puertoLinkedServer}'";

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    int count = (int)sqlCommand.ExecuteScalar();
                    if (count > 0) return true;
                }
            }
            catch (SqlException ex)
            {
                Log.Error($"Error - Function VerificarExistenciaDeLinkedServer(...)\nQuery\n: {query}\nMessage Error: {ex.Message}");
            }
            return false;
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

        #region Traer Equipos Linked Server
        public void CargarEquiposLinkedServer(ComboBox comboBox)
        {
            // Consulta para obtener los equipos asociados a la base de datos del servidor principal.
            string query = "USE[Backoffice]; " +
                "DECLARE @infoCaja TABLE([caja] varchar(10), [equipo] varchar(50), [version] varchar(50) );" +
                "\r\n\r\nINSERT INTO @infoCaja\r\nSELECT DISTINCT caja, EQUIPO, valor \r\nFROM (\r\n    SELECT RANK() OVER " +
                "(\r\n        PARTITION BY caja, parametro\r\n        ORDER BY fechatrans DESC) rango, *\r\n    " +
                "FROM hparamloc\r\n    WHERE parametro = 'VERSION') pinga\r\nWHERE rango = 1\r\nORDER BY equipo;\r\n\r\n" +
                "SELECT LEFT(equipo, CHARINDEX('#', equipo + '#') - 1) AS equipo\r\nFROM (\r\n    " +
                "SELECT \r\n        ROW_NUMBER() OVER (PARTITION BY v.vene_caja ORDER BY v.vene_fecha DESC) " +
                "AS rn,\r\n        v.vene_caja,\r\n        v.suc_codigo,\r\n        i.equipo\r\n    FROM VENTAS_E v\r\n    " +
                "INNER JOIN @infoCaja i ON v.vene_caja = i.caja COLLATE SQL_Latin1_General_CP1_CI_AS\r\n    " +
                "WHERE v.vene_caja != ''\r\n) AS subquery\r\nWHERE rn = 1\r\nORDER BY equipo;";
            try
            {
                using(SqlConnection sqlConnection = new SqlConnection(StringConexion())) // Establece la conexión
                {
                    sqlConnection.Open(); // Abre la conexión

                    using(SqlCommand sqlCommand =  new SqlCommand(query, sqlConnection)) // Ejecuta la query
                    {
                        using(SqlDataReader reader = sqlCommand.ExecuteReader()) // Lee los resultados
                        {
                            while (reader.Read())
                            {
                                // Agrega los resultados en el ComboBox de Equipos
                                comboBox.Items.Add(reader["equipo"].ToString().ToUpper().Trim());
                            }
                        }
                    }
                }
                // Registra el error en el log
                Log.Information("QUERY: " + query);
            }
            catch(SqlException ex)
            {
                // Registra el error en el log
                Log.Error("ERROR QUERY: " + ex.Message);
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
            string query = $"SELECT PARA_VALOR FROM {VerificarLinkedServer()}PARAMETROS WHERE PARA_CODIGO = 'NOMLOCAL'";

            string codLocal = "" ;

            try
            {
                using (SqlConnection sqlConnection =new SqlConnection(StringConexion())) 
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand (query, sqlConnection))
                    {
                        using (SqlDataReader reader = sqlCommand.ExecuteReader()) {
                            while (reader.Read())
                            {
                                codLocal = reader["PARA_VALOR"].ToString();
                            }
                        }
                    }
                    sqlConnection.Close();

                }
            }
            catch (SqlException ex)
            {
                Log.Error(ex.ToString());
                
            }

            if (!nombreEquipo.IsNullOrEmpty())
            {
                return form + " - " + nombreEquipo.ToUpper() + " - " + codLocal.ToUpper();
            }

            return form + " - " + codLocal.ToUpper();
        }
        #endregion
    }
}
