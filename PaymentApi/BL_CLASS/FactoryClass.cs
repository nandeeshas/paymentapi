namespace PaymentApi.BL_CLASS
{
    /// <summary>
    /// Its a factory class: The creation of object is done here
    /// </summary>
    public class FactoryClass
    {

        public IPayment GetPaymentType(PaymentRequest objRequest)
        {
            IPayment objpaPayment = null;
            switch (objRequest.PaymentCategory)
            {
                case PaymentCategory.Memebership:
                    objpaPayment=new MemberShip();
                    break;
                case PaymentCategory.Product:
                    objpaPayment=new Product();
                    break;
            }
            return objpaPayment;
        }
    }
}