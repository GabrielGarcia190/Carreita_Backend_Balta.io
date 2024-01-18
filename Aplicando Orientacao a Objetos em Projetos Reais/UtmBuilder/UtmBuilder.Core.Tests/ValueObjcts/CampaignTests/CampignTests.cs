using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects.CampaignTest;

public class CampaignTest
{
    [TestMethod]
    [DataRow("", "", "", true)]
    [DataRow("src", "", "", true)]
    [DataRow("", "med", "", true)]
    [DataRow("src", "med", "name", true)]
    public void TestCampaign(string source, string medium, string name, bool expectException)
    {
        if (expectException)
        {
            try
            {
                new Campaign(source, medium, name);
                Assert.Fail();
            }
            catch (InvalidCampaignException e)
                when (e.Message == "Source is invalid")
            {
                Assert.IsTrue(true);
            }
            catch (InvalidCampaignException e)
                when (e.Message == "Medium is invalid")
            {
                Assert.IsTrue(true);
            }
            catch (InvalidCampaignException e)
                when (e.Message == "name is invalid")
            {
                Assert.IsTrue(true);
            }
        }
        else
        {
            new Campaign(source, medium, name);
            Assert.IsTrue(true);
        }
    }
}