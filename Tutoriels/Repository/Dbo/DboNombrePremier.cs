using Repository.Dbo;
using Repository.Entities;

namespace Tutoriel.Database.Dbo
{
    public class DboNombrePremier : BaseDbo
    {
        public static IEnumerable<NombrePremierEntity> GetAll()
        {
            lock (dbLock)
            {
                return Db.Query<NombrePremierEntity>("select * from NOMBRE_PREMIER");
            }
        }

        public static bool Any()
        {
            lock (dbLock)
            {
                return Db.Query<NombrePremierEntity>("select * from NOMBRE_PREMIER WHERE NONBRE = 2").Any();
            }
        }
    }
}