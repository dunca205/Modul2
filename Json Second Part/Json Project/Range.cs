﻿using System;

namespace Json
{
 public class Range
{
       private readonly char start;
       private readonly char end;

       public Range(char start, char end)
       {
        this.start = start;
        this.end = end;
       }

       public bool Match(string text)
       {
          if (string.IsNullOrEmpty(text))
          {
                return false;
          }

          foreach (char ch in text)
          {
             if (ch < start || ch > end)
             {
                    return false;
             }
          }

          return true;
       }

       static void Main(string[] args)
        {
        }
    }
}