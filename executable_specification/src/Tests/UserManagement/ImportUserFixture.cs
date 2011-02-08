using fit;

public class ImportUserFixture : ColumnFixture
{
    public ImportUserFixture():this(new UserService())
    {
        
    }
    public ImportUserFixture(IUserService userService)
    {
        this.userService = userService;
    }

    public string Username;
    public string FirstName;
    public string LastName;

    private readonly IUserService userService;
    
    private User currentUser;
    private ValidationResult validationResult;

    public override void Execute()
    {
        base.Execute();
        ImportUserFromRow();
    }

    public string ErrorMessage()
    {
        return validationResult.ToString();
    }

    private void ImportUserFromRow()
    {
        currentUser = GetImportedUserFromRow();
        validationResult = userService.ImportUser(currentUser);
    }

    private User GetImportedUserFromRow()
    {
        var importedUser = new User();
        importedUser.FirstName = FirstName;
        importedUser.LastName = LastName;
        importedUser.Username = Username;
        return importedUser;
    }
}