using System;
using System.Security.Cryptography;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace UserManager.Model.Encryption
{
    public class HmacSha512Hasher : PasswordHasher
    {

        public override string GetHash(string input, string key)
        {
            using (HMACSHA512 hmacsha512 = new HMACSHA512(Encoding.UTF8.GetBytes(key)))
            {
                byte[] data = hmacsha512.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes 
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data  
                // and format each one as a hexadecimal string. 
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string. 
                return sBuilder.ToString();
            }            
        }
    }
}
