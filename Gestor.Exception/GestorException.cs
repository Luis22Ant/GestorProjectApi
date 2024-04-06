using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Exception
{
    public class GestorException : SystemException
    {
        public GestorException(string message) : base(message)
        {

        }
    }
}
