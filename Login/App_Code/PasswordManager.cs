using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridAndSalt
{
    public class PasswordManager
    {
        HashComputer m_hashComputer = new HashComputer();

        public string GeneratePasswordHash(string plainTextPassword, out string salt)
        {
            salt = SaltGenerator.GetSaltString();

            string finalString = plainTextPassword + salt;

            return m_hashComputer.GetPasswordGridAndSalt(finalString);
        }

        public bool IsPasswordMatch(string password, string salt, string hash)
        {
            string finalString = password + salt;
            return hash == m_hashComputer.GetPasswordGridAndSalt(finalString);
        }
    }
}
