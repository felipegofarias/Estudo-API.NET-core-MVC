using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Department
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        //Lista de vendedores
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();



        public Department()
        {
        }

        //Construtor
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }


        //para adicionar um vendedor
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        //calcular a quantidade de vendas do departamento nesse intervalo de datas
        //pegar a lista de vendedores e somar o total de vendas de cada vendedor nesse intervalo de datas
        public double TotalSales(DateTime initial, DateTime final)
        {
            //pegando cada vendedor da lista, chamando o total de sales do vendedor naquele periodo  e ai faz a soma desse resultado para todos os vendedores desse departamento
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }

    }
}
