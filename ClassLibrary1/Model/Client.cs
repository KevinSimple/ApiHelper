using ApiHelper.Shared;

namespace ApiHelper.Model
{
    public class Client:ModelBaseClass
    {
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
