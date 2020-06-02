using System;
using System.Net;
using System.Web.Http;
using PaymentApi.BL_CLASS;

namespace PaymentApi.Controllers
{
    /// <summary>
    /// This class accept payment requests and process it.
    /// Url:http://localhost/PaymentApi/api/payment
    /// Json Request : { "paymentId": 123, "price": 23, "userName": "ramesh", "paymentCategory": 1, "paymentType": 1 }
    /// Json Response : {"statusCode":200,"statusDesc":"<html>Slip Genrated sucessfully</html>","messageId":"123"}
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class PaymentController : ApiController
    {
        // POST api/payment
        public PaymentResponse Post([FromBody]PaymentRequest objPaymentRequest)
        {
            return GetPaymentResponse(objPaymentRequest);
        }

        // Get api/payment
        public PaymentResponse Get(PaymentRequest objPaymentRequest)
        {
            return GetPaymentResponse(objPaymentRequest);
        }
        /// <summary>
        /// return Payment response
        /// </summary>
        /// <returns></returns>
        private PaymentResponse GetPaymentResponse(PaymentRequest objPaymentRequest)
        {
            var objPaymentResonse = new PaymentResponse();
            try
            {
                if (objPaymentRequest == null)
                {
                    objPaymentResonse.StatusCode = (int)HttpStatusCode.BadRequest;
                    objPaymentResonse.StatusDesc = "Invalid request format";
                    objPaymentResonse.MessageId = "";
                }
                else
                {
                    var objFactoryClass = new FactoryClass();
                    var objPaymenType = objFactoryClass.GetPaymentType(objPaymentRequest);
                    if (objPaymenType != null)
                    {
                        string response;
                        if (objPaymenType.ProcessPayment(objPaymentRequest, out response))
                        {
                            objPaymentResonse.StatusCode = (int) HttpStatusCode.OK;
                            objPaymentResonse.StatusDesc = response;
                            objPaymentResonse.MessageId = objPaymentRequest.PaymentId.ToString();
                        }
                        else
                        {
                            objPaymentResonse.StatusCode = (int) HttpStatusCode.NotAcceptable;
                            objPaymentResonse.StatusDesc = response;
                            objPaymentResonse.MessageId = objPaymentRequest.PaymentId.ToString();
                        }
                    }
                    else
                    {
                        objPaymentResonse.StatusCode = (int)HttpStatusCode.NotAcceptable;
                        objPaymentResonse.StatusDesc = "Invalid payment type";
                        objPaymentResonse.MessageId = ""; 
                    }
                }

            }
            catch (Exception ex)
            {
                objPaymentResonse.StatusCode = (int)HttpStatusCode.InternalServerError;
                objPaymentResonse.StatusDesc = ex.Message;
                objPaymentResonse.MessageId = "";
            }
            return objPaymentResonse;
        }
    }
}
