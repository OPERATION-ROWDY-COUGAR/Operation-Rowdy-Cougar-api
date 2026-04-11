using Microsoft.VisualStudio.TestTools.UnitTesting;
using Operation.Rowdy.Cougar.Domain.Catalog;

namespace Operation_Rowdy_Cougar.Domain.Tests;

[TestClass]
public sealed class ItemTests
{
    [TestMethod]
    public void Can_Create_New_Item()
    {
        var item = new Item("Name", "Description", "Brand", 10.00m);

        Assert.AreEqual("Name", item.Name);
        Assert.AreEqual("Description", item.Description);
        Assert.AreEqual("Brand", item.Brand);
        Assert.AreEqual(10.00m, item.Price);
    }
}