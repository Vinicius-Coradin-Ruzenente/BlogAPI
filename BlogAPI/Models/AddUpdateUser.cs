﻿namespace BlogAPI.Models
{
    public class AddUpdateUser
    {
        public required string Name { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
