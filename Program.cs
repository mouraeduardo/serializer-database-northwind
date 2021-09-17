using System;
using System.Linq;
using agoravai.Models;

namespace agoravai
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new AppDbcontext();

            
            var Clientes = context.Customers.ToList();
            var TodasAsCidades = Clientes.Select(x => x.City).OrderBy(x=> x).ToList();

            foreach (var item in TodasAsCidades)
            {
                Console.Write(item + ", ");
            }

           
            Console.Write("\nDIGITE O NOME DE UMA CIDADE: ");
            string Cidade = Console.ReadLine();
            var ListaClientes = Clientes.Where(x => x.City == Cidade).ToList();

            foreach (var item in ListaClientes)
            {
                Console.WriteLine(item.CompanyName);
            }
        }
    }
}