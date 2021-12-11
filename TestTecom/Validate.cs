using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTecom
{
   
    class Validate
    {
         static List<string> Diseas = new List<string>() { "cold", "bronchitis", "virus", "allergy", "quinsy", "insomnia" };
         static List<string> BadHabits = new List<string>() { "alcoholism", "insomnia", "narcomania", "injury" };
        public class PatientWeightValidator : IRuleValidator
        {
            
            public bool ValidateRule(Candidate candidate, IList<RuleViolation> violations)
            {
                if (candidate.Weight >= 75 && candidate.Weight <= 90)
                {
                   
                    return true;
                }
                if(candidate.Weight > 90 && candidate.Weight <= 100)
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Satisfactorily, Notification = "вес в пределах 91-100 кг" });
                    return false;
                }
                if(candidate.Weight >= 70 && candidate.Weight < 75)
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Satisfactorily, Notification = "вес в пределах 71-75 кг" });
                    return false;
                }
                if(candidate.Weight < 70)
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "вес меньше 70 кг" });
                    return false;
                }
                if (candidate.Weight > 100)
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "вес больше 100 кг" });
                    return false;
                }
                else
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "не подходит по весу"});
                    return false;
                } 
            }
        }
        public class PatientHeightValidator : IRuleValidator
        {
            public bool ValidateRule(Candidate candidate, IList<RuleViolation> violations)
            {
                if(candidate.Height >= 170 && candidate.Height <= 185)
                {
                    
                    return true;
                }
                if(candidate.Height >= 160 && candidate.Height < 170)
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Satisfactorily, Notification = "рост в пределах 160-169 см" });
                    return false;
                }
                if(candidate.Height > 185 && candidate.Height <= 190)
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Satisfactorily, Notification = "рост в пределах 186-190 см" });
                    return false;
                }
                if(candidate.Height > 190)
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "рост выше 190 см" });
                    return false;
                }
                if(candidate.Height < 160)
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "рост ниже 160 см" });
                    return false;
                }
                else
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "не прошел по росту" });
                    return false;
                }
            }
        }
        public class PatientAgeValidator : IRuleValidator
        {
            public bool ValidateRule(Candidate candidate, IList<RuleViolation> violations)
            {
                if(candidate.Age >= 25 && candidate.Age <= 35)
                {  
                    return true;
                }
                if(candidate.Age >= 23 && candidate.Age < 25 )
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Satisfactorily, Notification = "возраст 23-24 года" });
                    return false;
                }
                if(candidate.Age > 35 && candidate.Age <= 37)
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Satisfactorily, Notification = "возраст 36-37 лет" });
                    return false;
                }
                if(candidate.Age > 37 && candidate.Age < 23)
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "не подходит по возрасту" });
                    return false;
                }
                else
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "не подходит по возрасту" });
                    return false;
                }
            }
        }
        public class PatientVisionValidator : IRuleValidator
        {
            public bool ValidateRule(Candidate candidate, IList<RuleViolation> violations)
            {
                if(candidate.Vision == 1)
                {
                    return true;
                }
                if(candidate.Vision < 1)
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "зрение меньше 1" });
                    return false;
                }
                else
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "плохое зрение" });
                    return false;
                }
            }
        }
        public class PatientSmokingValidator : IRuleValidator
        {
            public bool ValidateRule(Candidate candidate, IList<RuleViolation> violations)
            {
                if (candidate.Diseases.Contains("smoking"))
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "курит" });
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public class PatientTherapistValidator : IRuleValidator
        {
            public bool ValidateRule(Candidate candidate, IList<RuleViolation> violations)
            {
                int NumberOfDis = Diseas.Where(w => candidate.Diseases.Any(i => w.Contains(i))).Count();
                if (NumberOfDis <= 2)
                {
                    return true;
                }
                if(NumberOfDis == 3)
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Satisfactorily, Notification = "болен 3 болезнями" });
                    return false;
                }
                if(NumberOfDis > 3)
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "имеет больше 3 болезней" });
                    return false;
                }
                else
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "не проходит по болезням" });
                    return false;
                }
            }
        }
        public class PatientPsychologistValidator : IRuleValidator
        {
            public bool ValidateRule(Candidate candidate, IList<RuleViolation> violations)
            {
               int NumberOfBadh = BadHabits.Where(w => candidate.Diseases.Any(i => w.Contains(i))).Count();
               if(NumberOfBadh == 0)
                {
                    return true;
                }
               if(NumberOfBadh == 1)
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Satisfactorily, Notification = "имеется 1 психическое заболевание"});
                    return false;
                }
               if(NumberOfBadh > 1)
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "имеется больше 1 психических заболеваний" });
                    return false;
                }
                else
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "не прошел психолога"});
                    return false;
                }
            }
        }
        public class PatientWeightBadHabs : IRuleValidator
        {
            public bool ValidateRule(Candidate candidate, IList<RuleViolation> violations)
            {
                int NumberOfDis = Diseas.Where(w => candidate.Diseases.Any(i => w.Contains(i))).Count();
                int NumberOfBadh = BadHabits.Where(w => candidate.Diseases.Any(i => w.Contains(i))).Count();
                if ((candidate.Weight >= 75 && candidate.Weight <= 90) && (candidate.Height >= 170 && candidate.Height <= 185) 
                    && (candidate.Age >= 25 && candidate.Age <= 35) && candidate.Vision == 1 
                    && !(candidate.Diseases.Contains("smoking")) && NumberOfDis <= 2 && NumberOfBadh == 0)
                {
                    return true;
                }
                if( !(candidate.Weight > 100 && candidate.Weight < 70) && !(candidate.Height > 190 && candidate.Height < 160) 
                    && !(candidate.Age > 37 && candidate.Age < 23) && !(candidate.Vision < 1) && !(candidate.Diseases.Contains("smoking")) 
                    && !(NumberOfDis > 3) && !(NumberOfBadh > 1) 
                    && (Diseas.Where(w => candidate.Diseases.Any(i => w.Contains(i))).Contains("cold") 
                    || Diseas.Where(w => candidate.Diseases.Any(i => w.Contains(i))).Contains("virus")) && candidate.Weight > 110)
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Satisfactorily, Notification = "пройден тест \"Вес и вредные привычки\""  });
                    return false;
                }
                if((candidate.Diseases.Contains("smoking") && (Diseas.Where(w => candidate.Diseases.Any(i => w.Contains(i))).Contains("cold")
                    || Diseas.Where(w => candidate.Diseases.Any(i => w.Contains(i))).Contains("virus")) && candidate.Weight > 120 || candidate.Weight < 60))
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "пройден тест \"Вес и вредные привычки\"" });
                    return false;
                }
                else
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "пройден тест \"Вес и вредные привычки\"" });
                    return false;
                }
            }
        }
        public class PatientOdditiesValidator : IRuleValidator
        {
            public bool ValidateRule(Candidate candidate, IList<RuleViolation> violations)
            {
                if(candidate.Name.First() == 'П')
                {
                    return true;
                }
                if(!(candidate.Name.First() == 'П') && candidate.Age > 68)
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Satisfactorily, Notification = "пройден тест \"Странный\". Старше 68 лет и имя начинается не на \"П\""});
                    return false;
                }
                if(!(candidate.Name.First() == 'П'))
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "пройден тест \"Странный\". Имя начинается не на \"П\"" });
                    return false;
                }
                if(!(candidate.Age > 68))
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "пройден тест \"Странный\". Старше 68 лет" });
                    return false;
                }
                else
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "пройден тест \"Странный\". Не старше 68 лет и имя начинается не на \"П\"" });
                    return false;
                }
            }
        }
        public class PatientMathematicalValidator : IRuleValidator
        {

            public bool ValidateRule(Candidate candidate, IList<RuleViolation> violations)
            {
                int NumberOfDis = Diseas.Where(w => candidate.Diseases.Any(i => w.Contains(i))).Count();
                int NumberOfBadh = BadHabits.Where(w => candidate.Diseases.Any(i => w.Contains(i))).Count();
                if (!(candidate.Weight > 100 && candidate.Weight < 70) && !(candidate.Height > 190 && candidate.Height < 160)
                    && !(candidate.Age > 37 && candidate.Age < 23) && !(candidate.Vision < 1) && !(candidate.Diseases.Contains("smoking"))
                    && !(NumberOfDis > 3) && !(NumberOfBadh > 1) && candidate.Height % 2 == 0)
                {
                    return true; 
                }
                if((candidate.Weight > 90 && candidate.Weight <= 100 && candidate.Weight >= 70 && candidate.Weight < 75) 
                    && (candidate.Height >= 160 && candidate.Height < 170 && candidate.Height > 185 && candidate.Height <= 190)
                    && (candidate.Age >= 23 && candidate.Age < 25 && candidate.Age > 35 && candidate.Age <= 37)
                    && (NumberOfDis == 3) && (NumberOfBadh == 1))
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Satisfactorily, Notification = "пройден тест \"Математический\". Удовлетворительные показатели" });
                    return false;
                }
                if(candidate.Height % 3 == 0)
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "пройден тест \"Математический\". Рост не делится на 3" });
                    return false;
                }
                if(Diseas.Where(w => candidate.Diseases.Any(i => w.Contains(i))).Contains("cold"))
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "пройден тест \"Математический\". Имеется простуда" });
                    return false;
                }
                else
                {
                    violations.Add(new RuleViolation() { RateCandidate = Rate.Unsatisfactory, Notification = "пройден тест \"Математический\"" });
                    return false;
                }
            }
        }
    }
}
