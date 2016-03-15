using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerController
{
    /// <summary>
    /// Operating modes of the controller
    /// </summary>
    public enum ConverterMode
    {
        Off = 0,
        ForwardCV = 1,
        ForwardCC = 2,
        ReverseCV = 3,
        ReverseCC = 4
    }
}
