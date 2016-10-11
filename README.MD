## Google Maps Utils Binding

This is a set of Xamarin bindings for the [Utility Library for Google Maps SDK for iOS][0] (google-maps-ios-utils CocoaPod).


## Building

To build, run `make` in the `extern` directory. Then open `GoogleMapsUtils.sln` in Xamarin Studio and build.

## Using

Take the generated `GoogleMapsUtils.iOS.dll` from `bin/Debug` (or from whatever build config was used) and add a reference to it in your Xamarin.iOS project.

The library can be used as in the included sample (adapted from the Swift sample included with the SDK).  **Note** that you'll also need to initialize Google Maps with an API key in the AppDelegate.


## Requirements

* Xamarin Studio 6.0+
* Xcode 7+ with Xcode command line build tools installed
* CocoaPods gem installed/configured
* A public key created and added to your Github account - [instructions](https://help.github.com/articles/generating-an-ssh-key/)
* To use the library, you'll need a Google Maps API key


[0]:https://github.com/googlemaps/google-maps-ios-utils