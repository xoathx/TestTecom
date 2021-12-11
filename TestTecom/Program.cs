using System;
using System.Collections.Generic;


namespace TestTecom
{
    class Program
    {
        static Candidate candidate;
        static List<IRuleValidator> validators = new List<IRuleValidator>();
        static void Main(string[] args)
        {
            
            validators.Add(new Validate.PatientWeightValidator());
            validators.Add(new Validate.PatientHeightValidator());
            validators.Add(new Validate.PatientAgeValidator());
            validators.Add(new Validate.PatientVisionValidator());
            validators.Add(new Validate.PatientSmokingValidator());
            validators.Add(new Validate.PatientTherapistValidator());
            validators.Add(new Validate.PatientPsychologistValidator());
            validators.Add(new Validate.PatientWeightBadHabs());
            validators.Add(new Validate.PatientOdditiesValidator());
            validators.Add(new Validate.PatientMathematicalValidator());
            
            SetInformation();
        }

       static public void SetInformation()
        {
            string Name;
            int Weight;
            int Height;
            int Age;
            float Vision;
            string Diseases;
            candidate = new Candidate();
            Console.WriteLine("Введите имя:");
            Name = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Имя не должно быть пустым! Введите имя:");
                Name = Console.ReadLine();
            }else { candidate.Name = Name; }

            Console.WriteLine("Введите вес (кг):");
            var value = Console.ReadLine();
            if(!int.TryParse(value, out Weight))
            {
                Console.WriteLine("Вес должен быть целым числом и больше 0!");
            }
            else if(Weight <= 0)
            {
                Console.WriteLine("Вес должен быть больше нуля!");
            }
            else
            {
                candidate.Weight = Weight;
            }

            Console.WriteLine("Введите рост (см):");
            value = Console.ReadLine();
            if (!int.TryParse(value, out Height))
            {
                Console.WriteLine("Рост должен быть целым числом и больше 0!");
            }
            else if (Height <= 0)
            {
                Console.WriteLine("Рост должен быть больше нуля!");
            }
            else
            {
                candidate.Height = Height;
            }

            Console.WriteLine("Введите возраст:");
            value = Console.ReadLine();
            if (!int.TryParse(value, out Age))
            {
                Console.WriteLine("Возраст должен быть целым числом и больше 0!");
            }
            else if (Age <= 0)
            {
                Console.WriteLine("Возраст должен быть больше нуля!");
            }
            else
            {
                candidate.Age = Age;
            }

            Console.WriteLine("Введите показатели зрения:");
            value = Console.ReadLine();
            if (!float.TryParse(value, out Vision))
            {
                Console.WriteLine("Показатели зрения должны быть дробным числом!");
            }
            else if (Vision < 0 || Vision > 1)
            {
                Console.WriteLine("Показатели зрения должны быть от 0 до 1 !");
            }
            else
            {
                candidate.Vision = Vision;
            }

            Console.WriteLine("Введите болезни и вредные привычки:");
            Diseases = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Diseases))
            {
                candidate.Diseases = new List<string>(0);
            }
            else
            {
                candidate.Diseases = new List<string>(Diseases.Split(' '));
            }
            Validation();

        }
       static public string GetString(Rate rate)
        {
            switch (rate)
            {
                case Rate.Good:
                    return "Хорошо";
                case Rate.Satisfactorily:
                    return "Удовлетворительно";
                case Rate.Unsatisfactory:
                    return "Неудовлетворительно";
                default:
                    return string.Empty;
            }
        }
       static void Validation()
        {
            List<RuleViolation> violations = new List<RuleViolation>();
            bool result = true;
            foreach (var validator in validators)
            {
                if (!validator.ValidateRule(candidate, violations))
                    result = false;
            }
            if (result)
                Console.WriteLine($"Кандидат {candidate.Name} подходит.");
            else
            {
                var numberSati = violations.FindAll(c => c.RateCandidate == Rate.Satisfactorily).Count;
                var numberUnsati = violations.FindAll(c => c.RateCandidate == Rate.Unsatisfactory).Count;
                if (numberSati < 3 && numberUnsati == 0)
                    Console.WriteLine($"Кандидат {candidate.Name} подходит.");
                else
                {
                    Console.WriteLine($"Кандидат {candidate.Name} не прошел тестирование. Проблемы:");
                    foreach (var violation in violations)
                        Console.WriteLine($"У кандидата {violation.Notification} {GetString(violation.RateCandidate)}");
                }
            }

            Console.WriteLine("Хотите протестировать други кандидатов? (Y/N)");
            string answer = Console.ReadLine();
            if (answer == "Y")
                SetInformation();
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
