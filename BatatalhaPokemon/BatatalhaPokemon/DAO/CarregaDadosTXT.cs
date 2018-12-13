using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatatalhaPokemon.DAO
{
    public static class CarregaDadosTXT
    {
        


        public static List<CarD> CarregarPokemons()
        {
            List<CarD> Retorno = new List<CarD>();

            string nome = @"listaPokemon"; 
              
            StreamReader leitor = new StreamReader(nome);
            String linha = leitor.ReadLine(); // lê a primeira linha


            while (linha != null)
            {

                String[] array;

                array = linha.Split('-');


                int idPk = Convert.ToInt32(array[0].Trim());
                String nomePk = array[1].Trim();
                String tipoPK = array[2].Trim();
                int ataquePK = Convert.ToInt32(array[3].Trim());
                int evolucaoPK = Convert.ToInt32(array[4].Trim());

                CarD aux = new CarD(idPk, nomePk, tipoPK, ataquePK, evolucaoPK);

                Retorno.Add(aux);

                linha = leitor.ReadLine();  // lê da segunda até a última linha
            }

            leitor.Close();

            return Retorno;
        }

    }


    
}
