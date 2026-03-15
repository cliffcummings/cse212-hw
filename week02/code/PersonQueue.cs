/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    // Shows the number of elements currently stored in the private queue (_queue)
    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        // _queue.Insert(0, person);  // TODO - BUG - was inserting at the beginning of the List 
        _queue.Add(person);           // TODO - add to the end of the List
    }

    public Person Dequeue()
    {
        var person = _queue[0];
            _queue.RemoveAt(0);
            return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}