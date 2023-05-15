using System;
using System.Collections.Generic;

namespace SharedModels
{
    public partial class Login
    {
        public string Id { get; set; } = null!;
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
    }
}
