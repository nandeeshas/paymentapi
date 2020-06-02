using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentApi.BL_CLASS;
using PaymentApi.Controllers;

namespace PaymentApi.Tests.Controllers
{
    /// <summary>
    /// Summary description for PaymentControllerTest
    /// </summary>
    [TestClass]
    public class PaymentControllerTest
    {

        [TestMethod]
        public void PaymentPost()
        {
            var apiController=new PaymentController();

            var objPay=new PaymentRequest {PaymentId = 123, PaymentType = 1, 
                Price = 1000,PaymentCategory = PaymentCategory.Product,UserName = "naveen"};

            var result = apiController.Post(objPay);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            //Assert.AreEqual("Invalid payment type", result.statusDesc);
        }

        [TestMethod]
        public void PaymentGet()
        {
            var apiController = new PaymentController();
            var objPay = new PaymentRequest
            {
                PaymentId = 123,
                PaymentType = 6,
                Price = 1000,
                PaymentCategory = PaymentCategory.Product,
                UserName = "naveen"
            };


            var result = apiController.Get(objPay);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Invalid product type", result.StatusDesc);
        }
    }
}
