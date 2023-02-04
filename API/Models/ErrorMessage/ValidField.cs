using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ErrorMessage
{
    public class ValidField
    {
        public IEnumerable<string> Errors { get; set; }

        public ValidField(IEnumerable<string> error)
        {
            Errors = error;
        }
    }
}