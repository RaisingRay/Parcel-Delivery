using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PFE.Tiers.Data_Access_Layer;

namespace PFE.Entity.Authentification
{
    public class UserRole
    {
        public Data id = new Data("role_id");
        public Data role = new Data("role");


        public UserRole() { }

        public UserRole(int id) { this.id.Value = id; }

        public UserRole(int id,String role)
        {
            this.id.Value = id;
            this.role.Value = role;
        }

    }
}