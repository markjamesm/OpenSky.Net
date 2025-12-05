using OpenSky.Net;
using OpenSky.Net.Models;

namespace ExampleProject;

class Program
{
    static async Task Main(string[] args)
    {
        var openSkyApi = new OpenSkyClient(10);
        
        var sr = new StateRequest
        {
            Extended = 1,
            Lamin = 45.8389f,
            Lomin = 5.9962f,
            Lomax = 10.5226f, 
            Lamax = 47.8229f
        };

        var fr = new FlightRequest
        {
            Begin = 1764896859,
            End = 1764896759,
        };
        
        
        // Get all state vectors & print them.
        var vecs = await openSkyApi.GetAllStateVectorsAsync(sr);

        Console.WriteLine(vecs.Time);

        foreach (var i in vecs.StateVectors)
        {
            Console.WriteLine($"({i.Callsign} {i.LastContactTime})");
        } 
    }
}