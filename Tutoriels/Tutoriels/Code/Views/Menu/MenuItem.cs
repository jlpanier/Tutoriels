using Common;
using Tutoriel;
using Tutoriels.Code.Activities.AndroidColors;
using Tutoriels.Code.Activities.AndroidIcons;
using Tutoriels.Code.Activities.AutoComplete;
using Tutoriels.Code.Activities.Background;
using Tutoriels.Code.Activities.Canvas;
using Tutoriels.Code.Activities.Composant;
using Tutoriels.Code.Activities.Countries;
using Tutoriels.Code.Activities.CRRBluetooth;
using Tutoriels.Code.Activities.Culture;
using Tutoriels.Code.Activities.DatePicker;
using Tutoriels.Code.Activities.Departements;
using Tutoriels.Code.Activities.Fermat;
using Tutoriels.Code.Activities.Fourier;
using Tutoriels.Code.Activities.GeoLocalisation;
using Tutoriels.Code.Activities.Http;
using Tutoriels.Code.Activities.Image;
using Tutoriels.Code.Activities.IntentAction;
using Tutoriels.Code.Activities.Limite;
using Tutoriels.Code.Activities.MareeInfo;
using Tutoriels.Code.Activities.NavigationBar;
using Tutoriels.Code.Activities.NumberPickerNamespace;
using Tutoriels.Code.Activities.Pager;
using Tutoriels.Code.Activities.Parametres;
using Tutoriels.Code.Activities.ProgresssBar;
using Tutoriels.Code.Activities.Speech;
using Tutoriels.Code.Activities.SpeechRecognizer;
using Tutoriels.Code.Activities.Text2Speech;
using Tutoriels.Code.Activities.TutorialBitmap;
using Tutoriels.Code.Activities.Unicodes;
using Tutoriels.Code.Activities.Webview;

namespace Tutoriels.Code.Activities.Menu
{
    public class MenuTutorial
    {
        public enum TypeMenus
        {
            [StringValue("Auto Complete")]
            [TypeValue(typeof(AutoCompleteActivity))]
            AutoComplete,
            [StringValue("Date Picker dialog")]
            [TypeValue(typeof(DatePickerActivity))]
            DatePicker,
            [StringValue("Time Picker dialog")]
            [TypeValue(typeof(TimePickerActivity))]
            TimePicker,
            [StringValue("Colors")]
            [TypeValue(typeof(AndroidColorsActivity))]
            Colors,
            [StringValue("Departements")]
            [TypeValue(typeof(DepartementActivity))]
            ListViewDepartements,
            [StringValue("Navigation Bar")]
            [TypeValue(typeof(NavigationBarActivity))]
            NavigationBar,
            [StringValue("Texture View")]
            [TypeValue(typeof(TextureViewActivity))]
            TextureView,
            [StringValue("Android Icons")]
            [TypeValue(typeof(AndroidIconActivity))]
            AndroidIcons,
            [StringValue("WebView")]
            [TypeValue(typeof(WebViewActivity))]
            WebView,
            [StringValue("Bitmap")]
            [TypeValue(typeof(BitmapActivity))]
            Bitmap,
            [StringValue("Image")]
            [TypeValue(typeof(ImageActivity))]
            Image,
            [StringValue("NumberPicker")]
            [TypeValue(typeof(NumberPickerActivity))]
            NumberPicker,
            [StringValue("https")]
            [TypeValue(typeof(HttpsActivity))]
            Http,
            [StringValue("ProgressBar")]
            [TypeValue(typeof(ProgresssBarActivity))]
            ProgresssBar,
            [StringValue("Marée Info")]
            [TypeValue(typeof(MareeInfoActivity))]
            MaréeInfo,
            [StringValue("Pixels")]
            [TypeValue(typeof(PixelsActivity))]
            Pixels,
            [StringValue("Animation")]
            [TypeValue(typeof(AnimationActivity))]
            Animation,
            [StringValue("Bluetooth")]
            [TypeValue(typeof(BluetoothActivity))]
            Bluetooth,
            [StringValue("CRR")]
            [TypeValue(typeof(AlphaBluetoothActivity))]
            CRR,
            [StringValue("Screen Size")]
            [TypeValue(typeof(ScreenSizeActivity))]
            ScreenSize,
            [StringValue("Text2Speech")]
            [TypeValue(typeof(Text2SpeechActivity))]
            Text2Speech,
            [StringValue("Speech")]
            [TypeValue(typeof(SpeechActivity))]
            Speech,
            [StringValue("Speech Recognizer")]
            [TypeValue(typeof(SpeechRecognizerActivity))]
            SpeechRecognizer,
            [StringValue("Country")]
            [TypeValue(typeof(CountryActivity))]
            CountryActivity,
            [StringValue("Paramètres")]
            [TypeValue(typeof(ParametresActivity))]
            ParametresActivity,
            [StringValue("Nombre Premier")]
            [TypeValue(typeof(NombrePremierActivity))]
            NombrePremier,
            [StringValue("Fermat-Wiles")]
            [TypeValue(typeof(FermatActivity))]
            Fermat,
            [StringValue("Background")]
            [TypeValue(typeof(BackgroundActivity))]
            Background,
            [StringValue("Unicodes")]
            [TypeValue(typeof(UnicodeActivity))]
            Unicodes,
            [StringValue("Série de Fourier")]
            [TypeValue(typeof(FourierActivity))]
            SerieFourier,
            [StringValue("Geo Localisation")]
            [TypeValue(typeof(GeoLocalisationActivity))]
            GeoLocalisation,
            [StringValue("Intent")]
            [TypeValue(typeof(IntentActivity))]
            IntentActivity,
            [StringValue("Math")]
            [TypeValue(typeof(MathActivity))]
            Math,
            [StringValue("Composant")]
            [TypeValue(typeof(ComposantActivity))]
            Composant,
            [StringValue("Pick file")]
            [TypeValue(typeof(PickFileActivity))]
            PickFile,
            [StringValue("Culture Info")]
            [TypeValue(typeof(CultureInfoActivity))]
            CultureInfo,
            [StringValue("Limite")]
            [TypeValue(typeof(LimiteActivity))]
            Limite,
            [StringValue("Pager")]
            [TypeValue(typeof(ViewPagerActivity))]
            Pager,
        };

        public TypeMenus Menu { get; private set; }

        public MenuTutorial(TypeMenus menu)
        {
            Menu = menu;
        }
    }
}