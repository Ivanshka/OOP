namespace Laba_4
{
    /// <summary>
    /// Статический класс, реализующий математические операции с множествами
    /// </summary>
    static class MathOperations
    {
        /// <summary>
        /// Возвращает максимальный элемент множества s.
        /// </summary>
        /// <param name="s">Множество Set, из которого получаем максимальное.</param>
        /// <returns>Максимальный эдемент множества s.</returns>
        public static int GetMaxElement(Set s)
        {
            int max = s.Elements[0];
            for (int i = 0; i < s.Elements.Count; i++)
                if (max < s.Elements[i])
                    max = s.Elements[i];
            return max;
        }

        /// <summary>
        /// Возвращает минимальный элемент множества s.
        /// </summary>
        /// <param name="s">Множество Set, из которого получаем минимальное.</param>
        /// <returns>Минимальный эдемент множества s.</returns>
        public static int GetMinElement(Set s)
        {
            int min = s.Elements[0];
            for (int i = 0; i < s.Elements.Count; i++)
                if (min > s.Elements[i])
                    min = s.Elements[i];
            return min;
        }

        /// <summary>
        /// Возвращает количество элементов множества s.
        /// </summary>
        /// <param name="s">Множество, количество элементов которого нужно узнать.</param>
        /// <returns>Количество элементов множества s.</returns>
        public static int GetCount(Set s) { return s.Elements.Count; }
    }
}
