﻿namespace NotificationManagement.Domain.Domain.Models
{
    public class Person : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
