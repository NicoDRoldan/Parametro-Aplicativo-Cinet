﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Parametro.Desings;
using Parametro.Desings.SubDesings;
using Parametro.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Parametro.Class
{
    internal class Querys
    {
        ConexionDB conexionDB = new ConexionDB();

        #region Configurar Números de Comercio
        public void ConfigurarNumeroComercio(string numeroComercio, string tarjeta)
        {
            string queryUpdateComercio = $"DECLARE @NUMCOMERCIO VARCHAR(20) = '{tarjeta}'; DECLARE @VALCODIGO VARCHAR(10) = '{numeroComercio}'; IF (@VALCODIGO = 'CABALCRE' OR @VALCODIGO = 'CABALDEB') AND NOT EXISTS (SELECT TOP 1 * FROM ValLapos WHERE Val_codigo = 'CABALCRE') INSERT INTO ValLapos(Val_codigo, LPO_CodTarjeta, lpo_numcomercio) VALUES('CABALCRE','CA',@NUMCOMERCIO); IF @VALCODIGO = 'CABALDEB' AND NOT EXISTS (SELECT TOP 1 * FROM ValLapos WHERE Val_codigo = 'CABALDEB') INSERT INTO ValLapos(Val_codigo, LPO_CodTarjeta, lpo_numcomercio) VALUES('CABALDEB','C2',@NUMCOMERCIO); IF (@VALCODIGO = 'CABALCRE' OR @VALCODIGO = 'CABALDEB') AND EXISTS (SELECT TOP 1 * FROM ValLapos WHERE Val_codigo = 'CABALCRE') UPDATE ValLapos SET lpo_numcomercio = @NUMCOMERCIO WHERE Val_codigo IN ('CABALCRE','CABALDEB'); IF @VALCODIGO = 'VISA' UPDATE ValLapos SET lpo_numcomercio = @NUMCOMERCIO WHERE Val_codigo IN ('VISA','DEBLECTRO'); IF @VALCODIGO = 'AMEX' UPDATE ValLapos SET lpo_numcomercio = @NUMCOMERCIO WHERE Val_codigo IN ('AMEX'); IF @VALCODIGO = 'MASTER' UPDATE ValLapos SET lpo_numcomercio = @NUMCOMERCIO WHERE Val_codigo IN ('MASTER','DEBMAESTRO','DEBMASTER'); IF @VALCODIGO = 'TNARANJA' UPDATE ValLapos SET lpo_numcomercio = @NUMCOMERCIO WHERE Val_codigo IN ('TNARANJA');";
            string queryUpdateComercioLinked = $"DECLARE @NUMCOMERCIO VARCHAR(20) = '{tarjeta}'; DECLARE @VALCODIGO VARCHAR(10) = '{numeroComercio}'; IF (@VALCODIGO = 'CABALCRE' OR @VALCODIGO = 'CABALDEB') AND NOT EXISTS (SELECT TOP 1 * FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.ValLapos WHERE Val_codigo = 'CABALCRE') INSERT INTO [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.ValLapos(Val_codigo, LPO_CodTarjeta, lpo_numcomercio) VALUES('CABALCRE','CA',@NUMCOMERCIO); IF @VALCODIGO = 'CABALDEB' AND NOT EXISTS (SELECT TOP 1 * FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.ValLapos WHERE Val_codigo = 'CABALDEB') INSERT INTO [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.ValLapos(Val_codigo, LPO_CodTarjeta, lpo_numcomercio) VALUES('CABALDEB','C2',@NUMCOMERCIO); IF (@VALCODIGO = 'CABALCRE' OR @VALCODIGO = 'CABALDEB') AND EXISTS (SELECT TOP 1 * FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.ValLapos WHERE Val_codigo = 'CABALCRE') UPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.ValLapos SET lpo_numcomercio = @NUMCOMERCIO WHERE Val_codigo IN ('CABALCRE','CABALDEB'); IF @VALCODIGO = 'VISA' UPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.ValLapos SET lpo_numcomercio = @NUMCOMERCIO WHERE Val_codigo IN ('VISA','DEBLECTRO'); IF @VALCODIGO = 'AMEX' UPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.ValLapos SET lpo_numcomercio = @NUMCOMERCIO WHERE Val_codigo IN ('AMEX'); IF @VALCODIGO = 'MASTER' UPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.ValLapos SET lpo_numcomercio = @NUMCOMERCIO WHERE Val_codigo IN ('MASTER','DEBMAESTRO','DEBMASTER'); IF @VALCODIGO = 'TNARANJA' UPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.ValLapos SET lpo_numcomercio = @NUMCOMERCIO WHERE Val_codigo IN ('TNARANJA');";

            if(!LoginForm.checkLinkedServer is true)
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(queryUpdateComercio, sqlConnection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    sqlConnection.Close();
                }
            }
            else
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(queryUpdateComercioLinked, sqlConnection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    sqlConnection.Close();
                }
            }
        }
        #endregion

        #region Regenerar Cierre
        public DataTable RegenerarCierre()
        {
            DataTable table = new DataTable();
            ConexionDB conexionDB = new ConexionDB();

            string cadenaConexion = conexionDB.StringConexion();
            string consulta = $"begin try drop table  #valores_cierre end try begin catch end catch; begin try drop table  #cancelaciones end try begin catch end catch; begin try drop table  #dtos end try begin catch end catch; begin try drop table  #record end try begin catch end catch; declare @numcierre varchar(20); set @numcierre = '{ConexionDB.numeroCierre}'; declare @numeroZ varchar(20); set @numeroZ = isnull((SELECT NUMEROZ FROM {conexionDB.VerificarLinkedServer()}ZETA_e WHERE numcierre = @numcierre),0); declare @importeZ decimal(10,2); set @importeZ = isnull((SELECT venta FROM {conexionDB.VerificarLinkedServer()}ZETA_e WHERE numcierre = @numcierre),0); SELECT val_codigo_ingreso_egreso as codigo, SUM(SALDO) AS SALDO, SUM(CIECAJA_DIFCAJA) as dif into #valores_cierre FROM {conexionDB.VerificarLinkedServer()}VALORES_TIPOS VT INNER JOIN {conexionDB.VerificarLinkedServer()}CIERRE_CAJA_d CCD ON CCD.VAL_CODIGO = VT.VAL_CODIGO WHERE CIECAJA_NUMEROCIERRE = @numcierre GROUP BY val_codigo_ingreso_egreso ORDER BY val_codigo_ingreso_egreso DESC; declare @fecha datetime; set @fecha = (select CIECAJA_FECHA from {conexionDB.VerificarLinkedServer()}CIERRE_CAJA_E where CIECAJA_NUMEROCIERRE = @numcierre); declare @hora varchar(20); set @hora = (select CIECAJA_HORA from {conexionDB.VerificarLinkedServer()}CIERRE_CAJA_E where CIECAJA_NUMEROCIERRE = @numcierre); declare @pdv varchar(20); set @pdv = (select CIECAJA_VTAPTO from {conexionDB.VerificarLinkedServer()}CIERRE_CAJA_E where CIECAJA_NUMEROCIERRE = @numcierre); declare @usuario varchar(20); set @usuario = (select ciecaja_usuario from {conexionDB.VerificarLinkedServer()}CIERRE_CAJA_E where CIECAJA_NUMEROCIERRE = @numcierre); declare @nom_usuario varchar(20); set @nom_usuario = (select USU_NOMBRE from {conexionDB.VerificarLinkedServer()}USUARIOS where USUARIO = @usuario); declare @cajero varchar(20); set @cajero = (select LICA_USUARIO from {conexionDB.VerificarLinkedServer()}LIBROCAJA where LICA_NUMCIERRE = @numcierre and LICA_DETALLE like '%inicio%'); declare @nom_cajero varchar(20); set @nom_cajero = (select USU_NOMBRE from {conexionDB.VerificarLinkedServer()}USUARIOS where USUARIO = @cajero); declare @numcaja varchar(20); set @numcaja = (select LICA_NUMCAJA from {conexionDB.VerificarLinkedServer()}LIBROCAJA where LICA_NUMCIERRE = @numcierre and LICA_DETALLE like '%inicio%'); declare @efectivo decimal(10,2); set @efectivo = (select SALDO-dif from #valores_cierre where codigo = 'EFE') - (select LICA_EFECTIVO from {conexionDB.VerificarLinkedServer()}LIBROCAJA where LICA_NUMCIERRE = @numcierre and LICA_DETALLE like '%inicio%'); declare @tarjeta decimal(10,2); set @tarjeta = (select SALDO from #valores_cierre where codigo = 'TAR') + (select SALDO from #valores_cierre where codigo = 'DEB'); declare @merpago decimal(10,2); set @merpago = (select SALDO from #valores_cierre where codigo = 'MPA'); declare @tickets decimal(10,2); set @tickets = (select SALDO from #valores_cierre where codigo = 'TIC'); declare @tardeli decimal(10,2); set @tardeli = (select SALDO from #valores_cierre where codigo = 'PYA'); declare @dif decimal(10,2); set @dif = (select dif from #valores_cierre where codigo = 'EFE'); declare @tot decimal(10,2); set @tot = (select sum(SALDO) from #valores_cierre); declare @canttick int; set @canttick = (select CIECAJA_CANTFAB from {conexionDB.VerificarLinkedServer()}CIERRE_CAJA_E where CIECAJA_NUMEROCIERRE = @numcierre); declare @promo decimal(10,2); set @promo = (select ROUND(ISNULL(sum(vend_cant*vend_precio),0),0) promos from {conexionDB.VerificarLinkedServer()}ventas_e e inner join {conexionDB.VerificarLinkedServer()}ventas_d d on e.vene_numero = d.vene_numero and e.cbtee_codigo = d.cbtee_codigo and e.suc_codigo = d.suc_codigo inner join {conexionDB.VerificarLinkedServer()}articulos_e a on a.art_codigo = d.art_codigo WHERE ciecaja_numerocierre = @numcierre and E.cbtee_codigo not like 'NC%' and a.art_padre = 'PROMO'); select top 1 e.vene_fecha, substring(e.vene_hora,1,2) hora, ISNULL(sum(vent_importe),0) importe, COUNT(*) lica_tickrecord into #record from {conexionDB.VerificarLinkedServer()}ventas_e e inner join {conexionDB.VerificarLinkedServer()}ventas_t t on t.vene_numero = e.vene_numero and e.suc_codigo = t.suc_codigo and e.cbtee_codigo = t.cbtee_codigo and vent_concepto='TOTAL' WHERE ciecaja_numerocierre = @numcierre and E.cbtee_codigo not like 'NC%' group by e.vene_fecha,substring(e.vene_hora,1,2) order by 3 desc; declare @hsrecord int; set @hsrecord = (select hora from #record); declare @fachsrecord decimal(10,2); set @fachsrecord = (select importe from #record); declare @tickrecord int; set @tickrecord = (select lica_tickrecord from #record); drop table #record; select count(*) cancela, ISNULL(SUM(importe),0) importe into #cancelaciones from {conexionDB.VerificarLinkedServer()}auditoria where ciecaja_numerocierre = @numcierre; declare @cancelaciones int; set @cancelaciones = (select cancela from #cancelaciones); declare @importecancelado decimal(10,2); set @importecancelado = (select importe from #cancelaciones); drop table #cancelaciones; declare @agrandables int; set @agrandables = (select ROUND(ISNULL(sum(vend_cant),0),0) cantvendida from {conexionDB.VerificarLinkedServer()}ventas_e e inner join {conexionDB.VerificarLinkedServer()}ventas_d d on e.vene_numero = d.vene_numero and e.cbtee_codigo = d.cbtee_codigo and e.suc_codigo = d.suc_codigo inner join {conexionDB.VerificarLinkedServer()}articulos_e a on a.art_codigo = d.art_codigo where ciecaja_numerocierre = @numcierre and E.cbtee_codigo not like 'NC%' and a.art_agranda='S'); declare @agrandates int; set @agrandates = (select ROUND(ISNULL(sum(vend_cant),0),0) agrandates from {conexionDB.VerificarLinkedServer()}ventas_e e inner join {conexionDB.VerificarLinkedServer()}ventas_d d on e.vene_numero = d.vene_numero and e.cbtee_codigo = d.cbtee_codigo and e.suc_codigo = d.suc_codigo inner join {conexionDB.VerificarLinkedServer()}articulos_e a on a.art_codigo = d.art_codigo WHERE ciecaja_numerocierre = @numcierre and E.cbtee_codigo not like 'NC%' and (a.art_descorta like '%agrandate%' OR a.art_descorta like 'agr%')); declare @terminal varchar(20); set @terminal = (SELECT PARA_VALOR FROM {conexionDB.VerificarLinkedServer()}PARAMETROS WHERE PARA_CODIGO = 'TERMINAL'); declare @items int; set @items = (select ROUND(ISNULL(sum(vend_cant),0),0) cantvendida from {conexionDB.VerificarLinkedServer()}ventas_e e inner join {conexionDB.VerificarLinkedServer()}ventas_d d on e.vene_numero = d.vene_numero and e.cbtee_codigo = d.cbtee_codigo and e.suc_codigo = d.suc_codigo inner join {conexionDB.VerificarLinkedServer()}articulos_e a on a.art_codigo = d.art_codigo where ciecaja_numerocierre = @numcierre and E.cbtee_codigo not like 'NC%'); select ISNULL(COUNT(*),0) cuantosdtos,ISNULL(sum(vent_importe),0) importe into #dtos from {conexionDB.VerificarLinkedServer()}ventas_e e inner join {conexionDB.VerificarLinkedServer()}ventas_t t on t.vene_numero = e.vene_numero and e.suc_codigo = t.suc_codigo and e.cbtee_codigo= t.cbtee_codigo and t.vent_concepto='dto1' WHERE ciecaja_numerocierre = @numcierre and e.cbtee_codigo not like 'NC%' and vent_importe <> 0; declare @dtoss decimal(10,2); set @dtoss = (select importe from #dtos); declare @tickdtos int; set @tickdtos = (select cuantosdtos from #dtos); drop table #dtos; IF (select count(*) from {conexionDB.VerificarLinkedServer()}LIBROCAJA where LICA_NUMCIERRE = @numcierre and LICA_DETALLE like '%CIERRE%' ) = 0 INSERT INTO {conexionDB.VerificarLinkedServer()}LIBROCAJA (LICA_FECHA,	LICA_HORA,LICA_USUARIO,LICA_DETALLE,LICA_NUMCIERRE,	LICA_NUMCAJA,LICA_IMPORTEZETA,	LICA_EFECTIVO,	LICA_TARJETAS,	LICA_TICKETS,LICA_NC ,LICA_DIFERENCIA,	LICA_NUMZETA,LICA_CTAGASTO, ASI_TRANSMITIDO , PRO_CODIGO , LICA_COMENTARIO,DATECONFIRM, LICA_HS,lica_totalvta, lica_canttick, lica_cantnc, lica_dtos, lica_tickdtos,lica_hsrecord, lica_fachsrecord, lica_agrandables  , lica_agrandates,lica_promos,lica_items,lica_cancelaciones,lica_usunombre, lica_cajero,lica_nomcajero, lica_tickrecord, lica_importecancelado,lica_pdv,lica_terminal,lica_alivio,lica_firma,lica_tarjetasdeli,LICA_MERPAGO,LICA_DOLARES,lica_dolarenpesos,lica_cashout)  VALUES (@fecha ,@hora ,@usuario ,'Cierre Caja '+@numcaja +'('+replace(@pdv,' ','')+') Cajero:'+@nom_cajero+' Cerro:'+@nom_usuario , @numcierre , @numcaja , @importeZ , @efectivo , @tarjeta , @tickets , '0' , @dif , @numeroZ , '' , '' , '' , '' , @fecha + @hora , '00:00' , @tot , @canttick , '0' , @dtoss , @tickdtos , @hsrecord , @fachsrecord , @agrandables , @agrandates , @promo , @items , @cancelaciones , @nom_usuario , @cajero , @nom_cajero , @tickrecord , @importecancelado , @pdv , @terminal , '0' , @nom_usuario , @tardeli , @merpago , '0' , '0' ,'0' );";
            string consultaCierres = $"SELECT * FROM {conexionDB.VerificarLinkedServer()}LIBROCAJA WHERE LICA_NUMCIERRE = '{ConexionDB.numeroCierre}'";

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    if (!CierreExiste(conexion, ConexionDB.baseDatos, ConexionDB.numeroCierre))
                    {
                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                            {
                                adapter.Fill(table);
                            }
                        }
                        using (SqlCommand comando = new SqlCommand(consultaCierres, conexion))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                            {
                                adapter.Fill(table);
                            }
                        }
                        Log.Information("SQL Query: \n" + consulta);
                        MessageBox.Show($"Se insertó el cierre indicado ({ConexionDB.numeroCierre}).");
                    }
                    else
                    {
                        using (SqlCommand comando = new SqlCommand(consultaCierres, conexion))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                            {
                                adapter.Fill(table);
                            }
                        }
                        Log.Warning("El registro ya existe. No se realizará la inserción.");
                        MessageBox.Show($"Error, el cierre indicado ({ConexionDB.numeroCierre}) ya existe, no se realizó la inserción.");
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                MessageBox.Show($"Error, leer la excepción completa en el Log. \n" + ex.Message);
            }
            return table;
        }
        #endregion

        #region Cierre Existe
        public bool CierreExiste(SqlConnection sqlConnection, string baseDatos, string numCierre)
        {
            string query = $"SELECT COUNT(*) FROM {conexionDB.VerificarLinkedServer()}LIBROCAJA WHERE LICA_NUMCIERRE = '{numCierre}' AND LICA_DETALLE LIKE '%CIERRE%'";

            using (SqlCommand comando = new SqlCommand(query, sqlConnection))
            {
                int count = (int)comando.ExecuteScalar();
                return (count > 0);
            }
        }
        #endregion

        #region Articulo Prueba
        public void ActivarArticuloPrueba()
        {
            string query = "DECLARE @PRECIO VARCHAR(10) = '1.0';\r\n\r\nIF (SELECT ART_FACTURABLE FROM ARTICULOS_E WHERE ART_CODIGO = '999') = 'N'\r\n\tAND (SELECT ART_SEVENDE FROM ARTICULOS_E WHERE ART_CODIGO = '999') = 'N'\r\n\tAND (SELECT ART_ENMENU FROM ARTICULOS_E WHERE ART_CODIGO = '999') = 'N' \r\n\r\n\tUPDATE ARTICULOS_E \r\n\tSET ART_PADRE = 'CAJITAS', ART_ACTIVO = 'S', ART_FACTURABLE = 'S', ART_SEVENDE = 'S', ART_ENMENU = 'S', ART_COMANDA = 'S'\r\n\tWHERE ART_CODIGO = '999'\r\n\r\nELSE \r\n\r\n\tUPDATE ARTICULOS_E \r\n\tSET ART_PADRE = 'CAJITAS', ART_ACTIVO = 'S', ART_FACTURABLE = 'N', ART_SEVENDE = 'N', ART_ENMENU = 'N', ART_COMANDA = 'S'\r\n\tWHERE ART_CODIGO = '999'\r\n;\r\n\r\nIF NOT EXISTS (SELECT TOP 1 * FROM PRECIOS WHERE ART_CODIGO = '999')\r\n\tINSERT INTO PRECIOS(\r\n\tLISP_CODIGO,\tART_CODIGO\t,PRE_PRECIO\t,PRE_FECCAM\t,TU_CODIGO\t,PRE_PRECIOUNIDAD,\tdfecha_desde\t,dfecha_hasta,\tasi_transmitido)\r\n\tvalues (1, 999,0,getdate(),'','.',getdate(),getdate(),null)\r\nELSE\r\n\tUPDATE PRECIOS SET PRE_PRECIO = @PRECIO WHERE ART_CODIGO = '999'\r\n;";
            string queryLinked = $"DECLARE @PRECIO VARCHAR(10) = '1.0';\r\n\r\nIF (SELECT ART_FACTURABLE FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.ARTICULOS_E WHERE ART_CODIGO = '999') = 'N'\r\n\tAND (SELECT ART_SEVENDE FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.ARTICULOS_E WHERE ART_CODIGO = '999') = 'N'\r\n\tAND (SELECT ART_ENMENU FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.ARTICULOS_E WHERE ART_CODIGO = '999') = 'N' \r\n\r\n\tUPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.ARTICULOS_E \r\n\tSET ART_PADRE = 'CAJITAS', ART_ACTIVO = 'S', ART_FACTURABLE = 'S', ART_SEVENDE = 'S', ART_ENMENU = 'S', ART_COMANDA = 'S'\r\n\tWHERE ART_CODIGO = '999'\r\n\r\nELSE \r\n\r\n\tUPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.ARTICULOS_E \r\n\tSET ART_PADRE = 'CAJITAS', ART_ACTIVO = 'S', ART_FACTURABLE = 'N', ART_SEVENDE = 'N', ART_ENMENU = 'N', ART_COMANDA = 'S'\r\n\tWHERE ART_CODIGO = '999'\r\n;\r\n\r\nIF NOT EXISTS (SELECT TOP 1 * FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PRECIOS WHERE ART_CODIGO = '999')\r\n\tINSERT INTO [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PRECIOS(\r\n\tLISP_CODIGO,\tART_CODIGO\t,PRE_PRECIO\t,PRE_FECCAM\t,TU_CODIGO\t,PRE_PRECIOUNIDAD,\tdfecha_desde\t,dfecha_hasta,\tasi_transmitido)\r\n\tvalues (1, 999,0,getdate(),'','.',getdate(),getdate(),null)\r\nELSE\r\n\tUPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PRECIOS SET PRE_PRECIO = @PRECIO WHERE ART_CODIGO = '999'\r\n;";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();

                    if(!LoginForm.checkLinkedServer is true)
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(queryLinked, sqlConnection))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                    }

                    if(VerificarPruebaActiva(sqlConnection, "prueba"))
                    {
                        MessageBox.Show("Se activó la prueba");
                    }
                    else
                    {
                        MessageBox.Show("Se desactivó la prueba");
                    }

                    Log.Information(query);
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error(ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        #endregion

        # region Test Conito
        public void ActivarTestConito()
        {
            string query = "if  ISNULL((select para_valor FROM PARAMETROS  where para_codigo = 'TESTCONITO'),'N') = 'N'\r\nBEGIN\r\nINSERT INTO PARAMETROS (PARA_CODIGO,PARA_DESCRIPCION,PARA_VALOR)\r\nVALUES ('TESTCONITO','CONITO MARCHA',(SELECT PRE_PRECIO FROM PRECIOS WHERE ART_CODIGO  ='600'))\r\n\r\n\r\nUPDATE ARTICULOS_E \r\nSET ART_COMANDA = 'S',\r\n ART_DESCORTA = 'PRUEBA CINET CONITO',\r\n\r\n art_deslarga = 'PRUEBA CINET CONITO'\r\nwhere ART_CODIGO = '600'\r\nUPDATE precios \r\nSET PRE_PRECIO = '1.0'\r\nwhere ART_CODIGO = '600'\r\n\r\nPRINT('TEST CONITO ON')\r\n\r\nEND\r\n\r\n\r\nELSE \r\n\r\nBEGIN\r\nUPDATE ARTICULOS_E \r\nSET ART_COMANDA = 'N',\r\n art_descorta = 'CONITO',\r\n art_deslarga = 'CONITO'\r\nwhere ART_CODIGO = '600'\r\nUPDATE precios \r\nSET PRE_PRECIO = (SELECT PARA_VALOR FROM PARAMETROS  where para_codigo = 'TESTCONITO')\r\nwhere ART_CODIGO = '600'\r\n\r\n\r\nDELETE  PARAMETROS  where para_codigo = 'TESTCONITO'\r\n\r\nPRINT('TEST CONITO OFF')\r\nEND";
            string queryLinked = $"if  ISNULL((select para_valor FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PARAMETROS  where para_codigo = 'TESTCONITO'),'N') = 'N'\r\nBEGIN\r\nINSERT INTO [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PARAMETROS (PARA_CODIGO,PARA_DESCRIPCION,PARA_VALOR)\r\nVALUES ('TESTCONITO','CONITO MARCHA',(SELECT PRE_PRECIO FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PRECIOS WHERE ART_CODIGO  ='600'))\r\n\r\n\r\nUPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.ARTICULOS_E \r\nSET ART_COMANDA = 'S',\r\n ART_DESCORTA = 'PRUEBA CINET CONITO',\r\n\r\n art_deslarga = 'PRUEBA CINET CONITO'\r\nwhere ART_CODIGO = '600'\r\nUPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.precios \r\nSET PRE_PRECIO = '1.0'\r\nwhere ART_CODIGO = '600'\r\n\r\nPRINT('TEST CONITO ON')\r\n\r\nEND\r\n\r\n\r\nELSE \r\n\r\nBEGIN\r\nUPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.ARTICULOS_E \r\nSET ART_COMANDA = 'N',\r\n art_descorta = 'CONITO',\r\n art_deslarga = 'CONITO'\r\nwhere ART_CODIGO = '600'\r\nUPDATE [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.precios \r\nSET PRE_PRECIO = (SELECT PARA_VALOR FROM [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PARAMETROS  where para_codigo = 'TESTCONITO')\r\nwhere ART_CODIGO = '600'\r\n\r\n\r\nDELETE  [{ConexionDB.equipoLinkedServer},{ConexionDB.puertoLinkedServer}].[{LoginForm.baseDatosLinkedServer}].DBO.PARAMETROS  where para_codigo = 'TESTCONITO'\r\n\r\nPRINT('TEST CONITO OFF')\r\nEND";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();

                    if (!LoginForm.checkLinkedServer is true)
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(queryLinked, sqlConnection))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                    }

                    if (VerificarPruebaActiva(sqlConnection, "conito"))
                    {
                        MessageBox.Show("Se activó el conito");
                    }
                    else
                    {
                        MessageBox.Show("Se desactivó el conito");
                    }

                    Log.Information(query);
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error(ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        #endregion 

        #region Verificar Activo
        public bool VerificarPruebaActiva(SqlConnection sqlConnection, string tipoPrueba)
        {
            string queryPrueba = $"SELECT COUNT(*) FROM {conexionDB.VerificarLinkedServer()}ARTICULOS_E WHERE ART_CODIGO = '999' AND ART_FACTURABLE = 'S' AND ART_SEVENDE = 'S' AND ART_ENMENU = 'S' ";
            string queryConito = $"SELECT COUNT(*) FROM {conexionDB.VerificarLinkedServer()}PARAMETROS  WHERE PARA_CODIGO = 'TESTCONITO'";

            int count = 0;

            if (tipoPrueba == "prueba")
            {
                using (SqlCommand comando = new SqlCommand(queryPrueba, sqlConnection))
                {
                    count = (int)comando.ExecuteScalar();
                }
            }
            else if (tipoPrueba == "conito")
            {
                using (SqlCommand comando = new SqlCommand(queryConito, sqlConnection))
                {
                    count = (int)comando.ExecuteScalar();
                }
            }

            return (count > 0);
        }
        #endregion

        #region Zetas en 0
        public DataSet VerZetasEnCero(string fechaDesde, string fechaHasta)
        {
            DataSet dataSet = new DataSet();

            string query = $"SET DATEFORMAT DMY; DECLARE @DESDE VARCHAR(10) = '{fechaDesde}', @HASTA VARCHAR(10) = '{fechaHasta}'; SELECT LICA_FECHA, LICA_HORA, LICA_NUMCAJA, LICA_NUMCIERRE, LICA_DETALLE, LICA_totalvta, LICA_IMPORTEZETA FROM {conexionDB.VerificarLinkedServer()}LIBROCAJA WHERE LICA_NUMCAJA != '0' AND LICA_IMPORTEZETA = '0.00' AND LICA_TOTALVTA != '0.00' AND LICA_FECHA BETWEEN @DESDE AND @HASTA; SELECT SUM(LICA_totalvta) [TOTAL DE Z EN 0] FROM {conexionDB.VerificarLinkedServer()}LIBROCAJA WHERE LICA_NUMCAJA != '0' AND LICA_IMPORTEZETA = '0.00' AND LICA_TOTALVTA != '0.00' AND LICA_FECHA BETWEEN @DESDE AND @HASTA;";

            try
            {
                using(SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();
                    using(SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using(SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(dataSet);
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                MessageBox.Show($"Error, leer la excepción completa en el Log. \n" + ex.Message);
            }
            return dataSet;
        }

        public void CorregirZetasEnCero(string fechaDesde, string fechaHasta)
        {
            string query = $"SET DATEFORMAT DMY; DECLARE @DESDE VARCHAR(10) = '{fechaDesde}', @HASTA VARCHAR(10) = '{fechaHasta}'; UPDATE {conexionDB.VerificarLinkedServer()}LIBROCAJA SET LICA_IMPORTEZETA = LICA_totalvta WHERE LICA_NUMCAJA != '0' AND LICA_IMPORTEZETA = '0.00' AND LICA_TOTALVTA != '0.00' AND LICA_FECHA BETWEEN @DESDE AND @HASTA;";

            try
            {
                using(SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand( query, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    Log.Information("SQL Query: \n" + query);
                    MessageBox.Show($"Se corrigieron los Z de las fechas indicadas.");
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                MessageBox.Show($"Error, leer la excepción completa en el Log. \n" + ex.Message);
            }
        }
        #endregion

        #region Verificar Caja
        public DataTable VerificarCaja()
        {
            DataTable dataTable = new DataTable();

            string query = $"declare @infoCaja table([caja] varchar(100), [equipo] varchar(100), [version] varchar(100) );\r\n\r\ninsert into @infoCaja\r\nselect distinct caja,EQUIPO,valor from (\r\nselect RANK() OVER (\r\n    PARTITION BY caja, parametro\r\n    ORDER BY fechatrans desc) rango, *\r\nfrom {conexionDB.VerificarLinkedServer()}hparamloc\r\nwhere parametro = 'VERSION') pinga\r\nwhere rango = 1\r\norder by equipo\r\n\r\nSELECT vene_caja, suc_codigo, equipo\r\nFROM (\r\n    SELECT \r\n        ROW_NUMBER() OVER (PARTITION BY v.vene_caja ORDER BY v.vene_fecha DESC) AS rn,\r\n        v.vene_caja,\r\n        v.suc_codigo,\r\n        i.equipo\r\n    FROM {conexionDB.VerificarLinkedServer()}VENTAS_E v\r\n    INNER JOIN @infoCaja i ON v.vene_caja = i.caja COLLATE SQL_Latin1_General_CP1_CI_AS\r\n    WHERE v.vene_caja != ''\r\n) AS subquery\r\nWHERE rn = 1\r\nORDER BY equipo;";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(dataTable);
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                MessageBox.Show($"Error, leer la excepción completa en el Log. \n" + ex.Message);
            }
            return dataTable;
        }
        #endregion

        #region Verificar País de la Base
        public string BasePais()
        {
            string query = $"SELECT PARA_VALOR FROM {conexionDB.VerificarLinkedServer()}PARAMETROS WHERE PARA_CODIGO = 'EMPREPAIS'";
            string pais = "";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            if (sqlDataReader.Read())
                            {
                                pais = sqlDataReader["PARA_VALOR"].ToString();
                            }
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                MessageBox.Show($"Error, leer la excepción completa en el Log. \n" + ex.Message);
            }

            return pais;
        }
        #endregion

        #region Corregir RUT de Cliente
        public void CorregirRutCliente(string numVentaRut, string numRutCorrecto)
        {
            string query = $"DECLARE @numVenta varchar(20) = '{numVentaRut}'; DECLARE @numRut varchar(20) = '{numRutCorrecto}'; DECLARE @cliente varchar(20) = (select cl.CLI_CODIGO from {conexionDB.VerificarLinkedServer()}CLIENTES cl inner join {conexionDB.VerificarLinkedServer()}VENTAS_E ne on ne.CLI_CODIGO = cl.CLI_CODIGO where VENE_NUMERO = @numVenta); update {conexionDB.VerificarLinkedServer()}CLIENTES set CLI_LGLCUIT = @numRut where CLI_CODIGO = @cliente";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();
                    
                    using (SqlCommand sqlCommand = new SqlCommand( query, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    Log.Information("Query: " + query);
                    MessageBox.Show("Se corrigió el RUT correspondiente.");
                    sqlConnection.Close();
                }
            }
            catch(SqlException ex )
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                MessageBox.Show($"Error, leer la excepción completa en el Log. \n" + ex.Message);
            }
        }
        #endregion

        #region FE Automatico
        public void FacturaElectronicaAuto()
        {
            string query = $"UPDATE {conexionDB.VerificarLinkedServer()}SUCURSALES SET SUC_MANUAL = '2' WHERE SUC_CODIGO = (SELECT PARA_VALOR FROM {conexionDB.VerificarLinkedServer()}PARAMETROS WHERE PARA_CODIGO = 'VTAPUNTO');";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }

                    Log.Information("Query: " + query);
                    MessageBox.Show("Se configura impresión automatica de Factura Electronica.");
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                MessageBox.Show($"Error, leer la excepción completa en el Log. \n" + ex.Message);
            }
        }

        public void FacturaElectronicaAutoBO()
        {
            string query = $"DECLARE @SUCURSAL VARCHAR(10) = (SELECT TOP 1 SUC_CODIGO FROM {conexionDB.VerificarLinkedServer()}VENTAS_E ORDER BY VENE_FECHA DESC, VENE_NUMERO DESC); UPDATE {conexionDB.VerificarLinkedServer()}SUCURSALES SET SUC_MANUAL = '0'; UPDATE {conexionDB.VerificarLinkedServer()}SUCURSALES SET SUC_MANUAL = '2' WHERE SUC_CODIGO = @SUCURSAL;";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }

                    Log.Information("Query: " + query);
                    MessageBox.Show("Se configura impresión automatica de Factura Electronica.");
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                MessageBox.Show($"Error, leer la excepción completa en el Log. \n" + ex.Message);
            }
        }
        #endregion

        #region Configurar Timbrado
        public void ConfigurarTimbrado(string tim_local, string tim_caja)
        {
            string query = $"UPDATE {conexionDB.VerificarLinkedServer()}TIMBRADO SET TIM_LOCAL = '{tim_local}', TIM_CAJA = '{tim_caja}'; UPDATE {conexionDB.VerificarLinkedServer()}PARAMETROS SET PARA_VALOR = (SELECT PARA_VALOR FROM {conexionDB.VerificarLinkedServer()}PARAMETROS WHERE PARA_CODIGO = 'PTOVTAFIS') WHERE PARA_CODIGO = 'PTOVTAMAN';";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }

                    Log.Information("Query: " + query);
                    MessageBox.Show("Timbrado Configurado.");
                    sqlConnection.Close();
                }
            }
            catch( SqlException ex )
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                MessageBox.Show($"Error, leer la excepción completa en el Log. \n" + ex.Message);
            }
        }
        #endregion

        #region Corregir Numeración
        public string ConsultarUltimaNumeracion(string TipoCBTEE)
        {
            QuerysForm querysForm = new QuerysForm();
            // Select para ver la numeración antes de cambiarla.
            string querySelect = $"DECLARE @TipoCBTEE VARCHAR(3) = '{TipoCBTEE}'; DECLARE @SucCodigo VARCHAR(4) = (SELECT TOP 1 SUC_CODIGO FROM {conexionDB.VerificarLinkedServer()}VENTAS_E ORDER BY VENE_FECHA DESC, VENE_HORA DESC, VENE_NUMERO DESC); /*SELECT DE LA NUMRACIÓN ANTERIOR A CAMBIARLA*/ SELECT CBTEN_NUMERO [NumeracionAnterior] FROM {conexionDB.VerificarLinkedServer()}COMPROBANTES_N WHERE CBTEE_CODIGO = @TipoCBTEE AND SUC_CODIGO = @SucCodigo;";

            string numCbteAnt = "";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySelect, sqlConnection))
                    {
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            if (sqlDataReader.Read())
                            {
                                //QuerysForm.nroAnteriorCbtee = sqlDataReader["NumeracionAnterior"].ToString();
                                numCbteAnt = sqlDataReader["NumeracionAnterior"].ToString();
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch(SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                MessageBox.Show($"Error, leer la excepción completa en el Log. \n" + ex.Message);
            }

            return numCbteAnt;
        }

        public void CorregirNumeracion(string TipoCBTEE, string UltimoNroCorrelativo)
        {
            QuerysForm querysForm = new QuerysForm();

            //Update a la numeración nueva.
            string queryUpdate = $"DECLARE @TipoCBTEE VARCHAR(3) = '{TipoCBTEE}'; DECLARE @UltimoNroCorrelativo VARCHAR(8) = '{UltimoNroCorrelativo}'; DECLARE @NroComprobanteCorrelativo VARCHAR(8) = SUBSTRING(@UltimoNroCorrelativo, PATINDEX('%[^0]%', @UltimoNroCorrelativo + '.'), LEN(@UltimoNroCorrelativo)); DECLARE @SucCodigo VARCHAR(4) = (SELECT TOP 1 SUC_CODIGO FROM {conexionDB.VerificarLinkedServer()}VENTAS_E ORDER BY VENE_FECHA DESC, VENE_HORA DESC, VENE_NUMERO DESC); /*UPDATE A LA NUMERACIÓN INDICADA */ UPDATE {conexionDB.VerificarLinkedServer()}COMPROBANTES_N SET CBTEN_NUMERO = @NroComprobanteCorrelativo WHERE CBTEE_CODIGO = @TipoCBTEE AND SUC_CODIGO = @SucCodigo;";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }

                    Log.Information("Query: " + queryUpdate);
                    MessageBox.Show("Se modificó el número de comprobante.");

                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                MessageBox.Show($"Error, leer la excepción completa en el Log. \n" + ex.Message);
            }
        }
        #endregion

        #region ConsultaConexiones
        public DataTable ConsultaConexiones()
        {
            DataTable dataTable = new DataTable();

            string query = "SELECT \r\n    RTRIM(DB_NAME(dbid)) AS BaseDatos, \r\n    RTRIM(COUNT(dbid)) AS Conexiones,\r\n    RTRIM(loginame) AS [Login],\r\n\tRTRIM(hostname) [EQUIPO],\r\n\tRTRIM(program_name) [APLICATIVO]\r\nFROM\r\n    sys.sysprocesses\r\nWHERE \r\n    dbid > 0\r\n\tand DB_NAME(dbid) != 'master'\r\n\tand program_name NOT IN ('Microsoft SQL Server Management Studio - Query','Microsoft SQL Server Management Studio - Transact-SQL IntelliSense')\r\nGROUP BY \r\n    dbid, loginame, hostname , program_name order by conexiones desc";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(dataTable);
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                MessageBox.Show($"Error, leer la excepción completa en el Log. \n" + ex.Message);
            }
            return dataTable;
        }
        #endregion

        #region VerificarVersionAplicativos
        public DataTable VerificarVersionLocal()
        {
            DataTable dataTable = new DataTable();

            string query = $"DECLARE @NOMLOCAL VARCHAR (10) = (SELECT PARA_VALOR FROM {conexionDB.VerificarLinkedServer()}PARAMETROS WHERE PARA_CODIGO = 'NOMLOCAL')" +
                "SELECT RTRIM(LTRIM(@NOMLOCAL)) [LOCAL], RTRIM(LTRIM(PARAMETRO)) [APLICATIVO], RTRIM(LTRIM(VALOR)) [VERSION]\r\n" +
                "FROM (\r\n    " +
                "SELECT \r\n        " +
                "LOCAL, PARAMETRO, VALOR, FECHATRANS,\r\n        " +
                "ROW_NUMBER() OVER (PARTITION BY LOCAL, PARAMETRO ORDER BY FECHATRANS DESC) AS rn\r\n    " +
                $"FROM {conexionDB.VerificarLinkedServer()}HPARAMLOC\r\n" +
                ") subquery\r\n" +
                "WHERE rn = 1 AND LOCAL = @NOMLOCAL\r\n" +
                "AND PARAMETRO NOT IN ('Backup','SO','TareaProgramada|VERSION','FECHADB','HD_SPACE','IncorporaSync|VERSION'," +
                "\r\n\t\t\t\t\t\t'SQL_DATASPACE','EQU_USU','ULTDIFZ','DBVERSION','SQL_LOGSPACE','REPLICAREG','CTRALIZPOSBKO'," +
                "\r\n\t\t\t\t\t\t'CLASEVBNET','ACTIVEXNET','ZonaEntrega|SO','DataSync|VERSION')";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            // Agregar los datos al DataTable con Trim en cada columna:
                            sqlDataAdapter.Fill(dataTable);
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                MessageBox.Show($"Error, leer la excepción completa en el Log. \n" + ex.Message);
            }

            return dataTable;
        }
        #endregion

        #region VerificarVersionPorCaja
        public DataTable VerificarVersionPorCaja(string aplicativo)
        {
            DataTable dataTable = new DataTable();

            string query =
                "\r\nSELECT RTRIM(LTRIM(EQUIPO)) [EQUIPO], RTRIM(LTRIM(CAJA)) [CAJA], RTRIM(LTRIM(PARAMETRO)) [APLICATIVO], RTRIM(LTRIM(VALOR)) [VERSIÓN]\r\n" +
                "FROM (\r\n" +
                "    SELECT \r\n" +
                "        EQUIPO, CAJA, PARAMETRO, VALOR, FECHATRANS,\r\n" +
                "        ROW_NUMBER() OVER (PARTITION BY CAJA, PARAMETRO ORDER BY FECHATRANS DESC) AS rn\r\n" +
                $"    FROM {conexionDB.VerificarLinkedServer()}HPARAMLOC\r\n" +
                ") subquery\r\n" +
                "WHERE rn = 1\r\n" +
                "AND PARAMETRO = @APLICATIVO;";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@APLICATIVO", aplicativo);
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(dataTable);
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                MessageBox.Show($"Error, leer la excepción completa en el Log. \n" + ex.Message);
            }

            return dataTable;
        }
        #endregion

        #region ReducirLogs
        public DataSet ReducirLogs()
        {
            DataSet dataSet = new DataSet();

            string query = "";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conexionDB.StringConexion()))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(dataSet);
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                Log.Error("ERROR QUERY: n" + ex.ToString());
                MessageBox.Show($"Error, leer la excepción completa en el Log. \n" + ex.Message);
            }
            return dataSet;
        }
        #endregion
    }
}