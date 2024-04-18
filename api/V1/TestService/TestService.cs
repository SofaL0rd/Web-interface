using ClosedXML.Excel;

namespace api.V1.TestService
{
    public class TestService : ITestService
    {
        

        public int GetValue()
        {
            // Business logic for version 1.0 
            return new Random().Next();
        }

        
    }
}
