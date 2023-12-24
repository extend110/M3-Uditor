using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3_Uditor
{
    public class StackObject : object
    {
        internal string Command {  get; set; }
        internal object Container { get; set; }
    }
}
