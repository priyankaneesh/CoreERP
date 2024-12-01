using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CoreERP.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; } // Primary key
        public string Username { get; set; } = null!; // Username for login
        public string Password { get; set; } = null!; // Password for login
        public string Role { get; set; } = "Admin"; // User role (default: Admin)
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp for creation
    }
}
