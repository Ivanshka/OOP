using System.Text;

namespace Laba_9
{
    static class StringExtends
    {
        /// <summary>
        /// Метод удаляет знаки препинания из строки. Список знаков: . ! ? … , ; : - ( ) " '
        /// </summary>
        /// <param name="str">Строка для удаления знаков препинания.</param>
        /// <returns>Возвращает строку без знаков препинания.</returns>
        public static string RemovePunctuation(string str)
        {
            StringBuilder sb = new StringBuilder(str);
            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] == '.' || sb[i] == '!' || sb[i] == '?' || sb[i] == '…' || sb[i] == ',' || sb[i] == ';' || sb[i] == ':' || sb[i] == '-' || sb[i] == '(' || sb[i] == ')' || sb[i] == '\"' || sb[i] == '\'')
                {
                    sb = sb.Remove(i, 1);
                    i--;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Метод удаляет лишние пробелы из строки
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveSpaces(string str)
        {
            StringBuilder sb = new StringBuilder(str);
            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] == ' ' && sb[i+1] == ' ')
                {
                    sb = sb.Remove(i, 1);
                    i--;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Возвращает символ в верхнем регистре
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static char ToUpperCase(this char c)
        {
            int num = c;
            if (num > 1071 && num < 1136)
                num -= 32;
            if (num > 96 && num < 123)
                num -= 32;
            return (char)num;
        }

        /// <summary>
        /// Возвращает символ в нижнем регистре
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static char ToLowerCase(this char c)
        {
            int num = c;
            if (num > 1039 && num < 1072)
                num += 32;
            if (num > 64 && num < 91)
                num += 32;
            return (char)num;
        }

        /// <summary>
        /// Преобразование строки к верхнему регистру.
        /// </summary>
        /// <param name="str">Строка, которую нужно преобразовать</param>
        /// <returns>Строка в верхнем регистре</returns>
        public static string ToUpperCase(string str)
        {
            StringBuilder sb = new StringBuilder(str);
            for (int i = 0; i < sb.Length; i++)
                sb[i] = sb[i].ToUpperCase();
            return sb.ToString();
        }

        /// <summary>
        /// Преобразование строки к верхнему регистру.
        /// </summary>
        /// <param name="str">Строка, которую нужно преобразовать</param>
        /// <returns>Строка в верхнем регистре</returns>
        public static string ToLowerCase(string str)
        {
            StringBuilder sb = new StringBuilder(str);
            for (int i = 0; i < sb.Length; i++)
                sb[i] = sb[i].ToLowerCase();
            return sb.ToString();
        }

        /// <summary>
        /// Метод добавляет count символов c в конец строки
        /// </summary>
        /// <param name="str">Строка, в которую следует добавить символ</param>
        /// <param name="c">Символ, который будет добавляться</param>
        /// <param name="count">Количество символов для добавления</param>
        /// <returns>Строка с добавленным в конец символом</returns>
        public static string AddChars(string str, char c, int count)
        {
            StringBuilder sb = new StringBuilder(str);
            for (int i = 0; i < count; i++)
                sb.Append(c);
            return sb.ToString();
        }
    }
}
