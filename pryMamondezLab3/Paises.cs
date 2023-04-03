using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace pryMamondezLab3
{
    internal class Paises
    {
        private string Cadena="";
        private OleDbConnection conector;
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataTable Tabla;


        private int Pais;
        private string Nombre;
        private string Capital;

        public int paises
        {
            get { return Pais; }
            set { Pais = value; }
        }

        public string Nombres 
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string capitales 
        {
            get { return Capital; }
            set { Capital = value; }
        }
        public Paises() 
        {
            Cadena = "provider=microsoft.jet.oledb.4.0;data source=MUNDO.mdb";
            conector = new OleDbConnection(Cadena);
            comando = new OleDbCommand();
            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Paises";
            adaptador = new OleDbDataAdapter(comando);
            Tabla = new DataTable();    
            adaptador.Fill(Tabla);
            DataColumn[] vector = new DataColumn[1];
            vector[0] = Tabla.Columns["pais"];
            Tabla.PrimaryKey = vector;

        }

        public void Grabar() 
        {
            DataRow fila = Tabla.NewRow();
            fila["pais"] = paises;
            fila["nombre"] = Nombres;
            fila["capital"] = capitales;
            Tabla.Rows.Add(fila);
            OleDbCommandBuilder cb = new OleDbCommandBuilder();
            adaptador.Update(Tabla);
        }
        public void Eliminar() 
        {

        }
        public void Modificar() 
        {

        }
        public void Buscar() 
        {
            DataRow fila = Tabla.Rows.Find(paises);
            if (fila is null)
            {
                paises = 0;
                Nombres = "";
                capitales = "";
            }
            else
            {
                paises = Convert.ToInt32(fila["pais"]);
                Nombres = fila["nombre"].ToString();
                capitales = fila["capital"].ToString();
            }

        }
        public void Listar() 
        {

        }
    }
}
