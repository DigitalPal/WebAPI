using System;

namespace DigitalPal.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
        }

        public Guid? Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid? PlantId { get; set; }
        public Guid? TenantId { get; set; }
    }
}
