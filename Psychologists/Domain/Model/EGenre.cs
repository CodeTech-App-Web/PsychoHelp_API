using System.ComponentModel;

namespace PsychoHelp_API.Psychologists.Domain.Model
{
    public enum EGenre : byte
    {
        [Description("M")]
        Male = 1,
        [Description("F")]
        Female = 2,
        [Description("O")]
        Other = 3
    }
}