using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatatalhaPokemon
{
    public class Planta : Pokemon
    {
        public String NomeAtaque { get; set; }

        public Planta(string nome,String tipo, int ataque, int evolucao):base(nome,ataque,evolucao,tipo)
        {
            
        }

        public override void Atacar(Pokemon adversario)
        {
            
        }
    }
}
