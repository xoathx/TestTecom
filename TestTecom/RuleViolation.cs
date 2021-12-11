using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTecom
{
    public class RuleViolation
    {
        public string Notification;
        public Rate RateCandidate { get; set; }
    }
    public enum Rate
    {
        
        Good,
        Satisfactorily,
        Unsatisfactory
    }
}
