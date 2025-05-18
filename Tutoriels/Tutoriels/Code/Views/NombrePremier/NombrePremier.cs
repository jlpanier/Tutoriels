using System;

namespace Tutoriels.Code.Activities
{
    public class NombrePremier
    {
        public override string ToString() => $"{Index} : {Nombre} {Duration}";

        public int Index { get; private set; }
        public long Nombre { get; private set; }
        public TimeSpan Duration { get; private set; }

        public NombrePremier(int index, long nombre, TimeSpan duration)
        {
            Index = index;
            Nombre = nombre;
            Duration = duration;
        }
    }
}