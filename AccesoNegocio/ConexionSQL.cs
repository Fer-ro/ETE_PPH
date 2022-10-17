using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoNegocio
{
   public class ConexionSQL
    {
        public SQLDatos connectionSQL()
        {
            return  new SQLDatos("prensas", "Fypprensas", "FYP_Soldadura_ETE", "172.25.10.90\\FYPAPP");
        }

    }
}
