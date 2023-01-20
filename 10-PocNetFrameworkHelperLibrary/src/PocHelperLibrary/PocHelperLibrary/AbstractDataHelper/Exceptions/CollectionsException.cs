using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDataHelper.Exceptions
{
    [Serializable]
    public class CollectionsException : Exception
    { 
        public CollectionsException() {}

        public CollectionsException(string pMessage) : base(pMessage) {}

        protected CollectionsException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
        : base(serializationInfo, streamingContext)
        {
            
        }
    }
}
