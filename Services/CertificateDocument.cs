using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.IO;

public class CertificateDocument : IDocument
{
    private readonly string _timestamp;
    private readonly string _herName;

    public CertificateDocument(string timestamp, string herName)
    {
        _timestamp = timestamp;
        _herName = herName;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(40);
            page.DefaultTextStyle(x => x.FontFamily("Times New Roman"));

            page.Content().Layers(layers =>
            {
                // Watermark layer
                layers.Layer()
    .AlignCenter()
    .AlignMiddle()
    .Rotate(-25)
    .Column(col =>
    {
        col.Item().AlignCenter()
            .Text("Eternal Love")
            .FontSize(120)
            .FontColor("#F9E6EB")
            .Italic();         
    });

                // Main content layer
                layers.PrimaryLayer()
                    .Border(5)
                    .BorderColor("#D4AF37")
                    .Padding(25)
                    .Column(column =>
                    {
                        column.Spacing(20);
                                                
                        column.Item().AlignCenter().Row(row =>
                        {
                            row.AutoItem().Width(40)
                                .Image(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/heart.jpg"), ImageScaling.FitWidth);


                            row.RelativeItem().AlignMiddle()
                                .Text("Royal Certificate of Eternal Love")
                                .FontSize(26)
                                .Bold()
                                .FontColor("#5B3A29");

                            row.AutoItem().Width(40)
                                .Image(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/heart.jpg"), ImageScaling.FitWidth);
                            
                        });

                        column.Item().AlignCenter()
                            .Text("This Official Certificate Proudly Certifies That\r\n")
                            .FontSize(16);

                        column.Item().AlignCenter()
                            .Text(_herName)
                            .FontSize(22)
                            .Bold()
                            .FontColor("#B22222");

                        column.Item().AlignCenter()
                            .Text("graciously said")
                            .FontSize(16);

                        column.Item().AlignCenter()
                            .Text("YES")
                            .FontSize(24)
                            .Bold();

                        column.Item().AlignCenter()
                            .Text($"On the glorious date of {_timestamp}")
                            .FontSize(14);

                        column.Item().PaddingTop(25)
                            .Text(
                                "From this day forward, I pledge my loyalty, my love, " +
                                "my laughter, my support, and my endless affection. " +
                                "This certificate stands as proof of our beautiful journey."
                            )
                            .FontSize(14);

                        column.Item().PaddingTop(40)
                            .AlignCenter()
                            .Text("Signed with Love,")
                            .FontSize(14);

                        column.Item().AlignCenter()
                            .Text("Abhishek")
                            .FontSize(18)
                            .Italic();

                        // Cupid image (kept small to avoid new page)
                        column.Item().PaddingTop(20)
                            .AlignCenter()
                            .Width(120).Image(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/cupid.jpg"), ImageScaling.FitWidth);

                    });
            });
        });
    }
}
