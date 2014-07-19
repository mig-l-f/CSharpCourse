using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace UserManager.Model.Encryption
{
    public abstract class PasswordHasher
    {
        //public abstract string GetHash(string input);

        public abstract string GetHash(string input, string key = "");

        public virtual bool VerifyHash(string input, string hash, string key = "")
        {
            // Hash the input. 
            string hashOfInput = GetHash(input, key);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
