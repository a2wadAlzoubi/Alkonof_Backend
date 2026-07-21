namespace Alkonof_Backend.Application.Modulers.Identities.Users.Services
{
    public interface IPasswordService
    {
        string Hash(string plainPassword);
        bool Compare(string plainPassword, string hash);
        bool CompareNH(string plainPassword, string hash);

    }
}
