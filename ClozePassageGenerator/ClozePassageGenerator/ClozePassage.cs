using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClozePassageGenerator
{
    public class ClozePassage
    {
        public List<Word> words = new List<Word>();

        public void LoadPassage(string passage)
        {
            string[] arr = passage.Split( new string[] { "\r\n", "\r", "\n", " " }, StringSplitOptions.RemoveEmptyEntries);
            words.Clear();

            for (int i = 0; i < arr.Length; i++)
            {
                words.Add(new Word(arr[i], i));
            }
        }

        public void WriteToFile(string filePath)
        {
            int wordCount = words.Count;

            Stream s = File.OpenWrite(filePath);
            BinaryWriter bin = new BinaryWriter(s);
            using (bin)
            {
                //Write wordcount
                bin.Write(wordCount);

                //Write bool[] blanked
                for (int i = 0; i < wordCount; i++)
                {
                    bin.Write(words[i].blanked);
                }

                //Write string[] wordStrings
                for (int i = 0; i < wordCount; i++)
                {
                    bin.Write(words[i].RawString);
                }
            }
        }

        public string GetClozePassage()
        {
            string output = string.Empty;

            for (int i = 0; i < words.Count; i++)
            {
                output += words[i].GetString();
                if (i < words.Count - 1) output += " ";
            }

            return output;
        }
    }

    public class Word
    {
        public int wordIndex;
        public bool blanked = false;

        public string prefix = string.Empty;
        public string centre = string.Empty;
        public string suffix = string.Empty;

        public string RawString => prefix + centre + suffix;

        public string GetString()
        {
            string mid = string.Empty;

            if (blanked)
            {
                for (int i = 0; i < Math.Max(5, centre.Length); i++)
                {
                    mid += "_";
                }
            }
            else
            {
                mid = centre;
            }

            return prefix + mid + suffix;
        }

        public Word(string rawWord, int wordIndex)
        {
            this.wordIndex = wordIndex;

            int min = 0;
            int max = rawWord.Length - 1;
            bool significantFound = false;

            while (min < rawWord.Length && !significantFound)
            {
                if (char.IsLetterOrDigit(rawWord[min]))
                {
                    significantFound = true;
                }
                else min++;
            }

            significantFound = false;
            while (max > 0 && !significantFound)
            {
                if (char.IsLetterOrDigit(rawWord[max]))
                {
                    significantFound = true;
                }
                else max--;
            }

            prefix = rawWord.Substring(0, min);
            if (min <= max)
            {
                centre = rawWord.Substring(min, max - min + 1);

                if (max < rawWord.Length - 1)
                {
                    suffix = rawWord.Substring(max + 1, rawWord.Length - max - 1);
                }
            }
        }
    }
}
