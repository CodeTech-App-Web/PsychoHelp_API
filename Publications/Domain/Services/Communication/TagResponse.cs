using PsychoHelp_API.Domain.Services.Communication;
using PsychoHelp_API.Publications.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsychoHelp_API.Publications.Domain.Services.Communication
{
    public class TagResponse : BaseResponse<Tag>
    {
        public TagResponse(string message) : base(message)
        {
        }

        public TagResponse(Tag tag) : base(tag)
        {
        }
    }
}
