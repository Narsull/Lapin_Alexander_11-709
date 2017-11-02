using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            List<string> phrases = new List<string>();

            for (int i = 0; i < text.Count; i++)
            {
                if (text[i].Count > 1)
                    for (int j = 0; j < text[i].Count - 1; j++)
                    {
                        phrases.Add(text[i][j] + " " + text[i][j + 1]);
                    }
            }

            return Biogramma(phrases);
        }

        public static Dictionary<string, string> Biogramma(List<string> phrases)
        {
            Dictionary<string, string> biogramma = new Dictionary<string, string>();

            foreach (string i in phrases)
            {
                foreach (string j in phrases)
                {
                    int max = 0;
                    if (j.Split(' ')[0] == i.Split(' ')[0])
                    {
                        if (j.Split(' ')[1] == i.Split(' ')[1])
                        {
                            max++;
                        }
                    }
                }
            }

            return biogramma;
        }
    }
}