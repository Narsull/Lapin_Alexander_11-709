namespace Pluralize
{
    public static class PluralizeTask
    {
        public static string PluralizeRubles(int count)
        {
            // Напишите функцию склонения слова "рублей" в зависимости от предшествующего числительного count.
            {
                int number1 = count % 10; //2
                int number2 = count % 100; //22
                if ((number2 >= 11 && number2 <= 19) || (number1 >= 5 && number1 <= 9) || number1 == 0)
                {
                    return "рублей";
                }
                else if (number1 == 1 && number2 != 11)
                {
                    return "рубль";
                }
                else
                {
                    return "рубля";
                }
            }
        }
    }
}