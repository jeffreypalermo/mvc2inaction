using UnitTestingExamples.Models;

namespace UnitTestingExamples.Services
{
    public interface IUserSession
    {
        User GetCurrentUser();
        void LogIn(User user);
        void LogOut();
    }
}