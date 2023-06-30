using Core.Entities.Base;

namespace Core.Entities
{
    public partial class Owner : EntityBase<int>
    {
        public Owner()
        {
            Properties = new HashSet<Property>();
        }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? Photo { get; set; }
        public DateTime Birthday { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
