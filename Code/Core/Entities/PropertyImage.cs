using Core.Entities.Base;

namespace Core.Entities
{
    public partial class PropertyImage : EntityBase<int>
    {
        public int IdProperty { get; set; }
        public string FileUrl { get; set; } = null!;
        public bool Enabled { get; set; }
        public virtual Property IdPropertyNavigation { get; set; } = null!;
    }
}
