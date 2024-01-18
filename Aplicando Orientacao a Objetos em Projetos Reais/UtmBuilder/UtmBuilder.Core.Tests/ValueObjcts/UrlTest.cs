using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests;

[TestClass]
public class UrlTests
{
    [TestMethod]
    [ExpectedException(typeof(InvalidUrlException))]
    public void Dado_uma_URL_invalida_deve_retornar_execao()
    {
        new Url("");
        #region Exemplo de como testar de outra maneira
        // try
        // {
        //     var url = new Url("");
        //     Assert.Fail();
        // }
        // catch (InvalidUrlException)
        // {
        //     Assert.IsTrue(true);
        // }
        #endregion
    }


    [TestMethod]
    [DataRow(" ", true)]
    [DataRow("http", true)]
    [DataRow("banana", true)]
    [DataRow("https://balta.io", false)]
    public void TestUrl(
     string link,
     bool expectException)
    {
        if (expectException)
        {
            try
            {
                new Url(link);
                Assert.Fail();
            }
            catch (InvalidUrlException)
            {
                Assert.IsTrue(true);
            }
        }
        else
        {
            new Url(link);
            Assert.IsTrue(true);
        }
    }
}