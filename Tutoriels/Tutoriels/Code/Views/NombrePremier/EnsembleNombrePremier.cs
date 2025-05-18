using Repository.Entities;
using Tutoriel.Database.Dbo;

namespace Tutoriels.Code.Activities
{
    public class EnsembleNombrePremier
    {
        private const int MaxNombre = 10000;
        private readonly NombrePremier[] Items = new NombrePremier[MaxNombre];

        public List<NombrePremier> List()
        {
            var result = new List<NombrePremier>();
            for (int index = 0; index < Index; index++)
            {
                result.Add(Items[index]);
            }
            return result;
        }
        private int Index = 0;

        public bool CanAdd => Index < MaxNombre;

        public void Load()
        {
            IEnumerable<NombrePremierEntity> items = DboNombrePremier.GetAll();
            if (!items.Any())
            {
                Add(2, new TimeSpan(0, 0, 0, 0));
                Add(3, new TimeSpan(0, 0, 0, 0));
            }
            else
            {
                Index = 0;
                foreach (NombrePremierEntity item in items.OrderBy(_ => _.NONBRE))
                {
                    Items[Index] = new NombrePremier(Index + 1, item.NONBRE, item.DURATION);
                    Index++;

                }
            }
        }

        public NombrePremier Add(long nombre, TimeSpan ts)
        {
            NombrePremier result = new NombrePremier(Index + 1, nombre, ts);
            if (Index < MaxNombre)
            {
                NombrePremierEntity item = new NombrePremierEntity()
                {
                    DURATION = ts,
                    NONBRE = nombre,
                };

                DboNombrePremier.Save(item);
                Items[Index] = result;
                Index++;

            }
            return result;
        }

        public long Last() => Index > 0 ? Items[Index - 1].Nombre : 3;

        public bool EstNombrePremier(long element)
        {
            bool result = true;
            double racine = Math.Sqrt((double)element);
            int index = 0;

            while (index < Index && Items[index].Nombre <= racine && result)
            {
                if (element % Items[index].Nombre == 0)
                {
                    result = false;
                }
                index++;
            }
            return result;
        }
    }
}