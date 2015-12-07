namespace SharpEqualsTester.Tests.TestObjects
{
    public class EqualToNullClass
    {
        public EqualToNullClass(string str)
        {
            m_string = str;
        }
        
        public override bool Equals (object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return true;
            }
            
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            
            return Equals(obj as EqualToNullClass);
        }
        
        public bool Equals(EqualToNullClass other) {
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
                return hash; 
            }
        }
        
        private readonly string m_string;
    }
}