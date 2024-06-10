using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareWpApp.Model
{
    internal class RegisterResponse
    {
        public string Type { get; set; }
        public string? Title { get; set; } // Making it nullable
        public int Status { get; set; }
        public string TraceId { get; set; }
        public Dictionary<string, string[]> Errors { get; set; } // Error dictionary
        public int Result { get; set; }
        public string Message { get; set; }
    }
}
