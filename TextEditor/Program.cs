using Microsoft.Extensions.DependencyInjection;
namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();

            var textEditor = serviceProvider.GetRequiredService<TextEditor.GUI.TextEditor>();

            textEditor.StartApp();
        }
        private static ServiceProvider ConfigureServices()
        {
            // Set up dependency injection
            var services = new ServiceCollection();

            // Register services
            services.AddScoped<TextEditor.GUI.TextEditor, TextEditor.GUI.TextEditor>();


            return services.BuildServiceProvider();
        }
    }
}