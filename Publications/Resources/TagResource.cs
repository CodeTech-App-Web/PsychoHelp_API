using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsychoHelp_API.Publications.Resources
{
    public class TagResource
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public PublicationResource Publication { get; set; }

    }
}
