using System;
using System.Threading;
using SafeApp.Utilities;

namespace SafeApp.NativeBindings {
  public class DependencyResolver {
    private static readonly Lazy<INativeBindings> Implementation =
      new Lazy<INativeBindings>(CreateNativeBindings, LazyThreadSafetyMode.PublicationOnly);

    public static INativeBindings CurrentBindings {
      get {
        var ret = Implementation.Value;
        if (ret == null) {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    private static INativeBindings CreateNativeBindings() {
#if NETSTANDARD1_2
      return null;
#else
      return new NativeBindings();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly() {
      return new NotImplementedException(
        "This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
