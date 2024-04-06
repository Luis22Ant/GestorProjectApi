using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Exception
{
    public class NotFoundException : GestorException
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
