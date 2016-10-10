using System;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using UIKit;
using Google.Maps;

namespace GMCluster
{
	// @protocol GMUClusterItem <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface GMUClusterItem
	{
		// @required @property (readonly, nonatomic) CLLocationCoordinate2D position;
		[Abstract]
		[Export ("position")]
		CLLocationCoordinate2D Position { get; }
	}

	interface IGMUClusterItem { }

	// @protocol GMUCluster <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface GMUCluster
	{
		// @required @property (readonly, nonatomic) CLLocationCoordinate2D position;
		[Abstract]
		[Export ("position")]
		CLLocationCoordinate2D Position { get; }

		// @required @property (readonly, nonatomic) NSUInteger count;
		[Abstract]
		[Export ("count")]
		nuint Count { get; }

		// @required @property (readonly, nonatomic) NSArray<id<GMUClusterItem>> * _Nonnull items;
		[Abstract]
		[Export ("items")]
		IGMUClusterItem [] Items { get; }
	}

	interface IGMUCluster { }

	// @protocol GMUClusterAlgorithm <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface GMUClusterAlgorithm
	{
		// @required -(void)addItems:(NSArray<id<GMUClusterItem>> * _Nonnull)items;
		[Abstract]
		[Export ("addItems:")]
		void AddItems (IGMUClusterItem [] items);

		// @required -(void)removeItem:(id<GMUClusterItem> _Nonnull)item;
		[Abstract]
		[Export ("removeItem:")]
		void RemoveItem (IGMUClusterItem item);

		// @required -(void)clearItems;
		[Abstract]
		[Export ("clearItems")]
		void ClearItems ();

		// @required -(NSArray<id<GMUCluster>> * _Nonnull)clustersAtZoom:(float)zoom;
		[Abstract]
		[Export ("clustersAtZoom:")]
		IGMUCluster [] ClustersAtZoom (float zoom);
	}

	interface IGMUClusterAlgorithm { };

	// @protocol GMUClusterIconGenerator <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface GMUClusterIconGenerator
	{
		// @required -(UIImage *)iconForSize:(NSUInteger)size;
		[Abstract]
		[Export ("iconForSize:")]
		UIImage IconForSize (nuint size);
	}

	interface IGMUClusterIconGenerator { }

	// @protocol GMUClusterRenderer <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface GMUClusterRenderer
	{
		// @required -(void)renderClusters:(NSArray<id<GMUCluster>> * _Nonnull)clusters;
		[Abstract]
		[Export ("renderClusters:")]
		void RenderClusters (IGMUCluster [] clusters);

		// @required -(void)update;
		[Abstract]
		[Export ("update")]
		void Update ();
	}

	interface IGMUClusterRenderer { };

	// @protocol GMUClusterManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface GMUClusterManagerDelegate
	{
		// @optional -(void)clusterManager:(GMUClusterManager * _Nonnull)clusterManager didTapCluster:(id<GMUCluster> _Nonnull)cluster;
		[Export ("clusterManager:didTapCluster:")]
		void DidTapCluster (GMUClusterManager clusterManager, IGMUCluster cluster);

		// @optional -(void)clusterManager:(GMUClusterManager * _Nonnull)clusterManager didTapClusterItem:(id<GMUClusterItem> _Nonnull)clusterItem;
		[Export ("clusterManager:didTapClusterItem:")]
		void DidTapClusterItem (GMUClusterManager clusterManager, IGMUClusterItem clusterItem);
	}

	interface IGMUClusterManagerDelegate { }

	// @interface GMUClusterManager : NSObject
	[BaseType (typeof (NSObject))]
	interface GMUClusterManager
	{
		// -(instancetype _Nonnull)initWithMap:(id)mapView algorithm:(id<GMUClusterAlgorithm> _Nonnull)algorithm renderer:(id<GMUClusterRenderer> _Nonnull)renderer;
		[Export ("initWithMap:algorithm:renderer:")]
		IntPtr Constructor (NSObject mapView, IGMUClusterAlgorithm algorithm, IGMUClusterRenderer renderer);

		// @property (readonly, nonatomic) id<GMUClusterAlgorithm> _Nonnull algorithm;
		[Export ("algorithm")]
		IGMUClusterAlgorithm Algorithm { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		IGMUClusterManagerDelegate Delegate { get; }

		// @property (readonly, nonatomic, weak) id<GMUClusterManagerDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; }

		[Wrap ("WeakMapDelegate")]
		[NullAllowed]
		NSObject MapDelegate { get; }

		// @property (readonly, nonatomic, weak) id _Nullable mapDelegate;
		[NullAllowed, Export ("mapDelegate", ArgumentSemantic.Weak)]
		NSObject WeakMapDelegate { get; }

		// -(void)setDelegate:(id<GMUClusterManagerDelegate> _Nullable)delegate mapDelegate:(id _Nullable)mapDelegate;
		[Export ("setDelegate:mapDelegate:")]
		void SetDelegate ([NullAllowed] IGMUClusterManagerDelegate @delegate, [NullAllowed] NSObject mapDelegate);

		// -(void)addItem:(id<GMUClusterItem> _Nonnull)item;
		[Export ("addItem:")]
		void AddItem (IGMUClusterItem item);

		// -(void)addItems:(NSArray<id<GMUClusterItem>> * _Nonnull)items;
		[Export ("addItems:")]
		void AddItems (IGMUClusterItem [] items);

		// -(void)removeItem:(id<GMUClusterItem> _Nonnull)item;
		[Export ("removeItem:")]
		void RemoveItem (IGMUClusterItem item);

		// -(void)clearItems;
		[Export ("clearItems")]
		void ClearItems ();

		// -(void)cluster;
		[Export ("cluster")]
		void Cluster ();
	}


	// @interface GMUDefaultClusterIconGenerator : NSObject <GMUClusterIconGenerator>
	[BaseType (typeof (NSObject))]
	interface GMUDefaultClusterIconGenerator : GMUClusterIconGenerator
	{
		// -(instancetype _Nonnull)initWithBuckets:(NSArray<NSNumber *> * _Nonnull)buckets;
		[Export ("initWithBuckets:")]
		IntPtr Constructor (NSNumber [] buckets);

		// -(instancetype _Nonnull)initWithBuckets:(NSArray<NSNumber *> * _Nonnull)buckets backgroundImages:(NSArray<UIImage *> * _Nonnull)backgroundImages;
		[Export ("initWithBuckets:backgroundImages:")]
		IntPtr Constructor (NSNumber [] buckets, UIImage [] backgroundImages);

		// -(UIImage * _Nonnull)iconForSize:(NSUInteger)size;
		[Export ("iconForSize:")]
		UIImage IconForSize (nuint size);
	}

	// @interface GMUDefaultClusterRenderer : NSObject <GMUClusterRenderer>
	[BaseType (typeof (NSObject))]
	interface GMUDefaultClusterRenderer : GMUClusterRenderer
	{
		// @property (nonatomic) BOOL animatesClusters;
		[Export ("animatesClusters")]
		bool AnimatesClusters { get; set; }

		// @property (nonatomic) int zIndex;
		[Export ("zIndex")]
		int ZIndex { get; set; }

		// -(instancetype _Nonnull)initWithMapView:(GMSMapView * _Nonnull)mapView clusterIconGenerator:(id<GMUClusterIconGenerator> _Nonnull)iconGenerator;
		[Export ("initWithMapView:clusterIconGenerator:")]
		IntPtr Constructor (MapView mapView, IGMUClusterIconGenerator iconGenerator);

		// -(BOOL)shouldRenderAsCluster:(id<GMUCluster> _Nonnull)cluster atZoom:(float)zoom;
		[Export ("shouldRenderAsCluster:atZoom:")]
		bool ShouldRenderAsCluster (IGMUCluster cluster, float zoom);
	}

	// @interface GMUGridBasedClusterAlgorithm : NSObject <GMUClusterAlgorithm>
	[BaseType (typeof (NSObject))]
	interface GMUGridBasedClusterAlgorithm : GMUClusterAlgorithm
	{
	}

	// @interface GMUStaticCluster : NSObject <GMUCluster>
	[BaseType (typeof (NSObject))]
	interface GMUStaticCluster : GMUCluster
	{
		// -(instancetype _Nonnull)initWithPosition:(CLLocationCoordinate2D)position;
		[Export ("initWithPosition:")]
		IntPtr Constructor (CLLocationCoordinate2D position);

		// @property (readonly, nonatomic) CLLocationCoordinate2D position;
		[Export ("position")]
		CLLocationCoordinate2D Position { get; }

		// @property (readonly, nonatomic) NSUInteger count;
		[Export ("count")]
		nuint Count { get; }

		// @property (readonly, nonatomic) NSArray<id<GMUClusterItem>> * _Nonnull items;
		[Export ("items")]
		IGMUClusterItem [] Items { get; }

		// -(void)addItem:(id<GMUClusterItem> _Nonnull)item;
		[Export ("addItem:")]
		void AddItem (IGMUClusterItem item);

		// -(void)removeItem:(id<GMUClusterItem> _Nonnull)item;
		[Export ("removeItem:")]
		void RemoveItem (IGMUClusterItem item);
	}

	// @interface GMUWrappingDictionaryKey : NSObject <NSCopying>
	[BaseType (typeof (NSObject))]
	interface GMUWrappingDictionaryKey : INSCopying
	{
		// -(instancetype)initWithObject:(id)object;
		[Export ("initWithObject:")]
		IntPtr Constructor (NSObject @object);
	}

	// @protocol GQTPointQuadTreeItem <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface GQTPointQuadTreeItem
	{
		// @required -(GQTPoint)point;
		[Abstract]
		[Export ("point")]
		GQTPoint Point { get; }
	}

	interface IGQTPointQuadTreeItem { }

	// @interface GQTPointQuadTree : NSObject
	[BaseType (typeof (NSObject))]
	interface GQTPointQuadTree
	{
		// -(id)initWithBounds:(GQTBounds)bounds;
		[Export ("initWithBounds:")]
		IntPtr Constructor (GQTBounds bounds);

		// -(BOOL)add:(id<GQTPointQuadTreeItem>)item;
		[Export ("add:")]
		bool Add (IGQTPointQuadTreeItem item);

		// -(BOOL)remove:(id<GQTPointQuadTreeItem>)item;
		[Export ("remove:")]
		bool Remove (IGQTPointQuadTreeItem item);

		// -(void)clear;
		[Export ("clear")]
		void Clear ();

		// -(NSArray *)searchWithBounds:(GQTBounds)bounds;
		[Export ("searchWithBounds:")]
		NSObject [] SearchWithBounds (GQTBounds bounds);

		// -(NSUInteger)count;
		[Export ("count")]
		nuint Count { get; }
	}

	// @interface GQTPointQuadTreeChild : NSObject
	[BaseType (typeof (NSObject))]
	interface GQTPointQuadTreeChild
	{
		// -(void)add:(id<GQTPointQuadTreeItem>)item withOwnBounds:(GQTBounds)bounds atDepth:(NSUInteger)depth;
		[Export ("add:withOwnBounds:atDepth:")]
		void Add (IGQTPointQuadTreeItem item, GQTBounds bounds, nuint depth);

		// -(BOOL)remove:(id<GQTPointQuadTreeItem>)item withOwnBounds:(GQTBounds)bounds;
		[Export ("remove:withOwnBounds:")]
		bool Remove (IGQTPointQuadTreeItem item, GQTBounds bounds);

		// -(void)searchWithBounds:(GQTBounds)searchBounds withOwnBounds:(GQTBounds)ownBounds results:(NSMutableArray *)accumulator;
		[Export ("searchWithBounds:withOwnBounds:results:")]
		void SearchWithBounds (GQTBounds searchBounds, GQTBounds ownBounds, NSMutableArray accumulator);

		// -(void)splitWithOwnBounds:(GQTBounds)ownBounds atDepth:(NSUInteger)depth;
		[Export ("splitWithOwnBounds:atDepth:")]
		void SplitWithOwnBounds (GQTBounds ownBounds, nuint depth);
	}

	// @interface GMUNonHierarchicalDistanceBasedAlgorithm : NSObject <GMUClusterAlgorithm>
	[BaseType (typeof (NSObject))]
	interface GMUNonHierarchicalDistanceBasedAlgorithm : GMUClusterAlgorithm
	{
	}

	// @interface GMClusterHelper : NSObject
	[BaseType (typeof (NSObject))]
	interface GMClusterHelper
	{
		[Wrap ("WeakGmsHelperDelegate")]
		GMClusterHelperDelegate GmsHelperDelegate { get; set; }

		// @property (nonatomic, weak) id<GMClusterHelperDelegate> gmsHelperDelegate;
		[NullAllowed, Export ("gmsHelperDelegate", ArgumentSemantic.Weak)]
		NSObject WeakGmsHelperDelegate { get; set; }

		// @property (assign, nonatomic) BOOL isGridBased;
		[Export ("isGridBased")]
		bool IsGridBased { get; set; }

		// -(instancetype)initWith:(id)gMapView;
		[Export ("initWith:")]
		IntPtr Constructor (NSObject gMapView);

		// -(void)configureClusteringWithItems:(NSArray *)items Bucket:(NSArray<NSNumber *> *)buckets clusterImages:(NSArray<UIImage *> *)images;
		[Export ("configureClusteringWithItems:Bucket:clusterImages:")]
		void ConfigureClusteringWithItems (NSObject [] items, NSNumber [] buckets, UIImage [] images);

		// -(void)removeClusterManager;
		[Export ("removeClusterManager")]
		void RemoveClusterManager ();
	}

	// @protocol GMClusterHelperDelegate <NSObject>
	[BaseType (typeof (NSObject))]
	[Model]
	public partial interface GMClusterHelperDelegate
	{
		// @optional -(void)didTapMarker:(id)marker;
		[Export ("didTapMarker:")]
		void DidTapMarker (NSObject marker);

		// @optional -(void)didTapAtCoordinate:(id)coordinate;
		[Export ("didTapAtCoordinate:")]
		void DidTapAtCoordinate (NSObject coordinate);

		// @optional -(void)didTapCluster:(id)cluster;
		[Export ("didTapCluster:")]
		void DidTapCluster (NSObject cluster);
	}
}