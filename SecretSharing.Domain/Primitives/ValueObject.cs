﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SecretSharing.Domain.Primitives
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public override bool Equals(object obj)
        {
            return obj is ValueObject other && ValuesAreEqual(other);
        }
        public bool Equals(ValueObject other)
        {
            return other is not null && ValuesAreEqual(other);
        }

        public override int GetHashCode()
        {
            return GetAtomicValues().Aggregate(default(int), HashCode.Combine);
        }

        private bool ValuesAreEqual(ValueObject other)
        {
            return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
        }

        public abstract IEnumerable<object> GetAtomicValues();


    }
}