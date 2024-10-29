using BaseLocalesG2.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLocalesG2.Platforms.Android.Dependency
{
    public class ObtenerRuta : IRuta
    {
        public string GetRutaDB(string filename)
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            return Path.Combine(ruta, filename);

        }
    }
}
