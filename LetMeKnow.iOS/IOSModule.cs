using Autofac;
using LetMeKnow.iOS.Services;
using LetMeKnow.Interfaces;

namespace LetMeKnow.iOS {
    public class IOSModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<FirebaseAuthenticator>().As<IFirebaseAuthenticator>().SingleInstance();
        }
    }
}
