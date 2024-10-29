using Android.App;
using Android.Runtime;
using BaseLocalesG2.Dependency;
using BaseLocalesG2.Platforms.Android.Dependency;

namespace BaseLocalesG2
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
            DependencyService.Register<IRuta, ObtenerRuta>();
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
