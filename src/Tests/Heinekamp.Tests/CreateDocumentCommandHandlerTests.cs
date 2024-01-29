using Heinekamp.Application.Exceptions;
using Heinekamp.Application.Features.Documents.Commands.CreateDocument;
using Heinekamp.Application.Models;
using Heinekamp.Application.Services;
using Microsoft.AspNetCore.Http.Internal;
using NSubstitute;

namespace Heinekamp.Tests
{
    public class CreateDocumentCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsResponseWithDocumentId()
        {
            // Arrange
            var documentServiceMock = Substitute.For<IDocumentService>();
            var dateTimeServiceMock = Substitute.For<IDateTimeService>();

            var handler = new CreateDocumentCommandHandler(documentServiceMock, dateTimeServiceMock);

            var request = new CreateDocumentCommand
            {
                Name = "TestDocument",
                ContentType = "application/pdf",
                File = new FormFile(Stream.Null, 0, 0, "TestFile", "test.pdf")
            };

            var cancellationToken = new CancellationToken();

            var expectedDocumentId = 1L;
            documentServiceMock.UploadDocumentAsync(Arg.Any<DocumentDTO>()).Returns(expectedDocumentId);

            dateTimeServiceMock.NowUtc.Returns(DateTime.UtcNow);

            // Act
            var result = await handler.Handle(request, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDocumentId, result.Data);

            await documentServiceMock.Received(1).UploadDocumentAsync(Arg.Any<DocumentDTO>());
        }

        [Fact]
        public async Task Handle_ExceptionThrown_ReturnsApiException()
        {
            // Arrange
            var documentServiceMock = Substitute.For<IDocumentService>();
            var dateTimeServiceMock = Substitute.For<IDateTimeService>();

            var handler = new CreateDocumentCommandHandler(documentServiceMock, dateTimeServiceMock);

            var request = new CreateDocumentCommand
            {
                Name = "TestDocument",
                ContentType = "application/pdf",
                File = new FormFile(Stream.Null, 0, 0, "TestFile", "test.pdf")
            };

            var cancellationToken = new CancellationToken();

            documentServiceMock
                .When(x => x.UploadDocumentAsync(Arg.Any<DocumentDTO>()))
                .Throw(new Exception("Simulated exception"));

            // Act and Assert
            await Assert.ThrowsAsync<ApiExceptions>(() => handler.Handle(request, cancellationToken));

            await documentServiceMock.Received(1).UploadDocumentAsync(Arg.Any<DocumentDTO>());
        }
    }
}