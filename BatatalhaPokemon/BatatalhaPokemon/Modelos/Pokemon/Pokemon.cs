using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatatalhaPokemon
{
    public abstract class Pokemon : ICombate
    {
        public String Nome { get; private set; }
        public int  Vida { get; set; }
        public int Ataque { get; set; }
        public String Tipo { get; private set; }
        public int Evolucao { get; set; }
        public int HPCombate { get; set; }

        public Pokemon(String nome, int ataque,int evolucao,String tipo)
        {
            Nome = nome;
            Ataque = ataque;
            Vida = Ataque * 10;
            HPCombate = Vida;
            Evolucao = evolucao;
            Tipo = tipo;

        }

        public abstract void Atacar(Pokemon adversario);

        public void BonusLevel(int ataqueExtra)
        {
            Vida = Vida + ataqueExtra * 10;
            Ataque = Ataque + ataqueExtra / 2;
        }


        public void ReceberAtaque(int dano)
        {
            if (HPCombate - dano < 0)
            {
                HPCombate = 0;
            }
            else
            {
                HPCombate -= dano;
            }
        }

        public void restaurarHp()
        {

            HPCombate = Vida;
            
        }

    }
}
