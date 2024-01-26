using BusinessLogicLayer.Services;
using DataAccessLayer.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Generator
{
    public class ReportGenerator: ReportService
    {
        public override void PDFGenerator()
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.MarginTop(1, Unit.Inch);
                    page.MarginBottom(1, Unit.Inch);
                    page.MarginLeft(0.75f, Unit.Inch);
                    page.MarginRight(0.75f, Unit.Inch);
                    page.DefaultTextStyle(x => x.FontSize(12).FontFamily(Fonts.Arial));

                    page.Header().Text($"Report number: {reportNew.ID_Report}\n").ExtraBold().FontSize(24);
                    /*page.Header().Text($"From: {reportNew.startDate}\t To: {reportNew.finishDate}\n");
                    page.Header().Text($"Creator: {reportNew.creatorWorker.FirstName} {reportNew.creatorWorker.LastName}\n");*/

                });
            }).GeneratePdf("C:\\Users\\mdesa\\Documents\\Test\\test.pdf");
        }
         
    }
}
