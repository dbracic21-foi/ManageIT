using EntitiesLayer.Entities;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusinessLogicLayer.Generator
{
    public class RecieptGenerator: IDocument
    {
        public Receipt receiptNew { get; set; }
        public WorkOrder workOrderForReceipt { get; set; }
        public RecieptGenerator(Receipt receipt, WorkOrder workOrder) 
        {
            receiptNew = receipt;
            workOrderForReceipt = workOrder;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.ContinuousSize(3, QuestPDF.Infrastructure.Unit.Inch);
                    page.MarginVertical(5);
                    page.MarginHorizontal(10);

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);
                    page.Footer().Element(ComposeFooter);

                });
        }

        void ComposeHeader(QuestPDF.Infrastructure.IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column
                        .Item().Text($"Receipt #{receiptNew.ID_receipt}")
                        .FontSize(14).SemiBold();

                    column.Item().Text(text =>
                    {
                        text.Span("Date of service: ");
                        text.Span($"{workOrderForReceipt.OrderDetail.Date}");
                    });
                });
            });
        }

        void ComposeContent(QuestPDF.Infrastructure.IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                column.Spacing(20);
                column.Item().Element(ComposeTable);
            });
        }

        void ComposeTable(QuestPDF.Infrastructure.IContainer container)
        {
            var headerStyle = TextStyle.Default.SemiBold();
            var contentStyle = TextStyle.Default.Size(10);

            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.Header(header =>
                {
                    header.Cell().Text("#");
                    header.Cell().Text("Work type").Style(headerStyle);
                    header.Cell().Text("Price").Style(headerStyle);

                    header.Cell().ColumnSpan(6).PaddingTop(5).BorderBottom(1).BorderColor(Colors.Black);
                });

                QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer styleContainer) => styleContainer.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);

                    table.Cell().Element(CellStyle).Text("1").Style(contentStyle);
                   
                    table.Cell().Element(CellStyle).Text($"{workOrderForReceipt.OrderDetail.WorkType.Name}").Style(contentStyle);
                    table.Cell().Element(CellStyle).Text($"{workOrderForReceipt.OrderDetail.WorkType.Price}").Style(contentStyle);
            });
        }

        void ComposeFooter(QuestPDF.Infrastructure.IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text(text =>
                    {
                        text.Span("Creator: ID ");
                        text.Span($"{receiptNew.ID_Worker}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Date of creation: ");
                        text.Span($"{receiptNew.Date}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Company OIB: ");
                        text.Span($"{receiptNew.Date}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Additional information");
                        text.Span($"{receiptNew.Additional_info}");
                    });
                });
            });
        }

        public DocumentSettings GetSettings()
        {
            return new DocumentSettings
            {
                ContentDirection = QuestPDF.Infrastructure.ContentDirection.LeftToRight
            };
        }
    }
}
