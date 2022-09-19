namespace Json
{
    public class TextFacts
    {
          [Fact]
          public void TextIsPrefixedWithGivenString()
          {
              var textTrue = new Text("true");
            //  var bfalse = new Text("false");

             IMatch match =  textTrue.Match("true"); // true / ""
             Assert.True(match.Succes());
             Assert.Equal("", match.RemainingText());
          //    true.Match("trueX"); // true / "X"
           //   true.Match("false"); // false / "false"
           //   true.Match(""); // false / ""
          //    true.Match(null); // false / null

           //   false.Match("false"); // true / ""
          //    false.Match("falseX"); // true / "X"
          //    false.Match("true"); // false / "true"
         //     false.Match(""); // false / ""
           //   false.Match(null); // false / null

           //   var empty = new Text("");
          //    empty.Match("true"); // true / "true"
          //    empty.Match(null); // false / null
          }
    }
}