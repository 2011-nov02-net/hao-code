using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.API.Data_Model;
using WebAPI.API.Domain_Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.API.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepo;

        public NotesController(INoteRepository noteRepo)
        {
            _noteRepo = noteRepo;
        }

        // GET: api/<NotesController>
        [HttpGet]
        public ActionResult<IEnumerable<Note>> Get()
        {
            var notes = _noteRepo.GetAll();
            if (notes == null)
                return NotFound();
            return Ok(notes);
            // return all notes           
        }

        [HttpGet("{id}")]
        public ActionResult<Note> GetOneNote(string id)
        {
            var note = _noteRepo.GetOneNote(id);
            if (note == null)
                return NotFound();
            return Ok(note);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Note note)
        {
            // create a new note
            // client sends in one resource
            _noteRepo.AddNote(note);
            return CreatedAtAction(nameof(GetOneNote), new { id = note.NoteID }, note);
        }
     

        [HttpPut("{id}")]
        public IActionResult PutOneNote(string id, [FromBody] Note note)
        {
            // update a note
            var editedNote = _noteRepo.EditOneNote(id, note);
            if (editedNote == null)
                return NotFound();
            else
                // 200, 201, 204
                // return the edited note 
                return CreatedAtAction(nameof(GetOneNote), new { id = editedNote.NoteID }, editedNote);
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteOneNote(string id)
        {
            // delete a note
            if (_noteRepo.GetOneNote(id) is Note note)
            {
                _noteRepo.DeleteOneNote(id);
                return NoContent();
            }
            return NotFound();

        }
        
         

    }
}
