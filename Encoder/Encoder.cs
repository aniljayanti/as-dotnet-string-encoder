using System;
using System.Text;
using System.Linq;

namespace Encoder
{
    public class EncoderProcessor
    {
        public string Encode(string message)
        {
            //Implement your code here!

            StringBuilder sb = new StringBuilder();

            string str = message.ToLower();

            int iChar = -1;

            // 1. Reverse the existing numbers
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\d+",
                    m => new string(m.Value.Reverse().ToArray()));

            //2. Convert string to char array
            char[] ch = str.ToCharArray(0, str.Length);

            //3. Loop upto char length
            for (int i = 0; i < ch.Length; i++)
            {
                //4. Replace space is replaced with y
                if (ch[i] == ' ')
                    sb.Append("y");
                else if (ch[i] == 'y') //5. Replace y with space
                    sb.Append(" ");
                else if (Char.IsNumber(ch[i])) //6. If it is Numeric, consider it.
                    sb.Append(ch[i]);
                else if (!Char.IsLetterOrDigit(ch[i])) //6. If it is non Numeric and non letter, then consider it.
                    sb.Append(ch[i]);
                else
                {
                    //7. Check is it vowel or not, if it is then take previous char of that, else consider the same.
                    iChar = isVowel(ch[i]);
                    if (iChar == 0)
                        sb.Append((char)(ch[i] - 1));
                    else
                        sb.Append(iChar);
                }
            }
            return sb.ToString();

        }
        private static int isVowel(char chr)
        {
            switch (chr)
            {
                case 'a':
                    return 1;
                case 'e':
                    return 2;
                case 'i':
                    return 3;
                case 'o':
                    return 4;
                case 'u':
                    return 5;
            }
            return 0;
        }
    }
}