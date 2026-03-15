public class Person
{
    public readonly string Name;

    // From Google: C# compiler treats this as:
    // private int _turns; // Hidden backing field
    // public int Turns
    // {
    //     get { return _turns; }
    //     set { _turns = value; }
    // }
    public int Turns { get; set; }


    internal Person(string name, int turns)
    {
        Name = name;    // sets the Name  when the Person is created
        Turns = turns;  // sets the Turns when the Person is created
    }

    public override string ToString()
    {
        return Turns <= 0 ? $"({Name}:Forever)" : $"({Name}:{Turns})";
    }
}