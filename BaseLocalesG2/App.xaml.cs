using BaseLocalesG2.Data;
using BaseLocalesG2.Dependency;

namespace BaseLocalesG2
{
    public partial class App : Application
    {
        private static PersonaDataBase _personaDataBase;

        public static PersonaDataBase PersonaDataBase
        {
            get
            {
                if (_personaDataBase == null)
                {
                    return new PersonaDataBase(DependencyService.Get<IRuta>().GetRutaDB("database2.db3"));
                }
                else
                {
                    return _personaDataBase;
                }

            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
    }
}
