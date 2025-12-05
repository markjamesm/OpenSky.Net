# OpenSky.Net

OpenSky.NET is a library for interacting with the [OpenSky Network](https://opensky-network.org) REST API. 

The library is under active development.

## Usage

Initialize a new OpenSkyClient() using:

```csharp
var openSkyApi = new OpenSkyClient(int maxApiCallsPerMinute);
```

### Endpoints

```csharp
GetAllStateVectorsAsync(StateRequest stateRequest)
```
- Retrieves all [state vectors](https://openskynetwork.github.io/opensky-api/rest.html#all-state-vectors) from the OpenSky API.

```csharp
GetFlightsAsync(FlightRequest flightRequest)
```
- Retrieve flights for a certain time interval [begin, end].

```csharp
GetAircraftMetadataAsync(string icao24)
```
- Get metadata associated with an aircraft (make, model, owner/operator, etc.).

