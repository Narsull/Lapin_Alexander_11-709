using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static readonly string[] StopWords =
        {
            "the", "and", "to", "a", "of", "in", "on", "at", "that",
            "as", "but", "with", "out", "for", "up", "one", "from", "into"
        };

        public static readonly char[] SymbolsOfSeparation =
        {
            '.', '!', '?', ';', ':', '(', ')'
        };

        public static List<List<string>> ParseSentences(string text)
        {
            string[] sentences = text.Split(SymbolsOfSeparation);
            List<List<string>> listOfSentences = new List<List<string>>();

            for (int a = 0; a < sentences.Length; a++)
            {
                List<string> wordList = SentenceToWords(sentences[a]);
                if (wordList.Count > 0)
                    listOfSentences.Add(wordList);
            }
            return listOfSentences;
        }

        public static List<string> SentenceToWords(string sentence)
        {
            List<string> wordList = new List<string>();
            int word = 0;

            for (int b = 0; b < sentence.Length + 1; b++)
            {
                if (b != sentence.Length && (char.IsLetter(sentence[b]) | sentence[b] == '\''))
                    word++;
                else if (word != 0)
                {
                    if (!StopWords.Contains(sentence.Substring(b - word, word).ToLower()))
                        wordList.Add(sentence.Substring(b - word, word).ToLower());
                    word = 0;
                }
            }
            return wordList;
        }
    }
}