using System.Threading.Tasks;
using SafeApp.NativeBindings;
using SafeApp.Utilities;

// ReSharper disable ConvertToLocalFunction

namespace SafeApp.MData {
  public static class MDataPermissionSet {
    private static readonly INativeBindings NativeBindings = DependencyResolver.CurrentBindings;

    public static Task AllowAsync(NativeHandle permissionSetH, MDataAction allowAction) {
      var tcs = new TaskCompletionSource<object>();
      MDataPermissionSetAllowCb callback = (_, result) => {
        if (result.ErrorCode != 0) {
          tcs.SetException(result.ToException());
          return;
        }

        tcs.SetResult(null);
      };

      NativeBindings.MDataPermissionSetAllow(Session.AppPtr, permissionSetH, allowAction, callback);

      return tcs.Task;
    }

    public static Task FreeAsync(ulong permissionSetH) {
      var tcs = new TaskCompletionSource<object>();
      MDataPermissionSetFreeCb callback = (_, result) => {
        if (result.ErrorCode != 0) {
          tcs.SetException(result.ToException());
          return;
        }

        tcs.SetResult(null);
      };

      NativeBindings.MDataPermissionSetFree(Session.AppPtr, permissionSetH, callback);

      return tcs.Task;
    }

    public static Task<NativeHandle> NewAsync() {
      var tcs = new TaskCompletionSource<NativeHandle>();

      MDataPermissionSetNewCb callback = (_, result, permissionSetH) => {
        if (result.ErrorCode != 0) {
          tcs.SetException(result.ToException());
          return;
        }

        tcs.SetResult(new NativeHandle(permissionSetH, FreeAsync));
      };

      NativeBindings.MDataPermissionSetNew(Session.AppPtr, callback);

      return tcs.Task;
    }
  }
}
