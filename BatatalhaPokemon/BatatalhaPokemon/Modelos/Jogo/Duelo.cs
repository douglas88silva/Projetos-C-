using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BatatalhaPokemon
{
    public class Duelo
    {
        public Jogador Player { get; set; }
        public Jogador Adversario { get; set; }
        public static int Tempo { get; set; }
        public int Vencedor { get; set; }
        


        public Duelo(Jogador player, Jogador adversario)
        {

            Player = player;
            Adversario = adversario;


        }

        public int Duelar()
        {

            Pokemon pokemonPlayer = Player.PokemonPrincipal.Pk;
            Pokemon pokemonAdversario = Adversario.PokemonPrincipal.Pk;

            pokemonPlayer.RestaurarHp();
            pokemonAdversario.RestaurarHp();

            Random r = new Random();
            ResetarContador();

            Console.WriteLine("####Duracao da partida: " + Duelo.Tempo + " ####");
            while ((Tempo /*=Tempo - 3*/) > 0 && pokemonPlayer.HPCombate > 0 && pokemonAdversario.HPCombate > 0)
            {

                Thread.Sleep(1000);
                if (r.Next(2) == 1)//taxa de acerto
                {
                    pokemonPlayer.Atacar(pokemonAdversario);
                    if (pokemonAdversario.HPCombate == 0)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("O " + pokemonPlayer.Nome + " errou o golpe");
                }

                Thread.Sleep(1000);
                if (r.Next(2) == 1)//taxa de acerto
                {
                    pokemonAdversario.Atacar(pokemonPlayer);

                    if (pokemonPlayer.HPCombate == 0)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("O " + pokemonAdversario.Nome + " errou o golpe");
                }
                Thread.Sleep(1000);

            }
            Console.WriteLine("");
            Console.WriteLine("####Duracao da partida: " + Tempo + " ####");
            Console.WriteLine("||||  " + pokemonPlayer.Nome + " HP:" + pokemonPlayer.HPCombate + "\t" + pokemonAdversario.Nome + " HP:" + pokemonAdversario.HPCombate + "  ||||");


            pokemonPlayer.RestaurarHp();
            pokemonAdversario.RestaurarHp();

            if (Tempo <= 0)
            {
                Console.WriteLine("Tempo limite da partida atingido!");
            }

            if (pokemonPlayer.HPCombate > pokemonAdversario.HPCombate)
            {
                Vencedor = 1;
                return 1;
            }
            else
            {
                Vencedor = 0;
                return 0;
            }           
        }

        public static void Exibirtempo()
        {
            for (int c = Tempo; c >= 0; c--)
            {
                Thread.Sleep(1000);
                Tempo = c;
            }         
        }

        public static void ResetarContador()
        {
            Duelo.Tempo = 30;
        }



    }
}

