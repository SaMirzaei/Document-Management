using Heinekamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Heinekamp.Persistence.EntityFramework.Context;

public class HeinekampContext : DbContext
{
    public HeinekampContext(DbContextOptions<HeinekampContext> options) : base(options)
    {
    }

    public DbSet<Document> Documents { get; set; }

    public DbSet<DocumentType> DocumentTypes { get; set; }

    public DbSet<ShareLink> ShareLinks { get; set; }

    public static void SeedData(HeinekampContext context)
    {
        context.Database.EnsureCreated();

        // Seed DocumentTypes
        if (!context.DocumentTypes.Any())
        {
            context.DocumentTypes.AddRange(
                new DocumentType { Name = "Unknown", Mime = "Unknown", Icon = "Unknown.png" },
                new DocumentType { Name = "Pdf", Mime = "application/pdf", Icon = "Pdf.png" },
                new DocumentType { Name = "JPEG Pictures", Mime = "image/jpeg", Icon = "JPEG.png" },
                new DocumentType { Name = "PNG Pictures", Mime = "image/png", Icon = "png.png" },
                new DocumentType { Name = "Text", Mime = "text/plain", Icon = "Text.png" },
                new DocumentType { Name = "Gif", Mime = "image/gif", Icon = "GIF.png" },
                new DocumentType { Name = "Excel 2007", Mime = "application/vnd.ms-excel", Icon = "Excel.png" },
                new DocumentType { Name = "Word 2007", Mime = "application/msword", Icon = "Word.png" },
                new DocumentType { Name = "Excel", Mime = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Icon = "Excel.png" },
                new DocumentType { Name = "Word", Mime = "application/vnd.openxmlformats-officedocument.wordprocessingml.document", Icon = "Word.png" }
            );

            context.SaveChanges();
        }
    }
}