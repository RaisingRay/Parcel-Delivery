using System.Collections.Generic;
using System;
using PFE.Tiers.Data_Access_Layer;
using PFE.Entity.Authentification;
using PFE.Entity.HumanRessources;
using PFE.Entity.Transactions;
namespace PFE.Tiers.Buisnes_Objects_Layer
{
    public class BuisnesObject:DynamicQueryProcedureManager
    {
        private EntityConverter ec = new EntityConverter();
        private List<Data> filters = new List<Data>();

        public BuisnesObject() : base() { }

        public BuisnesObject FilteringBy(Data data)
        {
            filters = new List<Data>();
            filters.Add(data);
            return this;
        }

        public BuisnesObject And(Data data)
        {
            filters.Add(data);
            return this;
        }


        /*******************************__Update__***********************************/
        public int loggedIn(User u, bool log)
        {
            UserStatus status = (UserStatus)u.status.Value;
            status.lastLogIn.Value = DateTime.Now;
            status.loggedIn.Value = log;

            List<Data> data = new List<Data>();
            data.Add(status.lastLogIn);
            data.Add(status.loggedIn);

            return updateUserStatus(data, status.id);
        }


        public int editPerson(Person person)
        {
            List<Data> data = new List<Data>();
            person.editedDate.Value = DateTime.Now;
            data.Add(person.firstName);
            data.Add(person.lastName);
            data.Add(person.phonenumber);
            data.Add(person.editedDate);
            return updatePerson(data, person.cin);
        }

        public int editAddress(Address address)
        {
            List<Data> data = new List<Data>();
            data.Add(address.state);
            data.Add(address.city);
            data.Add(address.addressLine1);
            data.Add(address.addressLine2);
            data.Add(address.zipCode);

            return updateAddress(data, address.id);
        }

        public int editCustomer(Customer customer)
        {
            List<Data> data = new List<Data>();
            customer.ctmEditedDate.Value = DateTime.Now;
            data.Add(customer.job);
            data.Add(customer.ctmEditedDate);

            return updateCustomer(data, customer.ctmId);
        }

        public int editEmployee(Employee employee)
        {
            List<Data> data = new List<Data>();
            employee.empEditedDate.Value = DateTime.Now;
            data.Add(employee.title);
            data.Add(employee.hireDate);
            data.Add(employee.empEditedDate);

            return updateEmployee(data, employee.empId);
        }

        public int editDriver(Driver driver)
        {
            List<Data> data = new List<Data>();
            driver.dvrEditedDate.Value = DateTime.Now;
            data.Add(driver.driverType);
            data.Add(driver.dvrEditedDate);

            return updateDriver(data, driver.dvrId);
        }
        

        //special
        public int AssignmentSuccess(Assignment assignment)
        {
            List<Data> data = new List<Data>();
            data.Add(assignment.done);
            return updateAssignment(data, assignment.id);
        } 
        
        public int SwitchAvailability(Driver driver)
        {
            List<Data> data = new List<Data>();
            data.Add(driver.available);
            return updateDriver(data, driver.dvrId);
        }


        /*******************************__READ__********************************/
        public List<User> getUser()
        {
            try
            {
                return ec.convertUser(selectUser(filters));
            } catch (Exception) { return null; }
        }

        public List<UserStatus> getStatus()
        {
            try
            {
                return ec.convertUserStatus(selectUserStatus(filters));
            } catch (Exception) { return null; }
        }

        public List<UserRole> getRole()
        {
            try
            {
                return ec.convertUserRole(selectUserRole(filters));
            } catch (Exception) { return null; }
        }

        public List<Customer> getCustomer()
        {
            try
            {
                return ec.convertCostumer(selectCustomer(filters));
            } catch (Exception) { return null; }
        }

        public List<Employee> getEmployee()
        {
            try
            {
                return ec.convertEmployee(selectEmployee(filters));
            } catch (Exception) { return null; }
        }

        public List<Driver> getDriver()
        {
            try
            {
                return ec.convertDriver(selectDriver(filters));
            } catch (Exception) { return null; }
        }

        public List<Address> getAddress()
        {
            try
            {
                return ec.convertAddress(selectAddress(filters));
            } catch (Exception) { return null; }
        }

        public List<Package> getPackage()
        {
            try
            {
                return ec.convertPackage(selectPackage(filters));
            } catch (Exception) { return null; }
        }

        public List<Location> getLocation()
        {
            try
            {
                return ec.convertLocation(selectLocation(filters));
            } catch (Exception) { return null; }
        }

        public List<Vehicle> getVehicle()
        {
            try
            {
                return ec.convertVehicle(selectVehicle(filters));
            } catch (Exception) { return null; }
        }

        public List<OrderTransport> getOrderTransport()
        {
            try
            {
                return ec.convertOrderTransport(selectOrderTransport(filters));
            } catch (Exception) { return null; }
        }

        public List<Assignment> getAssignments()
        {
            try
            {
                return ec.convertAssignment(selectAssignment(filters));
            } catch (Exception) { return null; }
        }

        /*special*/

        public List<OrderTransport> getNotAssignedOrderTransport()
        {
            try
            {
                return ec.convertOrderTransport(selectNotAssignedOrderTransport());
            } catch (Exception) { return null; }
        }
        public List<Invoice> getInvoice()
        {
            try
            {
                return ec.convertInvoice(selectInvoice(filters));
            } catch (Exception) { return null; }
        }


        public object getWeightDriversVehicle(Data driverId)
        {
            try
            {
                return selectDriverVehicleWeight(driverId);
            } catch (Exception) { return null; }
        }


        public List<Assignment> getDriverAssignments(Data driverId)
        {
            try
            {
                return ec.convertAssignment(selectDriversAssignment(driverId));
            } catch (Exception) { return null; }
        }

        public List<OrderTransport> getPickupOrder()
        {
            try
            {
                return ec.convertOrderTransport(selectPickupOrder());
            } catch (Exception) { return null; }
        }

        public List<OrderTransport> getDeliveryOrder()
        {
            try { return ec.convertOrderTransport(selectDeliveryOrder()); } catch (Exception) { return null; }
            
        }

        public bool checkCard(int number, int cvv, String name)
        {
            try {
                int count = 0;
                count = Convert.ToInt32(checkCardExist(number, cvv, name));
                return count == 1;
            } catch (Exception) { return false; }
            
        }
        //***************************************************___CREAT___***************************************************************//

        public int addUserStatus(UserStatus status)
        {
            return insertUserStatus(status);
        }
        public int addAddress(Address address)
        {
            return insertAddress(address);
        }
        public int addPackage(Package package)
        {
            return insertPackage(package);
        }
        public int addLocation(Location location)
        {
            return insertLocation(location);
        }
        public int addVehicle(Vehicle vehicle)
        {
            return insertVehicle(vehicle);
        }
        public int addOrderTransport(OrderTransport order)
        {
            return insertOrderTransport(order);
        }
        public int addAssignment(Assignment assignment)
        {
            return insertAssignment(assignment);
        }
        public int addInvoice(Invoice invoice)
        {
            return insertInvoice(invoice);
        }
    }
}