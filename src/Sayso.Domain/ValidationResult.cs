using System.Collections.Generic;

namespace Sayso.Domain
{
    public class ValidationResult
    {
        private readonly ICollection<string> errors = new List<string>();
        
        public void AddErrorMessage(string message)
        {
            errors.Add(message);
        }
        public bool IsValid
        {
            get { return errors.Count == 0; }
        }
    }
}