using System;

public class Booking
{
    public int ClientID { get; private set; }
    public string ClientName { get; set; }
    public string Phone { get; set; }
    public string StartTime { get; private set; }
    public string Comment { get; set; }
    public Table AssignedTable { get; private set; }

    private static int nextId = 1;
    public Booking(string name, string phone, string timeSlot, Table table, string comment = "")
    {
        ClientID = nextId++;
        ClientName = name;
        Phone = phone;
        StartTime = timeSlot;
        Comment = comment;
        AssignedTable = table;

        bool success = table.Book(timeSlot, this);
        if (!success)
        {
            throw new Exception($"Стол {table.ID} уже занят в {timeSlot}");
        }
    }

    public void Update(string newName, string newPhone, string newComment)
    {
        ClientName = newName;
        Phone = newPhone;
        Comment = newComment;
    }

    public void Cancel()
    {
        if (AssignedTable != null)
        {
            AssignedTable.CancelBook(StartTime);
            AssignedTable = null;
        }
    }

    public override string ToString()
    {
        return $"Бронь ID{ClientID}: {ClientName}, {Phone}, {StartTime}, стол {AssignedTable?.ID}, \"{Comment}\"";
    }
}