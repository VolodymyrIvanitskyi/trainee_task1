using System;

namespace trainee_task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = "abcbabcbabcbabcbabcba";
            Console.WriteLine("Input text: "+inputText);
            int numberOfRails = 3;


            if (numberOfRails < 2 || numberOfRails > inputText.Length)
            {
                if(inputText.Length == 0)
                    Console.WriteLine("Encrypt text: ");
                else
                Console.WriteLine("Error number of rails, please write a correct number");

            }
            else
            {
                string encrypted = Encrypt(inputText, numberOfRails);
                Console.WriteLine("Encrypt text: " + encrypted);

                string decrypted = Decrypt(encrypted, numberOfRails);
                Console.WriteLine("Decrypted text: " + decrypted);
            }
            
        }


        public static string Encrypt(string text, int numberOfRails)
        {
            if (text.Length == 0)
                return "";
            string[] rail = new string[numberOfRails];

            int index = 0;
            int number = 0;
            while (index < text.Length)
            {
                int i;

                for (i=number; i < numberOfRails; i++)
                {
                    if (index == text.Length)
                        break;
                    rail[i] += text[index];
                    index++;
                }
                for (int j = numberOfRails - 2; j >= 0; j--)
                {
                    number = 1;
                    if (index == text.Length)
                        break;
                    rail[j] += text[index];
                    index++;
                }
            }

            string encryptText="";
            foreach(string text1 in rail)
            {
                //Console.WriteLine("line: "+ text1);
                encryptText += text1;
            }
            return encryptText;
        }


        public static string Decrypt(string encodedText, int numberOfRails)
        {
            int length = encodedText.Length;
            char[,] rail = new char[numberOfRails,length];

            for (int i = 0; i < numberOfRails; i++)
                for (int j = 0; j < encodedText.Length; j++)
                    rail[i,j] = ' ';

            bool direction_down = false ;

            int row = 0;
            int col = 0;

            for (int i = 0; i < encodedText.Length; i++)
            {
                if (row == 0)
                    direction_down = true;
                if (row == numberOfRails - 1)
                    direction_down = false;

                rail[row,col++] = '*';
 
                if (direction_down)
                {
                    row++;
                }
                else
                    row--;
            }

            int index = 0;
            for (int i = 0; i < numberOfRails; i++)
            {
                for (int j = 0; j < encodedText.Length; j++)
                {
                    if (rail[i, j] == '*' && index < encodedText.Length)
                        rail[i, j] = encodedText[index++];
                }
            }

            string result="";

            col = 0;
            row = 0;
            for (int i = 0; i < encodedText.Length; i++)
            {
                if (row == 0)
                    direction_down = true;
                if (row == numberOfRails - 1)
                    direction_down = false;

                if (rail[row,col] != '*')
                    result+= rail[row,col++];

                if (direction_down)
                {
                    row++;
                }
                else row--;

            }
            return result;
        }


    }

}

