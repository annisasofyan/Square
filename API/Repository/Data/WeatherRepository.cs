using API.Context;
using API.Models;

namespace API.Repository.Data
{
    public class WeatherRepository: GeneralRepository<Db_context, Weather, int>
    {
        private readonly Db_context _context;

        public WeatherRepository(Db_context myContext) : base(myContext)
        {
            this._context = myContext;
        }
    }
}
