using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using SafeApp.NativeBindings;
using SafeApp.Utilities;

// ReSharper disable ConvertToLocalFunction

namespace SafeApp.Misc {
  public static class NativeUtils {
    private static readonly INativeBindings NativeBindings = DependencyResolver.CurrentBindings;

    public static Task<List<byte>> Sha3HashAsync(List<byte> source) {
      var tcs = new TaskCompletionSource<List<byte>>();
      var sourcePtr = source.ToIntPtr();
      Sha3HashCb callback = (_, result, digestPtr, digestLen) => {
        if (result.ErrorCode != 0) {
          tcs.SetException(result.ToException());
          return;
        }

        tcs.SetResult(digestPtr.ToList<byte>(digestLen));
      };

      NativeBindings.Sha3Hash(sourcePtr, (IntPtr)source.Count, callback);
      Marshal.FreeHGlobal(sourcePtr);

      return tcs.Task;
    }
  }
}
