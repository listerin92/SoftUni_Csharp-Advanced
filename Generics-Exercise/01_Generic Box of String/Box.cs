﻿
using System;
using System.Collections.Generic;

namespace _01_Generic_Box_of_String
{
    public class Box<T>
    {
        private T item;

        public Box(T item)
        {
            this.item = item;
        }

    public override string ToString()
        {
            return $"{item.GetType()}: {item}";

        }
    }
}
