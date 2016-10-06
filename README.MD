## Google Maps Utils Binding

This is a set of Xamarin bindings for the [Utility Library for Google Maps SDK for iOS][0] (google-maps-ios-utils CocoaPod).


## Building

To build, run `make` in the `extern` directory. Then open `GoogleMapsUtils.sln` in Xamarin Studio and build.

## Using

Take the generated `GoogleMapsUtils.iOS.dll` from `bin/Debug` (or from whatever build config was used) and add a reference to it in your Xamarin.iOS project.

The library can be used as in the following sample (adapted from the Swift sample included with the SDK).  Note that you'll also need to initialize the Google MapView and also set the API key in your AppDelegate.


```
public double GetRandomNumber (double minimum, double maximum)
{
	Random random = new Random ();
	return random.NextDouble () * (maximum - minimum) + minimum;
}

public override void ViewDidLoad ()
{
	base.ViewDidLoad ();

	var kClusterItemCount = 10000;
	var kCameraLatitude = -33.8;
	var kCameraLongitude = 151.2;
	var extent = 0.2;

	var googleMapView = new Google.Maps.MapView (); //use the real mapview init'd somewhere else instead of this
	var iconGenerator = new GMUDefaultClusterIconGenerator ();
	var algorithm = new GMUNonHierarchicalDistanceBasedAlgorithm ();
	var renderer = new GMUDefaultClusterRenderer (googleMapView, iconGenerator);
	var clusterManager = new GMUClusterManager (googleMapView, algorithm, renderer);

	for (var i = 0; i <= kClusterItemCount; i++) {
		var lat = kCameraLatitude + extent * GetRandomNumber (-1.0, 1.0);

		var lng = kCameraLongitude + extent * GetRandomNumber (-1.0, 1.0);

		var name = $"Item {i}";

		var item = new POIItem (new CLLocationCoordinate2D (lat, lng), name);

		clusterManager.AddItem (item);
	}

	clusterManager.Cluster ();

	...
}
```

Implement `IGMUClusterManagerDelegate` in your ViewController in order to receive callbacks.


## Requirements

* Xamarin Studio 6.0+
* Xcode 7+ with Xcode command line build tools installed
* CocoaPods gem installed/configured
* A public key created and added to your Github account - [instructions](https://help.github.com/articles/generating-an-ssh-key/)
* To use the library, you'll need a Google Maps API key


### Todo

* Sample?
* Test this... all the above sample code compiles but is not verified in a running sample yet (sorry!)


[0]:https://github.com/googlemaps/google-maps-ios-utils