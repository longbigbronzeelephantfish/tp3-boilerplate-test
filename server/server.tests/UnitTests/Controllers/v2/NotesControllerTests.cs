using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using Server.Controllers.v2;
using Server.Models;
using Server.Respositories.Interfaces;
using Xunit;

namespace Server.Tests.UnitTests.Controllers.v2
{
    public class NotesControllerTests
    {
        [Fact]
        public void Get_ReturnsNotes()
        {
            // Test object
            int id = 1;
            Note note = new Note()
            {
                NoteId = id,
                Name = "Hello",
                Colour = Note.NoteColour.Red,
                TodoItems = null
            };

            // Arrange
            var mockRepo = new Mock<INotesRepository>();
            mockRepo.Setup(repo => repo.CheckIfExists(id))
                .Returns(true)
                .Verifiable();
            mockRepo.Setup(repo => repo.GetById(id))
                .Returns(note)
                .Verifiable();

            var controller = new NotesController(mockRepo.Object);

            // Act
            var result = controller.Get(id) as JsonResult;
            Note resultNote = result.Value as Note;
            
            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(resultNote.Name, note.Name);
            mockRepo.Verify();
        }
    }
}
