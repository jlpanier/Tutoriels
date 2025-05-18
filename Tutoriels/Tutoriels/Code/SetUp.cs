using Android.Content.Res;
using Android.OS;
using Repository.Dbo;

namespace Tutoriels.Code
{
    /// <summary>
    /// Main application
    /// </summary>
    public static class Setup
    {
        /// <summary>
        /// Répertoire interne de l'application
        /// </summary>
        public static string AppPath { get; private set; } = "";

        /// <summary>
        /// Répertoire de stockage des cartes
        /// </summary>
        public static string MapPath { get; private set; } = "";

        /// <summary>
        /// Chemin des images 
        /// </summary>
        public static string ImagePath { get; private set; } = "";

        /// <summary>
        /// Chemin de la base de données
        /// </summary>
        public static string DbPath { get; private set; } = "";

        /// <summary>
        /// Chemin complet de la base de données
        /// </summary>
        public static string DbFilePath { get; private set; } = "";

        /// <summary>
        /// Chemin de partage des fichiers
        /// </summary>
        public static string FilePath { get; private set; } = "";

        /// <summary>
        /// Chemin temporaire des fichiers
        /// </summary>
        public static string TmpPath { get; private set; } = "";

        /// <summary>
        /// Initialisation du projet
        /// </summary>
        /// <param name="projectname"></param>
        /// <returns></returns>
        public static void Init(AssetManager? assetManager, string projectname)
        {
            // Version Android minimale
            // https://socialcompare.com/fr/comparison/android-versions-comparison   
            // Android  7.0 - 22/08/2016 - Nougat  (24)
            // Android  7.1 - 01/10/2016 - Nougat  (25)
            // Android  8.0 - 21/08/2017 - Oreo  (26)
            // Android  9.0 - 09/08/2018 - Pie  (28)
            // Android 10.0 - 03/09/2019 - Queen Cake  (29)
            // Android 11.0 - 08/09/2020 - Red Velvet Cake  (30)
            // Android 12.0 - 04/10/2021 - Snow Cone  (31)
            // Android 13.0 - 15/08/2022 - Tiramisu  (33)
            // Android 14.0 - 04/10/2023 - Upside Down Cake  (34)

            // Xiaomi M2003J15SC Android 10.0 API 29
            // LEVANO TB310FU    Android 13.0 API 33
            // Galaxy TAB A      Android 11.0 API 30


            var rootdir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            AppPath = Path.Combine(rootdir, projectname);
            DbPath = Path.Combine(AppPath, "db");
            DbFilePath = Path.Combine(DbPath, $"{projectname.ToUpper()}.sqlite");
            ImagePath = Path.Combine(AppPath, "images");
            FilePath = Path.Combine(AppPath, "file");
            TmpPath = Path.Combine(AppPath, "tmp");
            MapPath = Path.Combine(AppPath, "maps");

            Directory.CreateDirectory(AppPath);
            Directory.CreateDirectory(DbPath);
            Directory.CreateDirectory(FilePath);
            Directory.CreateDirectory(TmpPath);
            Directory.CreateDirectory(ImagePath);
            Directory.CreateDirectory(MapPath);

            CopyAssets(assetManager);

            BaseDbo.Init(DbFilePath);
        }

        /// <summary>
        /// Copie les assets (base de données si inexistante)
        /// </summary>
        /// <param name="assetManager"></param>
        public static void CopyAssets(AssetManager? assetManager)
        {
            System.Diagnostics.Debug.Assert(assetManager != null);

            // Check if the file already exists.
            if (!File.Exists(DbFilePath))
            {
                //using (FileStream writeStream = new FileStream(DbFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                //{
                //    using (var asset = assetManager.Open("NAVIGATION.sqlite"))
                //    {
                //        asset.CopyTo(writeStream);
                //    }
                //}
            }

            var files = assetManager.List("images");
            foreach (var file in files)
            {
                string path = Path.Combine(ImagePath, file);
                using (FileStream writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    string assetfile = Path.Combine("images", file);
                    using (var asset = assetManager.Open(assetfile))
                    {
                        asset.CopyTo(writeStream);
                    }
                }
            }

            files = assetManager.List("maps");
            foreach (var file in files)
            {
                string path = Path.Combine(MapPath, file);
                using (FileStream writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    string assetfile = Path.Combine("maps", file);
                    using (var asset = assetManager.Open(assetfile))
                    {
                        asset.CopyTo(writeStream);
                    }
                }
            }


        }

        /// <summary>
        /// Copie les fichiers de données dans le répertoire de téléchargement
        /// </summary>
        public static void Copy()
        {
            System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(Android.OS.Environment.DirectoryDownloads));
            var downloadPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, Android.OS.Environment.DirectoryDownloads);
            var path = Path.Combine(downloadPath, "Navigation");
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            Directory.CreateDirectory(path);
            CopyDirectory(ImagePath, Path.Combine(path, "images"));
            CopyDirectory(DbPath, Path.Combine(path, "db"));
            CopyDirectory(FilePath, Path.Combine(path, "file"));
            CopyDirectory(MapPath, Path.Combine(path, "maps"));

        }

        /// <summary>
        /// Recopie un répertoire
        /// </summary>
        private static void CopyDirectory(string sourceDir, string destinationDir)
        {
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }

            foreach (var file in Directory.GetFiles(sourceDir))
            {
                var destFile = Path.Combine(destinationDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }
        }

        /// <summary>
        /// Supprime la base de données
        /// </summary>
        public static void Clean()
        {
            if (File.Exists(DbFilePath))
            {
                File.Delete(DbFilePath);
            }
            if (File.Exists(DbFilePath))
            {
                File.Delete(DbFilePath);
            }
        }

        /// <summary>
        /// Correction de la base de données
        /// </summary>
        public static int Patch()
        {
            int rows = 0;
            try
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return rows;
        }
    }
}
