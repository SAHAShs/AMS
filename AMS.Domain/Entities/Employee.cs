namespace AMS.Domain.Entities
{
    public class Employee
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Asset> AssignedAssets { get; set; }
    }
}