namespace Alkonof_Backend.Application.Common.Interfaces;

public interface IPasswordService
{
    string Hash(string plainPassword);
    bool Compare(string plainPassword, string hash);
    bool CompareNH(string plainPassword, string hash);

}
