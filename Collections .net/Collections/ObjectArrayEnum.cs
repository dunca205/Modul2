using System.Collections;

namespace Collections
{
    public class ObjectArrayEnum : IEnumerator
    {
        private readonly object[] objectArray;
        int position = -1;

        public ObjectArrayEnum(object[] values)
        {
            objectArray = values;
        }

        public object Current => objectArray[position];

        public bool MoveNext()
        {
            if (position > objectArray.Length - position) // doar daca este doar un sir de 4 elemente si toate pozitiile sunt ocupate e ok
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
