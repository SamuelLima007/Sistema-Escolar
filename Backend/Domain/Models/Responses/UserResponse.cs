using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Backend.Domain.Models.Responses;
using ProjetoNotas.Domain.Enums;
using ProjetoNotas.Domain.Models;

namespace Backend.Domain.Models
{
    [JsonDerivedType(typeof(UserResponse), typeDiscriminator: "base")]
    [JsonDerivedType(typeof(StudentResponse), typeDiscriminator: "Student")]
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UserType Role { get; set; }

    }
}