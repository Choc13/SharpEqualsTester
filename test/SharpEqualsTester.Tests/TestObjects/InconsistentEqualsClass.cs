namespace SharpEqualsTester.Tests.TestObjects
{
    public class InconsistentEqualsClass 
    {
        public InconsistentEqualsClass(string s, int i)
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
            
            return Equals(obj as InconsistentEqualsClass);
        }
        
        public bool Equals(InconsistentEqualsClass other) {
            if ((object) other == null)
            {
                return false;
            }
            
            return false;
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
