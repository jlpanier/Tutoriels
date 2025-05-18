using SQLite;
using System.ComponentModel;

namespace Repository.Entities
{
    [Table("COUNTRY")]
    public partial class Country : BaseEntity, INotifyPropertyChanged
    {
        #region Overall

        public override string ToString() => $"{ID} {SHORTNAME} {LONGNAME}";

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            IsDirty = true;
            PropertyChangedEventHandler? handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [Ignore]
        public bool IsDirty { get; set; }

        #endregion

        #region Fields/Properties

        private Guid _id;
        [PrimaryKey]
        [Column("ID")]
        public Guid ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged(nameof(ID));
                }
            }
        }

        [Column("SHORTNAME")]
        public string SHORTNAME
        {
            get { return _shortname; }
            set
            {
                if (_shortname != value)
                {
                    _shortname = value;
                    NotifyPropertyChanged(nameof(SHORTNAME));
                }
            }
        }
        private string _shortname = "";

        /// <summary>
        /// CAP du voilier : prise en compte de la dérive et du courant
        /// </summary>
        [Column("LONGNAME")]
        public string LONGNAME
        {
            get { return _longname; }
            set
            {
                if (_longname != value)
                {
                    _longname = value;
                    NotifyPropertyChanged(nameof(LONGNAME));
                }
            }
        }
        private string _longname = "";

        /// <summary>
        /// CAP du voilier : prise en compte de la dérive et du courant
        /// </summary>
        [Column("FLAG")]
        public string FLAG
        {
            get { return _flag; }
            set
            {
                if (_flag != value)
                {
                    _flag = value;
                    NotifyPropertyChanged(nameof(FLAG));
                }
            }
        }
        private string _flag = "";

        [Column("PROJECTION")]
        public string PROJECTION
        {
            get { return _projection; }
            set
            {
                if (_projection != value)
                {
                    _projection = value;
                    NotifyPropertyChanged(nameof(PROJECTION));
                }
            }
        }
        private string _projection = "";


        [Column("WIKI")]
        public string WIKI
        {
            get { return _wiki; }
            set
            {
                if (_wiki != value)
                {
                    _wiki = value;
                    NotifyPropertyChanged(nameof(WIKI));
                }
            }
        }
        private string _wiki = "";

        #endregion
    }
}
