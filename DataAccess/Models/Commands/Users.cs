using System;
using System.Collections.Generic;

namespace DataAccess.Domain.Commands
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
    }
}
