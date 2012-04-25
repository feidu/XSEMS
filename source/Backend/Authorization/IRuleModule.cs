using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Authorization
{
    public interface IRuleModule
    {
        int ModuleId { get; }
        bool Writable { get; }
        bool Accessible { get; }
    }
}
