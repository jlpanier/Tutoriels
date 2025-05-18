using System;

namespace Tutoriels.Code.Activities.Fermat
{
    public class FermatItem
    {
        public long A { get; private set; }
        public long B { get; private set; }
        public long C { get; private set; }
        public TimeSpan Duration { get; private set; }

        public FermatItem(long a, long b, long c, TimeSpan ts)
        {
            A = a;
            B = b;
            C = c;
            Duration = ts;
        }
    }
}