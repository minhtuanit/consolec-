using System;
using System.Text.RegularExpressions;

namespace Console4
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine(WildcardMatch("/abc/?/***/adasd/?a?*/123", "/abc/s/ascasc/ascascssa/ascqwe123/asdas/adasd/aaaascasc/123333", '/', true));
            Console.ReadLine();
        }

        static bool WildcardMatch(string pattern, string valuea, char cat,bool sosanh)
        {
            if( sosanh == true)
            {
                pattern = pattern.ToLower();
                valuea = valuea.ToLower();
            }

            string value = pattern;
            string valueMatch = valuea;
            string[] arr = value.Split(cat);
            string[] valuearrmatch = valueMatch.Split(cat);
            string tempValue = "";

            for (int i = 0; i < valuearrmatch.Length; i++)
            {
                tempValue += valuearrmatch[i];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Contains("*"))
                {
                    arr[i] = replace1sao(arr[i]);
                }
                if (arr[i].Contains("?"))
                {
                    arr[i] = replacedauhoi(arr[i]);
                }
            }
            string s = "";
            int p = 0;
            foreach (var item in arr)
            {
                s += item;

                p++;
            }

            Regex regex = new Regex(s);
            Match match = regex.Match(tempValue);
           
            if (match.Value.CompareTo(tempValue) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        static string replaceNhieuSao(string str)
        {
            return str.Replace("**", "[a-zA-Z0-9]*");
        }

        static string replace1sao(string str)
        {
            return str.Replace("*", "[a-zA-Z0-9]*");
        }

        static string replacedauhoi(string str)
        {

            return str.Replace("?", "([a-zA-z0-9]{0,1})");
        }
    }
}
