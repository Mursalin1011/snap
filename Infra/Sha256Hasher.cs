using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace snap.Infra
{
    public class Sha256Hasher : IHasher
    {
        public string ComputeHash(string input)
        {
            // Generate a SHA-256 hash of the input string
            // Convert the input string to a byte array
            // Compute the hash
            // Convert the byte array to a hexadecimal string and return
            using var sha256 = SHA256.Create();
            
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }
    }
}
