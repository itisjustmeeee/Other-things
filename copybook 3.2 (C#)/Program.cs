// контрольная работа 3
// тетрадь 3.1
// 1
/*
Console.WriteLine("enter number you want to reverse:");
int n = Convert.ToInt32(Console.ReadLine());

static int Reverse_number(int n, int save = 0)
{
    if (n % 10 != 0)
    {
        return Reverse_number(n / 10, save * 10 + n % 10);
    }
    else
    {
        return save;
    }
}

int new_numb = Reverse_number(n);
Console.Write(new_numb);
*/
// 2
/*
Console.WriteLine("enter positive m");
int m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("enter positive n");
int n = Convert.ToInt32(Console.ReadLine());

static int Akkerman(int m, int n)
{
    if (m == 0)
    {
        return n + 1;
    }
    else if (m > 0 && n == 0)
    {
        return Akkerman(m - 1, 1);
    }
    else
    {
        return Akkerman(m - 1, Akkerman(m, n - 1));
    }
}

int result = Akkerman(m, n);
Console.Write($"Akkerman({m},{n}) = {result}");
*/

using System;
using System.Collections.Generic;

class Program
{
    static List<Table> tables = new List<Table>();
    static List<Booking> bookings = new List<Booking>();

    static void Main()
    {
        tables.Add(new Table(1, "у окна", 4));
        tables.Add(new Table(2, "у прохода", 6));
        tables.Add(new Table(3, "в глубине", 2));
        tables.Add(new Table(4, "у прохода", 8));
        tables.Add(new Table(5, "в глубине", 1));
        tables.Add(new Table(6, "у прохода", 2));
        tables.Add(new Table(7, "у окна", 5));
        tables.Add(new Table(8, "в глубине", 3));
        tables.Add(new Table(9, "у окна", 5));
        tables.Add(new Table(10, "у окна", 1));

        while (true)
        {
            Console.WriteLine("Система бронирования столиков");
            Console.WriteLine("1. Создать бронь");
            Console.WriteLine("2. Отменить бронь");
            Console.WriteLine("3. Показать стол по ID");
            Console.WriteLine("4. Показать все доступные столики (с фильтром)");
            Console.WriteLine("5. Показать все брони");
            Console.WriteLine("6. Найти бронь по номеру телефона (посл. 4 цифры) и имени");
            Console.WriteLine("7. Редактировать стол");
            Console.WriteLine("0. Выход");

            string? choice = Console.ReadLine();

            switch(choice)
            {
                case "1": CreateBooking(); break;
                case "2": CancelBooking(); break;
                case "3": ShowTableById(); break;
                case "4": ShowAvailableTables(); break;
                case "5": ShowAllBookings(); break;
                case "6": SearchBooking(); break;
                case "7": EditTable(); break;
                case "0": return;
            }
        }

        static void CreateBooking()
        {
            Console.Write("Имя клиента - ");
            string? name = Console.ReadLine();
            Console.Write("Телефон - ");
            string? phone = Console.ReadLine();
            Console.Write("Время (формат XX:00 - XX:00) - ");
            string? time = Console.ReadLine();
            Console.Write("Комментарий (или Enter) - ");
            string? comment = Console.ReadLine();

            Console.WriteLine("Доступные столики в это время - ");
            List<Table> available = new List<Table>();
            foreach (Table t in tables)
            {
                if (t.IsFree(time))
                {
                    Console.WriteLine($"Стол {t.ID}: {t.Location}, {t.Seats} мест");
                    available.Add(t);
                }
            }

            if (available.Count == 0)
            {
                Console.WriteLine("Нет свободных столиков в это время");
                return;
            }

            Console.Write("Выберите ID стоилка - ");
            int tableId = int.Parse(Console.ReadLine());
            Table selected = tables.Find(t => t.ID == tableId);
            
            if (selected != null && selected.IsFree(time))
            {
                try
                {
                    Booking b = new Booking(name, phone, time, selected, comment);
                    bookings.Add(b);
                    Console.WriteLine("Бронь успешно создана");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка - " + ex.Message);
                }
            }
            
            else
            {
                Console.WriteLine("Стол недоступен");
            }
        }

        static void ShowTableById()
        {
            Console.Write("ID стола: ");
            int id = int.Parse(Console.ReadLine());
            Table t = tables.Find(x => x.ID == id);
            if (t != null) t.PrintTable();
            else Console.WriteLine("Стол не найден.");
        }

        static void ShowAvailableTables()
        {
            Console.Write("Время для поиска (например 14:00-15:00 или Enter — все свободные): ");
            string time = Console.ReadLine();
            Console.WriteLine("Доступные столики:");
            foreach (Table t in tables)
            {
                bool free = string.IsNullOrEmpty(time) || t.IsFree(time);
                if (free)
                {
                    Console.WriteLine($"Стол {t.ID}: {t.Location}, {t.Seats} мест");
                }
            }
        }

        static void ShowAllBookings()
        {
            if (bookings.Count == 0) Console.WriteLine("Нет броней.");
            foreach (Booking b in bookings)
            {
                if (b.AssignedTable != null)
                {
                    Console.WriteLine(b);
                }
            }
        }

        static void CancelBooking()
        {
            Console.Write("ID клиента для отмены: ");
            int id = int.Parse(Console.ReadLine());
            Booking b = bookings.Find(x => x.ClientID == id);
            if (b != null && b.AssignedTable != null)
            {
                b.Cancel();
                Console.WriteLine("Бронь отменена.");
            }
            else
            {
                Console.WriteLine("Бронь не найдена или уже отменена.");
            }
        }

        static void SearchBooking()
        {
            Console.Write("Имя клиента: ");
            string? name = Console.ReadLine();
            Console.Write("Последние 4 цифры телефона: ");
            string? digits = Console.ReadLine();

            foreach (Booking b in bookings)
            {
                if (b.AssignedTable != null && b.ClientName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0 && b.Phone.EndsWith(digits)) {
                    Console.WriteLine(b);
                }
            }
        }

        static void EditTable()
        {
            Console.Write("ID стола для редактирования: ");
            int id = int.Parse(Console.ReadLine());
            Table t = tables.Find(x => x.ID == id);
            if (t == null)
            {
                Console.WriteLine("Стол не найден.");
                return;
            }
            if (!t.CanBeEdited())
            {
                Console.WriteLine("Нельзя редактировать: есть активные брони.");
                return;
            }

            Console.Write($"Новое расположение (было: {t.Location}): ");
            t.Location = Console.ReadLine();
            Console.Write($"Новое кол-во мест (было: {t.Seats}): ");
            t.Seats = int.Parse(Console.ReadLine());
            Console.WriteLine("Стол обновлён.");
        }
    }
}
