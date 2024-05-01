
namespace NUnit
{
    internal class Framework
    {
        internal class TestSuite
        {
            internal TestResult Run(TestResult testResult)
            {
                throw new NotImplementedException();
            }
        }

        internal class TestResult
        {
            public TestResult()
            {
            }

            public int PassCount { get; internal set; }
            public int FailCount { get; internal set; }
        }
    }
}