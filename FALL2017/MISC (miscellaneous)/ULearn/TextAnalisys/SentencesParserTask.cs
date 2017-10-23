using System.Collections.Generic;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static readonly string[] StopWords =
        {
            "the", "and", "to", "a", "of", "in", "on", "at", "that",
            "as", "but", "with", "out", "for", "up", "one", "from", "into"
        };

        public static readonly char[] SymbolsOfPunctuation =
        {
            '.', '!', '?', ';', ':', '(', ')'
        };

        public static readonly char[] SymbolsOfSepatation =
        {
            ',', ' ', '[', ']', '/', '\\', '"', '|', '{', '}'
        };

        public static List<List<string>> ParseSentences(string text)
        {
            List<List<string>> listOfSentences = new List<List<string>>();

            foreach (string e in text.Split(SymbolsOfPunctuation))
            {
                List<string> sentence = new List<string>();
                foreach (string f in e.Split(SymbolsOfSepatation))
                {
                    sentence.Add(f);
                }
                listOfSentences.Add(sentence);
            }
            int countOfSentences = listOfSentences.Count;
            for (int a = 0; a < countOfSentences; a++)
            {
                int countOfWords = listOfSentences[a].Count;
                for (int b = 0; b < countOfWords; b++)
                {
                    listOfSentences[a][b] = listOfSentences[a][b].ToLower();
                    if (listOfSentences[a][b] == "")
                    {
                        listOfSentences[a].Remove(listOfSentences[a][b]);
                        countOfWords--;
                        break;
                    }

                    int wordLenght = listOfSentences[a][b].Length;
                    for (int c = 0; c < wordLenght; c++)
                    {
                        if (listOfSentences[a][b][c] == '\'' || char.IsLetter(listOfSentences[a][b][c]))
                            continue;
                        else
                        {
                            listOfSentences[a][b] = listOfSentences[a][b].Remove(c, 1);
                            c--;
                            wordLenght--;
                        }
                    }

                    for (int s = 0; s < StopWords.Length; s++)
                    {
                        if (listOfSentences[a][b] == StopWords[s])
                        {
                            listOfSentences[a].Remove(listOfSentences[a][b]);
                            countOfWords--;
                            break;
                        }
                    }
                }

                if (listOfSentences[a] == null)
                {
                    listOfSentences.Remove(listOfSentences[a]);
                    countOfSentences--;
                }
            }
            return listOfSentences;
        }
    }
}

/*
Разбейте файл с текстом на предложения и слова. 
Считайте, что слова могут состоять только из букв (используйте метод char.IsLetter) или символа апострофа ',
а предложения разделены одним из следующих символов .!?;:()
Слова могут быть разделены любыми символами, за исключением тех, которые разделяют предложения.
Удалите из текста слова, содержащиеся в массиве StopWords (частые незначащие слова при анализе текстов называют стоп-словами)
Метод должен возвращать список предложений, где каждое предложение — это список оставшихся слов в нижнем регистре.
*/
