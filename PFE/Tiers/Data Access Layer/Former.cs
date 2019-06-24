using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace PFE.Tiers.Data_Access_Layer
{
    public class Former:DataBaseAccess
    {
        String TabelQuery = "show tables";
        String ColumnQuery;
        DataBaseForm dbf = new DataBaseForm();
        List<String> tableNames = new List<String>();
        public Former():base()
        {
            FormTables();
            FormColumns();
        }

        private void FormTables()
        {
            MySqlDataReader rdr = offlineSelection(TabelQuery);

            while (rdr.Read())
            {
                tableNames.Add(Convert.ToString(rdr["Tables_in_raising"]));
            }
            Close();
        }
        private void FormColumns()
        {
            foreach(String name in tableNames)
            {
                List<String> columns = new List<String>();
                ColumnQuery = "select column_name from INFORMATION_SCHEMA.COLUMNS where TABLE_SCHEMA=@database and TABLE_NAME=@table";
                MySqlParameter[] parameters = new MySqlParameter[2];
                parameters[0] = new MySqlParameter("@database", "raising");
                parameters[1] = new MySqlParameter("@table", name);
                MySqlDataReader r =onlineSelection(ColumnQuery, parameters);
                while (r.Read())

                {
                    columns.Add(Convert.ToString(r["column_name"]));
                }

                Close();
                dbf.addTabel(name, columns);
               
            }
        }

    }
}