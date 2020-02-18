using GenHelper.Password;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleAppTester
{
    class Program
    {
        private static string tunggal = @"{""key1"":""va,lue1"",""key2"":""value2""}";
        private static string tunggalBanyak = @"[{""key1"":""value1"",""key2"":""value2""},{""key1"":""value1"",""key2"":""value2""}]";
        static void Main(string[] args)
        {
            RandomPassword password = new RandomPassword();
            byte[] passwordHash, passwordSalt;
            password.CreatePasswordHash("makan", out passwordHash, out passwordSalt);
            bool bola  =password.VerifyPasswordHash("makan", passwordHash, passwordSalt);
            string a = string.Empty;
           // test();
           // var ss =ParseJSON(tunggalBanyak);
        }
        private static void test()
        {
            Console.WriteLine("Hello World!");
            string ss = "[{\"name\":\"Brock\"},{\"name\":\"Brr,ock\"}    ,{\"name\":\"Brock\"}]";
            string str = "GeeksForGeeks";
            string makan = tunggal.Replace("\"", "");
            var nasi = makan.Replace("[", "").Replace("]", "").Split("\"}");
            ss = ss.Replace("\"", "").Replace("&nbsp","");
            var nasi2 = ss.Replace("[", "").Replace("]", "").Split("\"}");
            ss = ss.Replace("\"", "");
            // Finding the index of character  
            // which is present in string and 
            // this will show the value 5 
            string str2 = "GeeksForGeeks";
            int index1 = ss.IndexOf('{',0);//1
            int index2 = ss.IndexOf('}', 0);//16

            int index3 = ss.IndexOf('{', 13);//18
            int index4 = ss.IndexOf('}', 13);//33

            int index5 = ss.IndexOf('{', 26);//18
            int index6 = ss.IndexOf('}', 26);//33


            // string adsasd =

        }


        public static Dictionary<string, object> ParseJSON(string json)
        {
            int end;
            return ParseJSON(json, 0, out end);
        }
        private static Dictionary<string, object> ParseJSON(string json, int start, out int end)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            bool escbegin = false;
            bool escend = false;
            bool inquotes = false;
            string key = null;
            int cend;
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> child = null;
            List<object> arraylist = null;
            Regex regex = new Regex(@"\\u([0-9a-z]{4})", RegexOptions.IgnoreCase);
            int autoKey = 0;
            for (int i = start; i < json.Length; i++)
            {
                char c = json[i];
                if (c == '\\') escbegin = !escbegin;
                if (!escbegin)
                {
                    if (c == '"')
                    {
                        inquotes = !inquotes;
                        if (!inquotes && arraylist != null)
                        {
                            arraylist.Add(DecodeString(regex, sb.ToString()));
                            sb.Length = 0;
                        }
                        continue;
                    }
                    if (!inquotes)
                    {
                        switch (c)
                        {
                            case '{':
                                if (i != start)
                                {
                                    child = ParseJSON(json, i, out cend);
                                    if (arraylist != null) arraylist.Add(child);
                                    else
                                    {
                                        dict.Add(key, child);
                                        key = null;
                                    }
                                    i = cend;
                                }
                                continue;
                            case '}':
                                end = i;
                                if (key != null)
                                {
                                    if (arraylist != null) dict.Add(key, arraylist);
                                    else dict.Add(key, DecodeString(regex, sb.ToString()));
                                }
                                return dict;
                            case '[':
                                arraylist = new List<object>();
                                continue;
                            case ']':
                                if (key == null)
                                {
                                    key = "array" + autoKey.ToString();
                                    autoKey++;
                                }
                                if (arraylist != null && sb.Length > 0)
                                {
                                    arraylist.Add(sb.ToString());
                                    sb.Length = 0;
                                }
                                dict.Add(key, arraylist);
                                arraylist = null;
                                key = null;
                                continue;
                            case ',':
                                if (arraylist == null && key != null)
                                {
                                    dict.Add(key, DecodeString(regex, sb.ToString()));
                                    key = null;
                                    sb.Length = 0;
                                }
                                if (arraylist != null && sb.Length > 0)
                                {
                                    arraylist.Add(sb.ToString());
                                    sb.Length = 0;
                                }
                                continue;
                            case ':':
                                key = DecodeString(regex, sb.ToString());
                                sb.Length = 0;
                                continue;
                        }
                    }
                }
                sb.Append(c);
                if (escend) escbegin = false;
                if (escbegin) escend = true;
                else escend = false;
            }
            end = json.Length - 1;
            return dict; //theoretically shouldn't ever get here
        }
        private static string DecodeString(Regex regex, string str)
        {
            return Regex.Unescape(regex.Replace(str, match => char.ConvertFromUtf32(Int32.Parse(match.Groups[1].Value, System.Globalization.NumberStyles.HexNumber))));
        }










    }
}
