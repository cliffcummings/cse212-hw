using System.Collections;
using System.Collections.Generic;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value == Data)
        {
            // Do nothing - this is a duplicate
        }
        else if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
        {
            return true;  // found the requests value
        }
        else if (value < Data)
        {
            // Traverse to the left
            // Check if Left is null before recursing
            return Left != null && Left.Contains(value);
        }
        else
        {
            // Traverse to the right
            // Check if Right is null before recursing
            return Right != null && Right.Contains(value);
        }        
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int leftHeight = 0;
        int rightHeight = 0;

        // if (Left == null && Right == null) return 1; // already covered by the tests below
        // Check left branches
        if (Left != null) leftHeight = Left.GetHeight();

        // Check right branches
        if (Right != null) rightHeight = Right.GetHeight();

        if (leftHeight >= rightHeight) return leftHeight + 1;
        else return rightHeight +1;
    }



    // Yields all values in the tree
    // public IEnumerator<int> GetEnumerator()  // Requirement #1
    // {
    //     // call the typed version of the method
    //     return TraverseBackward().GetEnumerator();
    // }

    // IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();       // Requirement #2

    // private IEnumerable<int> TraverseBackward(Node? node)
    // {
    //     if (node is not null)
    //     {
    //         foreach (var val in TraverseBackward(node.Right))
    //             yield return val;

    //         yield return node.Data;

    //         foreach (var val in TraverseBackward(node.Left))
    //             yield return val;
    //     }
    //     else yield break;
    // }

}