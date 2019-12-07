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
        /// <param name="MustBeInteger"></param>
        public ExceptionDemonstration(object MustBeInteger)
        {
            if (MustBeInteger is int)
                Number = (int)MustBeInteger;
            else throw new ObjectIsNotIntegerException("Объект не является числом!");
        }
    }
}
