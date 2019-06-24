using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFE.Tiers.Data_Access_Layer
{
    public class DataBaseForm
    {
        public static Dictionary<String, List<String>> Tabels = new Dictionary<string, List<string>>();

        public DataBaseForm() { }

        public void addTabel(String tabelName, List<String> columns)
        {
            Tabels.Add(tabelName, columns);
        }
        public List<String> this[String index]
        {
            get { return Tabels[index]; }
        }

        public void addColumn(String tabelName, String column)
        {
            Tabels[tabelName].Add(column);
        }
    }
}