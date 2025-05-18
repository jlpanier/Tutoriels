using Common;

namespace Tutoriels.Code.Activities.CRRBluetooth
{
    internal class CRRMessage
    {
        public static CRRMessages Parse(string data)
        {
            CRRMessages result = CRRMessages.None;
            if (!string.IsNullOrEmpty(data))
            {
                foreach (CRRMessages item in Enum.GetValues(typeof(CRRMessages)))
                {
                    if (item.GetCodeValue() == data)
                    {
                        result = item;
                    }
                }
            }
            return result;
        }

        public enum TypesMessages
        {
            [StringValue("Alphabet phonétique international")]
            [CodeValue("Alfa")]
            Alphabet,
            [StringValue("Georges Brassens - Marquise Lyrics & Traduction")]
            [CodeValue("Georges Brassens - Marquise 1")]
            GeorgesBrassensMarquise,
        }

        public enum CRRMessages
        {
            [StringValue("None")]
            [CodeValue("None")]
            [NextValue("")]
            None,
            [StringValue("Alfa")]
            [CodeValue("Alfa")]
            [NextValue("Bravo")]
            Alfa,
            [StringValue("Bravo")]
            [CodeValue("Bravo")]
            [NextValue("Charlie")]
            Bravo,
            [StringValue("Charlie")]
            [CodeValue("Charlie")]
            [NextValue("Delta")]
            Charlie,
            [StringValue("Delta")]
            [CodeValue("Delta")]
            [NextValue("Echo")]
            Delta,
            [StringValue("Echo")]
            [CodeValue("Echo")]
            [NextValue("Foxtrot")]
            Echo,
            [StringValue("Foxtrot")]
            [CodeValue("Foxtrot")]
            [NextValue("Golf")]
            Foxtrot,
            [StringValue("Golf")]
            [CodeValue("Golf")]
            [NextValue("Hotel")]
            Golf,
            [StringValue("Hotel")]
            [CodeValue("Hotel")]
            [NextValue("India")]
            Hotel,
            [StringValue("India")]
            [CodeValue("India")]
            [NextValue("Juliette")]
            India,
            [StringValue("Juliette")]
            [CodeValue("Juliette")]
            [NextValue("Kilo")]
            Juliette,
            [StringValue("Kilo")]
            [CodeValue("Kilo")]
            [NextValue("Lima")]
            Kilo,
            [StringValue("Lima")]
            [CodeValue("Lima")]
            [NextValue("Mike")]
            Lima,
            [StringValue("Mike")]
            [CodeValue("Mike")]
            [NextValue("November")]
            Mike,
            [StringValue("November")]
            [CodeValue("November")]
            [NextValue("Oscar")]
            November,
            [StringValue("Oscar")]
            [CodeValue("Oscar")]
            [NextValue("Papa")]
            Oscar,
            [StringValue("Papa")]
            [CodeValue("Papa")]
            [NextValue("Quebec")]
            Papa,
            [StringValue("Quebec")]
            [CodeValue("Quebec")]
            [NextValue("Romeo")]
            Quebec,
            [StringValue("Roméo")]
            [CodeValue("Romeo")]
            [NextValue("Sierra")]
            Romeo,
            [StringValue("Sierra")]
            [CodeValue("Sierra")]
            [NextValue("Tango")]
            Sierra,
            [StringValue("Tango")]
            [CodeValue("Tango")]
            [NextValue("Uniform")]
            Tango,
            [StringValue("Uniform")]
            [CodeValue("Uniform")]
            [NextValue("Victor")]
            Uniform,
            [StringValue("Victor")]
            [CodeValue("Victor")]
            [NextValue("Whiskey")]
            Victor,
            [StringValue("Whiskey")]
            [CodeValue("Whiskey")]
            [NextValue("x-ray")]
            Whiskey,
            [StringValue("X-Ray")]
            [CodeValue("x-ray")]
            [NextValue("Yankee")]
            xray,
            [StringValue("Yankee")]
            [CodeValue("Yankee")]
            [NextValue("Zoulou")]
            Yankee,
            [StringValue("Zoulou")]
            [CodeValue("Zoulou")]
            [NextValue("")]
            Zoulou,
            [StringValue("Marquise, si mon visage")]
            [CodeValue("Georges Brassens - Marquise 1")]
            [NextValue("Georges Brassens - Marquise 2")]
            Feux,
            [StringValue("A quelques traits un peu vieux")]
            [CodeValue("Georges Brassens - Marquise 2")]
            [NextValue("Georges Brassens - Marquise 3")]
            GeorgesBrassensMarquise2,
            [StringValue("Souvenez-vous qu'à mon âge")]
            [CodeValue("Georges Brassens - Marquise 3")]
            [NextValue("Georges Brassens - Marquise 4")]
            GeorgesBrassensMarquise3,
            [StringValue("Vous ne vaudrez guère mieux")]
            [CodeValue("Georges Brassens - Marquise 4")]
            [NextValue("Georges Brassens - Marquise 5")]
            GeorgesBrassensMarquise4,
            [StringValue("")]
            [CodeValue("Georges Brassens - Marquise 5")]
            [NextValue("Georges Brassens - Marquise 6")]
            GeorgesBrassensMarquise5,
            [StringValue("Le temps aux plus belles choses")]
            [CodeValue("Georges Brassens - Marquise 6")]
            [NextValue("Georges Brassens - Marquise 7")]
            GeorgesBrassensMarquise6,
            [StringValue("Se plaît à faire un affront")]
            [CodeValue("Georges Brassens - Marquise 7")]
            [NextValue("Georges Brassens - Marquise 8")]
            GeorgesBrassensMarquise7,
            [StringValue("Et saura faner vos roses")]
            [CodeValue("Georges Brassens - Marquise 8")]
            [NextValue("Georges Brassens - Marquise 9")]
            GeorgesBrassensMarquise8,
            [StringValue("Comme il a ridé mon front")]
            [CodeValue("Georges Brassens - Marquise 9")]
            [NextValue("Georges Brassens - Marquise 10")]
            GeorgesBrassensMarquise9,
            [StringValue("")]
            [CodeValue("Georges Brassens - Marquise 10")]
            [NextValue("Georges Brassens - Marquise 11")]
            GeorgesBrassensMarquise10,
            [StringValue("Le même cours des planètes")]
            [CodeValue("Georges Brassens - Marquise 11")]
            [NextValue("Georges Brassens - Marquise 12")]
            GeorgesBrassensMarquise11,
            [StringValue("Règle nos jours et nos nuits")]
            [CodeValue("Georges Brassens - Marquise 12")]
            [NextValue("Georges Brassens - Marquise 13")]
            GeorgesBrassensMarquise12,
            [StringValue("On m'a vu ce que vous êtes")]
            [CodeValue("Georges Brassens - Marquise 13")]
            [NextValue("Georges Brassens - Marquise 14")]
            GeorgesBrassensMarquise13,
            [StringValue("Vous serez ce que je suis")]
            [CodeValue("Georges Brassens - Marquise 14")]
            [NextValue("Georges Brassens - Marquise 15")]
            GeorgesBrassensMarquise14,
            [StringValue("")]
            [CodeValue("Georges Brassens - Marquise 15")]
            [NextValue("Georges Brassens - Marquise 16")]
            GeorgesBrassensMarquise15,
            [StringValue("Peut-être que je serai vieille")]
            [CodeValue("Georges Brassens - Marquise 16")]
            [NextValue("Georges Brassens - Marquise 17")]
            GeorgesBrassensMarquise16,
            [StringValue("Répond Marquise, cependant")]
            [CodeValue("Georges Brassens - Marquise 17")]
            [NextValue("Georges Brassens - Marquise 18")]
            GeorgesBrassensMarquise17,
            [StringValue("J'ai vingt-six ans, mon vieux Corneille")]
            [CodeValue("Georges Brassens - Marquise 18")]
            [NextValue("Georges Brassens - Marquise 19")]
            GeorgesBrassensMarquise18,
            [StringValue("Et je t'emmerde en attendant")]
            [CodeValue("Georges Brassens - Marquise 19")]
            [NextValue("")]
            GeorgesBrassensMarquise19,
        }

        public CRRMessages Message { get; private set; }

        public CRRMessage(CRRMessages message)
        {
            Message = message;
        }

        public CRRMessages Next()
        {
            CRRMessages result = CRRMessages.None;
            foreach (CRRMessages item in Enum.GetValues(typeof(CRRMessages)))
            {
                if (item.GetCodeValue() == Message.GetNextValue())
                {
                    result = item;
                }
            }
            return result;
        }
    }
}