using System;

namespace Laba_7
{
    // исключение для класса ExceptionDemonstration
    [Serializable]
    public class ObjectIsNotIntegerException : Exception
    {
        public ObjectIsNotIntegerException() { }
        public ObjectIsNotIntegerException(string message) : base(message) { }
        public ObjectIsNotIntegerException(string message, Exception inner) : base(message, inner) { }
        protected ObjectIsNotIntegerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    
    // исключение для класса Ispitanie
    [Serializable]
    public class InvalidTimeValueException : Exception
    {
        public override string Message { get; }
        public InvalidTimeValueException() { }
        public InvalidTimeValueException(string message, string time) { Message = message + "\n Некорректное значение времени: " + time; }
        public InvalidTimeValueException(string message) : base(message) { }
        public InvalidTimeValueException(string message, Exception inner) : base(message, inner) { }
        protected InvalidTimeValueException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class InvalidNameException : Exception
    {
        public override string Message { get; }
        public InvalidNameException() { }
        public InvalidNameException(string message, string name) { Message = message + "\n Некорректное строковое значение: " + name; }
        public InvalidNameException(string message) : base(message) { }
        public InvalidNameException(string message, Exception inner) : base(message, inner) { }
        protected InvalidNameException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}