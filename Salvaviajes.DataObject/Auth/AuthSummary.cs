
namespace Salvaviajes.DataObject
{
    public class AuthSummary
    {
        public int AuthId { get; set; }
    }

    public class AuthInputs
    {
        public int OrganizationId { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
    }
}
