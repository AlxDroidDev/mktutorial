using CaseConversion.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CaseConversion.API.Service
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class CaseConversionService
    {


        private Dictionary<string, string> leetRules { get; set; }

        public CaseConversionService()
        {
            leetRules = new Dictionary<string, string>();
            leetRules.Add("4", "A");
            leetRules.Add("0", "O");
            leetRules.Add("3", "E");
            leetRules.Add("|", "I");
            leetRules.Add(@"\/", "V");
            leetRules.Add("6", "G");
            leetRules.Add("5", "s");
            leetRules.Add("2", "Z");
            leetRules.Add(@"\/\/", "W");
            leetRules.Add("><", "X");
            leetRules.Add("8", "B");
            leetRules.Add("|-|", "H");
            leetRules.Add("|)", "D");
        }


        public string Convert(ConversionCaseType caseType, string sentence)
        {
            string result = "";
            switch (caseType)
            {
                case ConversionCaseType.LOWER:
                    {
                        result = sentence.ToLower();
                        break;
                    }
                case ConversionCaseType.UPPER:
                    {
                        result = sentence.ToUpper();
                        break;
                    }
                case ConversionCaseType.SNAKE:
                    {
                        result = sentence.Trim().ToLower().Replace(" ", "_");
                        break;
                    }
                case ConversionCaseType.KEBAB:
                    {
                        result = sentence.Trim().ToLower().Replace(" ", "-");
                        break;
                    }
                case ConversionCaseType.PASCAL:
                    {
                        result = CapitalizeWords(sentence, 0);
                        break;
                    }
                case ConversionCaseType.CAMEL:
                    {
                        result = CapitalizeWords(sentence, 1);
                        break;
                    }
                case ConversionCaseType.LEET:
                    {
                        result = Leet(sentence);
                        break;
                    }
                case ConversionCaseType.FATORIAL:
                    {
                        result = calculateSomeRandomTaskIntensiveShit(sentence);
                        break;
                    }
            }
            return result;
        }


        private string CapitalizeWords(string sentence, int startIndex)
        {
            const char space = ' ';
            string res = "";
            String[] words = sentence.ToLower().Split(space, StringSplitOptions.RemoveEmptyEntries);
            int i = 0;
            foreach (string word in words)
            {
                res += ((startIndex > 0) && (i == 0)) ? word : word.First().ToString().ToUpper() + word.Substring(1);
                i++;
            }

            return res;
        }

        private string Leet(string sentence)
        {
            string result = sentence.ToUpper();
            foreach (KeyValuePair<string, string> x in leetRules)
            {
                result = result.Replace(x.Value, x.Key);
            }
            return result;
        }


        private string calculateSomeRandomTaskIntensiveShit(string sentence)
        {
            sentence = SortString(sentence);
            long x = sentence.Length * 2;
            BigInteger big = new BigInteger(0);

            for (int i = 1; i <= x; i++)
            {
                Random randGen = new Random();
                big = big + Fatorial(i) + Fatorial(i - 1) + randGen.Next(100000);
            }
            return CalculateMD5Hash(SortString(big.ToString())) + " : " + SortString(big.ToString());
        }


        private BigInteger Fatorial(int x)
        {

            if (x <= 1)
                return 1;

            BigInteger n = new BigInteger(x) * Fatorial(x - 1);

            return n;
        }


        private string SortString(string input)
        {
            char[] characters = input.ToArray();

            while (true)
            {
                bool sorted = false;
                for (int i = 0; i < characters.Length - 2; i++)
                {
                    char c1 = characters[i];
                    char c2 = characters[i + 1];
                    if (c2 < c1)
                    {
                        characters[i + 1] = c1;
                        characters[i] = c2;
                        sorted = true;
                    }
                }
                if (!sorted)
                    break;
            }
            //            Array.Sort(characters);
            return new string(characters);
        }


        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hash = md5.ComputeHash(inputBytes);

                // step 2, convert byte array to hex string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
