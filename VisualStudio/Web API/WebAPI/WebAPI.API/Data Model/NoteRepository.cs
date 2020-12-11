using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.API.Domain_Model;

namespace WebAPI.API.Data_Model
{
    public class NoteRepository: INoteRepository
    {

        private readonly List<Note> _notes;
        private readonly List<Tag> _tags;
        private readonly List<Author> _users;

        public NoteRepository()
        {
            _users = new List<Author>
            {
                new Author { AuthorID = "1", Name = "Fred" },
                new Author { AuthorID = "2", Name = "Nick" }
            };

            _tags = new List<Tag>
            {
                new Tag { TagID = "1", Name = "services" },
                new Tag { TagID = "2", Name = "basic" },
                new Tag { TagID = "3", Name = "advanced" }
            };

            _notes = new List<Note>
            {
                new Note {
                    NoteID = "1",
                    Author = _users.First(u => u.Name == "Nick"),                 
                    Content = "REST stands for representational state transfer",
                    CreatedTime = new DateTime(2020, 4, 1),
                    Tags = new List<Tag>
                    {
                        _tags.First(t => t.Name == "services"),
                        _tags.First(t => t.Name == "basic")
                    }
                },
                new Note {
                    NoteID = "2",
                    Author = _users.First(u => u.Name == "Fred"),                   
                    Content = "C# is an OOP language",
                    CreatedTime = new DateTime(2020, 4, 9),
                    Tags = new List<Tag>
                    {
                        _tags.First(t => t.Name == "basic")
                    }
                }
            };

            _users[0].Notes = new List<Note> { _notes[1] };
            _users[1].Notes = new List<Note> { _notes[0] };
        }

       

        public IEnumerable<Note> GetAll()
        {
            var notes = _notes.ToList();
            return notes;
            
        }


        public Note GetOneNote(string id)
        {
            var foundNote = _notes.FirstOrDefault(x => x.NoteID == id);
            return foundNote;
        }

        public void AddNote(Note note)
        {
            var newNote = new Note
            {
                NoteID = note.NoteID ,
                Author = note.Author,
                Content = note.Content,
                CreatedTime = note.CreatedTime,
                Tags = note.Tags,
            };
            _notes.Add(newNote);
        }

        public Note EditOneNote(string id, Note note )
        {
            var foundNote = _notes.FirstOrDefault(x => x.NoteID == id);
            if (foundNote == null) return null;
            foundNote = new Note
            {
                NoteID = note.NoteID + " edited",
                Author = note.Author,
                Content = note.Content + " edited",
                CreatedTime = note.CreatedTime,
                Tags = note.Tags,
            };
            return foundNote;

        }

        public void DeleteOneNote(string id)
        {
            var foundNote = _notes.FirstOrDefault(x => x.NoteID == id);
            _notes.Remove(foundNote);
            
        }
    }
}
