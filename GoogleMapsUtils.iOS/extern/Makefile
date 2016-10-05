IOS_GIT_BRANCH=master
XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
WORKSPACE=GoogleMapsUtils.xcworkspace
WORKSPACE_DIR=ios/google-maps-ios-utils/workspace
SCHEME=GoogleMapsUtils
SCHEME_FILE=GoogleMapsUtils.xcscheme
SCHEME_DIR=GoogleMapsUtils.xcworkspace/xcshareddata/xcschemes
BUILD_ROOT=build/Build/Products
VALID_ARCHS="armv7 armv7s arm64 i386 x86_64"

all: clean libGoogleMapsUtils.a

Podfile.lock:
	mkdir -p ios
	cd ios && git clone git@github.com:googlemaps/google-maps-ios-utils.git
	cd ios/google-maps-ios-utils && git checkout $(IOS_GIT_BRANCH)
	cd $(WORKSPACE_DIR) && pod install
	mkdir -p $(WORKSPACE_DIR)/$(SCHEME_DIR) && cp $(SCHEME_FILE) $(WORKSPACE_DIR)/$(SCHEME_DIR)

libGoogleMapsUtils-i386.a: Podfile.lock
	cd $(WORKSPACE_DIR) && $(XBUILD) -workspace $(WORKSPACE) -scheme $(SCHEME) -sdk iphonesimulator -arch i386 -configuration Release VALID_ARCHS=$(VALID_ARCHS) ONLY_ACTIVE_ARCH=NO EFFECTIVE_PLATFORM_NAME="-iphonesimulator" -derivedDataPath build clean build	
	mv $(WORKSPACE_DIR)/$(BUILD_ROOT)/Release-iphonesimulator/libGoogleMapsUtils.a $@

libGoogleMapsUtils-x86_64.a: Podfile.lock
	cd $(WORKSPACE_DIR) && $(XBUILD) -workspace $(WORKSPACE) -scheme $(SCHEME) -sdk iphonesimulator -arch x86_64 -configuration Release VALID_ARCHS=$(VALID_ARCHS) ONLY_ACTIVE_ARCH=NO EFFECTIVE_PLATFORM_NAME="-iphonesimulator" -derivedDataPath build clean build
	mv $(WORKSPACE_DIR)/$(BUILD_ROOT)/Release-iphonesimulator/libGoogleMapsUtils.a $@

libGoogleMapsUtils-armv7.a: Podfile.lock
	cd $(WORKSPACE_DIR) && $(XBUILD) -workspace $(WORKSPACE) -scheme $(SCHEME) -sdk iphoneos -arch armv7 -configuration Release -derivedDataPath build clean build
	mv $(WORKSPACE_DIR)/$(BUILD_ROOT)/Release-iphoneos/libGoogleMapsUtils.a $@

libGoogleMapsUtils-arm64.a: Podfile.lock
	cd $(WORKSPACE_DIR) && $(XBUILD) -workspace $(WORKSPACE) -scheme $(SCHEME) -sdk iphoneos -arch arm64 -configuration Release -derivedDataPath build clean build
	mv $(WORKSPACE_DIR)/$(BUILD_ROOT)/Release-iphoneos/libGoogleMapsUtils.a $@

libGoogleMapsUtils.a: libGoogleMapsUtils-i386.a libGoogleMapsUtils-x86_64.a libGoogleMapsUtils-armv7.a libGoogleMapsUtils-arm64.a 
	lipo -create -output $@ $^	

clean:
	rm -rf ios

.PHONY: all clean