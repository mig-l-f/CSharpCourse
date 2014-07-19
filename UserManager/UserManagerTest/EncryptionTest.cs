using System;
using NUnit.Framework;
using UserManager.Model.Encryption;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace UserManagerTest
{
    [TestFixture ]
    public class EncryptionTest
    {
        [Test]
        public void md5hashTest()
        {
            PasswordHasher target = new Md5Hasher();
            string hashedPassword = target.GetHash(@"teste");
            string validHash = @"698dc19d489c4e4db73e28a713eab07b";
            Assert.True(target.VerifyHash(@"teste", validHash));
        }

        [Test]
        public void sha256Test()
        {
            PasswordHasher target = new Sha256Hasher();
            string hashedPassword = target.GetHash(@"teste");
            string validHash = @"46070d4bf934fb0d4b06d9e2c46e346944e322444900a435d7d9a95e6d7435f5";
            Assert.True(target.VerifyHash(@"teste", validHash));
        }
        [Test]
        public void hmacsha512Test()
        {

            string key = "key";
            PasswordHasher target = new HmacSha512Hasher();          
            string hashedPassword = target.GetHash(@"teste", key);
            string validHash = @"3ec5572cbd1a609b00bec40e37ba5630b1218c146c339cdd26286ada12aebb77db9e5527c268cc04e1242b8817c26b1abc34077ea6a5702934f62d44417bdf3c";
            Assert.True(target.VerifyHash(@"teste", validHash, key));
        }
    }
}
