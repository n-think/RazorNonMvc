using System;
using System.IO;
using Westwind.RazorHosting;

namespace RazorNonMvc
{
    public class AppTemplates
    {
        public static RazorFolderHostContainer RazorHost { get; set; }
    
        public static string RenderTemplate(string template, object model, out string error)
        {
            if (RazorHost == null)
                StartRazorHost();

            error = null;
        
            string result = RazorHost.RenderTemplate(template,model);
            if (result == null)
                error = RazorHost.ErrorMessage;
            
            return result;
        }
    
        public static void StartRazorHost()
        {
            var host = new RazorFolderHostContainer() 
            {
                // *** Set your Folder Path here - physical or relative ***
                TemplatePath = Path.GetFullPath(@".\templates\"),
                // *** Path to the Assembly path of your application
                BaseBinaryFolder = Environment.CurrentDirectory
            };
        
            // Add any assemblies that are referenced in your templates
            host.AddAssemblyFromType(typeof(MyModel));
//            host.AddAssemblyFromType(typeof(AppConfiguration));
        
  
            // Always must start the host
            host.Start();
        
            RazorHost = host;
        }
    
        public static void StopRazorHost()
        {
            RazorHost?.Stop();
        }
    }
}