using Xunit;

using implementations;

namespace tests
{
    public class StackTest
    {
        [Fact]
        public void Test()
        {
            var stack = new Stack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
        }
    }
}