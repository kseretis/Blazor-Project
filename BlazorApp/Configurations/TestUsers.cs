using Duende.IdentityServer.Test;

namespace BlazorApp.Configurations;

public static class TestUsers
{
    public static List<TestUser> Users => new List<TestUser>
    {
        new TestUser
        {
            SubjectId = "1",
            Username = "test",
            Password = "password"
        }
    };
}