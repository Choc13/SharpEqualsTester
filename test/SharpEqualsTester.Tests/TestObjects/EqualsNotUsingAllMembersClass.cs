namespace SharpEqualsTester.Tests.TestObjects
{
    internal class EqualsNotUsingAllMembersClass
    {
        public EqualsNotUsingAllMembersClass(string included, int notIncluded)
        {
            m_string = included;
            m_int = notIncluded;
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
            
            return Equals(obj as EqualsNotUsingAllMembersClass);
        }
        
        public bool Equals(EqualsNotUsingAllMembersClass other) {
            if ((object) other == null)
            {
                return false;
            }
            
            return this.m_string == other.m_string;
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash ^= 31 * (m_string == null ? 0 : m_string.GetHashCode());
                hash ^= 37 * m_int.GetHashCode();
                return hash; 
            }
        }
        
        private readonly string m_string;
        private readonly int m_int;
    }
}