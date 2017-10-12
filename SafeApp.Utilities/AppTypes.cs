using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SafeApp.Utilities {
  public enum MDataAction {
    kInsert,
    kUpdate,
    kDelete,
    kManagePermissions
  }

  public struct FfiResult {
    public int ErrorCode;
    public string Description;
  }

  public struct AppExchangeInfo {
    public string Id;
    public string Scope;
    public string Name;
    public string Vendor;
  }

  public struct PermissionSet {
    [MarshalAs(UnmanagedType.U1)] public bool Read;
    [MarshalAs(UnmanagedType.U1)] public bool Insert;
    [MarshalAs(UnmanagedType.U1)] public bool Update;
    [MarshalAs(UnmanagedType.U1)] public bool Delete;
    [MarshalAs(UnmanagedType.U1)] public bool ManagePermissions;
  }

  public struct ContainerPermissions {
    public string ContainerName;
    public PermissionSet Access;
  }

  public struct AuthReq {
    public AppExchangeInfo AppExchangeInfo;
    public bool AppContainer;
    public List<ContainerPermissions> Containers;
  }

  public struct AuthReqFfi {
    public AppExchangeInfo AppExchangeInfo;
    [MarshalAs(UnmanagedType.U1)] public bool AppContainer;
    public IntPtr ContainersArrayPtr;
    public IntPtr ContainersLen;
    public IntPtr ContainersCap;
  }

  public struct AppKeys {
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public byte[] OwnerKeys;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public byte[] EncKey;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public byte[] SignPk;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] public byte[] SignSk;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public byte[] EncPk;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public byte[] EncSk;
  }

  public struct AccessContInfo {
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public byte[] Id;
    public ulong Tag;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)] public byte[] SymNonce;
  }

  public struct AuthGrantedFfi {
    public AppKeys AppKeys;
    public AccessContInfo AccessContainer;
    public IntPtr BootStrapConfigPtr;
    public IntPtr BootStrapConfigLen;
    public IntPtr BootStrapConfigCap;
  }

  public struct AuthGranted {
    public AppKeys AppKeys;
    public AccessContInfo AccessContainer;
    public List<byte> BootStrapConfig;
  }

  public struct DecodeIpcResult {
    public AuthGranted? AuthGranted;
    public (IntPtr, IntPtr) UnRegAppInfo;
    public uint? ContReqId;
    public uint? ShareMData;
    public bool? Revoked;
  }
}
