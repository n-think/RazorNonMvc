using System;
using System.Diagnostics;

namespace RazorNonMvc
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var watch = new Stopwatch();
            watch.Start();
            RazorHandler.StartRazorHost(new[] {typeof(MyModel),typeof(MyModel)});

            var result = RazorHandler.RenderTemplate("myTemplate.cshtml", new MyModel() {String = "asd", Int = 3},
                out string error);
            Console.WriteLine("ms: " + watch.ElapsedMilliseconds + "; ticks: " + watch.ElapsedTicks);
            Console.WriteLine(result);
            watch.Restart();

//            Console.WriteLine("test 1");
//            result = AppTemplates.RenderTemplate("myTemplate.cshtml", new MyModel() {String = "asd", Int = 3},
//                out error);
//            Console.WriteLine("ms: " + watch.ElapsedMilliseconds + "; ticks: " + watch.ElapsedTicks);
////            Console.WriteLine(result);
//            watch.Restart();
//
//            Console.WriteLine("test 2");
//            result = AppTemplates.RenderTemplate("myTemplate.cshtml", new MyModel() {String = "asfdgfsga", Int = 5},
//                out error);
//            Console.WriteLine("ms: " + watch.ElapsedMilliseconds + "; ticks: " + watch.ElapsedTicks);
////            Console.WriteLine(result);
//            watch.Restart();

            Console.ReadKey();

            var model = new MyModel() {String = "asda", Int = 5};
            Console.WriteLine("test 3");
            result = RazorHandler.RenderTemplate("myTemplate.cshtml", model,
                out error);
            Console.WriteLine("ms: " + watch.ElapsedMilliseconds + "; ticks: " + watch.ElapsedTicks);
            Console.WriteLine(result);
            watch.Restart();

//            Console.WriteLine("test 4");
//            result = AppTemplates.RenderTemplate("myTemplate.cshtml", model,
//                out error);
//            Console.WriteLine("ms: " + watch.ElapsedMilliseconds + "; ticks: " + watch.ElapsedTicks); 
////            Console.WriteLine(result);
//            watch.Restart();

            Console.ReadKey();
        }
    }
}