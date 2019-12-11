using Autofac;

using LetMeKnow.Interfaces;
using LetMeKnow.Droid.Database;

using Android.Content;

namespace LetMeKnow.Droid {
    public class AndroidModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<FirebaseAuthenticator>().As<IFirebaseAuthenticator>().SingleInstance();
        }
    }
}