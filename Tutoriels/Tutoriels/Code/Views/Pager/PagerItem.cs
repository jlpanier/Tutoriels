using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutoriels.Code.Activities.Pager
{
    internal class PagerItem: Java.Lang.Object
    {
        public readonly int ResourceId;

        public PagerItem(int resid)
        {
            ResourceId = resid;
        }
    }
}
