using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareWpApp.Model
{
    internal class LoginResponse
    {
        public int Status { get; set; }
        public string IdToken { get; set; }
        public int Result { get; set; }
        public string Message { get; set; }
        public object Errors { get; set; }
    }
}
