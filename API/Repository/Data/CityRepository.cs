using API.Context;
using API.Models;

namespace API.Repository.Data
{
    public class CityRepository : GeneralRepository<Db_context, City, int>
    {
        private readonly Db_context _context;

        public CityRepository(Db_context myContext) : base(myContext)
        {
            this._context = myContext;
        }
    }
}
