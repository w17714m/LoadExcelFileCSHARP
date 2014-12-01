using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

namespace uploadFile_ExcelABD
{
    public partial class _Default : System.Web.UI.Page
    {

        Archivo a; 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (file1.PostedFile != null && file1.PostedFile.ContentLength > 0 && (System.IO.Path.GetExtension(file1.PostedFile.FileName) == ".xls" || System.IO.Path.GetExtension(file1.PostedFile.FileName) == ".xlsx"))
            {
                String archivo = System.IO.Path.GetFileName(file1.PostedFile.FileName);
                String localizacionArchivo = Server.MapPath("Data") + "\\" + archivo;
                try {
                    file1.PostedFile.SaveAs(localizacionArchivo);
                    Resultado.Text = localizacionArchivo;
                    a = new Archivo(localizacionArchivo);
                    Lector l = new Lector(a);
                    String temp = "";
                    foreach (String s in l.funListaHojas()) {
                        temp = temp + s + "<br>";
                        foreach (String t in l.funListarColumnas(s)) {
                            temp = temp + "--" + t + "--"; 
                        }
                    }
                    Resultado.Text = temp;
                }
                catch (Exception ex)
                {
                    Resultado.Text = "No se cargo por el siguiente error: " + ex.Message + " " + ex.StackTrace;
                }


            }
            else 
            {
                Resultado.Text = "Por favor seleccione un archivo.";
            }
        }
    }
}
