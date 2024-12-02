using System.Linq;

namespace Helpers
{
    public static class StringExtension
    {
        public static string CapitalizeDataName(this string dataName) =>
            dataName?.Split("_").Select(_ => _.First().ToString().ToUpper() + _.Substring(1))
                .Aggregate((a, b) => a + '_' + b)
                .Split("-")
                .Select(_ => _.First().ToString().ToUpper() + _.Substring(1))
                .Aggregate((a, b) => a + b);
    }
}