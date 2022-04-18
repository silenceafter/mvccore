using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson1.Infrastructure.Commands.Base
{
    public abstract class Creator
    {
        public abstract CreateCommand FactoryMethod();
    }
}
