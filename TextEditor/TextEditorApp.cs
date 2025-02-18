using Microsoft.Extensions.DependencyInjection;
using Editor.Business.Interfaces;
using Editor.Business;

namespace Program
{
    public class TextEditorApp
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();

            var textEditor = serviceProvider.GetRequiredService<Editor.GUI.MenuUi>();

            textEditor.StartApp();
        }
        private static ServiceProvider ConfigureServices()
        {
            // Set up dependency injection
            var services = new ServiceCollection();

            // Register services
            services.AddScoped<Editor.GUI.MenuUi, Editor.GUI.MenuUi>();
            services.AddScoped<ITextEditor, TextEditor>();


            return services.BuildServiceProvider();
        }
    }
}