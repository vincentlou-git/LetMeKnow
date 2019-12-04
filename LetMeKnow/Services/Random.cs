using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LetMeKnow.Services
{
    public static class Random
    {
        // https://stackoverflow.com/questions/32932679/using-rngcryptoserviceprovider-to-generate-random-string
        public static string RandomPassword(int length) {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider()) {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0) {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();
        }
    }
}
