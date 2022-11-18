using System.Collections.Generic;

namespace webMobileShop.Contracts
{
    public interface IHashManager
    {
        List<byte[]> HashWithSalt(string password);
        bool VerifyPasswordWithSaltAndStoredHash(string password, byte[] storedHash, byte[] storedSalt);
        string EncryptPlainText(string plainText);
        string DecryptCipherText(string cipherText);  
    }
}
