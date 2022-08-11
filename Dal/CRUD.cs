using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Dal
{
    public class CRUD
    {
        private Acceso_Datos AC = null;
        public CRUD(string connection)
        {
            AC = new Acceso_Datos(connection);
        }






    }
}
