# safe_app_csharp

[![NuGet](https://img.shields.io/nuget/v/MaidSafe.SafeApp.svg)](https://www.nuget.org/packages/MaidSafe.SafeApp/0.0.1)

safe_app CSharp Library. Currently supports
- Xamarin.Android ( >=4.1.2. ABI: armeabi-v7a, x86)
- Xamarin.iOS ( >= 1.0, ABI: ARM64, x64)
- netstandard1.2 (for usage via portable libs)

**Note**: Just adding a package dependency to the Portable Library will not be enough. Package also needs to be added to the corresponding app projects(iOS/Android) for platform specific Native libraries to get included.

| [MaidSafe website](https://maidsafe.net) | [SAFE Dev Forum](https://forum.safedev.org) | [SAFE Network Forum](https://safenetforum.org) |
|:----:|:----:|:----:|


# TODO
- Extend Native API Scope to full Alpha-2 client APIs.
- Tests and Mock integration.
- Add other compatible target frameworks for Desktop-Win/Xamarin.Mac/...
- Managed API Docs.
- Code Samples.

## License

Licensed under either of

* the MaidSafe.net Commercial License, version 1.0 or later ([LICENSE](LICENSE))
* the General Public License (GPL), version 3 ([COPYING](COPYING) or http://www.gnu.org/licenses/gpl-3.0.en.html)

at your option.

## Contribution

Unless you explicitly state otherwise, any contribution intentionally submitted for inclusion in the
work by you, as defined in the MaidSafe Contributor Agreement ([CONTRIBUTOR](CONTRIBUTOR)), shall be
dual licensed as above, and you agree to be bound by the terms of the MaidSafe Contributor Agreement.
