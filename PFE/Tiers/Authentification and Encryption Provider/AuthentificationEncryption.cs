using System;
using System.Web.Configuration;
using PFE.Tiers.Data_Access_Layer;
using System.Collections.Generic;
using System.Data;
using PFE.Entity.Authentification;
using PFE.Entity.HumanRessources;


namespace PFE.Tiers.simple_Authentification_Security_Layer
{
    public class AuthentificationEncryption:DynamicQueryProcedureManager
    {
        EncryptionDecryptionProvider edp = new EncryptionDecryptionProvider();

        public AuthentificationEncryption():base() { }
        

        public bool checkUserExist(User user)
        {
            List<Data> data = new List<Data>();
            data.Add(user.email);
            return selectUser(data) != null;
        }



        public bool authentificateUser(User user,ref String err)
        {
            String Plainpassword =(String) user.password.Value;
            String PasswordFromdb = "";


            List<Data> data = new List<Data> ();
            data.Add(user.email);


            User u = new User();


            try {
               u= userConverter(selectUser(data))[0];
               PasswordFromdb =(String) u.password.Value;
            }
            catch (Exception) { }
            
            if (u.id.Value==null)
            {
                err = "Wrong Email";
                return false;
            }
            else
            {
                String staticSalt = WebConfigurationManager.OpenWebConfiguration("/Web.config").AppSettings.Settings["StaticSalt"].Value;
                Plainpassword = edp.CreateHash(Plainpassword, staticSalt, (String)u.salt.Value);
                if (PasswordFromdb.Equals(Plainpassword))
                    return true;
                else
                {
                    err = "Wrong Password";
                    return false;
                }
            }
        }
        /****************************************************___ADD__****************************************************/

        public int addSecuredCustomer(Customer user)
        {
            String password = (String)user.password.Value;
            String salt="";
            EncryptPassword(ref password, ref salt);
            user.password.Value = password;
            user.salt.Value = salt;

            return insertCustomer(user);
        }

        public int addSecuredEmployee(Employee user)
        {
            String password = (String)user.password.Value;
            String salt = "";
            EncryptPassword(ref password, ref salt);
            user.password.Value = password;
            user.salt.Value = salt;

            return insertEmployee(user);
        }

        public int addSecuredDriver(Driver user)
        {
            String password = (String)user.password.Value;
            String salt = "";
            EncryptPassword(ref password, ref salt);
            user.password.Value = password;
            user.salt.Value = salt;

            return insertDriver(user);
        }



        /*********************************__Edit__*********************************************/

 


        /*******************************__Converters__***********************************************/

        private List<User> userConverter(DataTable table)
        {
            List<User> listUser = new List<User>();
            User u = new User();
            DateTime createdDate = new DateTime();
            DateTime editedDate = new DateTime();
            if (table != null)
                foreach (DataRow row in table.Rows)
                {
                    if (row[u.createdDate.Key] != DBNull.Value)
                        createdDate = Convert.ToDateTime(row[u.createdDate.Key]);
                    if (row[u.editedDate.Key] != DBNull.Value)
                        editedDate = Convert.ToDateTime(row[u.editedDate.Key]);

                    listUser.Add(new User(
                        Convert.ToInt32(row[u.id.Key]),
                        Convert.ToString(row[u.email.Key]),
                        Convert.ToString(row[u.password.Key]),
                        Convert.ToString(row[u.salt.Key]),
                        createdDate,
                        editedDate,
                        new UserRole(
                            Convert.ToInt32(row[u.role.Key])),
                        new UserStatus(
                            0
                        )
                    ));
                }
            return listUser;
        }

        private void EncryptPassword(ref String password, ref String salt)
        {
            String staticSalt = WebConfigurationManager.OpenWebConfiguration("/Web.config").AppSettings.Settings["StaticSalt"].Value;
            System.Diagnostics.Debug.WriteLine(staticSalt);
            String dynamicSalt = edp.CreateSalt(18);
            password = edp.CreateHash(password, staticSalt, dynamicSalt);
            salt = dynamicSalt;
        }

    }
}