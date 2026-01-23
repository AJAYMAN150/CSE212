using Microsoft.VisualStudio.TestTools.UnitTesting;

// Problem 2 - PriorityQueue test cases

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Dequeue returns the item with the highest priority
    // Expected Result: "High" is dequeued before "Low"
    // Defect(s) Found: None yet; will fail if dequeue does not respect priority
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 10);

        string result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: FIFO order when multiple items have same priority
    // Expected Result: "First" is dequeued before "Second"
    // Defect(s) Found: None yet; will fail if queue does not maintain FIFO for same priority
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);

        string firstOut = priorityQueue.Dequeue();
        string secondOut = priorityQueue.Dequeue();

        Assert.AreEqual("First", firstOut);
        Assert.AreEqual("Second", secondOut);
    }

    [TestMethod]
    // Scenario: Dequeue on empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None yet; will fail if empty queue does not throw proper exception
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    // You can add more tests if you want to cover edge cases
}
