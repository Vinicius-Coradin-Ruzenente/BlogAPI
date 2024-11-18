﻿namespace BlogAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public List<Post> Posts { get; set; } = []; 
    }
}
