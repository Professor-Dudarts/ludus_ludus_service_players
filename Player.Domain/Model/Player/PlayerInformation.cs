using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Domain.Model.Player
{
    public class PlayerInformation
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? RepresentativeName { get; set; }
        public string? RepresentativePhoneNumber { get; set; }
        public int ShirtNumber { get; set; }
        public string Nickname { get; set; } = null!;
        public string Function { get; set; }
        public string AcronymFunction { get; set; }
    }
}
