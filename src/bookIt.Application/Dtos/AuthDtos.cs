namespace bookIt.Application.Dtos;

public class RegisterDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class AuthResponseDto
{
    public string Token { get; set; }
    public string Email { get; set; }
}