namespace BatatalhaPokemon
{
    public class LevelUP
    {

        public int LevelAtual { get; set; }
        public int ExperienciaAtual { get; set; }
        public int ExperienciaPorLevel { get; set; }
        public int BonusAtributoLevel { get; set; }

        public LevelUP()
        {
            this.LevelAtual = 1;
            this.ExperienciaAtual = 0;
            this.ExperienciaPorLevel = 100;
            this.BonusAtributoLevel = 200;
        }

        public void ReceberExperiencia(int experiencia)
        {
            if (experiencia < 0)
            {
                if (ExperienciaAtual + experiencia < 0)
                {
                    ExperienciaAtual = 0;
                }
                else
                {
                    ExperienciaAtual += experiencia;
                }
            }
            else
            {
                ExperienciaAtual += experiencia;

                while (ExperienciaAtual >= ExperienciaPorLevel)
                {
                    if (ExperienciaAtual >= ExperienciaPorLevel)
                    {
                        LevelAtual++;
                        ExperienciaAtual = ExperienciaAtual - ExperienciaPorLevel;
                        ExperienciaPorLevel = ExperienciaPorLevel * LevelAtual;
                    }
                }

            }


        }

        public void Evolucao()
        {
            LevelAtual = 1;
            ExperienciaAtual = 0;
            ExperienciaPorLevel = 100;
            BonusAtributoLevel = 200;

        }

    }
}