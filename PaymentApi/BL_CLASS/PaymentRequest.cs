namespace PaymentApi.BL_CLASS
{
    /// <summary>
    /// Payment request parameters
    /// </summary>
    public class PaymentRequest
    {
        //Payment id
        public int PaymentId { get; set; }

        //Price of product
        public int Price { get; set; }

        //Username of payment
        public string UserName { get; set; }

        //payment category
        public PaymentCategory PaymentCategory { get; set; }

        //Type of payment
        public int PaymentType { get; set; }

    }

    /// <summary>
    /// Response for payment requst
    /// </summary>
    public class PaymentResponse
    {
        //200=Sucess  
        public int StatusCode { get; set; }
        //resonse description
        public string StatusDesc { get; set; }
        // unique messageid for request
        public string MessageId { get; set; }
    }

    /// <summary>
    /// Payment Category
    /// </summary>
    public enum PaymentCategory
    {
        Product=1,
        Memebership=2,
    }

    /// <summary>
    /// Product Type
    /// </summary>
    public enum ProductType
    {
        PhysicalProduct=1,
        Book=2,
        Video=3,
    }

    /// <summary>
    /// MemberShip Type
    /// </summary>
    public enum MemberShipType
    {
        Activate = 1,
        Deactivate = 2,
        Upgrade = 3,
    }

    /// <summary>
    /// Used to decouple client class  and business class
    /// </summary>
    public interface IPayment
    {
        bool ProcessPayment(PaymentRequest objrequest, out string response);
    }
}