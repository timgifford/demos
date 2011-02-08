using System;
using System.Linq;
using fit;

public class VerifyUsersRowFixture : RowFixture
{
    private readonly IUserService userService;

    public VerifyUsersRowFixture(IUserService userService)
    {
        this.userService = userService;
    }

    public override object[] Query()
    {
        return userService.GetAll().ToArray();
    }

    public override Type GetTargetClass()
    {
        return typeof(User);
    }
}