using DataAccess.DataAccess;

namespace DataAccess.Models
{
    public class User : Base
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Code { get; set; }
    }
}
