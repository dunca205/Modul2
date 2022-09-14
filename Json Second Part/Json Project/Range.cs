using System;

namespace Json
{
 public class Range : IPattern
{
       private readonly char start;
       private readonly char end;

       public Range(char start, char end)
       {
        this.start = start;
        this.end = end;
       }

       public IMatch Match(string text)
       {
            bool isInRange = text[0] >= start && text[0] <= end;
            return string.IsNullOrEmpty(text) || !isInRange ? new FailedMatch(text) : new SuccesMatch(text[1..]);
       }

       static void Main(string[] args)
        {
        }
    }
}