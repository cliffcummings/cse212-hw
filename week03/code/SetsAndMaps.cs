using System.Text.Json;
using System.Diagnostics;
using System.Linq; // required for ToList() and removing white space
using System.Security.Cryptography;
using System.Runtime.InteropServices.Marshalling;  // for Debug.Write operations

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each
    /// string in the array. at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    /// --------------------------------------------------------------------
    /// words is the input strings array
    /// dynList is the input strings array converted to a dynamic array
    /// pairsList dynamic array to hold created paris-strings
    /// --------------------------------------------------------------------

    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        // DEBUG - show contents of words input-array
        foreach (string word in words)
        {
            Debug.Write($"{word}, ");
        }
        Debug.WriteLine(" :DBG1");
        // END DEBUG

        List<string> dynList = words.ToList();  // Uses System.Linq
        int listSize = dynList.Count;           // number of elements in the dynamic array
        List<string> pairsList = new List<string>();
        string pairString;

        string chars1 = dynList[0];             // To hold current input string (initialized to dynList[0])
        char[] chars1Arr;                       // chars1 to be converted to a chars1Arr
        string chars2;                          // To hold reversed input string

        // Declare a HashSet to store and check input words
        HashSet<string> items = new HashSet<string>();
        // Place the first string into the HashSet
        items.Add(chars1);
        for (int i = 1; i < listSize; i++)
        {
            chars1 = dynList[i];
            items.Add(chars1);                       // Add the next item to the Set
            chars1Arr = chars1.ToCharArray();        // Convert string to char array
            Array.Reverse(chars1Arr);                // Reverse characters for testing
            chars2 = new string(chars1Arr);          // assign char1Arr back to the chars2 string
            Debug.Write($"{chars2}, ");
            if (chars1 != chars2)
            {
                if (!items.Add(chars2))              // Check to see if reversed chars2 is in the set
                {
                    // Debug.Write(" Found Match ");
                    pairString = chars2 + " & " + chars1;
                    pairsList.Add(pairString);
                    // p++;
                }
            }
        }

        Debug.WriteLine("     :DBG2");

        // DEBUG - show pairsString array contents
        foreach (string item in pairsList)
        {
            Debug.Write($"{item}, ");
        }
        Debug.WriteLine("   :DBG3");

        string[] returnArray = pairsList.ToArray(); // convert the pairs dynamic List back into a retunList array
        return returnArray;
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (degrees.ContainsKey(fields[3]))
            {
                degrees[fields[3]]++;   // If there is an entry in the dictionary for the degree, icrement its value
            }
            else
            {
                degrees[fields[3]] = 1;
            }
            // TODO Problem 2 - ADD YOUR CODE HERE
        }
        // Alternative modern C# approach using deconstruction (C# 7.0+)
        Console.WriteLine("\nDictionary Contents (using deconstruction):");
        foreach (var (key, value) in degrees)
        {
            Console.WriteLine($"Key = {key},          Value = {value}");
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        
        string W1Lower;        // converted to lowercase
        string W2Lower;        // converted to lowercase

        char[] charsW1;
        char[] charsW2;

        string W1NS;           // string1 with spaces removed
        string W2NS;           // string2 with spaces removed

        string sortedW1;
        string sortedW2;

        string sortedW1Lower;        // converted to lowercase
        string sortedW2Lower;        // converted to lowercase

        string sortedW1LowerNS;      // NS - No Spaces
        string sortedW2LowerNS;      // NS - No Spaces
        
        // First remove spaces so that the Length test will be accurate
        // Uses System.Linq
        W1NS = string.Concat(word1.Where(c => !char.IsWhiteSpace(c)));
        W2NS = string.Concat(word2.Where(c => !char.IsWhiteSpace(c)));

        if (W1NS.Length == W2NS.Length)      // do not sort until we know the word lengths are the same
        {
            W1Lower = W1NS.ToLower();        // convert words to all lowercase
            W2Lower = W2NS.ToLower();

            charsW1 = W1Lower.ToCharArray(); // convert strings to character arrays
            charsW2 = W2Lower.ToCharArray();

            Array.Sort(charsW1);             // sort alphabetically the character arrays
            Array.Sort(charsW2);

            sortedW1 = new string(charsW1);  // convert the character arrays back to strings
            sortedW2 = new string(charsW2);

            Debug.WriteLine($"sortedW1 is {sortedW1}");
            Debug.WriteLine($"sortedW2 is {sortedW2}");

            if (sortedW1 == sortedW2)        // If the sorted strings match, this is a MATCH anagram
            {
                Debug.WriteLine("Match");
                return true;
            }
            else                             // else the sorted strings are not anagrams
            {
                Debug.WriteLine("NO Match");
                return false;
            }
        }
        Debug.WriteLine($"W1NS.Length {W1NS} does not match W2NS.Length {W2NS}");
        return false;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
        // var fc = new FeatureCollection();
        // fc.PrintFeatures();
        featureCollection.PrintFeatures();
        double? magnitude;
        string? location;
        List<string> outStrings = new List<string>();

        // string debugString = "Uninitialize";
        // int debugCnt = 0;
        List<string> locations = new List<string>();
        Debug.WriteLine("About to start foreach loop");
        foreach (var feature in featureCollection.features)
        {
            // debugCnt++;
            // debugString = "Entering foreach loop";
            // Debug.WriteLine($"{debugString} and DebugCnt={debugCnt}");
            magnitude = feature?.properties?.mag ?? 0.0;
            // {
            //     magnitude = 0.0;
            // }
            // else
            // {
            //     magnitude = feature.props.mag;
            // }
            location = feature.properties.place;

            // debugString = ($"location = {location}");
            locations.Add(location);
            Debug.WriteLine($"{location} - Mag {magnitude},");
            outStrings.Add($"{location} - Mag {magnitude},");  // Add to the dynamic array
        }

        var arrayMax = featureCollection.features.Count;
        Debug.WriteLine($"There are {arrayMax} entries in the featureCollection array");

        // Convert the dynamic array to a strings array to be returned.
        string[] returnString = outStrings.ToArray();

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        //    on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place an earthquake has happened today 
        //    and its magitude.
        // 3. Return an array of these string descriptions.
        return returnString;
    }
}