using System.Text.Json;
using System.Diagnostics;
using System.Linq; // required for ToList()
using System.Security.Cryptography;  // for Debug.Write operations

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

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}