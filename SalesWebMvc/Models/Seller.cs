using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;



namespace SalesWebMvc.Models
{
    public class Seller
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
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
