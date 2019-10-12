using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_4
{
    /// <summary>
    /// Статический класс, реализующий методы расширения
    /// </summary>
    static class Extensions
    {
        /// <summary>
        /// Шифрует строку статичным сдвигом символов по таблице символов.
        /// </summary>
        /// <param name="step">Шаг, на который сдвигается код каждого символа.</param>
        /// <returns></returns>
        public static string Encode(this string str, int step)
        {
            int count = str.Count();
            StringBuilder builder = new StringBuilder(count);
            for (int i = 0; i < count; i++)
                builder.Append((char)((int)str[i] + step));
            return builder.ToString();
        }

        /// <summary>
        /// роверяет упорядоченность множества s.   
        /// </summary>
        /// <param name="s">Проверяемое множество.</param>
        /// <returns>Упорядочено или нет.</returns>
        public static bool CheckSort(this Set s)
        {
            for (int i = 0; i < (int)s - 1; i++)
                if (s[i] <= s[i + 1])
                    continue;
                else return false;
            return true;
        }
    }
}
