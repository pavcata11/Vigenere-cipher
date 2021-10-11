using System;

namespace cipherVejener
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Inpyu Text:");
            string text = Console.ReadLine().ToUpper();
            Console.WriteLine("Inpyu Key:");
            string key = Console.ReadLine().ToUpper();
            key = MakeKeyLengthAsTextLength(key, text);
            CryptText(key, text);
            Console.WriteLine("Decrypt Text is:");
            Console.WriteLine(CryptText(key, text));
            Console.WriteLine("Input Your Decrypt Text");
            text = Console.ReadLine().ToUpper();
            Console.WriteLine("Input Your Key:");
            key = Console.ReadLine().ToUpper();
            key = MakeKeyLengthAsTextLength(key, text);
            Console.WriteLine(Encrypt(text, key));
        }

        private static string Encrypt(string text, string key)
        {
            char[] arrTxt = text.ToCharArray();
            char[] arrKey = key.ToCharArray();
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(arrTxt[i]))
                {
                    int position = (int)arrKey[i] - (int)'A';
                    int newPositionLetter = (char)((int)arrTxt[i] - position);
                    if (newPositionLetter < (int)'A')
                    {
                        newPositionLetter += 26;
                    }
                    arrTxt[i] = (char)newPositionLetter;

                }
            }
            var crypttext = new string(arrTxt);
            return crypttext;
        }

        private static string CryptText(string key, string text)
        {
            char[] arrTxt = text.ToCharArray();
            char[] arrKey = key.ToCharArray();
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(arrTxt[i]))
                {
                    int position = (int)arrKey[i] - (int)'A';
                    int newPositionLetter = (char)((int)arrTxt[i] + position);
                    if (newPositionLetter > (int)'Z')
                    {
                        newPositionLetter -= 26;
                    }
                    arrTxt[i] = (char)newPositionLetter;

                }
            }
            var crypttext = new string(arrTxt);
            return crypttext;
        }

        private static string MakeKeyLengthAsTextLength(string key, string text)
        {
            if (key.Length < text.Length)
            {
                char[] arr = key.ToCharArray();
                while (key.Length != text.Length)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        key += arr[i].ToString();
                        if (key.Length == text.Length)
                        {
                            break;
                        }
                    }
                }
                //Console.WriteLine(key) ;
            } 
            return key;
        }
    }
}
