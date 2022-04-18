using lesson1.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson1.Infrastructure.Commands;

public class CustomCreator : Creator
{
    public override CreateCommand FactoryMethod()
    {
        return new CustomCommand();
    }
}
