using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HW_008_Serialization_1
{
    public class Registration : IList, IEqualityComparer
    {

        private Users[] users = new Users[0];
        private int count;

        public Registration()
        {
            Count = 0;
        }

        public object this[int index]
        {
            get
            {
                return users[index];
            }
            set
            {
                users[index] = (Users)value;
            }
        }

        public bool IsFixedSize
        {
            get
            { return false; }
        }

        public bool IsReadOnly
        {
            get
            { return false; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public bool IsSynchronized
        {
            get
            { return false; }
        }

        public object SyncRoot
        {
            get
            { return null; }
        }

        public int Add(object value)
        {
            if (Contains(value))
            {
                Console.WriteLine("\nThe User with the same Login '" + ((Users)value).Login + "' is already exists. Please Log In in the system using this Login & Password.");
            }
            else
            {
                Count++;
                var newArray = new Users[Count];
                users.CopyTo(newArray, 0);
                newArray[newArray.Length - 1] = (Users)value;
                users = newArray;
                return Count - 1;
            }

            return -1;
        }

        public void Clear()
        {
            users = new Users[100];
            Count = 0;
        }

        public bool Contains(object value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(users[i], value))
                    return true;
            }
            return false;
        }

        public bool HasRegisteredUser(object value)
        {
            for (int i = 0; i < Count; i++)
            {
                if ((users[i].Login.GetHashCode() + users[i].Password.GetHashCode()) == (((Users)value).Login.GetHashCode() + ((Users)value).Password.GetHashCode()))
                    return true;
            }
            return false;
        }

        public void CopyTo(Array array, int index)
        {
            users.CopyTo(array, index);
        }

        public new bool Equals(object x, object y)
        {
            return GetHashCode(x) == GetHashCode(y);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable<Users>)users).GetEnumerator();
        }

        public int GetHashCode(object obj)
        {
            return ((Users)obj).Login.GetHashCode();
        }

        public int IndexOf(object value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(users[i], value))
                    return i;
            }
            return -1;
        }

        public void Insert(int index, object value)
        {
            if ((Count + 1 <= users.Length) && (index >= 0) && ((index > Count) || (index == Count)))
            {
                Count++;
                users[index] = (Users)value;
            }
        }

        public void Remove(object value)
        {
            RemoveAt(IndexOf(value));
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count; i++)
                {
                    users[i] = users[i + 1];
                }
                count--;
            }
        }

        public Users ReturnLast(out int lastindex)
        {
            lastindex = Count - 1;
            return users[Count - 1];
        }

    }
}


