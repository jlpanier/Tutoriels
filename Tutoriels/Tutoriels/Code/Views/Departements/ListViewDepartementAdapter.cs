using Android.Views;

namespace Tutoriels.Code.Activities.Departements
{
    class ListViewDepartementAdapter : SimpleAdapter<ListViewDepartementItem>
    {
        protected override int LayoutResourceId => Resource.Layout.ListViewDepartementItem;

        public ListViewDepartementAdapter(Activity context) : base(context)
        {
            Reset(ReadDepartementAsset());
        }

        private List<ListViewDepartementItem> ReadDepartementAsset()
        {
            try
            {
                List<ListViewDepartementItem> result = new List<ListViewDepartementItem>();
                using (var input = Context.Assets.Open("Departements.txt"))
                {
                    using (var sr = new System.IO.StreamReader(input))
                    {
                        string line = sr.ReadLine();
                        while (line != null)
                        {
                            var arrValues = line.Split(';');
                            if (arrValues.Length == 6)
                            {
                                var reference = arrValues[0];
                                var name = arrValues[1];
                                var prefecture = arrValues[2];
                                var sousprefectures = arrValues[3].Split(',');
                                var region = arrValues[4];
                                int.TryParse(arrValues[5], out int superficie);

                                result.Add(new ListViewDepartementItem(reference, name, prefecture, sousprefectures, region, superficie));
                            }
                            line = sr.ReadLine();
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not read file \"Departements.txt\" " + ex.ToString());
                return new List<ListViewDepartementItem>();
            }
        }

        public override View GetView(int position, View? convertView, ViewGroup? parent)
        {
            View view = convertView;
            if (view == null) view = Context.LayoutInflater.Inflate(LayoutResourceId, null);

            ListViewDepartementHolder holder = view.Tag as ListViewDepartementHolder;

            if (holder == null)
            {
                holder = new ListViewDepartementHolder();
                holder.tvDepartement = view.FindViewById<TextView>(Resource.Id.tvDepartement);
                holder.tvPrefecture = view.FindViewById<TextView>(Resource.Id.tvPrefecture);
                holder.imgDepartement = view.FindViewById<ImageView>(Resource.Id.imgDepartement);
                view.Tag = holder;
            }

            ListViewDepartementItem item = Items[position];
            holder.tvDepartement.Text = item.Name;
            holder.tvPrefecture.Text = item.Prefecture;
            holder.imgDepartement.SetImageResource(item.ImageId);

            return view;
        }
    }
}