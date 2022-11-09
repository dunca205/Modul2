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

        object IEnumerator.Current
        {
            get { return objectArray[position]; }
        }

        bool IEnumerator.MoveNext()
        {
            if (position >= objectArray.Count - 1)
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
