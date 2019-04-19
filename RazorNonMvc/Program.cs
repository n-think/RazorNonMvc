using System;

namespace RazorNonMvc
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = AppTemplates.RenderTemplate("myTemplate.cshtml", new MyModel() {String = "asd", Int = 3},
                out string error);
            Console.Write(result);
            Console.Write(error);
            Console.ReadKey();

        }
    }
}