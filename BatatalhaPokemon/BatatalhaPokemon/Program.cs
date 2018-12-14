using BatatalhaPokemon.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatatalhaPokemon
{
    public class Program
    {
        static void Main(string[] args)
        {

            JogoController batalhaCartasPokemon = null;
            batalhaCartasPokemon = new JogoController();
            batalhaCartasPokemon.IniciaJogoConsole();

            Console.Read();

        }

        public static void PausarAplicacao()
        {
            Console.WriteLine("Pressione enter para continuar...");
            Console.Read();

        }

    }
}
