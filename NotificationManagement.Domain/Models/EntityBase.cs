using System;

namespace NotificationManagement.Domain.Domain.Models
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
