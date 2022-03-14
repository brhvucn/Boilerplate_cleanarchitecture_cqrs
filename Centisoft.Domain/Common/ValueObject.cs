using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Domain.Common
{
    /// <summary>
    /// ValueObjects cannot have an identity and are immutable. They are reliant on an entity. A ValueObject compared with another ValueObject with the same values are said to be equal
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;
            if (ReferenceEquals(valueObject, null))
            {
                return false;
            }
            if (GetType() != obj.GetType())
            {
                return false;
            }
            return EqualsCore(valueObject);
        }

        protected abstract bool EqualsCore(T other);

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract int GetHashCodeCore();

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }
            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}
