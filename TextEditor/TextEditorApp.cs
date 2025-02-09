using Microsoft.Extensions.DependencyInjection;
using TextEditor.Business.Interfaces;
using TextEditor.Business;

namespace Program
{
    public class TextEditorApp
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();

            var textEditor = serviceProvider.GetRequiredService<TextEditor.GUI.MenuUi>();

            textEditor.StartApp();
        }
        private static ServiceProvider ConfigureServices()
        {
            // Set up dependency injection
            var services = new ServiceCollection();

            // Register services
            services.AddScoped<TextEditor.GUI.MenuUi, TextEditor.GUI.MenuUi>();
            services.AddScoped<ITextEditor, TextEditor.Business.TextEditor>();


            return services.BuildServiceProvider();
        }
    }
}