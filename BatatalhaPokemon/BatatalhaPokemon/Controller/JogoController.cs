using BatatalhaPokemon.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatatalhaPokemon.Controller
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
                String ginasio_nome = "GINASIO_" + (i+1);
                
                Ginasio g = new Ginasio(ginasio_nome, (List<CarD>)Cartas);
                GinasiosAtivos.Add(g);
            }
            
        }


    }
}
