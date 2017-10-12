using System.Threading.Tasks;
using SafeApp.MData;
using SafeApp.NativeBindings;
using SafeApp.Utilities;

// ReSharper disable ConvertToLocalFunction

namespace SafeApp {
  public static class AccessContainer {
    private static readonly INativeBindings NativeBindings = DependencyResolver.CurrentBindings;

    public static Task<NativeHandle> GetMDataInfoAsync(string containerId) {
      var tcs = new TaskCompletionSource<NativeHandle>();

      AccessContainerGetContainerMDataInfoCb callback = (_, result, mdataInfoH) => {
        if (result.ErrorCode != 0) {
          tcs.SetException(result.ToException());
          return;
        }

        tcs.SetResult(new NativeHandle(mdataInfoH, MDataInfo.FreeAsync));
      };

      NativeBindings.AccessContainerGetContainerMDataInfo(Session.AppPtr, containerId, callback);

      return tcs.Task;
    }
  }
}
