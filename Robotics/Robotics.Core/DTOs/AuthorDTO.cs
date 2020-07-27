using System.Collections.Generic;

namespace Robotics.Core.DTOs
{
    public class AuthorDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<BookDTO> Books { get; set; }
    }
}
