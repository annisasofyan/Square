using API.Context;
using API.Models;

namespace API.Repository.Data
{
    public class WetherDetailsRepository: GeneralRepository<Db_context, WetherDetails, int>
    {
        private readonly Db_context _context;

        public WetherDetailsRepository(Db_context myContext) : base(myContext)
        {
            this._context = myContext;
        }
    }
}
