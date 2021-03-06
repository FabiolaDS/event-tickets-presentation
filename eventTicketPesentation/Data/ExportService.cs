using System;
using System.IO;
using eventTicketPesentation.Models;
using eventTicketPesentation.Service.dto;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using PdfDocument = Syncfusion.Pdf.PdfDocument;
using PdfPage = Syncfusion.Pdf.PdfPage;

namespace eventTicketPesentation.Service
{
    public class ExportService
    {
        public MemoryStream CreatePdf(TicketGroupDTO tgroup)
        {
            if (tgroup == null)
            {
                throw new ArgumentNullException("Data cannot be null");
            }

            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 0;
                int cellMargin = 0;

                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

                PdfTextElement title = new PdfTextElement("Electronic Ticket - Event Enthusiast", font, PdfBrushes.Black);

                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.Helvetica, 16);

                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;

                foreach (var ticket in tgroup.Tickets)
                {
                    PdfPage page = pdfDocument.Pages.Add();
                    PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

                    PdfTextElement TicketName =
                        new PdfTextElement("Event: " + tgroup.NameOfEvent, contentFont, PdfBrushes.Black);
                    PdfTextElement TicketEventDate =
                        new PdfTextElement("Date/Time of the event: " + tgroup.TimeOfTheEvent, contentFont, PdfBrushes.Black);
                    PdfTextElement TicketEventLocation =
                        new PdfTextElement("Location:  " + tgroup.Location, contentFont, PdfBrushes.Black);
                    PdfTextElement TicketEventAddress =
                        new PdfTextElement("Address:  " + tgroup.Address, contentFont, PdfBrushes.Black);
                    PdfTextElement TicketNumber =
                        new PdfTextElement("Nr: " + ticket.TicketNr, contentFont, PdfBrushes.Black);
                    PdfTextElement TimeOfPurchase =
                        new PdfTextElement("Time of purchase: " + ticket.TimeOfPurchase, contentFont,
                            PdfBrushes.Black);
                    PdfTextElement PaidAmount =
                        new PdfTextElement("Price: " + tgroup.TicketPrice + " dkk", contentFont,
                            PdfBrushes.Black);
                    

                    result = TicketName.Draw(page,
                        new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width,
                            page.GetClientSize().Height), format);
                    result = TicketNumber.Draw(page,
                        new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width,
                            page.GetClientSize().Height), format);
                    result = TimeOfPurchase.Draw(page,
                        new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width,
                            page.GetClientSize().Height), format);
                    result = TicketEventDate.Draw(page,
                        new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width,
                            page.GetClientSize().Height), format);
                    result = TicketEventLocation.Draw(page,
                        new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width,
                            page.GetClientSize().Height), format);
                    result = TicketEventAddress.Draw(page,
                        new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width,
                            page.GetClientSize().Height), format);
                    PaidAmount.Draw(page,
                        new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width,
                            page.GetClientSize().Height), format);
                }
                
                using (MemoryStream stream = new MemoryStream())
                {
                    pdfDocument.Save(stream);
                    pdfDocument.Close(true);
                    return stream;
                }
            }
        }
    }
}