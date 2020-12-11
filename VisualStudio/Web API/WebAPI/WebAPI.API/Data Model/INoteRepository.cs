using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.API.Domain_Model;

namespace WebAPI.API.Data_Model
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetAll();
        Note GetOneNote(string id);
        void AddNote(Note note);
        Note EditOneNote(string id, Note note);
        void DeleteOneNote(string id);

    }
}
