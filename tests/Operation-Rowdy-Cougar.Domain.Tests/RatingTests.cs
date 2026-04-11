using Microsoft.VisualStudio.TestTools.UnitTesting;
using Operation.Rowdy.Cougar.Domain.Catalog;

namespace Operation_Rowdy_Cougar.Domain.Tests;

[TestClass]
public sealed class RatingTests
{
    [TestMethod]
    public void Can_Create_New_Rating()
    {
        var rating = new Rating(1, "Mike", "Great fit!");

        Assert.AreEqual(1, rating.Stars);
        Assert.AreEqual("Mike", rating.UserName);
        Assert.AreEqual("Great fit!", rating.Review);
    }

    [TestMethod]
    public void Cannot_Create_Rating_With_Invalid_Stars()
    {
        try
        {
            var rating = new Rating(0, "Mike", "Great fit!");
            Assert.Fail("Expected ArgumentException was not thrown.");
        }
        catch (ArgumentException)
        {
            Assert.IsTrue(true);
        }
    }
}