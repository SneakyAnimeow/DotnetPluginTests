using System.Reflection;
using Api;

var pluginDirectories = Directory.GetDirectories("plugins");

var loadedPlugins = new List<IMainSystemApi>();

foreach (var pluginDirectory in pluginDirectories) {
    Directory.GetFiles(pluginDirectory, "*.dll").ToList().ForEach(file => {
        var assembly = Assembly.LoadFrom(file);
        var types = assembly.GetTypes();
        foreach (var type in types) {
            if (!type.GetInterfaces().Contains(typeof(IMainSystemApi))) continue;

            var plugin = (IMainSystemApi)Activator.CreateInstance(type)!;

            plugin.OnLoad();
            
            loadedPlugins.Add(plugin);
        }
    });
}

foreach (var plugin in loadedPlugins) {
    plugin.OnEnable();
}

Console.WriteLine("Press any key to disable plugins");
Console.ReadKey();

foreach (var plugin in loadedPlugins) {
    plugin.OnDisable();
}

Console.WriteLine("Press any key to exit");
Console.ReadKey();