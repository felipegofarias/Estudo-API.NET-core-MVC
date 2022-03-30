 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;



namespace SalesWebMvc.Models
{
    public class Seller
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required ")]
        [StringLength (60, MinimumLength = 3, ErrorMessage ="Name size should be between 3 and 60")]
        public string Name { get; set; }


        [Required(ErrorMessage = "{0} required ")]
        [DataType (DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "{0} required ")]
        [Display (Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }


        [Required(ErrorMessage = "{0} required ")]
        [Display (Name = "Base Salary")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }



        [Display (Name = "Department Id")]
        public int DepartmentId { get; set; }


        //Lista de vendas de um vendedor
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();



        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }



        //adiconar vendas
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        //remover vendas
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        //Calcular o total de vendas de um vendedor  em um determinado intervalo de datas
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }


    }
}
