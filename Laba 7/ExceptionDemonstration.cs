using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_7
{
    /// <summary>
    /// Класс, созданный для демонстрации вызова исключения.
    /// </summary>
    class ExceptionDemonstration
    {
        int Number { get; set; }
        /// <summary>
        /// Конструктор, созданный для демонстрации вызова исключения.
        /// </summary>
        /// <param name="HaveBeInteger"></param>
        public ExceptionDemonstration(object HaveBeInteger)
        {
            if (HaveBeInteger is int)
                Number = (int)HaveBeInteger;
            else throw new ObjectIsNotIntegerException("Объект не является числом!");
        }
    }
}
