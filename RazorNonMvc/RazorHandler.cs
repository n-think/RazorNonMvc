using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Xml;
using Westwind.RazorHosting;

namespace RazorNonMvc
{
    public class RazorHandler
    {
        public static bool IsStarted { get; set; }
        private static RazorFolderHostContainer RazorHost { get; set; }
        private static object _lock = new object();

        public static string RenderTemplate(string template, object model, out string error)
        {
            if (RazorHost == null)
                throw new InvalidOperationException("Razor host is not started");

            error = null;

            string result = RazorHost.RenderTemplate(template, model);
            if (result == null)
                error = RazorHost.ErrorMessage;

            return result;
        }

        public static void StartRazorHost(Type[] modelTypes)
        {
            lock (_lock)
            {
                if (RazorHost != null)
                {
                    return;
                }
                
                var host = new RazorFolderHostContainer()
                {
                    // *** Set your Folder Path here - physical or relative ***
                    TemplatePath = Path.GetFullPath(@".\templates\"),
                    // *** Path to the Assembly path of your application
                    BaseBinaryFolder = Environment.CurrentDirectory
                };

                // Add any unique assemblies that are referenced in your templates
                var typesToAdd = modelTypes.GroupBy(x=>x.Assembly).Select(x=>x.First());
                foreach (var type in typesToAdd)
                {
                    host.AddAssemblyFromType(type);
                }

                // Always must start the host
                host.Start();

                RazorHost = host;
                IsStarted = true;
            }
 
        }

        public static void StopRazorHost()
        {
            lock (_lock)
            {
                RazorHost?.Stop();
                RazorHost = null;
                IsStarted = false;
            }
        }
    }
}