using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_4
{
    interface IMyNumber<T> where T : IMyNumber<T>
    {
        T Add(T b);
        T Substruct(T b);
        T Multiply(T b);
        T Divide(T b);
    }
}
