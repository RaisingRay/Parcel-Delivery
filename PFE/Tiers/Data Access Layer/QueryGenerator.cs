using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using PFE.Entity.Authentification;
using PFE.Entity.HumanRessources;
using PFE.Entity.Transactions;
namespace PFE.Tiers.Data_Access_Layer
{
    public class QueryGenerator
    {

        public QueryGenerator() { }



        public void generateUpdate(List<Data> data,Data id,String tableName, ref String Query, ref MySqlParameter[] parameters)
        {
            Query = "update " + tableName + " set ";
            parameters = new MySqlParameter[data.Count+1];

            for (int i = 0; i < data.Count; i++)
            {
                if (i != 0)
                    Query += " , ";
                Query += data[i].Key + " = @" + data[i].Key;
                parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);
            }
            Query += " where "+ id.Key + " = @" + id.Key;
            parameters[data.Count]=new MySqlParameter("@" + id.Key, id.Value);
        }

        //update

        public void generateUserSelection(List<Data> data,ref String Query,ref MySqlParameter[] parameters)
        {
            Query = "select * from user";
     
            if (data.Count == 0)
                return;
            else
            {
                User u = new User();
                parameters = new MySqlParameter[data.Count];
                for (int i = 0; i < data.Count; i++)
                {
                    if (i == 0)
                        Query += " where ";
                    else
                        Query += " and ";
                    if (data[i].Key == u.role.Key)
                    {
                        UserRole role = (UserRole)data[i].Value;
                        Query += data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key,role.id.Value);
                    }
                    else if (data[i].Key == u.status.Key)
                    {
                        UserStatus status = (UserStatus)data[i].Value;
                        Query +=  data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, status.id.Value);
                    }
                    else
                    {
                        Query += data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);
                    }
                }
            }

        }
        
        public void generateUserStatusSelection(List<Data> data, ref String Query, ref MySqlParameter[] parameters)
        {
            Query = "select * from user_status";

            if (data.Count == 0)
                return;
            else
            {
                parameters = new MySqlParameter[data.Count];
                for (int i = 0; i < data.Count; i++)
                {
                    if (i == 0)
                        Query += " where ";
                    else
                        Query += " and ";
                   
                        Query += data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);
                    
                }

            }
        }

        public void generateUserRoleSelection(List<Data> data, ref String Query, ref MySqlParameter[] parameters)
        {
            Query = "select * from user_role";

            if (data.Count == 0)
                return;
            else
            {
                parameters = new MySqlParameter[data.Count];
                for (int i = 0; i < data.Count; i++)
                {
                    if (i == 0)
                        Query += " where ";
                    else
                        Query += " and ";

                    Query += data[i].Key + "=@" + data[i].Key;
                    parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);

                }

            }
        }
        public void generateAddressSelection(List<Data> data, ref String Query, ref MySqlParameter[] parameters)
        {
            Query = "select * from address";

            if (data.Count == 0)
                return;
            else
            {
                parameters = new MySqlParameter[data.Count];
                for (int i = 0; i < data.Count; i++)
                {
                    if (i == 0)
                        Query += " where ";
                    else
                        Query += " and ";

                    Query += data[i].Key + "=@" + data[i].Key;
                    parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);

                }
            }
        }

        public void generatePersonSelection(List<Data> data, ref String Query, ref MySqlParameter[] parameters)
        {
            Person p = new Person();
            Query = "select * from person p , user u where p."+p.id.Key+"=u."+ p.id.Key;

            if (data.Count == 0)
                return;
            else
            {
                
                parameters = new MySqlParameter[data.Count];
                for (int i = 0; i < data.Count; i++)
                {
                        Query += " and ";
                    if (data[i].Key == p.address.Key)
                    {
                        Address a = (Address)data[i].Value;
                        Query +="p."+ data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, a.id.Value);
                    }else if (data[i].Key == p.id.Key)
                    {
                        Query+="p."+ data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);
                    }
                    else
                    {
                        Query += data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);
                    }

                }
            }
        }

        public void generateCustomerSelection(List<Data> data, ref String Query, ref MySqlParameter[] parameters)
        {
            Customer c = new Customer();
            Query = "select * from customer c, person p ,user u" +
                " where " +
                " c."+c.cin.Key+ " = p." + c.cin.Key+" and " +
                " u."+c.id.Key+ " = p." + c.id.Key;
            if (data.Count == 0)
                return;
            else
            {

                parameters = new MySqlParameter[data.Count];
                for (int i = 0; i < data.Count; i++)
                {
                    Query += " and ";
                    if (data[i].Key == c.address.Key)
                    {
                        Address a = (Address)data[i].Value;
                        Query += "p." + data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, a.id.Value);
                    }
                    else if (data[i].Key == c.id.Key)
                    {
                        Query += "p." + data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);
                    } 
                    else if (data[i].Key==c.cin.Key)
                    {
                        Query += "p." + data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);
                    }
                    else
                    {
                        Query += data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);
                    }

                }
            }
        }

        public void generateEmployeeSelection(List<Data> data, ref String Query, ref MySqlParameter[] parameters)
        {
            Employee e = new Employee();
            Query = "select * from employee e,person p,user u where" +
                " e." + e.cin.Key + "=p." + e.cin.Key + " and" +
                " p." + e.id.Key + "=u." + e.id.Key;
            if (data.Count == 0)
                return;
            else
            {

                parameters = new MySqlParameter[data.Count];
                for (int i = 0; i < data.Count; i++)
                {
                    Query += " and ";
                    if (data[i].Key == e.address.Key)
                    {
                        Address a = (Address)data[i].Value;
                        Query += "p." + data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, a.id.Value);
                    }
                    else if (data[i].Key == e.id.Key)
                    {
                        Query += "p." + data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);
                    }
                    else if (data[i].Key == e.cin.Key)
                    {
                        Query += "p." + data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);
                    }
                    else
                    {
                        Query += data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);
                    }

                }
            }
        }

        public void generateDriverSelection(List<Data> data, ref String Query, ref MySqlParameter[] parameters)
        {
            Driver d = new Driver();
            Query = "select * from driver d, employee e,person p,user u where" +
                    " e." + d.cin.Key + "=p." + d.cin.Key + " and " +
                    " p." + d.id.Key + "=u." + d.id.Key + " and " +
                     " d."+d.empId.Key+"=e."+d.empId.Key;
            if (data.Count == 0)
                return;
            else
            {

                parameters = new MySqlParameter[data.Count];
                for (int i = 0; i < data.Count; i++)
                {
                    Query += " and ";
                    if (data[i].Key == d.address.Key)
                    {
                        Address a = (Address)data[i].Value;
                        Query += "p." + data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, a.id.Value);
                    }
                    else if (data[i].Key == d.id.Key)
                    {
                        Query += "p." + data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);
                    }
                    else if (data[i].Key == d.cin.Key)
                    {
                        Query += "p." + data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);
                    }
                    else if (data[i].Key == d.empId.Key)
                    {
                        Query += "p." + data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);
                    }
                    else if (data[i].Key == d.vehicle.Key)
                    {
                        Vehicle v = (Vehicle)data[i].Value;
                        Query += data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, v.id.Value);
                    }
                    else
                    {
                        Query += data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);
                    }

                }
            }
        }

        public void generatePackageSelection(List<Data> data, ref String Query, ref MySqlParameter[] parameters)
        {
            Query = "select * from package";
            if (data.Count == 0)
                return;
            else
            {
                parameters = new MySqlParameter[data.Count];
                for (int i = 0; i < data.Count; i++)
                {
                    if (i == 0)
                        Query += " where ";
                    else
                        Query += " and ";

                    Query += data[i].Key + "=@" + data[i].Key;
                    parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);

                }

            }
        }

        public void generateLocationSelection(List<Data> data, ref String Query, ref MySqlParameter[] parameters)
        {
            Query = "select * from location";
            if (data.Count == 0)
                return;
            else
            {
                parameters = new MySqlParameter[data.Count];
                for (int i = 0; i < data.Count; i++)
                {
                    if (i == 0)
                        Query += " where ";
                    else
                        Query += " and ";

                    Query += data[i].Key + "=@" + data[i].Key;
                    parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);

                }
            }
        }

        public void generateVehicleSelection(List<Data> data, ref String Query, ref MySqlParameter[] parameters)
        {
            Query = "select * from vehicle";
            if (data.Count == 0)
                return;
            else
            {
                parameters = new MySqlParameter[data.Count];
                for (int i = 0; i < data.Count; i++)
                {
                    if (i == 0)
                        Query += " where ";
                    else
                        Query += " and ";

                    Query += data[i].Key + "=@" + data[i].Key;
                    parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);

                }
            }
        }

        public void generateOrderTransportSelection(List<Data> data, ref String Query, ref MySqlParameter[] parameters)
        {
            OrderTransport ot = new OrderTransport();
            Query = "select * from order_transport";
            if (data.Count == 0)
                return;
            else
            {
                parameters = new MySqlParameter[data.Count];
                for (int i = 0; i < data.Count; i++)
                {
                    if (i == 0)
                        Query += " where ";
                    else
                        Query += " and ";
                    if (data[i].Key==ot.pickupLocation.Key)
                    {
                        Location l = (Location)data[i].Value;
                        Query += data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, l.id.Value);
                    }
                    else if (data[i].Key == ot.destination.Key)
                    {
                        Location l = (Location)data[i].Value;
                        Query += data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, l.id.Value);

                    }
                    else if (data[i].Key == ot.customer.Key)
                    {
                        Customer c = (Customer)data[i].Value;
                        Query += data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, c.ctmId.Value);
                    }
                    else if (data[i].Key == ot.package.Key)
                    {
                        Package p = (Package)data[i].Value;
                        Query += data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, p.id.Value);
                    }
                    else if(data[i].Key == ot.invoice.Key)
                    {
                        Invoice invoice = (Invoice)data[i].Value;
                        Query += data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, invoice.id.Value);
                    }else
                    {
                        Query += data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);
                    }
                
                }
            }
            
        }


        public void generateInvoiceSelection(List<Data> data, ref String Query, ref MySqlParameter[] parameters)
        {
            Invoice invoice = new Invoice();
            Query = "select * from invoice";
            if (data.Count == 0)
                return;
            else
            {
                parameters = new MySqlParameter[data.Count];
                for (int i = 0; i < data.Count; i++)
                {
                    if (i == 0)
                        Query += " where ";
                    else
                        Query += " and ";
                    Query += data[i].Key + "=@" + data[i].Key;
                    parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);
                }
            }
            
        }

        public void generateAssignmentSelection(List<Data> data, ref String Query, ref MySqlParameter[] parameters)
        {
            Assignment a = new Assignment();
            Query = "select * from assignment";
            if (data.Count == 0)
                return;
            else
            {
                parameters = new MySqlParameter[data.Count];
                for (int i = 0; i < data.Count; i++)
                {
                    if (i == 0)
                        Query += " where ";
                    else
                        Query += " and ";
                    if (data[i].Key == a.order.Key)
                    {
                        OrderTransport ot = (OrderTransport)data[i].Value;
                        Query += data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, ot.id.Value);
                    }
                    else if (data[i].Key == a.employee.Key)
                    {
                        Employee e = (Employee)data[i].Value;
                        Query += data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, e.empId.Value);

                    }
                    else if (data[i].Key == a.driver.Key)
                    {
                        Driver d = (Driver)data[i].Value;
                        Query += data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, d.dvrId.Value);
                    }
      
                    else
                    {
                        Query += data[i].Key + "=@" + data[i].Key;
                        parameters[i] = new MySqlParameter("@" + data[i].Key, data[i].Value);
                    }
                }
            }

        }
    }
}