using BatatalhaPokemon.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatatalhaPokemon
{
    public class JogoController
    {
        public List<CarD> Cartas { get; set; }
        public Jogador Player { get; set; }
        public List<Ginasio> GinasiosAtivos { get; set; }
        public int ExperienciaPorVitoria { get; private set; }
        public bool FecharJogo { get; set; } = false;
        public int VENCEDOR { get; set; }


        public JogoController()
        {

            GinasiosAtivos = new List<Ginasio>();

            Cartas = CarregaDadosTXT.CarregarPokemons();

            //CRIANDO OS GINASIOS
            for (int i = 0; i < 5; i++)
            {
                String ginasio_nome = "GINASIO_" + (i + 1);

                Ginasio g = new Ginasio(ginasio_nome, (List<CarD>)Cartas);
                GinasiosAtivos.Add(g);
            }

        }

        public void IniciaJogoConsole()
        {
            Console.WriteLine("#### LOADING BATALHA CARTAS POKEMON ####");
            this.CarregarJogadorConsole();

            while (FecharJogo == false)
            {
                Console.WriteLine("\n#### BATALHA DE CARTAS POKEMON####");
                Console.WriteLine("#####MENU PRINCIPAL#####");
                Console.WriteLine("( 1) - GINASIOS");
                Console.WriteLine("( 2) - MEUS POKEMONS");
                Console.WriteLine("( 3) - CARTAS DISPONIVEIS");
                Console.WriteLine("(-1) - SAIR");

                Console.WriteLine();
                int opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 1)
                {
                    MenuGinasioConsole();
                }
                if (opcao == 2)
                {
                    ExibirMeusPokemonsConsole();
                }
                if (opcao == 3)
                {
                    this.ExibirPokemonsDisponiveisConsole();
                }
                if (opcao == -1)
                {
                    this.FecharJogo = true;
                }
            }
        }


        public void CarregarJogadorConsole()
        {

            Console.WriteLine("\n#### TELA DE CADASTRO ####");
            Console.WriteLine("Digite o seu nome:");
            String nome = Console.ReadLine();

            Player = new Jogador(nome);
            Console.WriteLine("\n#### ESCOLHA SUA CARTA POKEMON INICIAL ####");
            Console.WriteLine("(1) - " + Cartas[0].Pk.Nome);
            Console.WriteLine("(2) - " + Cartas[3].Pk.Nome);
            Console.WriteLine("(3) - " + Cartas[6].Pk.Nome);

            int id = Convert.ToInt32(Console.ReadLine());

            while (id < 0 || id > 3)
            {
                Console.WriteLine("******Codigo pokemon invalido!******");
                Console.WriteLine("\n#### ESCOLHA SUA CARTA POKEMON INICIAL ####");
                Console.WriteLine("(1) - " + Cartas[0].Pk.Nome);
                Console.WriteLine("(2) - " + Cartas[3].Pk.Nome);
                Console.WriteLine("(3) - " + Cartas[6].Pk.Nome);

                id = Convert.ToInt32(Console.ReadLine());
            }

            if (id == 1)
            {
                Player.AddDeckPokemon(Cartas[0]);
            }
            if (id == 2)
            {
                Player.AddDeckPokemon(Cartas[3]);
            }
            if (id == 3)
            {
                Player.AddDeckPokemon(Cartas[6]);
            }

            Console.WriteLine("**** Parabens, o " + Player.MinhasCartas[0].Pk.Nome + " e agora seu novo companheiro! ****");

            Program.PausarAplicacao();
        }


        public void ExibirPokemonsDisponiveisConsole()
        {

            foreach (CarD C in Cartas)
            {
                Console.WriteLine(C.IDCard + " - " + C.Pk.Nome);

            }

            Program.PausarAplicacao();
        }

        /**
         * Metodo responsavel por exibir os ginasios dentro do console
         */
        public void ExibirGinasiosConsole()
        {
            Console.WriteLine("#### GINASIOS ABERTOS ####");

            foreach (Ginasio G in GinasiosAtivos)
            {
                Console.WriteLine("(" + (GinasiosAtivos.IndexOf(G) + 1) + ")" + " - " + G.Nome);

            }

        }


        public void MenuGinasioConsole()
        {
            Console.WriteLine("\n#### EM QUAL GINASIO VOCE DESEJA BATALHAR ####");
            ExibirGinasiosConsole();
            Console.WriteLine("(-1) - Voltar");


            int idGinasio = Convert.ToInt32(Console.ReadLine());

            while (((idGinasio >= GinasiosAtivos.Count() || idGinasio < 1)) && idGinasio != -1)
            {
                MenuGinasioConsole();
            }
            if (idGinasio <= GinasiosAtivos.Count() && idGinasio > 0)
            {
                EntrarGinasioConsole(GinasiosAtivos[idGinasio - 1]);
            }
        }




        public void ExibirMeusPokemonsConsole()
        {
            Console.WriteLine("###MEUS POKEMONS###");
            Console.WriteLine("N#\tNOME:\t\t\tLEVEL:\t\t\tEXP/EXP\t\tVIDA\t\tATAQUE");
            int i = 1;
            List<int> opcoes = new List<int>();

            foreach (CarD c in Player.MinhasCartas)
            {
                if (c.Equals(this.Player.PokemonPrincipal))
                {
                    Console.WriteLine(i + "\t" + c.Pk.Nome + "\t\t" + c.LevelAtual + "\t\t\t" + c.ExperienciaAtual + "/" + c.ExperienciaPorLevel + "\t\t" + c.Pk.Vida + "\t\t" + c.Pk.Ataque + "\t - PRINCIPAL");
                }
                else
                {
                    Console.WriteLine(i + "\t" + c.Pk.Nome + "\t\t" + c.LevelAtual + "\t\t\t" + c.ExperienciaAtual + "/" + c.ExperienciaPorLevel + "\t\t" + c.Pk.Vida + "\t\t" + c.Pk.Ataque);
                }
                opcoes.Add(Player.MinhasCartas.IndexOf(c));
                i++;
            }

            Console.WriteLine("Caso deseja alterar seu pokemon principal digite o seu N#");
            int opcao = Convert.ToInt32(Console.ReadLine());

            if (opcao > 0 && opcao <= Player.MinhasCartas.Count())
            {
                Player.SetPokemonPrincipal((int)opcoes[opcao - 1]);
            }
        }


        public void EntrarGinasioConsole(Ginasio g)
        {
            //INICIAR A BATALHA
            Console.WriteLine("\ns#### ENTRANDO NO GINASIO " + g.Nome + " ####");

            g.ExibirAdversarios();
            Program.PausarAplicacao();

            for (int i = 0; i < g.Treinadores.Count(); i++)
            {
                Console.WriteLine("###################################### DUELO ##########################################");
                Console.WriteLine(
                            "[" + this.Player.Nome + " - " + Player.PokemonPrincipal.Nome() + "] "
                            + "X"
                            + " [" + g.Treinadores[i].Nome + " - " + g.Treinadores[i].PokemonPrincipal.Nome() + "]");

                Console.WriteLine("############");

                Program.PausarAplicacao();
                Duelo combate = new Duelo(Player, g.Treinadores[i]);
                combate.Duelar();

                if (combate.Vencedor != -1)
                {
                    if (combate.Vencedor == 1)
                    {
                        Console.WriteLine("Parabens você venceu a batalha!");
                        Player.PokemonPrincipal.AddExperiencia(ExperienciaPorVitoria, Cartas);
                        Program.PausarAplicacao();

                        if (g.Treinadores.Count() > 1 && i != g.Treinadores.Count() - 1)
                        {
                            Console.WriteLine("Deseja desafiar o proximo?(s/n)");
                            String opcao = Console.ReadLine();
                            
                            while (!"s".Equals(opcao) && !"n".Equals(opcao))
                            {
                                Console.WriteLine("Deseja desafiar o proximo?(s/n)");
                                opcao = Console.ReadLine();
                                
                            }
                            if (("s").Equals(opcao))
                            {
                                combate.Vencedor=-1;
                            }
                            else
                            {
                                Console.WriteLine("\nParabens você venceu " + (i + 1) + " adversarios!");
                                break;
                            }
                        }
                    }
                    else if (combate.Vencedor == 0)
                    {
                        Console.WriteLine("\nQue pena, voce foi derrotado adversario " + g.Treinadores[i].Nome);
                        Player.PokemonPrincipal.AddExperiencia(((int)-this.ExperienciaPorVitoria / 4), Cartas);

                        // Program.PausarAplicacao();
                        break;
                    }
                }
                if (combate.Vencedor == 1 && i == g.Treinadores.Count() - 1)
                {
                    Console.WriteLine("Parabens você venceu todos os adversarios!");
                    Program.PausarAplicacao();
                    PremioVitoriaConsole(g.Treinadores);
                }
                Program.PausarAplicacao();
            }
        }

        public void PremioVitoriaConsole(List<Jogador> adversarios)
        {
            Console.WriteLine("Escolha um pokemon como premio");
            List<int> opcoes = new List<int>();

            int i = 1;
            foreach (Jogador j in adversarios)
            {
                Console.WriteLine("(" + i + ") - " + j.PokemonPrincipal.Nome());
                opcoes.Add(adversarios.IndexOf(j));
                i++;
            }
            int opcao = Convert.ToInt32(Console.ReadLine());

            int indice = opcoes[opcao - 1];

            if (opcoes.Contains(indice))
            {
                Player.AddDeckPokemon(adversarios[indice].PokemonPrincipal.CreateNewCardPokemon());
            }
            else
            {
                PremioVitoriaConsole(adversarios);
            }
        }


    }
}
