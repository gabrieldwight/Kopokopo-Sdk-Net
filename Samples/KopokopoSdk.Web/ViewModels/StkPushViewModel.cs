namespace KopokopoSdk.Web.ViewModels
{
    public class StkPushViewModel
    {
        public string PaymentChannel { get; set; }
        public string TillNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Currency { get; private set; } = "KES";
        public int Amount { get; set; }
        public string CallbackUrl { get; set; }
    }
}
