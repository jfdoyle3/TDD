using NUnit.Framework;
using LotteryService;


public class LotteryServiceTenNumSortedTest
{
    [Test]
    public void Return_TenNumSorted()
    {
        Class1 obj = new Class1();
        int[] numArr = new int[] { 5, 1,4,8,9,100,23,600,44,21};
        obj.SortNumbers(numArr);
        var results = obj.SortNumbers(numArr);
        int[] numArr2 = new int[] { 1,4,5,8,9, 21,23,44,100,600};
        Assert.AreEqual(numArr2[0], results[0]);
    }
}