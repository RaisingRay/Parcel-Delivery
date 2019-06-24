using System;
using PFE.Tiers.Data_Access_Layer;
namespace PFE.Entity.Authentification
{
    public class User
    {
        public Data id = new Data("user_id");
        public Data email = new Data("email");
        public Data password = new Data("passwrd");
        public Data salt = new Data("salt");
        public Data createdDate = new Data("created_date");
        public Data editedDate = new Data("edited_date");
        public Data role =new Data("role_id");
        public Data status = new Data("status_id");


        public User() { }

        public User(int id) { this.id.Value = id; }

        public User(String email) { this.email.Value = email; }
        
        public User(String email,String password,String salt)
        {
            this.email.Value = email;
            this.password.Value = password;
            this.salt.Value = salt;
        }

        public User(int id, String email,String password,String salt,DateTime createdDate,DateTime editedDate,UserRole role,UserStatus status)
        {
            this.id.Value = id;
            this.email.Value = email;
            this.password.Value = password;
            this.salt.Value = salt;
            this.createdDate.Value = createdDate;
            this.editedDate.Value = editedDate;
            this.role.Value = role;
            this.status.Value = status;
        }
    }
}