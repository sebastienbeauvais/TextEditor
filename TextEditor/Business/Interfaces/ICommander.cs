using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Business.Interfaces
{
    public interface ICommander
    {
        void Execute();
        void Unexecute();
    }
}
