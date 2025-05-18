using Tutoriel;

namespace Tutoriels.Code.Activities.Departements
{
    public class ListViewDepartementItem
    {
        public string Reference { get; private set; }
        public string Name { get; private set; }
        public string Prefecture { get; private set; }
        public string[] SousPrefectures { get; private set; }
        public string Region { get; private set; }
        public int Superficie { get; private set; }
        public int ImageId { get; private set; }

        public ListViewDepartementItem(string reference, string name, string prefecture, string[] sousprefectures, string region, int superficie)
        {
            Reference = reference;
            Name = name;
            Prefecture = prefecture;
            SousPrefectures = sousprefectures;
            Region = region;
            Superficie = superficie;
            ImageId = Resource.Drawable.logo;

            switch (reference)
            {
                case "01": ImageId = Resource.Drawable.AIN; break;
                case "02": ImageId = Resource.Drawable.AISNE; break;
                case "03": ImageId = Resource.Drawable.ALLIER; break;
                case "04": ImageId = Resource.Drawable.ALPESHAUTEPROVENCE; break;
                case "05": ImageId = Resource.Drawable.HAUTESALPES; break;
                case "06": ImageId = Resource.Drawable.ALPESMARITIMES; break;
                case "07": ImageId = Resource.Drawable.Ardeche; break;
                case "08": ImageId = Resource.Drawable.Ardennes; break;
                case "09": ImageId = Resource.Drawable.Ariege; break;
                case "10": ImageId = Resource.Drawable.Aube; break;
                case "11": ImageId = Resource.Drawable.Aude; break;
                case "12": ImageId = Resource.Drawable.Aveyron; break;
                case "13": ImageId = Resource.Drawable.BouchesDuRhone; break;
                case "14": ImageId = Resource.Drawable.Calvados; break;
                case "15": ImageId = Resource.Drawable.Cantal; break;
                case "16": ImageId = Resource.Drawable.Charente; break;
                case "17": ImageId = Resource.Drawable.CharenteMaritime; break;
                case "18": ImageId = Resource.Drawable.Cher; break;
                case "19": ImageId = Resource.Drawable.Correze; break;
                case "2A": ImageId = Resource.Drawable.CorseDuSud; break;
                case "2B": ImageId = Resource.Drawable.HauteCorse; break;
                case "21": ImageId = Resource.Drawable.CoteDOr; break;
                case "22": ImageId = Resource.Drawable.CotesArmor; break;
                case "23": ImageId = Resource.Drawable.Creuse; break;
                case "24": ImageId = Resource.Drawable.Dordogne; break;
                case "25": ImageId = Resource.Drawable.Doubs; break;
                case "26": ImageId = Resource.Drawable.Drome; break;
                case "27": ImageId = Resource.Drawable.Eure; break;
                case "28": ImageId = Resource.Drawable.EureEtLoir; break;
                case "29": ImageId = Resource.Drawable.Finistere; break;
                case "30": ImageId = Resource.Drawable.Gard; break;
                case "31": ImageId = Resource.Drawable.HauteGaronne; break;
                case "32": ImageId = Resource.Drawable.Gers; break;
                case "33": ImageId = Resource.Drawable.Gironde; break;
                case "34": ImageId = Resource.Drawable.Herault; break;
                case "35": ImageId = Resource.Drawable.IlleEtVilaine; break;
                case "36": ImageId = Resource.Drawable.Indre; break;
                case "37": ImageId = Resource.Drawable.IndreLoire; break;
                case "38": ImageId = Resource.Drawable.Isere; break;
                case "39": ImageId = Resource.Drawable.Jura; break;
                case "40": ImageId = Resource.Drawable.Landes; break;
                case "41": ImageId = Resource.Drawable.LoirEtCher; break;
                case "42": ImageId = Resource.Drawable.Loire; break;
                case "43": ImageId = Resource.Drawable.HauteLoire; break;
                case "44": ImageId = Resource.Drawable.LoireAtlantique; break;
                case "45": ImageId = Resource.Drawable.Loiret; break;
                case "46": ImageId = Resource.Drawable.Lot; break;
                case "47": ImageId = Resource.Drawable.LotEtGaronne; break;
                case "48": ImageId = Resource.Drawable.Lozere; break;
                case "49": ImageId = Resource.Drawable.MaineEtLoire; break;
                case "50": ImageId = Resource.Drawable.Manche; break;
                case "51": ImageId = Resource.Drawable.Marne; break;
                case "52": ImageId = Resource.Drawable.HauteMarne; break;
                case "53": ImageId = Resource.Drawable.Mayenne; break;
                case "54": ImageId = Resource.Drawable.MeurtheEtMoselle; break;
                case "55": ImageId = Resource.Drawable.Meuse; break;
                case "56": ImageId = Resource.Drawable.Morbihan; break;
                case "57": ImageId = Resource.Drawable.Moselle; break;
                case "58": ImageId = Resource.Drawable.Nievre; break;
                case "59": ImageId = Resource.Drawable.Nord; break;
                case "60": ImageId = Resource.Drawable.Oise; break;
                case "61": ImageId = Resource.Drawable.Orne; break;
                case "62": ImageId = Resource.Drawable.PasDeCalais; break;
                case "63": ImageId = Resource.Drawable.PuyDeDome; break;
                case "64": ImageId = Resource.Drawable.PyreneesAtlantiques; break;
                case "65": ImageId = Resource.Drawable.HautesPyrenees; break;
                case "66": ImageId = Resource.Drawable.PyreneesOrientales; break;
                case "67": ImageId = Resource.Drawable.BasRhin; break;
                case "68": ImageId = Resource.Drawable.HautRhin; break;
                case "69": ImageId = Resource.Drawable.Rhone; break;
                case "70": ImageId = Resource.Drawable.HauteSaone; break;
                case "71": ImageId = Resource.Drawable.SaoneEtLoire; break;
                case "72": ImageId = Resource.Drawable.Sarthe; break;
                case "73": ImageId = Resource.Drawable.Savoie; break;
                case "74": ImageId = Resource.Drawable.HauteSavoie; break;
                case "75": ImageId = Resource.Drawable.Paris; break;
                case "76": ImageId = Resource.Drawable.SeineMaritime; break;
                case "77": ImageId = Resource.Drawable.SeineEtMarne; break;
                case "78": ImageId = Resource.Drawable.Yvelines; break;
                case "79": ImageId = Resource.Drawable.DeuxSevres; break;
                case "80": ImageId = Resource.Drawable.Somme; break;
                case "81": ImageId = Resource.Drawable.Tarn; break;
                case "82": ImageId = Resource.Drawable.TarnEtGaronne; break;
                case "83": ImageId = Resource.Drawable.Var; break;
                case "84": ImageId = Resource.Drawable.Vaucluse; break;
                case "85": ImageId = Resource.Drawable.Vendee; break;
                case "86": ImageId = Resource.Drawable.Vienne; break;
                case "87": ImageId = Resource.Drawable.HauteVienne; break;
                case "88": ImageId = Resource.Drawable.Vosges; break;
                case "89": ImageId = Resource.Drawable.Yonne; break;
                case "90": ImageId = Resource.Drawable.TerritoireDeBelfort; break;
                case "91": ImageId = Resource.Drawable.Essonne; break;
                case "92": ImageId = Resource.Drawable.HautsDeSeine; break;
                case "93": ImageId = Resource.Drawable.SeineSaintDenis; break;
                case "94": ImageId = Resource.Drawable.ValDeMarne; break;
                case "95": ImageId = Resource.Drawable.ValDOise; break;
                case "971": ImageId = Resource.Drawable.Guadeloupe; break;
                case "972": ImageId = Resource.Drawable.Martinique; break;
                case "973": ImageId = Resource.Drawable.Guyane; break;
                case "974": ImageId = Resource.Drawable.Reunion; break;
                case "976": ImageId = Resource.Drawable.Mayotte; break;
            }
        }

    }
}