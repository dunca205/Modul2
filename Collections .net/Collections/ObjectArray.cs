using System.Collections;

namespace Collections
{
    public class ObjectArray : IEnumerable
    {
        private readonly object[] objectArray;

        public ObjectArray(object[] values)
        {
            this.objectArray = values;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public ObjectArrayEnum GetEnumerator()
        {
            return new ObjectArrayEnum(objectArray);
        }
    }
}
