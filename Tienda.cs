using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace Tienda
{
    class Tienda
    {
         OleDbConnection conector;
         OleDbCommand comando;
         string sql;
         public Tienda ()
         {
            conector = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=TIENDA.mdb");
            comando = new OleDbCommand();
            sql = "";
         }
        public void grabar(int producto, string nombre, int stock)//pasamos esas cosas a grabar
        {
            sql = $"INSERT INTO Productos VALUES({producto}, '{nombre}', {stock})";//los strings siempre hay q ponerlos en comillas simples

            conector.Open();//abre la base de datos
            comando.Connection = conector; //indica a que base de datos le manda el comando
            comando.CommandType = CommandType.Text;//indica el tipo de comando
            comando.CommandText = sql; //indica cual es la tabla
            comando.ExecuteNonQuery();//ejecuta el comando

            conector.Close();//cierra la base de datos

        }
        public void listar(DataGridView Grilla)
        {
            sql = "SELECT * FROM Productos WHERE nombre='TECLADO'";//trae todas los registros y columnas de la tabla
            //el asterisco es para que traiga todos, si quiero alguna en particular pongo las variables
            //el where pone una condicion

            conector.Open();//abre la base de datos
            comando.Connection = conector; //indica a que base de datos le manda el comando
            comando.CommandType = CommandType.Text;//indica el tipo de comando
            comando.CommandText = sql; //indica cual es la tabla
           
            OleDbDataReader dr= comando.ExecuteReader();//crea un data reader y lo executa
            Grilla.Rows.Clear();//limpia la grilla
            while (dr.Read())//mientras no sean fin de archivo q siga recorriendo
            {
                Grilla.Rows.Add(dr["Producto"], dr["Nombre"],dr["Stock"]);
            }
        
            conector.Close();
        }
        public void eliminar(int producto)
        {
            sql = $"DELETE FROM Productos WHERE producto={producto}";
            conector.Open();//abre la base de datos
            comando.Connection = conector; //indica a que base de datos le manda el comando
            comando.CommandType = CommandType.Text;//indica el tipo de comando
            comando.CommandText = sql; //indica cual es la tabla
            comando.ExecuteNonQuery();//ejecuta el comando

            conector.Close();//cierra la base de datos

        }
    }
}
