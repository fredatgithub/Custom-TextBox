using HelperLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectApplication
{
  [TestClass]
  public class UnitTestReplacePassword
  {
    [DataTestMethod]
    [DataRow("message1\nmessage2=33", "message2=", "message1\nmessage2=XXXX")]
    public void Test_method_RemovePasswordFromPattern(string message, string pattern, string expected)
    {
      var result = Helper.RemovePasswordFromPattern(message, pattern, "XXXX");
      Assert.AreEqual(expected, result);
    }
  }
}
