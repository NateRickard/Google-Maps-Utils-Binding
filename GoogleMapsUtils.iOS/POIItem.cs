using CoreLocation;
using Foundation;

namespace GMCluster
{
	/// <summary>
	/// Point of Interest Item which implements the GMUClusterItem protocol.
	/// </summary>
	public class POIItem : NSObject, IGMUClusterItem
	{
		public POIItem (double latitude, double longitude, string name)
		{
			Position = new CLLocationCoordinate2D (latitude, longitude);
			Name = name;
		}

		public POIItem (CLLocationCoordinate2D position, string name)
		{
			Position = position;
			Name = name;
		}

		public CLLocationCoordinate2D Position {
			get;
			private set;
		}

		public string Name
		{
			get;
			private set;
		}
	}
}