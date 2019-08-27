using System.Linq;
using implementations;
using Xunit;

namespace tests
{
    public class SetHashMapTest
    {
        [Fact]
        public void Test()
        {
            var setHashMap = new SetHashMap();
            setHashMap.Add("hello");
            setHashMap.Add("tutu");
            setHashMap.Add("toto");
            setHashMap.Add("toto");
            setHashMap.Add("hello");
            setHashMap.Remove("hello");
            
            Assert.Equal(true, setHashMap.Contains("tutu"));
            Assert.Equal(true, setHashMap.Contains("toto"));
            Assert.Equal(false, setHashMap.Contains("hello"));
            Assert.Equal(2, setHashMap.Content().Count());
        }
    }
}