using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BatatalhaPokemon
{
    public class Ginasio
    {
        public static int Id { get; private set; }
        public String Nome { get; set; }
        public int Nivel { get; set; }
        public List<Jogador> Treinadores { get; set; }
        public bool Vencido { get; set; }


        public Ginasio(String nome, List<CarD> cartasDisponiveis)
        {

            Id++;
            Nivel = Id;
            Nome = nome;
            Treinadores = new List<Jogador>();

            Random r = new Random();
        
            int j = 0;
            for (int i = Id; i > 0; i--)
            {
                String adversario = "NPC_" + (j + 1);

                Jogador ad = new Jogador(adversario);
                ad.AddDeckPokemon((CarD)cartasDisponiveis[r.Next(cartasDisponiveis.Count())].createNewCardPokemon(Nivel));//pegar aleatoriamente
                Treinadores.Add(ad);
                j++;
            }
        }

        public void AtualizaPokemonsGinasio(List<CarD> cartasDisponiveis)
        {
            Random r = new Random();
            foreach (Jogador treinadores in Treinadores)
            {

                if (Vencido)
                {
                    treinadores.MinhasCartas.Clear();
                    treinadores.AddDeckPokemon((CarD)cartasDisponiveis[r.Next(cartasDisponiveis.Count())].createNewCardPokemon(Nivel++));//pegar aleatoriamente

                    Vencido = false;
                }
                else
                {
                    if (Nivel > 1)
                    {
                        Nivel--;
                        treinadores.MinhasCartas.Clear();
                        treinadores.AddDeckPokemon((CarD)cartasDisponiveis[r.Next(cartasDisponiveis.Count())].createNewCardPokemon(this.Nivel));//pegar aleatoriamente

                    }
                }

            }

        }

        public void ExibirAdversarios()
        {


            Console.WriteLine("---ADVERSARIO     ||    POKEMONS---");
            foreach (Jogador c in Treinadores)
            {

                Console.WriteLine(c.Nome+ "  -  " + c.PokemonPrincipal.Nome());
            }

        }




    }
}
