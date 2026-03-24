using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;  // for Debug.Write operations

public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public List<Feature> features { get; set; } = new List<Feature>();
    public void PrintFeatures()
    {
        Debug.WriteLine($"Feature Collection ({features.Count} items):");
        foreach (var feature in features)
        {
            // Print properties of each feature
            Debug.WriteLine($"- Feature: {feature.properties.ToString()}");
        }
    }
}

public class Feature
{
    public Properties properties { get; set; } = new Properties();

}


public class Properties
{
    public double? mag { get; set; }
    public string place { get; set; }
    public override string ToString() => $"mag: {mag}  /  place: {place}";    
}


// Example JSON data:
// {"type":"Feature",
//  "properties": {"mag":  1.5,
//                 "place":"55 km E of McCarthy, Alaska",
//                 "time":1774213023949,
//                 "updated":1774213206364,
//                 "tz":null,
//                 "url":"https://earthquake.usgs.gov/earthquakes/eventpage/aka2026fsltqx",
//                 "detail":"https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/aka2026fsltqx.geojson","felt":null,"cdi":null,"mmi":null,"alert":null,"status":"automatic","tsunami":0,"sig":35,"net":"ak","code":"a2026fsltqx","ids":",aka2026fsltqx,","sources":",ak,","types":",origin,phase-data,","nst":7,"dmin":0.3,"rms":0.8,"gap":180,"magType":"ml","type":"earthquake","title":"M 1.5 - 55 km E of McCarthy, Alaska"},
//                 "geometry":{"type":"Point","coordinates":[-141.884,61.365,5]},"id":"aka2026fsltqx"},
//