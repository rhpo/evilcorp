using System.Text;
using System.Linq;

namespace EvilCorp
{
    public static class CryptoHelper
    {
        // ── Math helpers ──────────────────────────────────────────────────
        public static int GCD(int a, int b)
        {
            while (b != 0) { int t = b; b = a % b; a = t; }
            return Math.Abs(a);
        }

        public static bool IsValidAffineA(int a) => GCD(a, 26) == 1;

        private static int ModInverse(int a, int m)
        {
            a = ((a % m) + m) % m;
            for (int x = 1; x < m; x++)
                if ((a * x) % m == 1) return x;
            return -1;
        }

        // ── Validation helpers (return null if valid, error string if not) ─

        public static string? ValidateCaesarInput(string input)
        {
            var bad = input.Where(c => !(c >= 'a' && c <= 'z') && c != ' ').Distinct().ToList();
            if (bad.Count == 0) return null;

            string chars = string.Join(", ", bad.Select(c =>
                c == '\n' ? "newline" :
                c == '\t' ? "tab" :
                char.IsUpper(c) ? $"'{c}' (uppercase)" :
                char.IsDigit(c) ? $"'{c}' (digit)" :
                $"'{c}'"));

            return $"Caesar cipher only accepts lowercase letters (a-z) and spaces.\n\n" +
                   $"Invalid characters found: {chars}\n\n" +
                   $"Please convert to lowercase and remove digits / special characters.";
        }

        public static string? ValidateCaesarKey(string key)
        {
            if (!int.TryParse(key, out int k))
                return "Caesar key must be a whole number (e.g. 3).";
            if (k == 0 || k % 27 == 0)
                return $"Caesar key {k} produces no encryption (shift of 0 or multiple of 27).\nChoose a key between 1 and 26.";
            return null;
        }

        public static string? ValidateAffineKey(string key)
        {
            var parts = key.Split(',');
            if (parts.Length != 2)
                return "Affine key must be in the format:  a,b   (e.g. 5,8)";

            if (!int.TryParse(parts[0].Trim(), out int a))
                return $"Value 'a' = \"{parts[0].Trim()}\" is not a valid integer.";
            if (!int.TryParse(parts[1].Trim(), out int b))
                return $"Value 'b' = \"{parts[1].Trim()}\" is not a valid integer.";

            if (!IsValidAffineA(a))
                return $"Invalid value for 'a' = {a}.\n\n" +
                       $"For Affine cipher, gcd(a, 26) must equal 1.\n\n" +
                       $"Valid values for 'a':\n  1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25";

            if (b < 0 || b > 25)
                return $"Invalid value for 'b' = {b}.\n'b' must be between 0 and 25.";

            if (a == 1 && b == 0)
                return "With a=1 and b=0 there is no encryption (identity transform).\nChoose a different key.";

            return null;
        }

        public static string? ValidateAffineInput(string input)
        {
            // Affine handles upper + lower + passes through non-letters — no restriction
            return null;
        }

        public static string? ValidateHillKey(string key)
        {
            var parts = key.Split(',');
            if (parts.Length != 4)
                return "Hill key must be 4 integers separated by commas.\n" +
                       "Format:  a,b,c,d   representing the 2×2 matrix:\n" +
                       "  [ a  b ]\n  [ c  d ]";

            int[] v = new int[4];
            for (int i = 0; i < 4; i++)
            {
                if (!int.TryParse(parts[i].Trim(), out v[i]))
                    return $"Matrix value [{i}] = \"{parts[i].Trim()}\" is not a valid integer.";
            }

            int det = ((v[0] * v[3] - v[1] * v[2]) % 26 + 26) % 26;
            if (det == 0)
                return $"Invalid Hill key: the matrix determinant is 0 (mod 26).\n" +
                       $"The matrix is not invertible — decryption would be impossible.\n\n" +
                       $"Try a different key (e.g. 3,3,2,5).";

            int detInv = ModInverse(det, 26);
            if (detInv == -1)
                return $"Invalid Hill key: determinant = {det} is not coprime with 26.\n" +
                       $"gcd({det}, 26) = {GCD(det, 26)} — must be 1 for the key to be invertible.\n\n" +
                       $"Try a different key (e.g. 3,3,2,5).";

            return null;
        }

        public static string? ValidateHillInput(string input)
        {
            // Hill strips spaces and pads with X — warn user spaces will be removed
            string cleaned = input.Replace(" ", "");
            if (cleaned.Length == 0)
                return "Input is empty after removing spaces. Please enter some text.";

            var bad = cleaned.Where(c => !char.IsLetter(c)).Distinct().ToList();
            if (bad.Count > 0)
            {
                string chars = string.Join(", ", bad.Select(c =>
                    char.IsDigit(c) ? $"'{c}' (digit)" : $"'{c}'"));
                return $"Hill cipher only accepts letters (a-z, A-Z).\n\n" +
                       $"Invalid characters found: {chars}\n\n" +
                       $"Spaces are automatically removed. Digits and special characters must be removed manually.";
            }
            return null;
        }

        // ── Caesar ────────────────────────────────────────────────────────
        /// <summary>
        /// 27-character alphabet: a-z (0-25) + space (26).
        /// </summary>
        public static string CaesarHash(string input, int key)
        {
            var result = new StringBuilder();
            foreach (char c in input)
            {
                int index = c == ' ' ? 26 : (c >= 'a' && c <= 'z' ? c - 'a' : -1);
                if (index == -1) continue;
                int shifted = ((index + key) % 27 + 27) % 27;
                result.Append(shifted == 26 ? ' ' : (char)('a' + shifted));
            }
            return result.ToString();
        }

        public static string CaesarEncrypt(string input, int key) => CaesarHash(input, key);
        public static string CaesarDecrypt(string input, int key) => CaesarHash(input, -key);

        // ── Affine ────────────────────────────────────────────────────────
        public static string AffineEncrypt(string input, int a, int b)
        {
            var result = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    int x = c - offset;
                    result.Append((char)(((a * x + b) % 26 + 26) % 26 + offset));
                }
                else result.Append(c);
            }
            return result.ToString();
        }

        public static string AffineDecrypt(string input, int a, int b)
        {
            int aInv = ModInverse(a, 26);
            var result = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    int y = c - offset;
                    result.Append((char)(((aInv * (y - b)) % 26 + 26) % 26 + offset));
                }
                else result.Append(c);
            }
            return result.ToString();
        }

        // ── Hill ──────────────────────────────────────────────────────────
        public static string HillEncrypt(string input, int[,] keyMatrix)
        {
            int n = keyMatrix.GetLength(0);
            string clean = new string(input.ToUpper().Where(char.IsLetter).ToArray());
            while (clean.Length % n != 0) clean += 'X';

            var result = new StringBuilder();
            for (int i = 0; i < clean.Length; i += n)
            {
                int[] vec = Enumerable.Range(0, n).Select(j => clean[i + j] - 'A').ToArray();
                int[] enc = MultiplyMatrix(keyMatrix, vec);
                foreach (int v in enc) result.Append((char)((v % 26 + 26) % 26 + 'A'));
            }
            return result.ToString();
        }

        public static string HillDecrypt(string input, int[,] keyMatrix)
        {
            int[,]? inv = InvertMatrix(keyMatrix, 26);
            if (inv == null) return input;
            return HillEncrypt(input, inv);
        }

        private static int[] MultiplyMatrix(int[,] m, int[] v)
        {
            int n = m.GetLength(0);
            int[] r = new int[n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    r[i] += m[i, j] * v[j];
            return r;
        }

        private static int[,]? InvertMatrix(int[,] m, int mod)
        {
            if (m.GetLength(0) != 2) return null;
            int det = ((m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0]) % mod + mod) % mod;
            int detInv = ModInverse(det, mod);
            if (detInv == -1) return null;

            int[,] inv = {
                { ( m[1,1] * detInv % mod + mod) % mod, (-m[0,1] * detInv % mod + mod) % mod },
                { (-m[1,0] * detInv % mod + mod) % mod, ( m[0,0] * detInv % mod + mod) % mod }
            };
            return inv;
        }

        // ── Bundle / Unbundle ─────────────────────────────────────────────
        public static string BundleMessage(string content, string algorithm, string key)
        {
            string metadata = $"{algorithm}|{key}";
            string header = metadata.Length.ToString("D3");
            var bundled = new StringBuilder(header);
            int mi = 0, ci = 0, total = metadata.Length + content.Length;

            for (int i = 0; i < total; i++)
            {
                bool isMeta = (i % 2 == 0) && mi < metadata.Length;
                if (ci >= content.Length) isMeta = true;
                if (mi >= metadata.Length) isMeta = false;
                bundled.Append(isMeta ? metadata[mi++] : content[ci++]);
            }
            return bundled.ToString();
        }

        public static (string content, string algorithm, string key) UnbundleMessage(string bundled)
        {
            if (bundled.Length < 3) return (bundled, "Caesar", "3");
            if (!int.TryParse(bundled.Substring(0, 3), out int metaLen))
                return (bundled, "Caesar", "3");

            string payload = bundled.Substring(3);
            var meta = new StringBuilder();
            var content = new StringBuilder();
            int mc = 0, cc = 0, expContent = payload.Length - metaLen;

            for (int i = 0; i < payload.Length; i++)
            {
                bool isMeta = (i % 2 == 0) && mc < metaLen;
                if (cc >= expContent) isMeta = true;
                if (mc >= metaLen) isMeta = false;
                if (isMeta) { meta.Append(payload[i]); mc++; }
                else { content.Append(payload[i]); cc++; }
            }

            var parts = meta.ToString().Split('|');
            return parts.Length >= 2
                ? (content.ToString(), parts[0], parts[1])
                : (content.ToString(), "Caesar", "3");
        }
    }
}