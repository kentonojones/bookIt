namespace bookIt.Application.Interfaces;

public interface IPasswordHasher
{
    string HashPassword(string password);
}