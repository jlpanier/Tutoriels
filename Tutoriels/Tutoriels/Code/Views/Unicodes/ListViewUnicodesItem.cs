namespace Tutoriels.Code.Activities.Unicodes
{
    public class ListViewUnicodesItem
    {
        public static string Value(int code)
        {
            ListViewUnicodesItem item = new ListViewUnicodesItem(code);
            return item.Display;
        }
        public int Id { get; private set; }

        public string Code
        {
            get
            {
                int power = 16 * 16 * 16;
                int digit4 = (int)(Id / power);
                int left = Id % power;
                power = 16 * 16;
                int digit3 = (int)(left / power);
                left = left % power;
                power = 16;
                int digit2 = (int)(left / power);
                int digit1 = left % power;

                return $"{Translate(digit4)}{Translate(digit3)}{Translate(digit2)}{Translate(digit1)}";
            }
        }
        public string Display
        {
            get
            {
                int code = int.Parse(Code, System.Globalization.NumberStyles.HexNumber);
                return char.ConvertFromUtf32(code);
            }
        }

        public ListViewUnicodesItem(int unicode)
        {
            Id = unicode;
        }

        private string Translate(int digit)
        {
            string result = "0";
            switch (digit)
            {
                case 1: result = "1"; break;
                case 2: result = "2"; break;
                case 3: result = "3"; break;
                case 4: result = "4"; break;
                case 5: result = "5"; break;
                case 6: result = "6"; break;
                case 7: result = "7"; break;
                case 8: result = "8"; break;
                case 9: result = "9"; break;
                case 10: result = "A"; break;
                case 11: result = "B"; break;
                case 12: result = "C"; break;
                case 13: result = "D"; break;
                case 14: result = "E"; break;
                case 15: result = "F"; break;
            }
            return result;
        }
    }

}