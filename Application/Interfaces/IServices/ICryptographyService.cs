using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface ICryptographyService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashpassword);
        byte[] GenerateHash(string password, byte[] salt);
        byte[] GenerateSalt();
        bool AreHashesEqual(byte[] hash1, byte[] hash2);
    }
}
