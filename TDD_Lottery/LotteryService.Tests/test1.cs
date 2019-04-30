using NUnit.Framework;
using LotteryService;
public class LotteryServiceOneNumSortedTest
{
    [Test]
    public void Return_OneNumSorted()
    {
        Class1 obj = new Class1();
        int[] numArr = new int[] { 1 };
        obj.SortNumbers(numArr);
        var results = obj.SortNumbers(numArr);
        Assert.AreEqual(numArr[0], results[0]);
    }
}