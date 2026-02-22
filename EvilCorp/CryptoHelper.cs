using System.Text;

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

        public static string CaesarHash(string input, int key)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    result.Append((char)((c + key - offset) % 26 + offset));
                }
                else
                {
                    result.Append((char)((c + key) % 256));
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
            if (GCD(a, 26) != 1)
                throw new ArgumentException("Invalid key: 'a' must be coprime with 26.");

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
            if (GCD(a, 26) != 1)
                throw new ArgumentException("Invalid key: 'a' must be coprime with 26.");

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
    }
}
