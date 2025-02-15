﻿using System.Runtime.Serialization;

namespace Laba_14
{
    [DataContract]
    public class ClassWithArray
    {
        [DataMember]
        public int[] Array;
        [DataMember]
        public int Count;

        public ClassWithArray()
        {
            Array = new int[10];
            for (int i = 1; i < 11; i++)
                Array[i-1] = i;
            Count = Array.Length;
        }
    }
}
