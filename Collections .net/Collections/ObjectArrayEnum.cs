using System.Collections;

namespace Collections
{
    public class ObjectArrayEnum : IEnumerator
    {
        private readonly object[] objectArray;
        int position = -1;

        public ObjectArrayEnum(object[] objectArrayValues)
        {
            objectArray = objectArrayValues;
        }

        public object Current => objectArray[position];

        public bool MoveNext()
        {
            if (position > objectArray.Length)
            {
                return false;
            }

            position++;
            return true;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
