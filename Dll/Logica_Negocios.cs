using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dal;
using Entidades;

namespace Dll
{
    public class Logica_Negocios
    {
        private Acceso_Datos AC = null;

        private CRUD OPC = null;

        public Logica_Negocios(string connection)
        {
            AC = new Acceso_Datos(connection);
            OPC = new CRUD(connection);
        }






    }
}
