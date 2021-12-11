using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTecom
{
    interface IRuleValidator
    {
        public bool ValidateRule(Candidate candidate, IList<RuleViolation> violations);
    }
}
