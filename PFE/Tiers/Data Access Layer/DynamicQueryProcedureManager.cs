using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using PFE.Entity.Authentification;
using PFE.Entity.Transactions;
using PFE.Entity.HumanRessources;

namespace PFE.Tiers.Data_Access_Layer
{
    public class DynamicQueryProcedureManager :DataBaseAccess
    {

        private DataBaseForm dbf = new DataBaseForm();
        private QueryGenerator qg = new QueryGenerator();
        private MySqlParameter[] parameters = null;
        private String Query = null;


        public DynamicQueryProcedureManager() : base() { }


        /******************************************__SELECTIONS__**********************************************************/

        protected DataTable selectUser(List<Data> data)
        {
            qg.generateUserSelection(data, ref Query, ref parameters);

            return dataTableConverter(onlineSelection(Query, parameters), dbf["user"]);
        }

        protected DataTable selectUserStatus(List<Data> data)
        {

            qg.generateUserStatusSelection(data, ref Query, ref parameters);

            return dataTableConverter(onlineSelection(Query, parameters), dbf["user_status"]);
        }

        protected DataTable selectUserRole(List<Data> data)
        {
            qg.generateUserRoleSelection(data, ref Query, ref parameters);

            return dataTableConverter(onlineSelection(Query, parameters), dbf["user_role"]);
        }

        protected DataTable selectPerson(List<Data> data)
        {
            qg.generatePersonSelection(data, ref Query, ref parameters);

            return dataTableConverter(onlineSelection(Query, parameters), dbf["user"].Concat(dbf["person"]).Distinct().ToList());
        }

        protected DataTable selectAddress(List<Data> data)
        {
            qg.generateAddressSelection(data, ref Query, ref parameters);

            return dataTableConverter(onlineSelection(Query, parameters), dbf["address"]);
        }

        protected DataTable selectCustomer(List<Data> data)
        {
            qg.generateCustomerSelection(data, ref Query, ref parameters);

            return dataTableConverter(onlineSelection(Query, parameters), dbf["user"].Concat(dbf["person"]).Concat(dbf["customer"]).Distinct().ToList());
        }

        protected DataTable selectEmployee(List<Data> data)
        {
            qg.generateEmployeeSelection(data, ref Query, ref parameters);

            return dataTableConverter(onlineSelection(Query, parameters), dbf["user"].Concat(dbf["person"]).Concat(dbf["employee"]).Distinct().ToList());
        }

        protected DataTable selectDriver(List<Data> data)
        {
            qg.generateDriverSelection(data, ref Query, ref parameters);

            return dataTableConverter(onlineSelection(Query, parameters), dbf["user"].Concat(dbf["person"]).Concat(dbf["employee"]).Concat(dbf["driver"]).Distinct().ToList());
        }

        protected DataTable selectPackage(List<Data> data)
        {
            qg.generatePackageSelection(data, ref Query, ref parameters);

            return dataTableConverter(onlineSelection(Query, parameters), dbf["package"]);
        }

        protected DataTable selectLocation(List<Data> data)
        {
            qg.generateLocationSelection(data, ref Query, ref parameters);

            return dataTableConverter(onlineSelection(Query, parameters), dbf["location"]);
        }

        protected DataTable selectVehicle(List<Data> data)
        {
            qg.generateVehicleSelection(data, ref Query, ref parameters);
            
            return dataTableConverter(onlineSelection(Query, parameters), dbf["vehicle"]);
        }

        protected DataTable selectOrderTransport(List<Data> data)
        {
            qg.generateOrderTransportSelection(data, ref Query, ref parameters);

            return dataTableConverter(onlineSelection(Query, parameters), dbf["order_transport"]);
        }

        protected DataTable selectAssignment(List<Data> data)
        {
            qg.generateAssignmentSelection(data, ref Query, ref parameters);

            return dataTableConverter(onlineSelection(Query, parameters), dbf["assignment"]);
        }

        protected DataTable selectInvoice(List<Data> data)
        {
            qg.generateInvoiceSelection(data, ref Query, ref parameters);
            return dataTableConverter(onlineSelection(Query, parameters), dbf["invoice"]);
        }
        //special Query


        protected DataTable selectNotAssignedOrderTransport()
        {
            Query = "select  * from order_transport where order_id not in (select order_id from assignment)";
            return dataTableConverter(offlineSelection(Query), dbf["order_transport"]);
        }
        

        protected object selectDriverVehicleWeight(Data driverId)
        {
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@" + driverId.Key, driverId.Value);

            return onlineProcedureCallScaler("Driver_Vehicle_On_Weight", parameters);
        }


        protected DataTable selectDriversAssignment(Data driverId)
        {
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@" + driverId.Key, driverId.Value);

            return dataTableConverter(onlineProcedureCall("Driver_Assignments", parameters),dbf["assignment"]);
        }

        protected object checkCardExist(int number,int cvv,String name)
        {
            MySqlParameter[] parameters = new MySqlParameter[3];
            parameters[0] = new MySqlParameter("@card_number", number);
            parameters[1] = new MySqlParameter("@cvv", cvv);
            parameters[2] = new MySqlParameter("@card_name", name);

            return onlineProcedureCallScaler("Card_Check", parameters);
        }


        protected DataTable selectPickupOrder()
        {
            return dataTableConverter(offlineProcedureCall("PickupOrders"), dbf["order_transport"]);
        }


        protected DataTable selectDeliveryOrder()
        {
            return dataTableConverter(offlineProcedureCall("DeliveryOrders"), dbf["order_transport"]);
        }


        /******************************************__Update__**********************************************************/


        protected int updateUserStatus(List<Data> data,Data id)
        {
            qg.generateUpdate(data, id, "user_status", ref Query, ref parameters);
            return updateQuery(Query, parameters);
        }

        protected int updateUser(List<Data> data, Data id)
        {
            qg.generateUpdate(data, id, "user", ref Query, ref parameters);
            return updateQuery(Query, parameters);
        }

        protected int updatePerson(List<Data> data, Data id)
        {
            qg.generateUpdate(data, id, "person", ref Query, ref parameters);
            return updateQuery(Query, parameters);
        }

        protected int updateCustomer(List<Data> data, Data id)
        {
            qg.generateUpdate(data, id, "customer", ref Query, ref parameters);
            return updateQuery(Query, parameters);
        }

        protected int updateEmployee(List<Data> data, Data id)
        {
            qg.generateUpdate(data, id, "employee", ref Query, ref parameters);
            return updateQuery(Query, parameters);
        }

        protected int updateDriver(List<Data> data, Data id)
        {
            qg.generateUpdate(data, id, "driver", ref Query, ref parameters);
            System.Diagnostics.Debug.WriteLine(Query);
            return updateQuery(Query, parameters);
        }

        protected int updateVehicle(List<Data> data, Data id)
        {
            qg.generateUpdate(data, id, "vehicle", ref Query, ref parameters);
            return updateQuery(Query, parameters);
        }

        protected int updateAddress(List<Data> data, Data id)
        {
            qg.generateUpdate(data, id, "address", ref Query, ref parameters);
            return updateQuery(Query, parameters);
        }

        protected int updateOrderTransport(List<Data> data, Data id)
        {
            qg.generateUpdate(data, id, "order_transport", ref Query, ref parameters);
            return updateQuery(Query, parameters);
        }

        protected int updateAssignment(List<Data> data, Data id)
        {
            qg.generateUpdate(data, id, "assignment", ref Query, ref parameters);
            return updateQuery(Query, parameters);
        }

        /******************************************__INSERT__**********************************************************/

       

        protected int insertUserStatus(UserStatus status)
        {
            MySqlParameter[] parameters = new MySqlParameter[2];
            parameters[0] = new MySqlParameter("@" + status.lastLogIn.Key, status.lastLogIn.Value);
            parameters[1] = new MySqlParameter("@" + status.loggedIn.Key, status.loggedIn.Value);

            return insertProcedureCall("ADD_USER_STATUS",parameters);
        }

        protected int insertUserRole(UserRole role)
        {
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@" + role.role.Key,role.role.Value);

            return insertProcedureCall("ADD_USER_ROLE", parameters);
        }

        protected int insertUser(User user)
        {
            UserStatus status=(UserStatus)user.status.Value;
            status.lastLogIn.Value = DateTime.Now;
            status.loggedIn.Value = true;
            UserRole role=(UserRole)user.role.Value;
            MySqlParameter[] parameters = new MySqlParameter[6];
            parameters[0] = new MySqlParameter("@" +user.email.Key ,user.email.Value);
            parameters[1] = new MySqlParameter("@" +user.password.Key ,user.password.Value);
            parameters[2] = new MySqlParameter("@" +user.salt.Key ,user.salt.Value);
            parameters[3] = new MySqlParameter("@" +user.createdDate.Key ,user.createdDate.Value);
            parameters[4] = new MySqlParameter("@" +user.role.Key ,role.id.Value);
            parameters[5] = new MySqlParameter("@" +user.status.Key ,insertUserStatus(status));

            return insertProcedureCall("ADD_USER", parameters);
        }

        protected int insertPerson(Person person)
        {
            Address address = (Address) person.address.Value;

            MySqlParameter[] parameters = new MySqlParameter[6];
            parameters[0] = new MySqlParameter("@" + person.cin.Key, person.cin.Value);
            parameters[1] = new MySqlParameter("@" +person.firstName.Key,person.firstName.Value);
            parameters[2] = new MySqlParameter("@" +person.lastName.Key,person.lastName.Value);
            parameters[3] = new MySqlParameter("@" +person.phonenumber.Key,person.phonenumber.Value);
            parameters[4] = new MySqlParameter("@" +person.id.Key,insertUser(person));
            parameters[5] = new MySqlParameter("@" +person.address.Key,address.id.Value);
            return insertProcedureCallWithoutID("ADD_PERSON", parameters);
        }

        protected int insertCustomer(Customer customer)
        {
            MySqlParameter[] parameters = new MySqlParameter[2];
            insertPerson(customer);
            parameters[0] = new MySqlParameter("@" +customer.job.Key,customer.job.Value);
            parameters[1] = new MySqlParameter("@" +customer.cin.Key,customer.cin.Value);

            return insertProcedureCall("ADD_CUSTOMER", parameters);
        }

        protected int insertEmployee(Employee employee)
        {
            MySqlParameter[] parameters = new MySqlParameter[3];
            insertPerson(employee);
            parameters[0] = new MySqlParameter("@" +employee.title.Key,employee.title.Value);
            parameters[1] = new MySqlParameter("@" +employee.hireDate.Key,employee.hireDate.Value);
            parameters[2] = new MySqlParameter("@" +employee.cin.Key,employee.cin.Value);
            return insertProcedureCall("ADD_EMPLOYEE", parameters);
        }

        protected int insertDriver(Driver driver)
        {
            MySqlParameter[] parameters = new MySqlParameter[4];
            int empid = insertEmployee(driver);
            parameters[0] = new MySqlParameter("@" +driver.driverType.Key,driver.driverType.Value);
            parameters[1] = new MySqlParameter("@" +driver.available.Key,driver.available.Value);
            parameters[2] = new MySqlParameter("@" +driver.empId.Key,empid);
            parameters[3] = new MySqlParameter("@" + driver.vehicle.Key,1);

            return insertProcedureCall("ADD_DRIVER", parameters);
        }

        protected int insertPackage(Package package)
        {
            MySqlParameter[] parameters = new MySqlParameter[2];
            parameters[0] = new MySqlParameter("@" +package.materialType.Key,package.materialType.Value);
            parameters[1] = new MySqlParameter("@" +package.weight.Key,package.weight.Value);

            return insertProcedureCall("ADD_PACKAGE", parameters);
        }

        protected int insertLocation(Location location)
        {
            MySqlParameter[] parameters = new MySqlParameter[6];
            parameters[0] = new MySqlParameter("@" + location.state.Key, location.state.Value);
            parameters[1] = new MySqlParameter("@" +location.city.Key,location.city.Value);
            parameters[2] = new MySqlParameter("@" +location.address.Key,location.address.Value);
            parameters[3] = new MySqlParameter("@" +location.zipCode.Key,location.zipCode.Value);
            parameters[4] = new MySqlParameter("@" + location.Latitude.Key, location.Latitude.Value);
            parameters[5] = new MySqlParameter("@" + location.Longitude.Key, location.Longitude.Value);

            return insertProcedureCall("ADD_LOCATION", parameters);
        }

        protected int insertVehicle(Vehicle vehicle)
        {
            MySqlParameter[] parameters = new MySqlParameter[4];
            parameters[0] = new MySqlParameter("@" +vehicle.license_plate.Key,vehicle.license_plate.Value);
            parameters[1] = new MySqlParameter("@" +vehicle.VehicleDate.Key,vehicle.VehicleDate.Value);
            parameters[2] = new MySqlParameter("@" +vehicle.available.Key,vehicle.available.Value);
            parameters[3] = new MySqlParameter("@" +vehicle.maxweight.Key,vehicle.maxweight.Value);

            return insertProcedureCall("ADD_VEHICLE", parameters);
        }

        protected int insertOrderTransport(OrderTransport ordertransport)
        {
            Location pickup = (Location)ordertransport.pickupLocation.Value;
            Location destination = (Location)ordertransport.destination.Value;
            Customer customer = (Customer)ordertransport.customer.Value;
            Package package = (Package)ordertransport.package.Value;
            Invoice invoice = (Invoice)ordertransport.invoice.Value;

            MySqlParameter[] parameters = new MySqlParameter[6];
            parameters[0] = new MySqlParameter("@" +ordertransport.createdDate.Key,ordertransport.createdDate.Value);
            parameters[1] = new MySqlParameter("@" +ordertransport.pickupLocation.Key,pickup.id.Value);
            parameters[2] = new MySqlParameter("@" +ordertransport.destination.Key,destination.id.Value);
            parameters[3] = new MySqlParameter("@" +ordertransport.customer.Key,customer.ctmId.Value);
            parameters[4] = new MySqlParameter("@" +ordertransport.package.Key,package.id.Value);
            parameters[5] = new MySqlParameter("@" + ordertransport.invoice.Key, invoice.id.Value);

            return insertProcedureCall("ADD_ORDER_TRANSPORT",parameters);
        }

        protected int insertAssignment(Assignment assignment)
        {
            OrderTransport order = (OrderTransport)assignment.order.Value;
            Employee employee = (Employee)assignment.employee.Value;
            Driver driver = (Driver)assignment.driver.Value;

            MySqlParameter[] parameters = new MySqlParameter[5];
            parameters[0] = new MySqlParameter("@" +assignment.assignmentDate.Key,assignment.assignmentDate.Value);
            parameters[1] = new MySqlParameter("@" +assignment.order.Key,order.id.Value);
            parameters[2] = new MySqlParameter("@" +assignment.employee.Key,employee.empId.Value);
            parameters[3] = new MySqlParameter("@" +assignment.driver.Key, driver.dvrId.Value);
            parameters[4] = new MySqlParameter("@" + assignment.assignmentType.Key, assignment.assignmentType.Value);

            return insertProcedureCall("ADD_ASSIGNMENT", parameters);
        }

        protected int insertAddress(Address address)
        {
            MySqlParameter[] parameters = new MySqlParameter[5];

            parameters[0] = new MySqlParameter("@" +address.state.Key,address.state.Value);
            parameters[1] = new MySqlParameter("@" +address.city.Key,address.city.Value);
            parameters[2] = new MySqlParameter("@" +address.addressLine1.Key,address.addressLine1.Value);
            parameters[3] = new MySqlParameter("@" +address.addressLine2.Key,address.addressLine2.Value);
            parameters[4] = new MySqlParameter("@" +address.zipCode.Key,address.zipCode.Value);

            return insertProcedureCall("ADD_ADDRESS", parameters);
        }

        protected int insertInvoice(Invoice invoice)
        {
            MySqlParameter[] parameters = new MySqlParameter[4];

            parameters[0] = new MySqlParameter("@" + invoice.price.Key, invoice.price.Value);
            parameters[1] = new MySqlParameter("@" + invoice.RecommandationTax.Key, invoice.RecommandationTax.Value);
            parameters[2] = new MySqlParameter("@" + invoice.AcknowledgmentOfReceipt.Key, invoice.AcknowledgmentOfReceipt.Value);
            parameters[3] = new MySqlParameter("@" + invoice.RemainingPostTax.Key, invoice.RemainingPostTax.Value);

            return insertProcedureCall("ADD_INVOICE", parameters);
        }

        /******************************************__Data Table Convertr__**********************************************************/

        private DataTable dataTableConverter(MySqlDataReader rd, List<String> ColumnNames)
        {
            DataTable table = new DataTable();
            foreach (String ColumnName in ColumnNames)
                table.Columns.Add(ColumnName);
            while (rd.Read())
            {
                DataRow dataRow = table.NewRow();
                foreach (String ColumnName in ColumnNames)
                    dataRow[ColumnName] = rd[ColumnName];
                table.Rows.Add(dataRow);
            }
            Close();
            return table;
        }
    }
}