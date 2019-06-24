using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PFE.Tiers.Data_Access_Layer;
namespace PFE.Entity.Authentification
{
    public class UserStatus
    {
        public Data id = new Data("status_id");
        public Data loggedIn = new Data("logged_in");
        public Data lastLogIn = new Data("last_log_in");

        public UserStatus() { }
        public UserStatus(int id) { this.id.Value = id; }
        public UserStatus(int id,bool loggedIn, DateTime lastLogIn)
        {
            this.id.Value = id;
            this.loggedIn.Value = loggedIn;
            this.lastLogIn.Value = lastLogIn;
        }

    }
}