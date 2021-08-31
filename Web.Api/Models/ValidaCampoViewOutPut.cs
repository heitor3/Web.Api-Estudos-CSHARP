using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Models
{
    public class ValidaCampoViewOutPut
    {
        public IEnumerable<string> Erros { get; private set; }

        public ValidaCampoViewOutPut(IEnumerable<string> erro)
        {
            Erros = erro;
        }
    }
}
