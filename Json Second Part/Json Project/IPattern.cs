using System;

namespace Json
{
     public interface IPattern
    {
       public IMatch Match(string text); // modifica functia match din ipattern sa retunreze imatch
    }
}
