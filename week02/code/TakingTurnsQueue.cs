/// <summary>
/// This queue is circular. When people are added via AddPerson, they are added to the
/// back of the queue (FIFO). When GetNextPerson is called, the next person in the queue
/// is returned and then placed back into the queue if they still have turns left.
/// Turns <= 0 means infinite turns. If a person is out of turns, they are not re-enqueued.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add a person to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue. Re-enqueue them if they have remaining turns or infinite turns.
    /// Throws an exception if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            // Must match the expected test message
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        // Decrement finite turns
        if (person.Turns > 0)
        {
            person.Turns--;
        }

        // Re-enqueue if still has turns left OR infinite turns
        if (person.Turns != 0)
        {
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
