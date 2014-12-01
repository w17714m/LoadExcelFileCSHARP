using System;
using System.IO;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Data;
using System.Linq;



namespace uploadFile_ExcelABD {
    class Lector {
        Archivo archivo;
        String ConexionString="";
        private OleDbConnection cn;
        private OleDbCommand cmd;
        private OleDbDataAdapter da;
        


        public Lector(Archivo archivo) {
            this.archivo = archivo;
            cn = new OleDbConnection(funStrConectionString());
        }

        public List<String> funListaHojas() {
            
            if (cn.State != ConnectionState.Open)
            {
                mtdAbrirConexion();
            }

            DataTable dt = cn.GetSchema("TABLES");

            IEnumerable<String> query = from DataRow row in dt.Rows.Cast<DataRow>()
                                        where row["TABLE_TYPE"].ToString().ToUpperInvariant() == "TABLE"
                                        orderby row["TABLE_NAME"].ToString()
                                        select row["TABLE_NAME"].ToString();
            mtdCerraConexion();
            return query.ToList<String>();
        }
        
        public List<String> funListarColumnas(String strNombreTabla) {
            List<String> column = new List<String>();
            if (cn.State != ConnectionState.Open)
            {
                mtdAbrirConexion();
            }
            da = new OleDbDataAdapter("Select * from [" + strNombreTabla + "]", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataColumn dc in dt.Columns) {
                column.Add(dc.Caption);
            }
            
            mtdCerraConexion();
            return column;
        }
        
        public Boolean funTieneUnaColumna(String Hoja) {
            return true; 
        }

        public String funStrConectionString() {
            if (ConexionString.Equals(null) || ConexionString.Equals(""))
            {
                switch (archivo.strExtension.ToLower())
                {
                    case ".xls":
                        ConexionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + archivo.strUbicacionCompleta + ";Extended Properties=Excel 8.0;";
                        break;
                    case ".xlsx":
                        ConexionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo.strUbicacionCompleta + ";Extended Properties=Excel 12.0;";
                        break;
                    default:
                        ConexionString = "";
                        break;

                }
                return ConexionString;
            }
            else {
                return ConexionString;
            }
            
        }

        public void mtdAbrirConexion() {
            cn.Open();
        }
        public void mtdCerraConexion() {
            if (cn.State == ConnectionState.Open || cn.State == ConnectionState.Connecting) { cn.Close();}
            
        }
        
    }
}

