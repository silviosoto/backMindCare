using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BLL.Documents
{

    public class FacturaDocument : IDocument
    {
        private readonly Domain.Models.Factura _factura;
        private readonly string _logoPath = ""; // Ruta al logo de la empresa
        public FacturaDocument(Domain.Models.Factura factura, string logoPath)
        {
            _factura = factura;
            _logoPath = logoPath;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);
                page.DefaultTextStyle(x => x.FontSize(11).FontColor(Colors.Black));

                // Encabezado con logo
                page.Header().Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("MindCare")
                            .Bold().FontSize(16).FontColor(Colors.Blue.Darken2);

                        col.Item().Text("NIT: 123.456.789-0");
                        col.Item().Text("Tel: +57 300 123 4567");
                        col.Item().Text("Email: contacto@mindcare.com");
                    });

                    // Logo
                    row.ConstantItem(100).Height(60).Image(_logoPath);
                });

                // Contenido
                page.Content().Column(col =>
                {
                    col.Spacing(15);

                    // Datos de la factura
                    col.Item().Text($"Factura N° {_factura.NumeroFactura}")
                        .Bold().FontSize(14).FontColor(Colors.Black);

                    col.Item().Row(row =>
                    {
                        row.RelativeItem().Column(c =>
                        {
                            c.Item().Text($"Cliente: {_factura.Paciente.DatosPersonale.Nombre}");
                            c.Item().Text($"Fecha: {_factura.FechaEmision:dd/MM/yyyy}");
                        });

                        row.RelativeItem().Column(c =>
                        {
                            c.Item().Text($"Estado: {_factura.Estado}")
                                .FontColor(Colors.Red.Darken2);
                        });
                    });

                    col.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                    // Tabla de detalle
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(3);
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(1);
                        });

                        // Encabezado
                        table.Header(header =>
                        {
                            header.Cell().Background(Colors.Blue.Darken2).Padding(5).Text("Servicio").Bold().FontColor(Colors.White);
                            header.Cell().Background(Colors.Blue.Darken2).Padding(5).Text("Cantidad").Bold().FontColor(Colors.White);
                            header.Cell().Background(Colors.Blue.Darken2).Padding(5).Text("Precio").Bold().FontColor(Colors.White);
                            header.Cell().Background(Colors.Blue.Darken2).Padding(5).Text("Total").Bold().FontColor(Colors.White);
                        });

                        // Filas
                        foreach (var item in _factura.FacturaDetalle)
                        {
                            table.Cell().Padding(5).Text(item.Servicio.Nombre);
                            table.Cell().Padding(5).Text(item.Cantidad.ToString());
                            table.Cell().Padding(5).Text($"${item.ValorUnitario:0,0.00}");
                            table.Cell().Padding(5).Text($"${item.Total:0,0.00}");
                        }
                    });

                    col.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                    // Totales
                    col.Item().AlignRight().Column(c =>
                    {
                        c.Item().Text($"Subtotal: ${_factura.Subtotal:0,0.00}");
                        c.Item().Text($"IVA: ${_factura.Iva:0,0.00}");
                        c.Item().Text($"TOTAL: ${_factura.Total:0,0.00}")
                            .Bold().FontSize(14).FontColor(Colors.Blue.Darken2);
                    });
                });

                // Pie de página
                page.Footer().AlignCenter().Text("Gracias por su compra")
                    .FontSize(10).FontColor(Colors.Grey.Medium);
            });
        }
    }
}
