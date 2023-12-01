using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using CQRS_lib.Data.Models.Contract;

namespace CQRS_lib.Data.Models
{
    public class Employee : ISoftDeleteable
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("phoneNumber")]
        [Phone, Required, Display(Name = "PhoneNumber"), StringLength(10, MinimumLength = 6)]
        public string? PhoneNumber { get; set; }

        [JsonPropertyName("email")]
        [EmailAddress, Required, Display(Name = "Email"), StringLength(100, MinimumLength = 10)]
        public string? Email { get; set; }

        [JsonPropertyName("salary")]
        public float Salary { get; set; }

        [JsonPropertyName("hireDate")]
        public DateTime? HireDate { get; set; }

        [JsonPropertyName("departmentId")]
        public int DepartmentId { get; set; } // Employee belongs to a Department

        [JsonPropertyName("imagePath")]
        public string? ImagePath { get; set; }


        //[IgnoreDataMember]
        public Department? Department { get; set; } // Navigation property to represent the Department relationship
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }

        public override string ToString()
        {
            return $"Id : {Id} | FirstName : {FirstName} | LastName : {LastName} | Salary : {Salary} | PhoneNumber : {PhoneNumber} | HireDate : {HireDate} | IsDeleted {IsDeleted} | DateDeleted  {DateDeleted}";
        }
    }
}

