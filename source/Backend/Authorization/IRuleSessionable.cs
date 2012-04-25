using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Authorization
{
    public interface IRuleSessionable : ISessionable
    {
        /// <summary>
        /// Return a dictionary that contains module id and IRuleModule
        /// </summary>
        Dictionary<int, IRuleModule> RuleModules { get; }
    }
}
