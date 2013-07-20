﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Runtime.InteropServices
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Size=4)]
    public struct NativeBool : IEquatable<NativeBool>
    {
        int _value;
        public NativeBool(bool value)
        {
            _value = value ? 1 : 0;
        }

        public bool Equals(NativeBool other)
        {
            return this._value == other._value;
        }

        public override bool Equals(object obj)
        {
            if (obj is NativeBool || obj is Boolean)
                return Equals((NativeBool)obj);

            return false;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(NativeBool left, NativeBool right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(NativeBool left, NativeBool right)
        {
            return !(left == right);
        }

        public static implicit operator bool(NativeBool value)
        {
            return value._value != 0;
        }

        public static implicit operator NativeBool(bool value)
        {
            return new NativeBool(value);
        }
    }
}
