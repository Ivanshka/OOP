using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_4
{
    /// <summary>
    /// Класс владельца.
    /// </summary>
    class Owner
    {
        /// <summary>
        /// Идентификатор владельца.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя владельца.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Организация владельца.
        /// </summary>
        public string Organization { get; set; }
        public Owner(int id, string name, string company) { Id = id; Name = name; Organization = company; }
    }
}
