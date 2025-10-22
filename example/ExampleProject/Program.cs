using OpenSky.Net;

namespace ExampleProject;

class Program
{
    static async Task Main(string[] args)
    {
        var openSkyApi = new OpenSkyClient(10);
        var vecs = await openSkyApi.GetAllStateVectors();
        
        Console.WriteLine(vecs);
    }
}