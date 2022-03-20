using System;
using System.Collections.Generic;
using System.Linq;
using Test;

public static class Program
{
    public static void Main()
    {
        
        var timeOfTrip = 32.0;
        var trips = new List<Trip>();

        trips.Add(new Trip("Исаакиевский собор", 10, 5));
        trips.Add(new Trip("Эрмитаж", 11, 8));
        trips.Add(new Trip("Кунсткамера", 4, 3.5));
        trips.Add(new Trip("Петропавловская крепость", 7, 10));
        trips.Add(new Trip("Ленинградский зоопарк", 15, 9));
        trips.Add(new Trip("Медный всадник", 17, 1));
        trips.Add(new Trip("Казанский собор", 3, 4));
        trips.Add(new Trip("Спас на крови", 9, 2));
        trips.Add(new Trip("Зимний дворец Петра 1", 12, 7));
        trips.Add(new Trip("Зоологический музей", 6, 5.5));
        trips.Add(new Trip("Музей обороны и блокады ленинграда", 19, 2));
        trips.Add(new Trip("Русский музей", 8, 5));
        trips.Add(new Trip("Навестить друзей", 20, 12));
        trips.Add(new Trip("Музей восковых фигур", 13, 2));
        trips.Add(new Trip("Литературно-мемориальный музей Ф.М. Достоевского", 2, 4));
        trips.Add(new Trip("Екатерининский музей", 5, 1.5));
        trips.Add(new Trip("Петербургский музей кукол", 14, 1));
        trips.Add(new Trip("Музей микроминиатюры Русский левша ", 18, 3));
        trips.Add(new Trip("Всероссийский музей А.С. Пушкина и фелиалы", 1, 6));
        trips.Add(new Trip("Музей современного искусства", 16, 7));

        SortByKpi(trips);
        var newTrips = GetTripsFor32Hours(trips, timeOfTrip);
        ShowResult(newTrips);
    }

    private static void SortByKpi(List<Trip> trips)
    {
        for (var i = 0; i < trips.Count - 1; i++)
        {
            for (var j = 0; j < trips.Count; j++)
            {
                if (trips[i].Kpi < trips[j].Kpi)
                {
                    Swap(trips, i, j);
                }
            }
        }
    }

    private static IEnumerable<Trip> GetTripsFor32Hours(IList<Trip> trips, double timeOfTrip)
    {
        var resultList = new List<Trip>();
        double sumTime = 0;

        for (var i = 0; i < trips.Count; i++)
        {
            if (sumTime < timeOfTrip && sumTime + trips[i].Time <= timeOfTrip)
            {
                sumTime += trips[i].Time;
                resultList.Add(trips[i]);
                trips.Remove(trips[i]);
            }
            else
            {
                break;
            }
        }

        var deltaTime = timeOfTrip - sumTime;


        foreach (var item in trips.Where(item => item.Time <= deltaTime))
        {
            resultList.Add(item);
            deltaTime -= item.Time;
        }


        Console.WriteLine($"General time:{sumTime}");

        return resultList;
    }

    private static void ShowResult(IEnumerable<Trip> trips)
    {
        foreach (var item in trips)
        {
            Console.WriteLine($"{item.Name}, priority - {item.Priority}, time-{item.Time}");
        }
    }

    private static void Swap<T>(IList<T> list, int indexA, int indexB)
    {
        var tmp = list[indexA];
        list[indexA] = list[indexB];
        list[indexB] = tmp;
    }
}