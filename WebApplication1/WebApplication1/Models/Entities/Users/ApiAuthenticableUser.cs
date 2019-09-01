using LdDevWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entities
{
    public class ApiAuthenticableUser //: Person
    {
        public Guid Id { get; set; } //LD defining it because not inheriting yet form "Person"
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
