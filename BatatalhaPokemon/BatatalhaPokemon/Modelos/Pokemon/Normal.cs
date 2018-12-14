using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatatalhaPokemon
{
    public class Normal : Pokemon
    {
        public String NomeAtaque { get; set; }

        public Normal(String nome, String tipo, int ataque, int evolucao):base(nome,ataque,evolucao,tipo)
        {

            //NomeAtaque ="Ataque de "+tipo;

            NomeAtaque = "Ataque de";
            String.Concat(NomeAtaque+" "+tipo);

        }

        public override void Atacar(Pokemon adversario)
        {
             Console.WriteLine(base.Nome + " usou " + NomeAtaque + " no " + adversario.Nome);

            if (adversario.HPCombate > 0)
            {
                adversario.ReceberAtaque(base.Ataque);
            }
        }
     }
}
