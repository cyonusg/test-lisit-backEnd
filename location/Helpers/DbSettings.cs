using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace users.Helpers
{
    public class DbSettings {
        public string? Server { get; set; }
        public string? Database { get; set; }
        public string? UserId { get; set; }
        public int? Port { get; set; }
        public string? Password { get; set; }
    }
}