using System;

public class UserImportValidator
{
    public ValidationResult Validate(User userToValidate)
    {
        var result =  new ValidationResult();
        if(String.IsNullOrEmpty(userToValidate.LastName))
        {
            result.Add("Last Name Required");
        }
        if (String.IsNullOrEmpty(userToValidate.FirstName))
        {
            result.Add("First Name Required");
        }
        return result;
    }
}