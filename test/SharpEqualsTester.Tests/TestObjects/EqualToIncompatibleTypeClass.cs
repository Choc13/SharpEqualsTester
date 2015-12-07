namespace SharpEqualsTester.Tests.TestObjects
{
    public class EqualToIncompatibleTypeClass
    {
        public EqualToIncompatibleTypeClass(string s)
        {
            m_string = s;    
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
            
            return true;
        }
        
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
    }
}