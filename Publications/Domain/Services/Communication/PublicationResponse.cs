using PsychoHelp_API.Domain.Services.Communication;
using PsychoHelp_API.Publications.Domain.Models;

namespace PsychoHelp_API.Publications.Domain.Services.Communication
{
    public class PublicationResponse : BaseResponse<Publication>
        {
            public PublicationResponse(string message) : base(message)
            {
            }

            public PublicationResponse(Publication publication) : base(publication)
            {
            }
        }

}