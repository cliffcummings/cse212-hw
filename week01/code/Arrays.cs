// Required for Debug.Writeline() commands
using System.Diagnostics;
public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        Debug.WriteLine("Running Arrays Code"); // TODO - added to make sure this code is running
        Debug.WriteLine($"Initial: number={number} length={length}");
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // START: Declare a dynamic array - the final size will be size=length
        List<double> numbers = new List<double>(); // Declare a numbers list
        for (var i = 1; i <= length; i++)
        {
            numbers.Add(number * i);  // Add each number to the numbers list
            Debug.Write($"{i} ");     // Make sure the for-loop is running
        }
        Debug.WriteLine("");          // Terminate the count line

        // Check to see if the list looks correct
        Debug.WriteLine("Printing list using string.Join():");
        Debug.WriteLine(string.Join(", ", numbers));

        // Return the list that has been converted to an arry
        return numbers.ToArray();
        // return []; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Get the number of elements using the Count property
        int length = data.Count;
        // Print the result
        Debug.WriteLine($"The length of the data list is: {length} and the rotation amount is {amount}");

        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // START: look into concatenating two sub-Lists together
        // First try printing the two sublists to see if you are grabbing the correct elements
        string debugList = String.Join(", ", data);
        // Grab two sublists: firstList  = list.GetRange(1,length-amount);
        //                    secondList = list.GetRange(length-amount, amount);
        // Append (second.List,first.List) using AddRange

        // Per Google search:
        // AddRange Return Type: The List<T>.AddRange() method does not return the
        // combined list; it is a void method that modifies the list in place

        Debug.WriteLine($"The {length} elements are {debugList}");
        // The following single-line implementation is illegal (because AddRange is a void function)
        // data = data.GetRange(1,length-amount).AddRange(data.GetRange(length-amount,amount));
        var list1 = data.GetRange(0, length - amount);
        debugList = String.Join(", ", list1);
        Debug.WriteLine($"The first {length - amount} elements are {debugList}");

        var list2 = data.GetRange(length - amount, amount);
        debugList = String.Join(", ", list2);
        Debug.WriteLine($"The last {amount} elements are {debugList}");

        // Add the first elements to the end of the list and 
        // then remove the first elements from the front of the list
        data.AddRange(list1);
        data.RemoveRange(0, length - amount);

        // The above commands could probably all be combined into a single 
        // command but it would be difficult to read and understand. Better
        // to separate the commands into understandable pieces

        debugList = String.Join(", ", data);
        Debug.WriteLine($"The new list elements are {debugList}");
    }
}
