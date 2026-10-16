class Program
{
    static void Main()
    {
        while (true)
        {
            string abc = "ABCDEFGHIKLMNOPQRSTUVWXYZ";

            Console.Write("Key: ");
            string key = (Console.ReadLine() ?? "").ToUpper().Replace("J", "I");
            Console.Write("Text: ");
            string text = (Console.ReadLine() ?? "").ToUpper().Replace("J", "I");

            string m = "";
            foreach (char c in key + abc)
                if (abc.Contains(c) && !m.Contains(c)) m += c;

            string t = "";
            foreach (char c in text)
                if (abc.Contains(c)) t += c;

            string result = "";
            for (int i = 0; i < t.Length; i++)
            {
                char a = t[i];
                char b = (i + 1 < t.Length && t[i + 1] != a) ? t[++i] : 'X';

                int p1 = m.IndexOf(a), p2 = m.IndexOf(b);
                int r1 = p1 / 5, c1 = p1 % 5, r2 = p2 / 5, c2 = p2 % 5;

                if (r1 == r2) result += m[r1 * 5 + (c1 + 1) % 5] + "" + m[r2 * 5 + (c2 + 1) % 5];
                else if (c1 == c2) result += m[(r1 + 1) % 5 * 5 + c1] + "" + m[(r2 + 1) % 5 * 5 + c2];
                else result += m[r1 * 5 + c2] + "" + m[r2 * 5 + c1];
            }

            Console.WriteLine("Result: " + result);
        }
    }
}