using System.Text;
using System.Linq;

namespace EvilCorp
{
    public static class CryptoHelper
    {
        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }
        private static bool IsValidAffineKey(int a)
        {
            return GCD(a, 26) == 1;
        }

        /// <summary>
        /// Returns true if the string is valid for Caesar encryption:
        /// only [a-z], [A-Z] and space characters are allowed.
        /// </summary>
        public static bool IsValidCaesarInput(string input)
        {
            foreach (char c in input)
            {
                if (!(c >= 'a' && c <= 'z') && c != ' ')
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Caesar cipher: uses a 27-character alphabet [a-z] + ' '.
        /// Space is the 27th character (index 26).
        /// When key=1: ' ' -> 'a', 'z' -> ' '.
        /// </summary>
        public static string CaesarHash(string input, int key)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in input)
            {
                int index;
                if (c == ' ')
                {
                    index = 26;
                }
                else if (c >= 'a' && c <= 'z')
                {
                    index = c - 'a';
                }
                else
                {
                    continue; // Skip invalid characters
                }

                int shiftedIndex = ((index + key) % 27 + 27) % 27;

                if (shiftedIndex == 26)
                {
                    result.Append(' ');
                }
                else
                {
                    result.Append((char)('a' + shiftedIndex));
                }
            }
            return result.ToString();
        }


        public static string CaesarEncrypt(string input, int key)
        {
            return CaesarHash(input, key);
        }

        public static string CaesarDecrypt(string input, int key)
        {
            return CaesarHash(input, -key);
        }

        public static string AffineEncrypt(string input, int a, int b)
        {
            if (!IsValidAffineKey(a))
                throw new ArgumentException(
                    $"Invalid key value for 'a'.\n\n" +
                    $"The value {a} is not coprime with 26.\n\n" +
                    $"For Affine cipher to work, gcd(a,26) must equal 1.\n" +
                    $"Valid values are: 1,3,5,7,9,11,15,17,19,21,23,25"
                );

            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    int x = c - offset;

                    int encrypted = ((a * x + b) % 26 + 26) % 26;
                    result.Append((char)(encrypted + offset));
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        public static string AffineDecrypt(string input, int a, int b)
        {
            if (!IsValidAffineKey(a))
                throw new ArgumentException(
                    $"Invalid key value for 'a'.\n\n" +
                    $"The value {a} is not coprime with 26.\n\n" +
                    $"Valid values are: 1,3,5,7,9,11,15,17,19,21,23,25"
                );

            int aInv = ModInverse(a, 26);

            if (aInv == -1)
                throw new ArgumentException("Modular inverse does not exist for this key.");

            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    int y = c - offset;

                    int decrypted = ((aInv * (y - b)) % 26 + 26) % 26;
                    result.Append((char)(decrypted + offset));
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        public static string HillEncrypt(string input, int[,] keyMatrix)
        {
            int n = keyMatrix.GetLength(0);
            StringBuilder result = new StringBuilder();
            string cleanInput = input.ToUpper().Replace(" ", "");

            while (cleanInput.Length % n != 0)
                cleanInput += 'X';

            for (int i = 0; i < cleanInput.Length; i += n)
            {
                int[] vector = new int[n];
                for (int j = 0; j < n; j++)
                {
                    vector[j] = cleanInput[i + j] - 'A';
                }

                int[] encrypted = MultiplyMatrix(keyMatrix, vector);
                for (int j = 0; j < n; j++)
                {
                    result.Append((char)((encrypted[j] % 26) + 'A'));
                }
            }
            return result.ToString();
        }

        public static string HillDecrypt(string input, int[,] keyMatrix)
        {
            int[,]? invMatrix = InvertMatrix(keyMatrix, 26);
            if (invMatrix == null) return input;
            return HillEncrypt(input, invMatrix);
        }

        private static int[] MultiplyMatrix(int[,] matrix, int[] vector)
        {
            int n = matrix.GetLength(0);
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = 0;
                for (int j = 0; j < n; j++)
                {
                    result[i] += matrix[i, j] * vector[j];
                }
            }
            return result;
        }

        private static int ModInverse(int a, int m)
        {
            a = a % m;
            for (int x = 1; x < m; x++)
            {
                if ((a * x) % m == 1)
                    return x;
            }
            return -1;
        }

        private static int[,]? InvertMatrix(int[,] matrix, int mod)
        {
            int n = matrix.GetLength(0);
            if (n != 2) return null;

            int det = (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]) % mod;
            if (det < 0) det += mod;

            int detInv = ModInverse(det, mod);
            if (detInv == -1) return null;

            int[,] inv = new int[2, 2];
            inv[0, 0] = (matrix[1, 1] * detInv) % mod;
            inv[0, 1] = (-matrix[0, 1] * detInv) % mod;
            inv[1, 0] = (-matrix[1, 0] * detInv) % mod;
            inv[1, 1] = (matrix[0, 0] * detInv) % mod;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (inv[i, j] < 0) inv[i, j] += mod;
                }
            }

            return inv;
        }

        /// <summary>
        /// Bundles the encrypted content, algorithm, and key into a single string
        /// by injecting metadata characters into the content.
        /// </summary>
        public static string BundleMessage(string content, string algorithm, string key)
        {
            // 1. Pack metadata into a single string with an internal separator
            string metadata = $"{algorithm}|{key}";
            string header = metadata.Length.ToString("D3"); // 3-digit length header

            // 2. Interleave metadata and content: meta at even, content at odd positions
            StringBuilder bundled = new StringBuilder(header);
            int metaIdx = 0;
            int contentIdx = 0;

            // Total length of the payload (excluding header)
            int total = metadata.Length + content.Length;

            for (int i = 0; i < total; i++)
            {
                // We alternate until one is exhausted, then fill the rest with the other
                bool isMetaTurn = (i % 2 == 0) && (metaIdx < metadata.Length);

                // Special case: if content is exhausted, everything else must be meta
                if (contentIdx >= content.Length) isMetaTurn = true;
                // Special case: if meta is exhausted, everything else must be content
                if (metaIdx >= metadata.Length) isMetaTurn = false;

                if (isMetaTurn)
                {
                    bundled.Append(metadata[metaIdx++]);
                }
                else
                {
                    bundled.Append(content[contentIdx++]);
                }
            }

            return bundled.ToString();
        }

        public static (string content, string algorithm, string key) UnbundleMessage(string bundled)
        {
            if (bundled.Length < 3) return (bundled, "Caesar", "3");

            // Extract the 3-digit metadata length
            if (!int.TryParse(bundled.Substring(0, 3), out int metaLen))
                return (bundled, "Caesar", "3");

            string payload = bundled.Substring(3);
            StringBuilder metaBuilder = new StringBuilder();
            StringBuilder contentBuilder = new StringBuilder();

            int metaCharsFound = 0;
            int contentCharsFound = 0;
            int expectedContentLen = payload.Length - metaLen;

            for (int i = 0; i < payload.Length; i++)
            {
                bool isMetaTurn = (i % 2 == 0) && (metaCharsFound < metaLen);

                // Adjust turns if one sequence is complete
                if (contentCharsFound >= expectedContentLen) isMetaTurn = true;
                if (metaCharsFound >= metaLen) isMetaTurn = false;

                if (isMetaTurn)
                {
                    metaBuilder.Append(payload[i]);
                    metaCharsFound++;
                }
                else
                {
                    contentBuilder.Append(payload[i]);
                    contentCharsFound++;
                }
            }

            string metadata = metaBuilder.ToString();
            var parts = metadata.Split('|');
            if (parts.Length >= 2)
            {
                return (contentBuilder.ToString(), parts[0], parts[1]);
            }

            return (contentBuilder.ToString(), "Caesar", "3");
        }
    }
}
