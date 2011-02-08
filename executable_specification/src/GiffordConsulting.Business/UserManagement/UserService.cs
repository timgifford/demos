using System.Collections.Generic;


public interface IUserService
{
    ValidationResult ImportUser(User user);
    IEnumerable<User> GetAll();
}

public class UserService : IUserService
{
    private readonly UserImportValidator validator;
    private IDictionary<string, User> innerList = new Dictionary<string, User>();
    
    public UserService() : this(new UserImportValidator())
    {
    }

    public UserService(UserImportValidator validator)
    {
        this.validator = validator;
    }

    public ValidationResult ImportUser(User user)
    {
        var validationResult = validator.Validate(user);
        if (validationResult.IsValid())
        {
            innerList[user.Username] = user;
        }
        return new ValidationResult();
    }

    public IEnumerable<User> GetAll()
    {
        return innerList.Values;
    }
}