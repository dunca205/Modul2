using System.Collections;

namespace Collections
{
    public class ObjectArrayEnum : IEnumerator
    {
        //  varianta1) private readonly ObjectArray objectArray; // daca ma folosesc de obictul ObjectArray - pot sa accesez count de care am nev in MoveNext
        private readonly object[] objectArray;
        int position = -1;

        public ObjectArrayEnum(object[] objectArray)
        {
            // varianta1) objectArray = new ObjectArray();
            this.objectArray = objectArray;
        }

        public object Current => objectArray[position];

        public bool MoveNext()
        {
            //  varianta1) if (position > objectArray.Count) \\ pt varianta in care constructorul este de tip ObjectArray
            if (position > objectArray.Length - position)
            // daca testez cu un sir de 4 elemente e ok, daca lungimea sirului e de 8 si doar 5 sub ocupate va da eroare din cauza celor 3 pozitii goale
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
