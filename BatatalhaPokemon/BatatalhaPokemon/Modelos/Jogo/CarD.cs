using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatatalhaPokemon
{
    public class CarD : LevelUP
    {
        public Pokemon Pk { get; set; }
        public int IDCard { get; set; }

        public CarD()
        {

        }


        public CarD(int idCard, String nome, String tipo, int ataque, int evolucao)
        {

            if ("Planta".Equals(tipo))
            {
                Pk = new Planta(nome, tipo, ataque, evolucao);
            }

            else
            {
                Pk = new Normal(nome, tipo, ataque, evolucao);
            }


            IDCard = idCard;

        }


        public int IndexOfCardID(int IDCARD, List<CarD> list)
        {
            foreach(CarD obj in list)
            {
                if (obj.IDCard == IDCARD)
                    return list.IndexOf(obj);

            }

            return -1;
        }

        public void AddExperiencia(int experiencia, List<CarD> cartasDiponiveis)
        {

            int level_inicial = base.LevelAtual;

            base.ReceberExperiencia(experiencia);

            if (level_inicial < base.LevelAtual)
            {
                if (base.LevelAtual % 5 == 0)//pokemon pode evoluir
                {
                    int totalEvolucao = base.LevelAtual - level_inicial;

                    while (totalEvolucao > 0)
                    {
                        if (Pk.Evolucao > 0)
                        {
                            //fazendo a troca do pokemon para sua evolucao
                            Console.WriteLine("\n\nOps... Parece que o " + Pk.Nome + " vai evoluir!");

                                                                                    
                            Pk = cartasDiponiveis[IndexOfCardID(IDCard,cartasDiponiveis)+1].Pk;
                            base.Evolucao();

                            Console.WriteLine("Parabens! seu pokemon evoluiu para " + this.Pk.Nome);
                            //Program.PausarAplicacao();
                        }
                        totalEvolucao--;
                    }
                }
                else
                {
                    Console.WriteLine("ops... Seu pokemon acaba de subir para o level " + base.LevelAtual);
                    Pk.BonusLevel(base.BonusAtributoLevel);
                    //Program.PausarAplicacao();
                    
                }

            }

        }

        public String Nome()
        {
            return Pk.Nome;
        }

        public CarD createNewCardPokemon(int nivel)
        {

            int idPk = this.IDCard;
            String nomePk = this.Pk.Nome;
            String tipoPK = this.Pk.Tipo;
            int ataquePK = this.Pk.Ataque;
            int evolucaoPK = this.Pk.Evolucao;

            CarD aux;

            switch (nivel)
            {
                case 1:
                    if (evolucaoPK == 0)
                    {
                        aux = new CarD(IDCard, nomePk, tipoPK, (int)(ataquePK - (ataquePK * 80 / 100)), evolucaoPK);
                    }
                    else
                    {
                        aux = new CarD(IDCard, nomePk, tipoPK, (int)(ataquePK - (ataquePK * 40 / 100)), evolucaoPK);
                    }

                    break;

                case 2:
                    if (evolucaoPK == 0)
                    {
                        aux = new CarD(IDCard, nomePk, tipoPK, (int)(ataquePK - (ataquePK * 60 / 100)), evolucaoPK);
                    }
                    else
                    {
                        aux = new CarD(IDCard, nomePk, tipoPK, (int)(ataquePK - (ataquePK * 30 / 100)), evolucaoPK);
                    }
                    break;

                case 3:
                    if (evolucaoPK == 0)
                    {
                        aux = new CarD(IDCard, nomePk, tipoPK, (int)(ataquePK - (ataquePK * 40 / 100)), evolucaoPK);
                    }
                    else
                    {
                        aux = new CarD(IDCard, nomePk, tipoPK, (int)(ataquePK - (ataquePK * 20 / 100)), evolucaoPK);
                    }
                    break;

                case 4:
                    if (evolucaoPK == 0)
                    {
                        aux = new CarD(IDCard, nomePk, tipoPK, (int)(ataquePK - (ataquePK * 20 / 100)), evolucaoPK);
                    }
                    else
                    {
                        aux = new CarD(IDCard, nomePk, tipoPK, (int)(ataquePK - (ataquePK * 10 / 100)), evolucaoPK);
                    }
                    break;

                default:
                    {
                        if (nivel > 10)
                        {
                            aux = new CarD(IDCard, nomePk, tipoPK, (int)(ataquePK + (ataquePK * nivel / 100)), evolucaoPK);
                        }
                        else
                        {
                            aux = new CarD(IDCard, nomePk, tipoPK, ataquePK, evolucaoPK);
                        }
                        break;
                    }
            }

            return aux;

        }
    }
}
