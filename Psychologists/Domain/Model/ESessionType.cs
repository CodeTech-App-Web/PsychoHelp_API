using System.ComponentModel;

namespace PsychoHelp_API.Psychologists.Domain.Model
{
    public enum ESessionType : byte
    {
        [Description("In")]
        Individual = 1,
        [Description("Co")]
        Couple = 2
    }
}