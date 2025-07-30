namespace AMS.Domain.Entities
{
    public class Employee
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Asset> AssignedAssets { get; set; } = new List<Asset>();
    }
}