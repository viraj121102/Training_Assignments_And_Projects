// class StringPrograms
// {
//     static void Main()
//     {

//         string text = "CSharp Language invented in 2002";

//         int length = text.Length; //15
//         Console.WriteLine("The Length of a string : " + length);
//         string subString = text.Substring(7, 8);
//         Console.WriteLine("The text from a string : " + subString);
//         Console.WriteLine(text.IndexOf("harp"));
//         Console.WriteLine(text.ToUpper());
//         string newString = text.Replace("CSharp", "Java");
//         Console.WriteLine(newString);

//         String replaced = text.Replace(" ", "");
//         Console.WriteLine("Without space : " + replaced.Length);

//         int pos = text.IndexOf("Language");
//         string newText = text.Substring(pos, 8);
//         Console.WriteLine("New Text Value " + newText.ToUpper());


//         string data = "CSharp,Language";
//         String[] lang = data.Split(',');
//         foreach (string valuess in lang)
//         {
//             Console.WriteLine(valuess);
//         }

//         //Count all the special chars in a string
//         int specialCharCount = 0;
//         foreach (char c in text)
//         {
//             if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
//                 specialCharCount++;
//         }
//         Console.WriteLine("Total number of special characters: " + specialCharCount);

//         // count all vowels
//         string nm= "vIraj";
//         int vowels = 0;
//                 string name=nm.ToLower();
//         foreach (char ch in name)
//         {
//             if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
//             {
//                 vowels++;
//             }
//         }
//         Console.WriteLine("the number of vowels are:" + vowels);
//     }
  
 
// }

