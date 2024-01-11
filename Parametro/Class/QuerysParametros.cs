﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Parametro.Desings;
using Parametro.Models;
using Serilog;

namespace Parametro.Class
{
    internal class QuerysParametros
    {
        ConexionDB connectDB = new ConexionDB();

        #region Habilitar Parametro
        public void HabilitarParametro(string para_codigo, string para_descripcion, string valorParametro)
        {
            ConexionDB conexionDB = new ConexionDB();

            string cadenaConexion = conexionDB.StringConexion();

            string queryUpdateS = $"IF NOT EXISTS (SELECT * FROM PARAMETROS WHERE PARA_CODIGO = '{para_codigo}') INSERT INTO PARAMETROS VALUES ('{para_codigo}','{para_descripcion}','S',NULL,NULL) ELSE UPDATE PARAMETROS SET PARA_VALOR = 'S' WHERE PARA_CODIGO = '{para_codigo}'";
            string queryUpdateN = $"UPDATE PARAMETROS SET PARA_VALOR = 'N' WHERE PARA_CODIGO = '{para_codigo}'";

            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    CinetPdvForm cinetPdvForm = new CinetPdvForm();

                    if (valorParametro != "S")
                    {
                        using (SqlCommand command = new SqlCommand(queryUpdateS, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        Log.Information("SQL Query: \n" + queryUpdateS);
                    }
                    else if (valorParametro == "S")
                    {
                        using (SqlCommand command = new SqlCommand(queryUpdateN, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        Log.Information("SQL Query: \n" + queryUpdateN);
                    }
                    MessageBox.Show($"Se actualizó el parametro {para_codigo}");
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                // Registra el error en el log
                Log.Error("ERROR QUERY: n" + ex.ToString());
                // Muestra un mensaje de error al usuario
                MessageBox.Show("No se realizó el cambio. \nVer Error: " + ex.Message);
            }
        }
        #endregion

        #region Habilitar Parametro Linked Server
        public void HabilitarParametro(string para_codigo, string para_descripcion, string valorParametro, string equipoLinkedServer, string puertoLinkedServer, string baseDatos)
        {
            ConexionDB conexionDB = new ConexionDB();

            string cadenaConexion = conexionDB.StringConexion();

            string queryUpdateS = $"IF NOT EXISTS (SELECT * FROM [{equipoLinkedServer},{puertoLinkedServer}].[{baseDatos}].DBO.PARAMETROS WHERE PARA_CODIGO = '{para_codigo}') INSERT INTO [{equipoLinkedServer},{puertoLinkedServer}].[{baseDatos}].DBO.PARAMETROS VALUES ('{para_codigo}','{para_descripcion}','S',NULL,NULL) ELSE UPDATE [{equipoLinkedServer},{puertoLinkedServer}].[{baseDatos}].DBO.PARAMETROS SET PARA_VALOR = 'S' WHERE PARA_CODIGO = '{para_codigo}'";
            string queryUpdateN = $"UPDATE [{equipoLinkedServer},{puertoLinkedServer}].[{baseDatos}].DBO.PARAMETROS SET PARA_VALOR = 'N' WHERE PARA_CODIGO = '{para_codigo}'";

            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    CinetPdvForm cinetPdvForm = new CinetPdvForm();

                    if (valorParametro != "S")
                    {
                        using (SqlCommand command = new SqlCommand(queryUpdateS, connection))
                        {
                            command.ExecuteNonQuery();
                            cinetPdvForm.SERV_DVY.Text = valorParametro;
                        }

                        Log.Information("SQL Query: \n" + queryUpdateS);
                    }
                    else if (valorParametro == "S")
                    {
                        using (SqlCommand command = new SqlCommand(queryUpdateN, connection))
                        {
                            command.ExecuteNonQuery();
                            cinetPdvForm.SERV_DVY.Text = valorParametro;
                        }

                        Log.Information("SQL Query: \n" + queryUpdateN);
                    }
                    MessageBox.Show($"Se actualizó el parametro {para_codigo}");
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                // Registra el error en el log
                Log.Error("ERROR QUERY: n" + ex.ToString());
                // Muestra un mensaje de error al usuario
                MessageBox.Show("No se realizó el cambio. \nVer Error: " + ex.Message);
            }
        }
        #endregion

        #region Update Parametro
        public void UpdateParametro(string para_codigo, string para_descripcion, string para_valor)
        {
            ConexionDB conexionDB = new ConexionDB();

            string cadenaConexion = conexionDB.StringConexion();

            string queryUpdate = $"DECLARE @PARACODIGO VARCHAR(100) = '{para_codigo}' DECLARE @PARAVALOR VARCHAR(100) = '{para_valor}' IF NOT EXISTS (SELECT * FROM PARAMETROS WHERE PARA_CODIGO = @PARACODIGO) INSERT INTO PARAMETROS VALUES (@PARACODIGO,'{para_descripcion}',@PARAVALOR,NULL,NULL) ELSE UPDATE PARAMETROS SET PARA_VALOR = @PARAVALOR WHERE PARA_CODIGO = @PARACODIGO";

            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(queryUpdate, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    Log.Information("SQL Query: \n" + queryUpdate);

                    MessageBox.Show($"Se actualizó el parametro {para_codigo}");
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                // Registra el error en el log
                Log.Error("ERROR QUERY: n" + ex.ToString());
                // Muestra un mensaje de error al usuario
                MessageBox.Show("No se realizó el cambio. \nVer Error: " + ex.Message);
            }
        }
        #endregion

        #region Update Parametro Linked Server
        public void UpdateParametro(string para_codigo, string para_descripcion, string para_valor, string equipoLinkedServer, string puertoLinkedServer, string baseDatos)
        {
            ConexionDB conexionDB = new ConexionDB();

            string cadenaConexion = conexionDB.StringConexion();

            string queryUpdate = $"DECLARE @PARACODIGO VARCHAR(100) = '{para_codigo}' DECLARE @PARAVALOR VARCHAR(100) = '{para_valor}' IF NOT EXISTS (SELECT * FROM [{equipoLinkedServer},{puertoLinkedServer}].[{baseDatos}].DBO.PARAMETROS WHERE PARA_CODIGO = @PARACODIGO) INSERT INTO [{equipoLinkedServer},{puertoLinkedServer}].[{baseDatos}].DBO.PARAMETROS VALUES (@PARACODIGO,'{para_descripcion}',@PARAVALOR,NULL,NULL) ELSE UPDATE [{equipoLinkedServer},{puertoLinkedServer}].[{baseDatos}].DBO.PARAMETROS SET PARA_VALOR = @PARAVALOR WHERE PARA_CODIGO = @PARACODIGO";

            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(queryUpdate, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    Log.Information("SQL Query: \n" + queryUpdate);

                    MessageBox.Show($"Se actualizó el parametro {para_codigo}");
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                // Registra el error en el log
                Log.Error("ERROR QUERY: n" + ex.ToString());
                // Muestra un mensaje de error al usuario
                MessageBox.Show("No se realizó el cambio. \nVer Error: " + ex.Message);
            }
        }
        #endregion

        #region Update Parametros Totem
        public void UpdateParametrosTotem()
        {
            ConexionDB conexionDB = new ConexionDB();

            string cadenaConexion = conexionDB.StringConexion();

            string queryUpdate = $"DECLARE @ValorParametroTotem VARCHAR(1) = (SELECT TOP 1 PARA_VALOR FROM PARAMETROS WHERE PARA_CODIGO = 'TOTEM') DECLARE @ValorParametroTotemPau VARCHAR(1) = (SELECT TOP 1 PARA_VALOR FROM PARAMETROS WHERE PARA_CODIGO = 'TOTEMPAU') IF NOT EXISTS ( SELECT * FROM PARAMETROS WHERE PARA_CODIGO = 'TOTEM') INSERT INTO PARAMETROS VALUES ('TOTEM','USA TOTEM','S',NULL,NULL) ELSE IF (@ValorParametroTotem = 'N') UPDATE PARAMETROS SET PARA_VALOR = 'S' WHERE PARA_CODIGO = 'TOTEM' ELSE UPDATE PARAMETROS SET PARA_VALOR = 'N' WHERE PARA_CODIGO = 'TOTEM' IF NOT EXISTS ( SELECT * FROM PARAMETROS WHERE PARA_CODIGO = 'TOTEMPAU') INSERT INTO PARAMETROS VALUES ('TOTEMPAU','USA TOTEM','S',NULL,NULL) ELSE IF (@ValorParametroTotem = 'N') UPDATE PARAMETROS SET PARA_VALOR = 'S' WHERE PARA_CODIGO = 'TOTEMPAU' ELSE UPDATE PARAMETROS SET PARA_VALOR = 'N' WHERE PARA_CODIGO = 'TOTEMPAU'";
            string queryUpdateLinkedServer = $"DECLARE @ValorParametroTotem VARCHAR(1) = (SELECT TOP 1 PARA_VALOR FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PARAMETROS WHERE PARA_CODIGO = 'TOTEM') DECLARE @ValorParametroTotemPau VARCHAR(1) = (SELECT TOP 1 PARA_VALOR FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PARAMETROS WHERE PARA_CODIGO = 'TOTEMPAU') IF NOT EXISTS ( SELECT * FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PARAMETROS WHERE PARA_CODIGO = 'TOTEM') INSERT INTO [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PARAMETROS VALUES ('TOTEM','USA TOTEM','S',NULL,NULL) ELSE IF (@ValorParametroTotem = 'N') UPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PARAMETROS SET PARA_VALOR = 'S' WHERE PARA_CODIGO = 'TOTEM' ELSE UPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PARAMETROS SET PARA_VALOR = 'N' WHERE PARA_CODIGO = 'TOTEM' IF NOT EXISTS ( SELECT * FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PARAMETROS WHERE PARA_CODIGO = 'TOTEMPAU') INSERT INTO [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PARAMETROS VALUES ('TOTEMPAU','USA TOTEM','S',NULL,NULL) ELSE IF (@ValorParametroTotem = 'N') UPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PARAMETROS SET PARA_VALOR = 'S' WHERE PARA_CODIGO = 'TOTEMPAU' ELSE UPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PARAMETROS SET PARA_VALOR = 'N' WHERE PARA_CODIGO = 'TOTEMPAU'";

            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    CinetPdvForm cinetPdvForm = new CinetPdvForm();

                    if (!LoginForm.checkLinkedServer is true)
                    {
                        using (SqlCommand command = new SqlCommand(queryUpdate, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        Log.Information("SQL Query: \n" + queryUpdate);
                    }
                    else
                    {
                        using (SqlCommand command = new SqlCommand(queryUpdateLinkedServer, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        Log.Information("SQL Query: \n" + queryUpdate);
                    }

                    MessageBox.Show($"Se actualizaron los parametros TOTEM y TOTEMPAU");
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                // Registra el error en el log
                Log.Error("ERROR QUERY: n" + ex.ToString());
                // Muestra un mensaje de error al usuario
                MessageBox.Show("No se realizó el cambio. \nVer Error: " + ex.Message);
            }
        }
        #endregion

        #region Configurar Rappi V2
        public DataTable ConfigurarRappiV2()
        {
            ConexionDB conexionDB = new ConexionDB();
            DataTable table = new DataTable();

            string stringConnection = conexionDB.StringConexion();

            string sqlQuery = $"DECLARE @storeID varchar(10); set @storeID = '{ParametrosModels.StoreIdRap}' DECLARE @UsaCafeteria varchar(4); set @UsaCafeteria = '{ParametrosModels.UsaCafe}' if not exists (select * from parametros where PARA_CODIGO = 'STOREIDRAP') insert into parametros values ('STOREIDRAP', 'Token Rappi', @storeID, NULL, NULL); else update parametros set PARA_VALOR = @storeID where PARA_CODIGO = 'STOREIDRAP' if ((@UsaCafeteria = 'S') AND (not exists (select * from parametros where PARA_CODIGO = 'RAP_CLI_I2'))) OR ((@UsaCafeteria = 'S') AND (exists (select * from parametros where PARA_CODIGO = 'RAP_CLI_I2'))) if (not exists (select * from parametros where PARA_CODIGO = 'RAP_CLI_I2')) insert into PARAMETROS values('RAP_CLI_I2','ClientId RAPPI API V2.0','g2tfre9tAbEvRN38iz6TKCZ81NidoPD2',NULL,NULL); else print('Nada'); else delete PARAMETROS where PARA_CODIGO in ('RAP_CLI_I2'); if ((@UsaCafeteria = 'S') AND (not exists (select * from parametros where PARA_CODIGO = 'RAP_CLI_S2'))) OR ((@UsaCafeteria = 'S') AND (exists (select * from parametros where PARA_CODIGO = 'RAP_CLI_S2'))) if (not exists (select * from parametros where PARA_CODIGO = 'RAP_CLI_S2')) insert into PARAMETROS values('RAP_CLI_S2','ClientSecret RAPPI API V2.0','f6jtwA2QpWSpr3Z5Ep6aIqDpumotTQVbG7iyZqFTiXqdxiNLSqkmKLLFSY24QiID',NULL,NULL); else print('Nada'); else delete PARAMETROS where PARA_CODIGO in ('RAP_CLI_S2'); update parametros set PARA_VALOR = 'g2tfre9tAbEvRN38iz6TKCZ81NidoPD2' where PARA_CODIGO = 'RAP_CLI_ID' update parametros set PARA_VALOR = 'f6jtwA2QpWSpr3Z5Ep6aIqDpumotTQVbG7iyZqFTiXqdxiNLSqkmKLLFSY24QiID' where PARA_CODIGO = 'RAP_CLI_SE' update parametros set PARA_VALOR = 'S' where PARA_CODIGO = 'RAPPI' update parametros set PARA_VALOR = '172DE6DCABD89246E988FBBB1FB300FB' where PARA_CODIGO = 'TKN_RAPPI' update parametros set PARA_VALOR = 'S' where PARA_CODIGO = 'V_RAPPI2' select PARA_CODIGO, PARA_DESCRIPCION, PARA_VALOR from parametros where PARA_CODIGO IN ('RAP_CLI_I2','RAP_CLI_ID','RAP_CLI_S2','RAP_CLI_SE','RAPPI','STOREIDRAP','TKN_RAPPI','V_RAPPI2')";
            string sqlQueryLinked = $"DECLARE @storeID varchar(10); SET @storeID = '{ParametrosModels.StoreIdRap}'; DECLARE @UsaCafeteria varchar(4); SET @UsaCafeteria = '{ParametrosModels.UsaCafe}'; IF NOT EXISTS (SELECT * FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros WHERE PARA_CODIGO = 'STOREIDRAP') INSERT INTO [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros VALUES ('STOREIDRAP', 'Token Rappi', @storeID, NULL, NULL); ELSE UPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros SET PARA_VALOR = @storeID WHERE PARA_CODIGO = 'STOREIDRAP' IF ((@UsaCafeteria = 'S') AND (NOT EXISTS (SELECT * FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros WHERE PARA_CODIGO = 'RAP_CLI_I2'))) OR ((@UsaCafeteria = 'S') AND (EXISTS (SELECT * FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros WHERE PARA_CODIGO = 'RAP_CLI_I2'))) BEGIN IF NOT EXISTS (SELECT * FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros WHERE PARA_CODIGO = 'RAP_CLI_I2') INSERT INTO [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PARAMETROS VALUES('RAP_CLI_I2','ClientId RAPPI API V2.0','g2tfre9tAbEvRN38iz6TKCZ81NidoPD2',NULL,NULL); ELSE PRINT('Nada'); END ELSE DELETE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PARAMETROS WHERE PARA_CODIGO IN ('RAP_CLI_I2'); IF ((@UsaCafeteria = 'S') AND (NOT EXISTS (SELECT * FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros WHERE PARA_CODIGO = 'RAP_CLI_S2'))) OR ((@UsaCafeteria = 'S') AND (EXISTS (SELECT * FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros WHERE PARA_CODIGO = 'RAP_CLI_S2'))) BEGIN IF NOT EXISTS (SELECT * FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros WHERE PARA_CODIGO = 'RAP_CLI_S2') INSERT INTO [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PARAMETROS VALUES('RAP_CLI_S2','ClientSecret RAPPI API V2.0','f6jtwA2QpWSpr3Z5Ep6aIqDpumotTQVbG7iyZqFTiXqdxiNLSqkmKLLFSY24QiID',NULL,NULL); ELSE PRINT('Nada'); END ELSE DELETE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PARAMETROS WHERE PARA_CODIGO IN ('RAP_CLI_S2'); UPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros SET PARA_VALOR = 'g2tfre9tAbEvRN38iz6TKCZ81NidoPD2' WHERE PARA_CODIGO = 'RAP_CLI_ID' UPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros SET PARA_VALOR = 'f6jtwA2QpWSpr3Z5Ep6aIqDpumotTQVbG7iyZqFTiXqdxiNLSqkmKLLFSY24QiID' WHERE PARA_CODIGO = 'RAP_CLI_SE' UPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros SET PARA_VALOR = 'S' WHERE PARA_CODIGO = 'RAPPI' UPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros SET PARA_VALOR = '172DE6DCABD89246E988FBBB1FB300FB' WHERE PARA_CODIGO = 'TKN_RAPPI' UPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros SET PARA_VALOR = 'S' WHERE PARA_CODIGO = 'V_RAPPI2' SELECT PARA_CODIGO, PARA_DESCRIPCION, PARA_VALOR FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.parametros WHERE PARA_CODIGO IN ('RAP_CLI_I2','RAP_CLI_ID','RAP_CLI_S2','RAP_CLI_SE','RAPPI','STOREIDRAP','TKN_RAPPI','V_RAPPI2')";

            if (!LoginForm.checkLinkedServer is true)
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(stringConnection))
                    {
                        sqlConnection.Open();

                        using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                            {
                                adapter.Fill(table);
                            }
                        }
                        Log.Information("SQL Query: \n" + sqlQuery);
                        MessageBox.Show($"Se realizó la configuración de Rappi");
                        sqlConnection.Close();
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("ERROR QUERY: n" + ex.ToString());
                    MessageBox.Show($"Error, leer la excepción completa en el Log. \n" + ex.Message);
                }

                return table;
            }
            else
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(stringConnection))
                    {
                        sqlConnection.Open();

                        using (SqlCommand sqlCommand = new SqlCommand(sqlQueryLinked, sqlConnection))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                            {
                                adapter.Fill(table);
                            }
                        }
                        Log.Information("SQL Query: \n" + sqlQuery);
                        MessageBox.Show($"Se realizó la configuración de Rappi");
                        sqlConnection.Close();
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("ERROR QUERY: n" + ex.ToString());
                    MessageBox.Show($"Error, leer la excepción completa en el Log. \n" + ex.Message);
                }

                return table;
            }

        }
        #endregion

        #region Verificar Cafeteria Rappi
        public bool RappiCafeActivo()
        {
            ConexionDB conexionDB = new ConexionDB();

            string query = $"SELECT COUNT(*) FROM BACKOFFICE.DBO.PARAMETROS WHERE PARA_CODIGO IN ('RAP_CLI_I2', 'RAP_CLI_S2')";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        int count = (int)sqlCommand.ExecuteScalar();
                        return (count > 1);
                    }

                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error (ex.ToString());
                return false;
            }
        }
        #endregion

        #region Configurar Mercado Pago
        public void ConfigurarMercadoPago()
        {
            string query = $"DECLARE @VARIABLEEXTERNAL VARCHAR(50); SET @VARIABLEEXTERNAL = (SELECT PARA_VALOR FROM {connectDB.VerificarLinkedServer()}PARAMETROS WHERE PARA_CODIGO = 'NOMLOCAL') + (SELECT PARA_VALOR FROM {connectDB.VerificarLinkedServer()}PARAMETROS WHERE PARA_CODIGO = 'PTOVTAFIS'); UPDATE {connectDB.VerificarLinkedServer()}PARAMETROS SET PARA_VALOR = @VARIABLEEXTERNAL WHERE PARA_CODIGO = 'EXTERIDMP';";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectDB.StringConexion()))
                {
                    sqlConnection.Open ();

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }

                    sqlConnection.Close();

                    Log.Information(query);
                }
            }
            catch (SqlException ex)
            {
                Log.Error (ex.ToString());
            }
        }
        #endregion

        #region Configurar Comprobantes_E
        public void ConfigurarComprobantesE()
        {
            ConexionDB conexionDB = new ConexionDB();

            string eliminarComprobantesE = $"DELETE {conexionDB.VerificarLinkedServer()}COMPROBANTES_E";
            string insertComprobantesE = $"INSERT INTO {conexionDB.VerificarLinkedServer()}COMPROBANTES_E VALUES (N'NDI', N'CPRAS', N'NOTA DE DEBITO', N'', N'S', N'S', N'N', N'11', N'+', N'+', N'+', 3, N'NDI', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'S', 0, N' '),(N'OFR', N'PROD', N'ORDEN DE FABRICACION', N' ', N'N', N'N', N'N', N'11', N' ', N' ', N' ', 0, N' ', N'N', N'N', N'N', N'N', N'N', N'N', N'N', N'N', N'N', 0, N' '),(N'OFS', N'PROD', N'ORDEN DE FABRICACION', N' ', N'N', N'N', N'N', N'11', N' ', N' ', N' ', 0, N' ', N'N', N'N', N'N', N'N', N'N', N'N', N'N', N'N', N'N', 0, N' '),(N'FAA  ', N'VTAS ', N'FACTURA A', N'', N'S', N'N', N'N', N'11', N'+', N'-', N'+', 5, N'FAA  ', N'N', N'N', N'N', N'N', N'S', N' ', N'N', N'N', N'N', 0, N' '),(N'REP', N'VTAS', N'REPROCESAR', N' ', N'N', N'N', N'N', N'33', N'+', N'+', N'-', 3, N'REP', N'N', N'N', N'N', N'N', N'N', N' ', N'N', N'N', N'N', 0, N' '),(N'FAB  ', N'VTAS ', N'FACTURA B', N'', N'S', N'N', N'N', N'14', N'+', N'-', N'+', 5, N'FAB  ', N'N', N'N', N'N', N'N', N'S', N' ', N'S', N'N', N'N', 0, N' '),(N'DNF', N'VTAS', N'PRENDAS X ABONO', N' ', N'N', N'N', N'N', N'11', N'-', N'+', N'-', 9, N'DNF', N'N', N'N', N'N', N'N', N'N', N'S', N'N', N'S', N' ', 0, N' '),(N'RMD', N'VTAS', N'REMITO EGRESO', N' ', N'N', N'N', N'N', N'4', N' ', N' ', N' ', 5, N'RMD', N'N', N'N', N'N', N'N', N'N', N'N', N'N', N'N', N'N', 0, N' '),(N'RMX', N'VTAS', N'REMITO', N' ', N'N', N'N', N'N', N'22', N' ', N'-', N' ', 3, N'RMX', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'OFM', N'PROD', N'ORDEN DE FABRICACION', N' ', N'N', N'N', N'N', N'11', N' ', N' ', N' ', 0, N' ', N'N', N'N', N'N', N'N', N'N', N'N', N'N', N'N', N'N', 0, N' '),(N'NCA  ', N'VTAS ', N'NOTA DE CREDITO A', N'', N'S', N'N', N'N', N'4 ', N'-', N'+', N'-', 5, N'NCA  ', N'N', N'N', N'N', N'N', N'S', N' ', N'N', N'N', N'N', 0, N' '),(N'PEA  ', N'VTAS ', N'PEDIDO ', N'', N'N', N'N', N'N', N'0 ', N' ', N'-', N'+', 2, N'PEA  ', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'ADU', N'CPRAS', N'DESPACHO ADUANA', N' ', N'S', N'S', N'N', N'45', N'+', N'+', N'+', 5, N'ADU', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'FAC  ', N'CPRAS', N'FACTURA C', N'', N'S', N'S', N'N', N'33', N'+', N'+', N'+', 5, N'FAC  ', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'NCB  ', N'VTAS ', N'NOTA DE CREDITO  ', N'', N'S', N'N', N'N', N'4 ', N'-', N'+', N'-', 5, N'FAB  ', N'N', N'N', N'N', N'N', N'S', N' ', N'S', N'N', N'N', 0, N' '),(N'PEB  ', N'VTAS ', N'PEDIDO ', N'', N'N', N'N', N'N', N'23', N'+', N'-', N'+', 2, N'PEB', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'OCA  ', N'CPRAS', N'ORDEN DE COMPRA  ', N'', N'N', N'N', N'N', N'11', N'+', N'+', N'+', 1, N'OCA  ', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'S', 0, N' '),(N'RMX  ', N'CPRAS', N'REMITO', N'', N'N', N'N', N'N', N'22', N' ', N'+', N' ', 3, N'RMX  ', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'FAB  ', N'CPRAS', N'FACTURA B', N'', N'S', N'S', N'N', N'1 ', N'+', N'+', N'+', 5, N'FAB  ', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'FAA  ', N'CPRAS', N'FACTURA A', N'', N'S', N'S', N'N', N'2 ', N'+', N'+', N'+', 5, N'FAA  ', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'NDA  ', N'VTAS ', N'NOTA DE DEBITO', N'', N'S', N'N', N'N', N'12', N'+', N'-', N'+', 5, N'NDA  ', N'N', N'N', N'N', N'N', N'N', N' ', N'N', N'N', N'N', 0, N' '),(N'PYA', N'PAUE', N'PEDIDO YA', N'', N'N', N'N', N'N', N'11', N'+', N'-', N'+', 5, N'FAB', N'N', N'N', N'N', N'N', N'S', N' ', N'S', N'N', N'N', 0, N' '),(N'NDA  ', N'CPRAS', N'NOTA DE DEBITO', N'', N'S', N'S', N'N', N'11', N'+', N'+', N'+', 3, N'NDA  ', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'NCA  ', N'CPRAS', N'NOTA DE CREDITO  ', N'', N'S', N'S', N'N', N'55', N'-', N'-', N'-', 5, N'NCA  ', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'NDB  ', N'CPRAS', N'NDB CPRAS', N'', N'S', N'S', N'N', N'66', N'+', N'+', N' ', 4, N'NDB  ', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'NDB  ', N'VTAS ', N'NOTA DE DEBITO B ', N'', N'S', N'N', N'N', N'45', N'+', N'-', N'+', 3, N'NDB  ', N'N', N'N', N'N', N'N', N'N', N' ', N'N', N'N', N'N', 0, N' '),(N'NCC  ', N'CPRAS', N'NOTA DE CREDITO C', N'', N'S', N'S', N'N', N'44', N'-', N'-', N'-', 3, N'NCC  ', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'NCB  ', N'CPRAS', N'NOTA DE CREDITO B', N'', N'S', N'S', N'N', N'45', N'-', N'-', N'-', 3, N'NCB  ', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'RIB  ', N'CPRAS', N'RETENCION IB', N'', N'S', N'N', N'N', N'5 ', N' ', N' ', N'-', 4, N'RIB  ', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'REQ', N'CPRAS', N'REQUERIMIENTO COMPRA', N' ', N'N', N'N', N'N', N'66', N' ', N'+', N' ', 5, N'REQ', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'S', 0, N' '),(N'TRS', N'CPRAS', N'TRANSFERENCIA INTERDEPOSITO - SALIDA', N' ', N'N', N'N', N'N', N'4', N' ', N'-', N' ', 5, N'TRS', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'OCC', N'CPRAS', N'OC COMPLEMENTARIA', N',', N'N', N'N', N'N', N'9', N'-', N'+', N'-', 5, N'OCA', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'S', 0, N' '),(N'RMD', N'CPRAS', N'REMITO POR DEVOLUCION', N' ', N'N', N'N', N'N', N'4', N' ', N'-', N' ', 5, N'RMD', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'FAE', N'CPRAS', N'FACTURA EXTERIOR', N' ', N'S', N'S', N'N', N'34', N'+', N'+', N'+', 5, N'FAE', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'TRF', N'CPRAS', N'ENVIO A FORMUL O FRAC', N' ', N'N', N'N', N'N', N'4', N' ', N'-', N' ', 5, N'TRF', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'FAI', N'CPRAS', N'IMPORTACION', N'', N'S', N'S', N'N', N'11', N'+', N'-', N'+', 5, N'FAI', N'N', N'N', N'N', N'N', N'N', N' ', N'N', N'N', N'N', 0, N' '),(N'NCI ', N'CPRAS', N'NOTA DE CREDITO', N'', N'S', N'S', N'N', N'55', N'-', N'-', N'-', 5, N'NCI', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'N', 0, N' '),(N'OCI', N'CPRAS', N'ORDEN DE IMPORTACION', N'', N'N', N'N', N'N', N'11', N'+', N'+', N'+', 1, N'OCI ', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'S', 0, N' '),(N'NDU', N'CPRAS', N'ND INTERNA X DIF COT', N'', N'N', N'S', N'N', N'11', N'+', N'+', N'+', 3, N'NDU', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'S', 0, N' '),(N'NCU', N'CPRAS', N'N C INTERNA X DIF COT', N'', N'N', N'S', N'N', N'11', N'-', N'-', N'-', 3, N'NCU', N'N', N'N', N'N', N'N', N'N', N' ', N'S', N'N', N'S', 0, N' '),(N'NDD', N'CPRAS', N'ND INTERNA X DIF COT SOLO UDS', N'', N'N', N'S', N'N', N'11', N'+', N'+', N'+', 3, N'NDD', N'N', N'N', N'N', N'N', N'N', N'N', N'S', N'N', N'S', 0, N'D'),(N'NCD', N'CPRAS', N'NC INTERNA X DIF COT SOLO UDS', N'', N'N', N'S', N'N', N'11', N'-', N'-', N'-', 3, N'NCD', N'N', N'N', N'N', N'N', N'N', N'N', N'S', N'N', N'S', 0, N'D');";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(eliminarComprobantesE, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }

                    using (SqlCommand sqlCommand = new SqlCommand(insertComprobantesE, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }

                    sqlConnection.Close();
                    Log.Information("Se reincertaron los registros de COMPROBANTES_E");
                }
            }
            catch (SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
            }
        }

        public bool VerificarRegistrosComprobantesE(SqlConnection sqlConnection)
        {
            ConexionDB conexionDB = new ConexionDB();

            string query = $"SELECT COUNT(*) FROM {conexionDB.VerificarLinkedServer()}COMPROBANTES_E";

            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                int count = (int)sqlCommand.ExecuteScalar();
                return (count >= 40);
            }
        }
        #endregion

        #region Configurar Comprobantes_N
        public void InsertarSucursalComprobantesN()
        {
            ConexionDB conexionDB = new ConexionDB();

            string Query = $"DECLARE @SUC_FISCAL VARCHAR(4) = '{ParametrosModels.sucFiscal}'; INSERT INTO {conexionDB.VerificarLinkedServer()}COMPROBANTES_N (CBTEE_MODULO, CBTEE_CODIGO, SUC_CODIGO, CBTEN_NUMERO, CBTEN_REPORTE, CBTEN_IMPRESORA, CBTEN_NUMERAENCOD, CBTEN_COPIAS, CBTEN_REPAUX, CBTEN_REPAUXN) VALUES ('VTAS','RMD',@SUC_FISCAL,'0','','CF','RMD','0','','0'), ('VTAS','DNF',@SUC_FISCAL,'0','','CF','DNF','0','','0'), ('VTAS','REP',@SUC_FISCAL,'0','VTA_PED','CF','REP','0','','0'), ('VTAS','RMX',@SUC_FISCAL,'0','','CF','RMX','0','','0'), ('VTAS','FAA',@SUC_FISCAL,'0','VTA_FAA','CF','FAA','0','','0'), ('VTAS','FAB',@SUC_FISCAL,'0','VTA_FAB','CF','FAB','0','','0'), ('VTAS','NCA',@SUC_FISCAL,'0','VTA_NCA','CF','NCA','0','','0'), ('VTAS','NCB',@SUC_FISCAL,'0','VTA_NCA','CF','NCB','0','','0'), ('VTAS','NDA',@SUC_FISCAL,'0','VTA_NCA','CF','NDA','0','','0'), ('VTAS','NDB',@SUC_FISCAL,'0','VTA_NCA','CF','NDB','0','','0');";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();

                    if (!VerificarRegistrosComprobantesE(sqlConnection))
                    {
                        ConfigurarComprobantesE();
                    }

                    using (SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
            }
        }
        #endregion

        #region Configurar Sucursales PDV
        public void InsertarSucursalesPDV()
        {
            ConexionDB conexionDB = new ConexionDB();

            string Query = $"DECLARE @SUC_FISCAL VARCHAR(4) = '{ParametrosModels.sucFiscal}'; INSERT INTO {conexionDB.VerificarLinkedServer()}SUCURSALES (SUC_CODIGO, SUC_DESCRIPCION, suc_local, SUC_MANUAL) VALUES(@SUC_FISCAL,'FISCAL','S','0');";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
            }
        }
        #endregion

        #region Configurar Sucursales Backoffice
        public void InsertarSucursalesBackoffice()
        {
            ConexionDB conexionDB = new ConexionDB();

            string Query = $"DECLARE @SUC_FISCAL VARCHAR(4) = '{ParametrosModels.sucFiscal}'; INSERT INTO [Backoffice].DBO.SUCURSALES (SUC_CODIGO, SUC_DESCRIPCION, suc_local, SUC_MANUAL) VALUES(@SUC_FISCAL,'FISCAL','S','0');";
            string QueryCbeinSucursal = $"DECLARE @SUC_FISCAL VARCHAR(4) = '{ParametrosModels.sucFiscal}'; INSERT INTO [Backoffice].DBO.CBTEIN_SUCURSAL VALUES(@SUC_FISCAL,'FISCAL');";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();

                    if (!SucBackofficeExiste(sqlConnection) || !CbeteinSucBackofficeExiste(sqlConnection))
                    {
                        //using (SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection))
                        //{
                        //    sqlCommand.ExecuteNonQuery();
                        //    MessageBox.Show("Se configuró la sucursal en Backoffice");
                        //}
                        try
                        {
                            using (SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection))
                            {
                                sqlCommand.ExecuteNonQuery();
                                Log.Information("QUERY: " + Query);
                            }
                        }
                        catch (SqlException ex)
                        {
                            Log.Error("ERROR QUERY 1: n" + ex.ToString());
                        }

                        try
                        {
                            using (SqlCommand sqlCommand = new SqlCommand(QueryCbeinSucursal, sqlConnection))
                            {
                                sqlCommand.ExecuteNonQuery();
                                Log.Information("QUERY: " + QueryCbeinSucursal);
                            }
                        }
                        catch (SqlException ex)
                        {
                            Log.Error("ERROR QUERY 2: n" + ex.ToString());
                        }
                        MessageBox.Show("Se configuró la sucursal en Backoffice");
                    }
                    else
                    {
                        Log.Error("ERROR QUERY: Ya existe la sucursal.");
                        MessageBox.Show("Ya existe la sucursal en Backoffice");
                    }

                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                MessageBox.Show("No se agregó sucursal a Backoffice, corroborar conexión. \n\n(EL APLICATIVO DEBE SER ABIERTO SIN LINKEDSERVER O HACIENDO LINKEDSERVER DESDE EL SERVIDOR).\n\n" + "Error: " + ex.Message);
            }
        }

        public bool SucBackofficeExiste(SqlConnection sqlConnection)
        {
            string query = $"SELECT COUNT(*) FROM BACKOFFICE.DBO.SUCURSALES WHERE TRY_CAST(SUC_CODIGO AS INT) = {ParametrosModels.sucFiscal}";

            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                int count = (int)sqlCommand.ExecuteScalar();
                return (count > 0);
            }
        }

        public bool CbeteinSucBackofficeExiste(SqlConnection sqlConnection)
        {
            string query = $"SELECT COUNT(*) FROM BACKOFFICE.DBO.CBTEIN_SUCURSAL WHERE TRY_CAST(CBTEINSUC_CODIGO AS INT) = {ParametrosModels.sucFiscal}";

            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                int count = (int)sqlCommand.ExecuteScalar();
                return (count > 0);
            }
        }
        #endregion

        #region Configurar Parametros Sucursales
        public void ConfigurarSucParametros()
        {
            ConexionDB conexionDB = new ConexionDB();

            string Query = $"DECLARE @SUC_FISCAL VARCHAR(4) = '{ParametrosModels.sucFiscal}'; UPDATE {conexionDB.VerificarLinkedServer()}PARAMETROS SET PARA_VALOR = @SUC_FISCAL WHERE PARA_CODIGO IN ('CDEFSUC','NUMSUCFIJO','PTOVTAFIS','VTAPUNTO');";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
            }
        }
        #endregion

        #region Configurar CBTE_INGRESOS_N
        public void InsertarSucIngresos()
        {
            ConexionDB conexionDB = new ConexionDB();

            string Query = $"DECLARE @SUC_FISCAL VARCHAR(4) = '{ParametrosModels.sucFiscal}'; INSERT INTO {conexionDB.VerificarLinkedServer()}CBTE_INGRESOS_N VALUES('REA', '01', @SUC_FISCAL, '1', 'REA', '', '', '1', 'VISTA'), ('REC', '01', @SUC_FISCAL, '1', 'REA', '', '', '1', 'VISTA');";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
            }
        }
        #endregion

        #region Configurar CBTEEG y CBTEING
        public void InsertarCbteegCbteing()
        {
            ConexionDB conexionDB = new ConexionDB();

            string QueryCbteeg = $"DECLARE @SUC_FISCAL VARCHAR(4) = '{ParametrosModels.sucFiscal}'; INSERT INTO {conexionDB.VerificarLinkedServer()}CBTEEG_SUCURSAL VALUES(@SUC_FISCAL,'FISCAL',NULL);";
            string QueryCbtein = $"DECLARE @SUC_FISCAL VARCHAR(4) = '{ParametrosModels.sucFiscal}'; INSERT INTO {conexionDB.VerificarLinkedServer()}CBTEIN_SUCURSAL VALUES(@SUC_FISCAL,'FISCAL');";
            //string QueryCBTE_EGRESOS_N = $"DECLARE @ULTIMOEGRESO VARCHAR(10); IF EXISTS (SELECT TOP 1 SUBSTRING(LTRIM(EGRE_NUMERO), PATINDEX('%[^0]%', LTRIM(EGRE_NUMERO) + ' '), LEN(EGRE_NUMERO)) FROM {conexionDB.VerificarLinkedServer()}EGRESOS_E ORDER BY EGRE_NUMERO DESC) SET @ULTIMOEGRESO = (SELECT TOP 1 SUBSTRING(LTRIM(EGRE_NUMERO), PATINDEX('%[^0]%', LTRIM(EGRE_NUMERO) + ' '), LEN(EGRE_NUMERO)) FROM {conexionDB.VerificarLinkedServer()}EGRESOS_E ORDER BY EGRE_NUMERO DESC) ELSE SET @ULTIMOEGRESO = '1'; DECLARE @SUC_FISCAL VARCHAR(4) = '{ParametrosModels.sucFiscal}'; INSERT INTO {conexionDB.VerificarLinkedServer()}CBTE_EGRESOS_N VALUES ('CIE','01',@SUC_FISCAL,@ULTIMOEGRESO,'','','','0'), ('OPC','01',@SUC_FISCAL,'17','opc','','','2')";
            string QueryCBTE_INGRESOS_N = $"DECLARE @SUC_FISCAL VARCHAR(4) = '{ParametrosModels.sucFiscal}'; INSERT INTO {conexionDB.VerificarLinkedServer()}CBTE_INGRESOS_N VALUES ('REA','01',@SUC_FISCAL,1,'rea','','','1','VISTA'), ('REC','01',@SUC_FISCAL,1,'REA','','','1','VISTA');";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();

                    try
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(QueryCbteeg, sqlConnection))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        Log.Error("ERROR QUERY 1: n" + ex.ToString());
                    }

                    try
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(QueryCbtein, sqlConnection))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        Log.Error("ERROR QUERY 2: n" + ex.ToString());
                    }

                    //try
                    //{
                    //    using (SqlCommand sqlCommand = new SqlCommand(QueryCBTE_EGRESOS_N, sqlConnection))
                    //    {
                    //        sqlCommand.ExecuteNonQuery();
                    //    }
                    //}
                    //catch (SqlException ex)
                    //{
                    //    Log.Error("ERROR QUERY 3: n" + ex.ToString());
                    //}

                    try
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(QueryCBTE_INGRESOS_N, sqlConnection))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        Log.Error("ERROR QUERY 4: n" + ex.ToString());
                    }
                    
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
            }
        }
        #endregion

        #region Configurar Punto de Venta
        public void ConfigurarPuntoDeVenta()
        {
            InsertarSucursalesPDV();
            InsertarSucursalComprobantesN();
            InsertarCbteegCbteing();
            InsertarSucIngresos();
            ConfigurarSucParametros();
            MessageBox.Show("Se configuró la sucursal");
            InsertarSucursalesBackoffice();
        }
        #endregion

        #region Configurar Comprobantes Bolivia
        public void ConfigurarComprobantesBO()
        {
            ConexionDB conexionDB = new ConexionDB();

            string query = $"DECLARE @SUCURSAL VARCHAR(10) = (SELECT TOP 1 SUC_CODIGO FROM {conexionDB.VerificarLinkedServer()}VENTAS_E ORDER BY VENE_FECHA DESC, VENE_NUMERO DESC);\r\n\r\n-- PDV --\r\n\r\nIF(NOT EXISTS (SELECT * FROM {conexionDB.VerificarLinkedServer()}SUCURSALES WHERE SUC_CODIGO = @SUCURSAL AND SUC_DESCRIPCION = 'FISCAL'))\r\nINSERT INTO {conexionDB.VerificarLinkedServer()}SUCURSALES (SUC_CODIGO, SUC_DESCRIPCION, suc_local, SUC_MANUAL)\r\nVALUES(@SUCURSAL,'FISCAL','S','2');\r\n\r\nIF(NOT EXISTS (SELECT * FROM {conexionDB.VerificarLinkedServer()}COMPROBANTES_N WHERE SUC_CODIGO = @SUCURSAL AND CBTEE_CODIGO = 'FAB'))\r\nINSERT INTO {conexionDB.VerificarLinkedServer()}COMPROBANTES_N\r\nVALUES('VTAS','FAB',@SUCURSAL,'1','','CF','FAB','0','','0','','',NULL,NULL,NULL,NULL);\r\n\r\nIF(NOT EXISTS (SELECT * FROM {conexionDB.VerificarLinkedServer()}CBTEIN_SUCURSAL WHERE CBTEINSUC_CODIGO = @SUCURSAL AND CBTEINSUC_DESCRIPCION = 'FISCAL'))\r\nINSERT INTO {conexionDB.VerificarLinkedServer()}CBTEIN_SUCURSAL\r\nVALUES(@SUCURSAL,'FISCAL');\r\n\r\n-- BACKOFFICE --\r\n\r\nIF(NOT EXISTS (SELECT * FROM [BACKOFFICE].DBO.SUCURSALES WHERE SUC_CODIGO = @SUCURSAL AND SUC_DESCRIPCION = @SUCURSAL))\r\nINSERT INTO [BACKOFFICE].DBO.SUCURSALES (SUC_CODIGO, SUC_DESCRIPCION, suc_local, ASI_SUCTRANSMITIDO)\r\nVALUES(@SUCURSAL,@SUCURSAL,'S','S');";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();
                    using(SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    sqlConnection.Close();
                    Log.Information(query);
                    MessageBox.Show("Se corrigieron los comprobantes.");
                }
            }
            catch(SqlException ex)
            {
                Log.Error(ex.ToString());
                MessageBox.Show("Error al configurar comprobantes. \n" +  ex.ToString());
            }
        }
        #endregion
    }
}
