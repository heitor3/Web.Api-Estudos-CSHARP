using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Models
{
    public class ErroGenericoViewModel
    {
        public IEnumerable<string> Erros { get; private set; }

        public ErroGenericoViewModel(IEnumerable<string> erro)
        {
            Erros = erro;
        }
    }
}
