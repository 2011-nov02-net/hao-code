using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI.API.Domain_Model
{
    public class Author
    {
        public string AuthorID { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}
