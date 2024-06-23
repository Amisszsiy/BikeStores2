using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf;

namespace BikeStores2.Application.Services
{
    public class PDFService
    {
        private HostEnvironmentService _hostEnvironmentService;
        private IWebHostEnvironment webHostEnvironment;

        public PDFService(HostEnvironmentService hostEnvironmentService, IWebHostEnvironment webHostEnvironment)
        {
            _hostEnvironmentService = hostEnvironmentService;
            this.webHostEnvironment = webHostEnvironment;

        }
        public void AddCustomerNameToPdf(string sourcePdfPath, string outputPdfPath, string customerName, int[] pagesToModify)
        {
            //string hostPath = _hostEnvironmentService.GetBaseUrl();
            string hostPath = webHostEnvironment.WebRootPath;
            string templatePath = hostPath+sourcePdfPath;
            string outputPath = hostPath + outputPdfPath;

            // Load the PDF template into a memory stream
            byte[] pdfBytes = File.ReadAllBytes(templatePath);
            MemoryStream pdfStream = new MemoryStream(pdfBytes);

            // Create a new memory stream to save the modified PDF
            using (MemoryStream outputStream = new MemoryStream())
            {
                // Open the PDF document
                PdfDocument pdfDoc = new PdfDocument(new PdfReader(pdfStream), new PdfWriter(outputStream));

                // Set font and size
                PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                float fontSize = 12;

                foreach (int pageNumber in pagesToModify)
                {
                    PdfPage page = pdfDoc.GetPage(pageNumber);

                    // Create a canvas to write content
                    PdfCanvas canvas = new PdfCanvas(page);

                    // Set text properties and position
                    canvas.SetFontAndSize(font, fontSize);
                    canvas.BeginText();
                    canvas.MoveText(100, 700); // Adjust (x, y) position as needed
                    canvas.ShowText(customerName);
                    canvas.EndText();
                }

                // Close the document to apply changes
                pdfDoc.Close();

                // Save the modified PDF to the specified output path
                File.WriteAllBytes(outputPath, outputStream.ToArray());
            }

            Console.WriteLine("PDF modified and saved successfully to " + outputPath);
        }
    }
}
