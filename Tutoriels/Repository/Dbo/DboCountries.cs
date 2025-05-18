using Repository.Dbo;
using Repository.Entities;

namespace Tutoriel.Database.Dbo
{
    public class DboCountries : BaseDbo
    {
        public static IEnumerable<Country> GetAll()
        {
            lock (dbLock)
            {
                return Db.Query<Country>("select * from COUNTRY");
            }
        }
    }
}