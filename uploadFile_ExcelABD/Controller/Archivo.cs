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
using System.IO;


namespace uploadFile_ExcelABD
{
    public class Archivo{

        private String _strNombre;
        private String _strExtension;
        private String _strUbicacion;
        private String _strUbicacionCompleta;

        public String strNombre {
            get { return _strNombre; }
            set { _strNombre = value; } 
        }

        public String strExtension
        {
            get { return _strExtension; }
            set { _strExtension = value; }
        }

        public String strUbicacionCompleta
        {
            get { return _strUbicacionCompleta; }
            set { _strUbicacionCompleta = value; }
        }

        public String strUbicacion
        {
            get { return _strUbicacion; }
            set { _strUbicacion = value; }
        }

        public Archivo(String ruta){
            strUbicacionCompleta = ruta;
            strNombre = Path.GetFileName(ruta).Trim();
            strExtension = Path.GetExtension(ruta).Trim();
            strUbicacion = Path.GetFullPath(ruta).Trim().Replace(strNombre,"");
            strUbicacionCompleta = Path.GetFullPath(ruta).Trim();
        }





    }
}