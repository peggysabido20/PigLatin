namespace PigLatin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter String: ");
            string Cadena = Console.ReadLine();
            string[] Words = Cadena.Split(' ');
            Func<string, bool> ValidVowel = CadenaStr => "aeiou".IndexOf(CadenaStr, StringComparison.InvariantCultureIgnoreCase) >= 0;
            //Func<string, bool> HasSpecialChar = SpecialChar => "?!".IndexOf(SpecialChar, StringComparison.InvariantCultureIgnoreCase) >= 0;
            //Func<string, int> GetIdx = SpecialCharIdx => "?!".IndexOf(SpecialCharIdx, StringComparison.InvariantCultureIgnoreCase);
            Func<string, bool> CadGreaterThan2 = CadenaStr => CadenaStr.Length > 2;
            Func<string, bool> CadEqual2 = CadenaStr => CadenaStr.Length == 2;
            Func<string, bool> CadLessThan2 = CadenaStr => CadenaStr.Length < 2;
            Func<string, string> ConvertPigLatin = ConcatCadena => string.Concat(ConcatCadena, "ay");
            string FinalPigLatin = "";
            foreach (string word in Words)
            {
                if (string.IsNullOrWhiteSpace(word))
                {
                    continue;
                }
                //if (HasSpecialChar(word)){
                //    int CharIdx = GetIdx(word);
                //    string SChar = word[CharIdx].ToString();
                //}
                string SinglePigLatin = "";
                if (CadGreaterThan2(word))
                {
                    if (ValidVowel(word[0].ToString()))
                    {
                        SinglePigLatin = ConvertPigLatin(string.Concat(word.ToString(), "w"));
                    }
                    else
                    {
                        if (ValidVowel(word[1].ToString()))
                        {
                            SinglePigLatin = string.Concat(word.ToString().Substring(1), ConvertPigLatin(word.ToString().Substring(0, 1)));
                        }
                        else
                        {
                            SinglePigLatin = string.Concat(word.ToString().Substring(2), ConvertPigLatin(word.ToString().Substring(0, 2)));
                        }
                    }
                }
                else if (CadEqual2(word))
                {
                    if (ValidVowel(word[0].ToString())) 
                    {
                        SinglePigLatin = ConvertPigLatin(word.ToString());
                    }
                    else
                    {
                        SinglePigLatin = string.Concat(word.ToString().Substring(1), ConvertPigLatin(word.ToString().Substring(0, 1)));
                    }
                }
                else if (CadLessThan2(word))
                {
                    if (ValidVowel(word.ToString()))
                    {
                        SinglePigLatin = ConvertPigLatin(string.Concat(word.ToString(), "w"));
                    }
                    else
                    {
                        SinglePigLatin = ConvertPigLatin(word.ToString());
                    }                    
                }
                FinalPigLatin = string.Concat(FinalPigLatin, " ", SinglePigLatin);
            }
            if (!string.IsNullOrEmpty(FinalPigLatin))
            {
                Console.WriteLine($"Pig Latin is: {FinalPigLatin.Trim()}");
            }            
        }
    }
}