
namespace DataAccess.DataAccess
{
    /// <summary>
    /// Base properties in tables.
    /// </summary>
    public class Base
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;
        public bool Available { get; set; } = true;
    }
}
