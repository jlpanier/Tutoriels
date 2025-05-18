using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    [Table("NOMBRE_PREMIER")]
    public partial class NombrePremierEntity : BaseEntity, INotifyPropertyChanged
    {
        #region Overall

        public override string ToString() => $"{NONBRE} {DURATION}";

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

        [Column("NOMBRE")]
        public long NONBRE
        {
            get { return _nombre; }
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    NotifyPropertyChanged(nameof(NONBRE));
                }
            }
        }
        private long _nombre;

        /// <summary>
        /// CAP du voilier : prise en compte de la dérive et du courant
        /// </summary>
        [Column("DURATION")]
        public TimeSpan DURATION
        {
            get { return _longdurationame; }
            set
            {
                if (_longdurationame != value)
                {
                    _longdurationame = value;
                    NotifyPropertyChanged(nameof(DURATION));
                }
            }
        }
        private TimeSpan _longdurationame;


        #endregion
    }
}
