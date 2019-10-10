using System;
using System.Collections.Generic;
using System.Text;

namespace Ascii_Combiner
{
    public class Logic
    {
        /* if correct: result is in one String
         * on Error  :  string[0]=null, string[1]=reason
         */
        public string combine(string[] files)
        {
            try
            {
                var exception = exceptionHandling(files);
                if (exception != null)
                {
                    return exception;
                }

                char[][][] text = new char[files.Length][][];
                for (int i = 0; i < files.Length; i++)
                {
                    text[i] = new char[files[i].Split('\n').Length][];
                    for (int k = 0; k < files[i].Split('\n').Length; k++)
                    {
                        text[i][k] = files[i].Split('\n')[k].ToCharArray();
                    }
                }
                string result = "";
                bool found = false;
                for (int i = 0; i < text[0].Length; i++)
                {
                    for (int k = 0; k < text[0][i].Length; k++)
                    {
                        for (int j = 0; j < text.Length; j++)
                        {
                            if (text[j][i][k] != ' ')
                            {
                                result += text[j][i][k];
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            result += ' ';
                        }
                        found = false;
                    }
                    result += "\n";
                }

                return result;

            }
            catch (Exception ex)
            {
                return "Unknown Exception";
            }
        }
        public string exceptionHandling(string[] files)
        {
            if (files.Length < 2)
            {
                return "Not enough Files";
            }
            var nrOfLines = files[0].Split('\n').Length;
            var lengthOfLines = files[0].Split('\n')[0].Length - 1;
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Replace("\r", string.Empty);
                if (files[i].Split('\n').Length != nrOfLines)
                {
                    return "Unequal nr of Lines";
                }
                for (int k = 0; k < files[i].Split('\n').Length; k++)
                {
                    if (files[i].Split('\n')[k].Length != lengthOfLines)
                    {
                        Console.WriteLine(i);
                        Console.WriteLine(k);
                        Console.WriteLine(files[i].Split('\n')[k].Length);
                        Console.WriteLine(lengthOfLines);
                        return "Unequal length of Lines";
                    }
                }
            }
            return null;
        }

    }
}
