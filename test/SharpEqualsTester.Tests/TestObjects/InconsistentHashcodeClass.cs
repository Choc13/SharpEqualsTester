using System;

namespace SharpEqualsTester.Tests.TestObjects
{
    public class InconsistentHashcodeClass
    {
        public InconsistentHashcodeClass(string s, int i)
        {
            m_string = s;
            m_int = i;
            m_hashcode = s_random.Next();
        }
        
        public override bool Equals (object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            
            return Equals(obj as InconsistentHashcodeClass);
        }
        
        public bool Equals(InconsistentHashcodeClass other) {
            if ((object) other == null)
            {
                return false;
            }
            
            return this.m_string == other.m_string
                && this.m_int == other.m_int;
        }
        
        // Returns a different value every time it's called
        public override int GetHashCode()
        {
            return m_hashcode;
        }
        
        private readonly string m_string;
        private readonly int m_int;
        private readonly int m_hashcode;
        
        private readonly static Random s_random = new Random();
    }
}