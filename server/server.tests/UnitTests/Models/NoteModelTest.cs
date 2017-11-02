using Server.Models;
using Xunit;

namespace Server.Tests.Models
{
    public class NoteModelTest
    {
        [Fact]
        public void GettingAndSettingNameTest1()
        {
            string name = "hello";

            Note note = new Note();
            note.Name = name;

            Assert.Equal(note.Name, name);
        }

        [Fact]
        public void GettingAndSettingNameTest2()
        {
            string name = "hello";

            Note note = new Note();
            note.Name = name;
            note.Name = "bye";

            Assert.NotEqual(note.Name, name);
        }
    }
}
