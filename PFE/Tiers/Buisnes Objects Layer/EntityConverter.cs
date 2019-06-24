using System;
using System.Collections.Generic;
using System.Data;
using PFE.Entity.Authentification;
using PFE.Entity.HumanRessources;
using PFE.Entity.Transactions;
namespace PFE.Tiers.Buisnes_Objects_Layer
{
    public class EntityConverter
    {
        public EntityConverter() { }


        /*****************************************__Authentification__************************************************************/
        public List<UserRole> convertUserRole(DataTable table)
        {
            List<UserRole> listRole = new List<UserRole>();
            UserRole role = new UserRole();
            if (table != null)
                foreach (DataRow row in table.Rows)
                {
                    listRole.Add(new UserRole(
                        Convert.ToInt32(row[role.id.Key]),
                        Convert.ToString(row[role.role.Key])
                        ));
                }
            return listRole;
        }

        public List<UserStatus> convertUserStatus(DataTable table)
        {
            List<UserStatus> listStatus = new List<UserStatus>();
            UserStatus status = new UserStatus();
            DateTime lastLogin = new DateTime();
            if (table != null)
                foreach (DataRow row in table.Rows)
                {
                    if (row[status.lastLogIn.Key] != DBNull.Value)
                        lastLogin = Convert.ToDateTime(row[status.lastLogIn.Key]);

                    listStatus.Add(new UserStatus(
                        Convert.ToInt32(row[status.id.Key]),
                        Convert.ToBoolean(row[status.loggedIn.Key]),
                        lastLogin));
                }
            return listStatus;
        }


        public List<User> convertUser(DataTable table)
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
                        new DateTime(),
                        new DateTime(),
                        new UserRole(
                            Convert.ToInt32(row[u.role.Key])),
                        new UserStatus(
                            Convert.ToInt32(row[u.status.Key])
                        )
                    ));
                }
            return listUser;
        }


        /*********************************************__HumanRessources__************************************************************/

        public List<Customer> convertCostumer(DataTable table)
        {
            List<Customer> listCustomer = new List<Customer>();
            Customer customer = new Customer();

            DateTime editedDate = new DateTime();
            DateTime peditedDate = new DateTime();
            DateTime ceditedDate = new DateTime();
            DateTime createdDate = new DateTime();

            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row[customer.createdDate.Key] != DBNull.Value)
                        createdDate = Convert.ToDateTime(row[customer.createdDate.Key]);

                    if (row[customer.PeditedDate.Key] != DBNull.Value)
                        peditedDate = Convert.ToDateTime(row[customer.PeditedDate.Key]);
                    if (row[customer.ctmEditedDate.Key] != DBNull.Value)
                        ceditedDate = Convert.ToDateTime(row[customer.ctmEditedDate.Key]);

                    if (row[customer.editedDate.Key] != DBNull.Value)
                        editedDate = Convert.ToDateTime(row[customer.editedDate.Key]);

                    listCustomer.Add(new Customer(
                        Convert.ToInt32(row[customer.ctmId.Key]),
                        Convert.ToString(row[customer.job.Key]),
                        ceditedDate,
                        Convert.ToInt32(row[customer.cin.Key]),
                        Convert.ToString(row[customer.firstName.Key]),
                        Convert.ToString(row[customer.lastName.Key]),
                        Convert.ToInt32(row[customer.phonenumber.Key]),
                        peditedDate,
                        new Address(Convert.ToInt32(row[customer.address.Key])),
                            Convert.ToInt32(row[customer.id.Key]),
                            Convert.ToString(row[customer.email.Key]),
                            Convert.ToString(row[customer.password.Key]),
                            Convert.ToString(row[customer.salt.Key]),
                            createdDate,
                            editedDate,
                            new UserRole(
                                Convert.ToInt32(row[customer.role.Key])),
                            new UserStatus(
                                Convert.ToInt32(row[customer.status.Key])
                            )
                        ));
                }

            }
            return listCustomer;
        }



        public List<Employee> convertEmployee(DataTable table)
        {
            List<Employee> listEmployee = new List<Employee>();
            Employee employee = new Employee();

            DateTime editedDate = new DateTime();
            DateTime peditedDate = new DateTime();
            DateTime empeditedDate = new DateTime();
            DateTime hireDate = new DateTime();
            DateTime createdDate = new DateTime();


            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row[employee.createdDate.Key] != DBNull.Value)
                        createdDate = Convert.ToDateTime(row[employee.createdDate.Key]);
                    if (row[employee.hireDate.Key] != DBNull.Value)
                        hireDate = Convert.ToDateTime(row[employee.hireDate.Key]);
                    if (row[employee.PeditedDate.Key] != DBNull.Value)
                        peditedDate = Convert.ToDateTime(row[employee.PeditedDate.Key]);
                    if (row[employee.empEditedDate.Key] != DBNull.Value)
                        empeditedDate = Convert.ToDateTime(row[employee.empEditedDate.Key]);

                    if (row[employee.editedDate.Key] != DBNull.Value)
                        editedDate = Convert.ToDateTime(row[employee.editedDate.Key]);

                    listEmployee.Add(new Employee(
                        Convert.ToInt32(row[employee.empId.Key]),
                        Convert.ToString(row[employee.title.Key]),
                        hireDate,
                        empeditedDate,
                        Convert.ToInt32(row[employee.cin.Key]),
                        Convert.ToString(row[employee.firstName.Key]),
                        Convert.ToString(row[employee.lastName.Key]),
                        Convert.ToInt32(row[employee.phonenumber.Key]),
                        peditedDate,
                        new Address(Convert.ToInt32(row[employee.address.Key])),
                            Convert.ToInt32(row[employee.id.Key]),
                            Convert.ToString(row[employee.email.Key]),
                            Convert.ToString(row[employee.password.Key]),
                            Convert.ToString(row[employee.salt.Key]),
                            createdDate,
                            editedDate,
                            new UserRole(
                                Convert.ToInt32(row[employee.role.Key])),
                            new UserStatus(
                                Convert.ToInt32(row[employee.status.Key])
                            )
                        ));
                }
            }
            return listEmployee;
        }

        public List<Driver> convertDriver(DataTable table)
        {
            List<Driver> listDriver = new List<Driver>();
            Driver driver = new Driver();

            DateTime editedDate = new DateTime();
            DateTime peditedDate = new DateTime();
            DateTime empeditedDate = new DateTime();
            DateTime drveditedDate = new DateTime();
            DateTime hireDate = new DateTime();
            DateTime createdDate = new DateTime();


            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row[driver.createdDate.Key] != DBNull.Value)
                        createdDate = Convert.ToDateTime(row[driver.createdDate.Key]);
                    if (row[driver.hireDate.Key] != DBNull.Value)
                        hireDate = Convert.ToDateTime(row[driver.hireDate.Key]);
                    if (row[driver.PeditedDate.Key] != DBNull.Value)
                        peditedDate = Convert.ToDateTime(row[driver.PeditedDate.Key]);
                    if (row[driver.empEditedDate.Key] != DBNull.Value)
                        empeditedDate = Convert.ToDateTime(row[driver.empEditedDate.Key]);
                    if (row[driver.dvrEditedDate.Key] != DBNull.Value)
                        drveditedDate = Convert.ToDateTime(row[driver.dvrEditedDate.Key]);
                    if (row[driver.editedDate.Key] != DBNull.Value)
                        editedDate = Convert.ToDateTime(row[driver.editedDate.Key]);


                    listDriver.Add(new Driver(
                        Convert.ToInt32(row[driver.dvrId.Key]),
                        Convert.ToString(row[driver.driverType.Key]),
                        Convert.ToBoolean(row[driver.available.Key]),
                        drveditedDate,
                        new Vehicle(Convert.ToInt32(row[new Vehicle().id.Key]))
                        , 
                        Convert.ToInt32(row[driver.empId.Key]),
                        Convert.ToString(row[driver.title.Key]),
                        hireDate,
                        empeditedDate,
                        Convert.ToInt32(row[driver.cin.Key]),
                        Convert.ToString(row[driver.firstName.Key]),
                        Convert.ToString(row[driver.lastName.Key]),
                        Convert.ToInt32(row[driver.phonenumber.Key]),
                        peditedDate,
                        new Address(Convert.ToInt32(row[driver.address.Key])),
                            Convert.ToInt32(row[driver.id.Key]),
                            Convert.ToString(row[driver.email.Key]),
                            Convert.ToString(row[driver.password.Key]),
                            Convert.ToString(row[driver.salt.Key]),
                            createdDate,
                            editedDate,
                            new UserRole(
                                Convert.ToInt32(row[driver.role.Key])),
                            new UserStatus(
                                Convert.ToInt32(row[driver.status.Key])
                            )
                        ));
                }
            }
            return listDriver;
        }

        public List<Address> convertAddress(DataTable table)
        {
            List<Address> listAddress = new List<Address>();
            Address addres = new Address();
            DateTime editedDate = new DateTime();
            if(table != null)
            {
                foreach(DataRow row in table.Rows)
                {
                    if (row[addres.editDate.Key] != DBNull.Value)
                        editedDate = Convert.ToDateTime(row[addres.editDate.Key]);

                    listAddress.Add(new Address(
                        Convert.ToInt32(row[addres.id.Key]),
                        Convert.ToString(row[addres.state.Key]),
                        Convert.ToString(row[addres.city.Key]),
                        Convert.ToString(row[addres.addressLine1.Key]),
                        Convert.ToString(row[addres.addressLine2.Key]),
                        Convert.ToInt32(row[addres.zipCode.Key]),
                        editedDate));
                }

            }
            return listAddress;
        }

        /***************************************___Transactions___********************************************************/

        public List<Package> convertPackage(DataTable table)
        {
            List<Package> listPackage = new List<Package>();
            Package package = new Package();

            if (table != null)
            {
                foreach(DataRow row in table.Rows)
                {
                    listPackage.Add(new Package(
                        Convert.ToInt32(row[package.id.Key]),
                        Convert.ToString(row[package.materialType.Key]),
                        (float) Convert.ChangeType(row[package.weight.Key], typeof(float))
                        ));
                }
            }
            return listPackage;
        }

        public List<Location> convertLocation(DataTable table)
        {
            List<Location> listLocation = new List<Location>();
            Location location = new Location();
            double lat = 0;
            double lng = 0;

            if(table != null)
            {
                foreach(DataRow row in table.Rows)
                {
                    if (row[location.Latitude.Key] != DBNull.Value)
                        lat = Convert.ToDouble(row[location.Latitude.Key]);
                    if (row[location.Longitude.Key] != DBNull.Value)
                        lng = Convert.ToDouble(row[location.Longitude.Key]);

                    listLocation.Add(new Location(
                        Convert.ToInt32(row[location.id.Key]),
                        Convert.ToString(row[location.state.Key]),
                        Convert.ToString(row[location.city.Key]),
                        Convert.ToString(row[location.address.Key]),
                        Convert.ToInt32(row[location.zipCode.Key]),
                        lat,
                        lng
                        ));
                }
            }
            return listLocation;
        }

        public List<Vehicle> convertVehicle(DataTable table)
        {
            List<Vehicle> listVehicle = new List<Vehicle>();
            Vehicle vehicle = new Vehicle();
            DateTime vehicleDate = new DateTime();
            if(table != null)
            {
                foreach(DataRow row in table.Rows)
                {
                    if (row[vehicle.VehicleDate.Key] != DBNull.Value)
                        vehicleDate = Convert.ToDateTime(row[vehicle.VehicleDate.Key]);
                    listVehicle.Add(new Vehicle(
                        Convert.ToInt32(row[vehicle.id.Key]),
                        Convert.ToString(row[vehicle.license_plate.Key]),
                        Convert.ToBoolean(row[vehicle.available.Key]),
                        vehicleDate,
                        (float) Convert.ChangeType(row[vehicle.maxweight.Key], typeof(float))
                        ));
                }
            }
            return listVehicle;
        }

        public List<OrderTransport> convertOrderTransport(DataTable table)
        {
            List<OrderTransport> listOrder = new List<OrderTransport>();
            OrderTransport order = new OrderTransport();
            DateTime createdDate = new DateTime();

            if(table != null)
            {
                foreach(DataRow row in table.Rows)
                {

                    if (row[order.createdDate.Key] != DBNull.Value)
                        createdDate = Convert.ToDateTime(row[order.createdDate.Key]);
                    listOrder.Add(new OrderTransport(
                        Convert.ToInt32(row[order.id.Key]),
                        createdDate,
                        new Location(Convert.ToInt32(row[order.pickupLocation.Key])),
                        new Location(Convert.ToInt32(row[order.destination.Key])),
                        new Package(Convert.ToInt32(row[order.package.Key])),
                        new Customer(Convert.ToInt32(row[order.customer.Key])),
                        new Invoice(Convert.ToInt32(row[order.invoice.Key]))
                        ));
                }
            }
            return listOrder;
        }

        public List<Assignment> convertAssignment(DataTable table)
        {
            List<Assignment> listAssignment = new List<Assignment>();
            Assignment assignment = new Assignment();

            DateTime assignmentDate = new DateTime();
            DateTime editedDate = new DateTime();

            if(table != null)
            {
                foreach(DataRow row in table.Rows)
                {
                    if (row[assignment.assignmentDate.Key] != DBNull.Value)
                        assignmentDate = Convert.ToDateTime(row[assignment.assignmentDate.Key]);
                    if (row[assignment.editedDate.Key] != DBNull.Value)
                        editedDate = Convert.ToDateTime(row[assignment.editedDate.Key]);

                    listAssignment.Add(new Assignment(
                        Convert.ToInt32(row[assignment.id.Key]),
                        assignmentDate,
                        editedDate,
                        new OrderTransport(Convert.ToInt32(row[assignment.order.Key])),
                        new Employee(Convert.ToInt32(row[assignment.employee.Key])),
                        new Driver(Convert.ToInt32(row[assignment.driver.Key])),
                        Convert.ToString(row[assignment.assignmentType.Key]),
                        Convert.ToBoolean(row[assignment.done.Key])
                        ));
                }
            }
            return listAssignment;
        }

        public List<Invoice> convertInvoice(DataTable table)
        {
            List<Invoice> listInvoice = new List<Invoice>();
            Invoice invoice = new Invoice();
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    listInvoice.Add(new Invoice(
                        Convert.ToInt32(row[invoice.id.Key]),
                        Convert.ToDouble(row[invoice.price.Key]),
                        Convert.ToBoolean(row[invoice.RecommandationTax.Key]),
                        Convert.ToBoolean(row[invoice.AcknowledgmentOfReceipt.Key]),
                        Convert.ToBoolean(row[invoice.RemainingPostTax.Key])
                        ));
                }
            }
            return listInvoice;
        }

    }
}