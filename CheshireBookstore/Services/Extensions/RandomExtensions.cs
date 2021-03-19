using System;

namespace CheshireBookstore.Services.Extensions
{
    static public class RandomExtensions
    {
        // Случайным образом выбирает индекс из массива items и возвращает элемент
        public static T NextItem<T>(this Random random, params T[] items) => items[random.Next(items.Length)];
    }
}
