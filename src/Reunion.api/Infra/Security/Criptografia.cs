namespace Reunion.api.Infra.Security;

using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using Reunion.api.Domain.Entities;

public class Criptografia : PasswordHasher<Usuario>
{
    public override string HashPassword(Usuario user, string password)
    {
        return BCrypt.HashPassword(password, 10);
    }

    public override PasswordVerificationResult VerifyHashedPassword(Usuario user, string hashedPassword, string providedPassword)
    {
        return BCrypt.Verify(providedPassword, hashedPassword) ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
    }

}