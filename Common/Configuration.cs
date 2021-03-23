using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Configuration : IConfiguration
    {
        private readonly string errorMessage;
        public string ErrorMessage { get => errorMessage; }
    }
}
