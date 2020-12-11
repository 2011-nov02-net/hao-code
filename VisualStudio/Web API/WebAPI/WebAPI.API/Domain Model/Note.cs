using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.API.Domain_Model
{
    
    public class Note
    {
        // still domain model, object reference
        public string NoteID { get; set; }
        public Author Author { get; set; }
        
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();


    }
}
