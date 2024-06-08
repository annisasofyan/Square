using API.Context;
using API.Models;
using API.Models.ViewModel;
using System;
using System.Drawing;

namespace API.Repository.Data
{
    public class SquareRepository : GeneralRepository<Db_context, Square, int>
    {
        private readonly Db_context myContext;

        public SquareRepository(Db_context myContext) : base(myContext)
        {
            this.myContext = myContext;

        }

        public Square Random() //use postman  to test
        {
            try
            {
                // Get all known color names
                var colorNames = Enum.GetNames(typeof(KnownColor));

                // Initialize the random number generator
                Random random = new Random();

                // Pick a random color name
                string randomColorName = colorNames[random.Next(colorNames.Length)];
                var act = new Square
                {
                    Color= randomColorName
                };
                myContext.Squares.Add(act);
                myContext.SaveChanges();
                return act;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null; // Return null in case of an error
            }

        }

    }
}
