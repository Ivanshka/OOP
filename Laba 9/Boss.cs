using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_9
{
    /// <summary>
    /// Класс робота-босса
    /// </summary>
    class Boss
    {
        public delegate void TurnOnDelegate(int voltage);
        public delegate void UpgradeDelegate(int newVoltage);

        public bool IsAlive { get; set; }

        // события
        /// <summary>
        /// Событие срабатывает при ремонте и улучшении робота
        /// </summary>
        public event UpgradeDelegate Upgrade;
        /// <summary>
        /// Событие срабатывает при включении робота
        /// </summary>
        public event TurnOnDelegate TurnOn;

        /// <summary>
        /// Рабочее напряжение робота
        /// </summary>
        public int WorkingVoltage { get; private set; }

        /// <summary>
        /// Создает робота с определенным рабочим напряжением
        /// </summary>
        /// <param name="workingVoltage">Рабочее напряжение робота</param>
        public Boss(int workingVoltage)
        {
            WorkingVoltage = workingVoltage;
            IsAlive = true;
        }

        public void Start(int voltage)
        {
            TurnOn?.Invoke(voltage);
        }

        /// <summary>
        /// Восстановить робота
        /// </summary>
        public void Repair(int newVoltage) { IsAlive = true; WorkingVoltage = newVoltage; Upgrade?.Invoke(newVoltage); }
    }
}
