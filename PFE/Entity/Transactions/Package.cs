using System;
using PFE.Tiers.Data_Access_Layer;

namespace PFE.Entity.Transactions
{
    public class Package
    {
        public Data id = new Data("package_id");
        public Data materialType = new Data("material_type");
        public Data weight = new Data("weight");

        public Package() { }
        public Package(int id) { this.id.Value = id; }
        public Package(int id,String materialType,float weight)
        {
            this.id.Value = id;
            this.materialType.Value = materialType;
            this.weight.Value = weight;
        }

    }
}