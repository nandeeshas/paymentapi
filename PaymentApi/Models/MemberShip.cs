using System;

namespace PaymentApi.BL_CLASS
{
    /// <summary>
    /// Accept request and process email
    /// </summary>
    /// <seealso cref="PaymentApi.BL_CLASS.IPayment" />
    public class MemberShip : IPayment
    {
        public bool ProcessPayment(PaymentRequest objrequest, out string response)
        {
            try
            {
                var productType = (MemberShipType)objrequest.PaymentType;
                switch (productType)
                {
                    case MemberShipType.Activate:
                        response = SendEmail(objrequest);
                        break;
                    case MemberShipType.Deactivate:
                        response = SendEmail(objrequest);
                        break;
                    case MemberShipType.Upgrade:
                        response = SendEmail(objrequest);
                        break;
                    default:
                        response = "Invalid Memebership type";
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

        public string SendEmail(PaymentRequest objrequest)
        {

            return "Email sent sucessfully";

        }
    }
}