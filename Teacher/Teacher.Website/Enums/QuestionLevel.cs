using System;

namespace Teacher.Website.Enums
{
    [Flags]
    public enum QuestionLevel
    {
        None = 0,
        Junior = 1,
        Regular = 2,
        Senior = 4
    }
}