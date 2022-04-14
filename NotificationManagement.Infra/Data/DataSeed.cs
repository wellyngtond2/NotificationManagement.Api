using Microsoft.EntityFrameworkCore;
using NotificationManagement.Domain.Domain.Models;
using System;
using System.Collections.Generic;

namespace NotificationManagement.Infra.Data
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(SeedPerson());
        }

        private static IEnumerable<Person> SeedPerson()
        {
            return new List<Person>()
            {
                new() { Id = 1, Name = "João", Email = "joao@devscope.net",PhoneNumber = "12345678", CreateDate = DateTime.Now},
                new() { Id = 2, Name = "Pedro", Email = "pedro@devscope.net",PhoneNumber = "23456789", CreateDate = DateTime.Now},
                new() { Id = 3, Name = "Marcos", Email = "marcos@devscope.net",PhoneNumber = "34567890", CreateDate = DateTime.Now},
                new() { Id = 4, Name = "Carlos", Email = "carlos@devscope.net",PhoneNumber = "45678901", CreateDate = DateTime.Now},
                new() { Id = 5, Name = "Emanuel", Email = "emanuel@devscope.net",PhoneNumber = "56789012", CreateDate = DateTime.Now},
            };
        }
    }
}
