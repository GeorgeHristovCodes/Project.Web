﻿namespace Project.Web.Models.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Subscribed { get; set; }

        public string ImageUrl { get; set; }

    }
}
