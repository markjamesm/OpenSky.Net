namespace OpenSky.Net.Models;

public class StateResponse
{
    /// <summary>
    /// The time which the state vectors in this response are associated with.
    /// All vectors represent the state of a vehicle with the interval [time - 1, time].
    /// </summary>
    public DateTimeOffset? Time { get; set; }
    
    /// <summary>
    /// The state of an aircraft is a summary of all tracking information (mainly position,
    /// velocity, and identity) at a certain point in time.
    /// </summary>
    public IReadOnlyList<StateVector>? StateVectors { get; set; }
}