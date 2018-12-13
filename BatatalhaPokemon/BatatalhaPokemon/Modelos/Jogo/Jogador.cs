using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BatatalhaPokemon;

namespace BatatalhaPokemon
{
    public class Jogador
    {
        public String Nome { get; set; }
        public CarD PokemonPrincipal { get; set; }
        public List<CarD> MinhasCartas { get; set; }

        public Jogador(string nome)
        {
            Nome = nome;
        }

        public void AddDeckPokemon(CarD pk)
        {

            MinhasCartas.Add(pk);

            if (MinhasCartas.Count == 1)
            {
                this.PokemonPrincipal = this.MinhasCartas[0];
            }
        }

        public CarD getDeckPokemon(int id)
        {

            CarD aux = null;

            foreach (CarD carD in MinhasCartas)
            {

                if (carD.IDCard == id)
                {
                    aux = carD;
                    break;
                }
            }

            return aux;
        }


        public int GetIndexOfDeck(int id)
        {

            int indexOfCardID = -1;

            foreach (CarD carta in MinhasCartas)
            {

                if (carta.IDCard == id)
                {
                    indexOfCardID = MinhasCartas.IndexOf(carta);
                    break;
                }

            }

            return indexOfCardID;

        }


        public void SetPokemonPrincipal(int idCard)
        {

            int indexOf = GetIndexOfDeck(idCard);
            bool local = PokemonPrincipal.Equals(MinhasCartas[indexOf]);

            if ((indexOf >= 0 && indexOf < this.MinhasCartas.Count))
            {

                if (!local)
                {
                    this.PokemonPrincipal = MinhasCartas[indexOf];
                    Console.WriteLine("Seu novo pokemon principal e " + PokemonPrincipal.Pk.Nome);
                }

                Program.PausarAplicacao();
            }
            else
            {
                Console.WriteLine("Nao foi possivel encontrar o pokemon de id= " + idCard);

            }

        }

        public Boolean ExistsOfIdCarD(int idCard)
        {
            bool a = false;

            foreach (CarD carD in MinhasCartas)
            {

                if (carD.IDCard == idCard)
                {
                    a = true;
                    break;
                }

            }

            return a;

        }


    }
}
