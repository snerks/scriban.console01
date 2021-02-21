using System;
using System.IO;
using System.Reflection;
using Scriban;

namespace scriban.console01
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Render();

            // Console.WriteLine("Hit Any Key to exit...");
            // Console.ReadKey();
        }

        private static void Render()
        {
            var folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(folderPath, "first.sbncs");

            // Parse the template
            //var template = Template.Parse(inputTemplateAsText);
            var template = Template.Parse(File.ReadAllText(filePath), filePath);

            var model = new Model
            {
                SamplePropName = "FirstName",
                Code = "if (true) { Console.WriteLine(FirstName); }"
            };

            // Renders the template with the variable `name` exposed to the template
            //var result = template.Render(model);
            var result = template.Render(model, member => member.Name); // Mapping logic for Model names

            // Prints the result: "This is a Hello World template"
            Console.WriteLine(result);
        }
    }
}
