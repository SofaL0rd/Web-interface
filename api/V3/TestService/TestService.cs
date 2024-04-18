using ClosedXML.Excel;

namespace api.V3.TestService
{
    public class TestService : ITestService
    {
        public TestService() { }


        public byte[] GetExcelFile()
        {
            // Business logic for version 3.0 using ClosedXML to generate Excel file
            XLWorkbook workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Sheet1");
            worksheet.Cell(1, 1).Value = "Hello";
            worksheet.Cell(1, 2).Value = "World";

            // Create a memory stream to hold the Excel file
            using (MemoryStream stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return stream.ToArray();
            }
        }
    }
}
