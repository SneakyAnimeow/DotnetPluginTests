using Api;
using Newtonsoft.Json;

namespace Plugin;

public class Class1 : IMainSystemApi {
    public void OnLoad() {
        Console.WriteLine("Plugin has been loaded");
    }

    public void OnEnable() {
        Console.WriteLine("Plugin has been enabled\nNow press any key to start the loading custom library test");
        Console.ReadKey();
        Console.WriteLine($"This json was written using Newtonsoft.Json: {JsonConvert.SerializeObject(new {test = "test"})}");
    }

    public void OnDisable() {
        Console.WriteLine("Plugin has been disabled");
    }
}