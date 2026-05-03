namespace StockManagement.Core
{
    public class Joint
    {
        public int JointId { get; set; }
        public int SpoolId { get; set; }
        public string JointNumber { get; set; } = string.Empty; // e.g., J-001
        public string? Description { get; set; }

        // The two component parts that constitute this joint
        public int Part1ComponentId { get; set; }
        public int Part2ComponentId { get; set; }

        // Optional navigation properties
        public Component? Part1Component { get; set; }
        public Component? Part2Component { get; set; }
    }
}
