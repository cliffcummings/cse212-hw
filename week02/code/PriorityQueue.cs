using System.Diagnostics;  // for Debug.Write operations

public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    public int Depth => _queue.Count;

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0) // Verify the queue is not empty
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority to remove
        var highPriorityIndex = 0;
        for (int index = 0; index <= _queue.Count - 1; index++)
        {
            Debug.WriteLine( "------------------------------------");
            Debug.WriteLine($"Examining Queue Item: {_queue[index].Value} / {_queue[index].Priority}");

            // Change comparison from >= to just > so the first item 
            // with equal priority will be removed
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                Debug.WriteLine("*** TRUE - NEW HIGH PRIORITY ***");
                highPriorityIndex = index;
                Debug.WriteLine($"Index     Priority: {_queue[index].Priority}");
                Debug.WriteLine($"highIndex Priority: {_queue[highPriorityIndex].Priority}");   
            }
            else 
            {
                Debug.WriteLine("*** FALSE **********************");
            }
            Debug.WriteLine($"Index:              {index}");
            Debug.WriteLine($"highPriorityIndex:  {highPriorityIndex}");
        }

        // Remove and return the item with the highest priority
        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);
        Debug.WriteLine( "---- Dequeue -----------------------");
        Debug.WriteLine($"     Dequeueing Item: {value}");
        return value;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs, so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

// internal class PriorityItem
public class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs, so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}