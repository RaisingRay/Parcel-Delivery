using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFE.Tiers.Data_Access_Layer
{
    public class Data
    {
        public String Key { get; }
        public object Value { get; set; }

        public Data(String Key)
        {
            this.Key = Key;
        }
    }
}