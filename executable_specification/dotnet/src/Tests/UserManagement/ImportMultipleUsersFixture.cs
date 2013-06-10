using fit;
using fitlibrary;

public class ImportMultipleUsersFixture : DoFixture
{
    private readonly IUserService userService = new UserService();

    public void LoginAs(string username)
    {
    }

    public void Given()
    {
    }

    public void When()
    {
    }

    public void When(string statement)
    {
    }
    public void Then()
    {
    }

    public Fixture ImportUsersFromFile()
    {
        return new ImportUserFixture(userService);
    }

    public Fixture VerifyUsersInSystem()
    {
        return new VerifyUsersRowFixture(userService);
    }
}




