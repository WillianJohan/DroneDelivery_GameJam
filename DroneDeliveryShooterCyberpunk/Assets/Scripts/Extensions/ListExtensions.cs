using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static T GetAndRemove<T>(this List<T> list, int index)
    {
        T element = list[index];
        list.RemoveAt(index);
        return element;
    }

    public static T GetRandom<T>(this List<T> list)
    {
        int random = Random.Range(0, list.Count);
        return list[random];
    }

    public static void AddToFront<T>(this List<T> list, T item)
    {
        list.Insert(0, item);
    }
}
