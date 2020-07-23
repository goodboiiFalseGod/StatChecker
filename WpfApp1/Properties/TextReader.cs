using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;
using System.Net;
using System.IO;

namespace MainApp
{
    static class TextReader
    {
        private static Regex regex = new Regex(@"([A-Za-z]+)\s=\s((,*\w+){3})");
        private static string textSource = System.IO.File.ReadAllText(@"HotkeysSettings.txt");

        public static Dictionary<string, int[]> GetHotkeys()
        {
            string[] textArray = textSource.Split('\n');
            Dictionary<string, int[]> hotkeys = new Dictionary<string, int[]>();
            foreach (string line in textArray)
            {
                if (regex.IsMatch(line))
                {
                    Match match = regex.Match(line);

                    string keys = match.Groups[2].ToString();
                    string[] stringKeys = keys.Split(',');
                    int[] intKeys = new int[stringKeys.Length];

                    for (int i = 0; i < stringKeys.Length; i++)
                    {
                        intKeys[i] = Convert.ToInt32(stringKeys[i], 16);
                    }
                    hotkeys.Add(match.Groups[1].ToString(), intKeys);
                }
            }
            return hotkeys;
        }
    }

    static class Network
    {
        public static string GetSteamProfileName(string Link)
        {
            WebClient client = new WebClient();
            Stream data = client.OpenRead(Link); //link
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            string[] stringarrray = s.Split('\n');
            Regex regex = new Regex(@"<\w*\s\w*=\""(actual_persona_name)\"">(.*)<\/\w*>");
            foreach (string line in stringarrray)
            {
                if (regex.IsMatch(line))
                {
                    Match match = regex.Match(line);
                    //Console.WriteLine(line);
                    return match.Groups[2].Value; //result
                }
            }
            data.Close();
            reader.Close();

            return String.Empty;
        }
    }
}
