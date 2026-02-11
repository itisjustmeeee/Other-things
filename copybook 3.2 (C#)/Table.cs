using System;
using System.Collections.Generic;

public class Table
{
    public int ID { get; private set; }
    public string Location { get; set; }
    public int Seats { get; set; }
    public Dictionary<string, Booking> Schedule;

    public Table(int id, string location, int seats)
    {
        ID = id;
        Location = location;
        Seats = seats;
        Schedule = new Dictionary<string, Booking>();

        for (int h = 9; h < 18; h++)
        {
            string timeSlot = $"{h:00}:00 - {(h + 1):00}:00";
            Schedule[timeSlot] = null;
        }
    }

    public bool IsFree(string timeSlot)
    {
        return Schedule.ContainsKey(timeSlot) && Schedule[timeSlot] == null;
    }

    public bool Book(string timeSlot, Booking booking)
    {
        if (!Schedule.ContainsKey(timeSlot)) return false;
        if (Schedule[timeSlot] != null) return false;

        Schedule[timeSlot] = booking;
        return true;
    }

    public void CancelBook(string timeSlot)
    {
        if (Schedule.ContainsKey(timeSlot)) Schedule[timeSlot] = null;
    }

    public bool CanBeEdited()
    {
        foreach (var b in Schedule.Values)
        {
            if (b != null)
            {
                return false;
            }
        }
        return true;
    }

    public void PrintTable()
    {
        Console.WriteLine($"ID: -------------------------------------------------------{ID, 2}");
        Console.WriteLine($"Расположение: ---------------------------------------------{Location}\n");
        Console.WriteLine($"Количество мест: ------------------------------------------{Seats}");
        Console.WriteLine("Расписание: ");
        foreach (var slot in Schedule)
        {
            string line = $"{slot.Key} ------------------------------------------------";
            if (slot.Value == null)
            {
                Console.WriteLine(line);
            }
            else
            {
                Console.WriteLine($"{line} ID {slot.Value.ClientID}, {slot.Value.ClientName}, {slot.Value.Phone}");
            }
        }
        Console.WriteLine();
    }

    public List<string> GetTimeSlots()
    {
        List<string> slots = new List<string>();
        foreach (string slot in Schedule.Keys)
        {
            slots.Add(slot);
        }
        return slots;
    }
}