using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaProjectMars
{
    interface IRover
    {
        void ReadOrder(string order);
        void Move();
        void Turn(char rotation);
        void ExecuteOrder();
    }
}
