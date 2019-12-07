using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_6
{
    /// <summary>
    /// Статический класс контроллера с методами расширения
    /// </summary>
    static class Controller
    {
        /// <summary>
        /// Подсчитывает количество испытаний в сессии
        /// </summary>
        /// <param name="session">Объект сессии</param>
        /// <returns>Количество испытаний в сессии</returns>
        public static byte GetCountIspitanie(this Session session)
        {
            // считаем только экзы
            byte Count = 0;
            for (int i = 0; i < session.Count; i++)
                if (session[i] is Examination)
                    Count++;
            return Count;
        }

        /// <summary>
        /// Возвращает количество тестов с заданным числом вопросов.
        /// </summary>
        /// <param name="session">Сессия, в которой подсчитываются тесты.</param>
        /// <param name="count">Количество тестов</param>
        /// <returns>Количество тестов с заданным числом вопросов.</returns>
        public static byte GetCountOfTestsByQuestions(this Session session, byte count)
        {
            byte Count = 0;
            for (int i = 0; i < session.Count; i++)
                if ((session[i] is Test) && ((session[i] as Test).CountOfQuestions == count))
                    Count++;
            return Count;
        }

        /// <summary>
        /// Поиск экзамена по имени
        /// </summary>
        public static string SearchExaminationsByName(this Session session, string name)
        {
            byte str = 1;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < session.Count; i++)
                if ((session[i] is Examination) && ((session[i] as Examination).Name == name))
                {
                    result.Append(str + ") " + (session[i] as Examination).ToString());
                    str++;
                }
            return result.ToString();
        }
    }
}
