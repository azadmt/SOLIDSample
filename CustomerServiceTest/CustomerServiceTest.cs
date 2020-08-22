using CustomerService;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CustomerServiceTest
{
    [TestClass]
    public class CustomerServiceTest
    {
        [TestMethod]
        public void CreateCustomer_WithValidData_ShudCreateCustomer()
        {
            //arrange
            var customerAdded = false;
            var notificationSent = false;
            var logAdded = false;

            using (ShimsContext.Create())
            {
                 CustomerService.Fakes.ShimRepositoryBase<Customer>.AllInstances.AddT0 = (a, b) => { customerAdded = true; };
                //var shimRepositoryBase = new CustomerService.Fakes.ShimRepositoryBase<Customer>()
                //{
                //    AddT0 = (a) => { customerAdded = true; }
                //};

                var shimCustomerRepository = new CustomerService.Fakes.ShimCustomerRepository()
                {
                
                };


                System.IO.Fakes.ShimFile.WriteAllTextStringString = (a, b) => { logAdded = true; };

                var sm = new SmtpClient();
                //System.Net.Mail.
                //       var customerRepoStub = new System.Net.Mail.Fakes.StubSmtpClient
                //       {
                //           Se
                //       };

                //Shim Does not Support Observer on method call
                //https://www.dotnetcurry.com/visualstudio/963/microsoft-fakes-framework-visual-studio

                var customerService = new CustomerService.CustomerService();
                SetPrivateField(customerService, "_repository", shimCustomerRepository.Instance);
                //customerService.CreateCustomer(new Customer { });

                var shimCustomerService = new CustomerService.Fakes.ShimCustomerService()
                {
                    SendNotificationCustomer = (a) => { notificationSent = true; },
                    CreateCustomerCustomer=(a)=> customerService.CreateCustomer(a)
                };

                //SetPrivateField(shimCustomerService.Instance, "_repository", shimCustomerRepository.Instance);
                shimCustomerService.Instance.CreateCustomer(new Customer());
                Assert.IsTrue(customerAdded);
                Assert.IsTrue(notificationSent);
                Assert.IsFalse(logAdded);         
            }
        }

        private void SetPrivateField(CustomerService.CustomerService customerServiceInstance, string fieldName, object value)
        {
            customerServiceInstance.GetType().GetField(fieldName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(customerServiceInstance, value);
        }
    }
}
