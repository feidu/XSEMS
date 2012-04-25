using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models.Admin;
using Backend.Authorization;

namespace Backend.Models
{
    public class AdminCookie : User, IRuleSessionable
    {
        private Dictionary<int, IRuleModule> _RuleModules;

        public Dictionary<int, IRuleModule> RuleModules
        {
            get { return _RuleModules; }
            set { _RuleModules = value; }
        }

        public static void BindRuleModules(AdminCookie cookie, List<ModuleAuthorization> mas)
        {
            cookie.RuleModules = new Dictionary<int, IRuleModule>();
            if (mas == null) return;
            foreach (ModuleAuthorization ma in mas)
            {
                cookie.RuleModules.Add(ma.ModuleId, ma);
            }
        }
    }
}
