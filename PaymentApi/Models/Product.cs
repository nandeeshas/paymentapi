using System;

namespace PaymentApi.BL_CLASS
{
    /// <summary>
    /// Genrate Slip
    /// </summary>
    /// <seealso cref="PaymentApi.BL_CLASS.IPayment" />
    public class Product : IPayment
    {
        public bool ProcessPayment(PaymentRequest objrequest,out string response)
        {
            try
            {
                var productType = (ProductType)objrequest.PaymentType;
                switch (productType)
                {
                    case ProductType.PhysicalProduct :
                        response = GenrateSlip(objrequest);
                        break;
                    case ProductType.Video :
                        response = GenrateSlip(objrequest);
                        break;
                    case ProductType.Book:
                        response = GenrateSlip(objrequest);
                        break;
                    default:
                        response = "Invalid product type";
                        return false;
                }
                return true;
            }
            catch (Exception er)
            {
                response = er.Message;
                return false;
            }
        }

        public string GenrateSlip(PaymentRequest objrequest)
        {
          
            return "<html>Slip Genrated sucessfully</html>";
                
        }
    }
}