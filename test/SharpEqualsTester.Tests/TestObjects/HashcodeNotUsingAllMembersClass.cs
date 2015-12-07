namespace SharpEqualsTester.Tests.TestObjects
{
    public class HashcodeNotUsingAllMembersClass
    {
        public HashcodeNotUsingAllMembersClass(string s, int i)
        {
            m_string = s;
            m_int = i;    
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
            
            return Equals(obj as HashcodeNotUsingAllMembersClass);
        }
        
        public bool Equals(HashcodeNotUsingAllMembersClass other) {
            if ((object) other == null)
            {
                return false;
            }
            
            return this.m_string == other.m_string
                && this.m_int == other.m_int;
        }
        
        // Deliberately miss out one of the properties from hashcode
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash ^= 31 * (m_string == null ? 0 : m_string.GetHashCode());
                return hash; 
            }
        }
        
        private readonly string m_string;
        private readonly int m_int; 
    }
}