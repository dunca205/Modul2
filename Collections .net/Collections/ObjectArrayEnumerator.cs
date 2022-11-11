using System.Collections;

namespace Collections
{
    public class ObjectArrayEnumerator : IEnumerator
    {
        private readonly ObjectArray objectArray;
        int position = -1;

        public ObjectArrayEnumerator(ObjectArray objectArray)
        {
            this.objectArray = objectArray;
        }

        public object Current
        {
            get
            {
                if (position == -1)
                {
                    return null;
                }

                return objectArray[position];
            }
        }

        public bool MoveNext()
        {
            if (position + 1 >= objectArray.Count)
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
