using System;

namespace Entities
{
    public abstract class AuditableEntity : Entity
    {
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
