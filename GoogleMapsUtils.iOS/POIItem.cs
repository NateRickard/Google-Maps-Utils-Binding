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
			this.position = new CLLocationCoordinate2D (latitude, longitude);
			Name = name;
		}

		public POIItem (CLLocationCoordinate2D position, string name)
		{
			this.position = position;
			Name = name;
		}

		CLLocationCoordinate2D position;

		public CLLocationCoordinate2D Position {
			get {
				return position;
			}
		}

		public string Name
		{
			get;
			private set;
		}
	}
}