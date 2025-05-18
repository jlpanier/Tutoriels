namespace Tutoriels.Code.Activities.Parametres
{
    internal class LabelValue
    {
        public enum TypeValue
        {
            Titre,
            SousTitre,
            Label,
            Valeur
        }

        public readonly string Label;

        public readonly string Valeur;

        public readonly TypeValue Type;

        public LabelValue(string text, TypeValue typeValue)
        {
            Label = text;
            Type = typeValue;
        }

        public LabelValue(string label, string valeur)
        {
            Label = label;
            Valeur = valeur;
            Type = TypeValue.Valeur;
        }
    }
}