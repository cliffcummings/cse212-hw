using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;  // for Debug.Write operations

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue the following string/priority pairs:
    // A/3  B/2  C/5  D/4
    // Expected Result: C/5  D/4  A/3  B/2
    // Defect(s) Found: None
    public void TestPriorityQueue_1()
    {
        var A = new PriorityItem("A", 3);
        var B = new PriorityItem("B", 2);
        var C = new PriorityItem("C", 5);
        var D = new PriorityItem("D", 4);

        PriorityItem[] expectedResult = [C, D, A, B];

        var pQueue = new PriorityQueue();
        pQueue.Enqueue("A", 3);
        pQueue.Enqueue("B", 2);
        pQueue.Enqueue("C", 5);
        pQueue.Enqueue("D", 4);

        PrioritizeQueue(pQueue, expectedResult);

        // Move to PrioritizeQueue) method at bottom of code for use by both tests
        // int i = 0;
        // var deep = pQueue.Depth;
        // Debug.WriteLine($"Queue Depth is {deep}");
        // while (pQueue.Depth > 0)
        // {
        //     if (i >= expectedResult.Length)
        //     {
        //         Assert.Fail("Queue should have run out of items by now.");
        //     }

        //     var item = pQueue.Dequeue();
        //     Debug.WriteLine($"Test Dequeueing Item: {item}");

        //     Assert.AreEqual(expectedResult[i].Value, item);
        //     i++;
        // }

        // Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: Enqueue the following string/priority pairs with duplicate priority:
    // F/3  G/6  H/5  I/6  J/4
    // Expected Result: G/6  I/6  H/5  J/4  F/3
    // Defect(s) Found: None
    public void TestPriorityQueue_2()
    {        
        var F = new PriorityItem("F", 3);
        var G = new PriorityItem("G", 6);
        var H = new PriorityItem("H", 5);
        var I = new PriorityItem("I", 6);
        var J = new PriorityItem("J", 4);

        PriorityItem[] expectedResult = [G, I, H, J, F];

        var pQueue = new PriorityQueue();
        pQueue.Enqueue("F", 3);
        pQueue.Enqueue("G", 6);
        pQueue.Enqueue("H", 5);
        pQueue.Enqueue("I", 6);
        pQueue.Enqueue("J", 4);

        PrioritizeQueue(pQueue, expectedResult);

        // var priorityQueue = new PriorityQueue();

        // Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below -------------------------------------
[TestMethod]
    // Scenario: Try dequeueing from an empty queue - should throw exception:
    // Empty
    // Expected Result: 
    // Defect(s) Found: Empty queue exception
    public void TestPriorityQueue_3()
    {
        // var Z = new PriorityItem("Z", 3);
        // var B = new PriorityItem("B", 2);
        // var C = new PriorityItem("C", 5);
        // var D = new PriorityItem("D", 4);

        PriorityItem[] expectedResult = [];

        var pQueue = new PriorityQueue();
        // pQueue.Enqueue("Z", 3);
        // pQueue.Enqueue("B", 2);
        // pQueue.Enqueue("C", 5);
        // pQueue.Enqueue("D", 4);

        PrioritizeQueue(pQueue, expectedResult);
        try
        {
            pQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }

    }
    public void PrioritizeQueue(PriorityQueue test, PriorityItem[] expect)
    {
        int i = 0;
        var deep = test.Depth;
        Debug.WriteLine($"Queue Depth is {deep}");
        while (test.Depth > 0)
        {
            if (i >= deep)
            {
                Assert.Fail("Queue should have run out of items by now.");
            }

            var item = test.Dequeue();
            Debug.WriteLine($"Test Dequeueing Item: {item}");

            Assert.AreEqual(expect[i].Value, item);
            i++;
        }
    }
}