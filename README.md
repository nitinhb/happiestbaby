# happiestbaby
Automation Framework

# Installation guide
1. Download Visual studio with Xamarin from below link.

		https://www.xamarin.com/download
		
2. Installation guide refer 

   1.For Mac: https://docs.microsoft.com/en-us/visualstudio/mac/installation
	 
   2.For Windows: https://developer.xamarin.com/guides/ios/getting_started/installation/windows

# To run automated tests, follow below steps:

1.Clone the latest code from git repository

	Steps
		1.Git clone  https://github.com/nitinhb/happiestbaby.git
		2.Cd happiestbaby
		3.Git fetch && git checkout dev-master

2.Open the cloned project in step 1 in visual studio.

3.Clean and Build the project once.

4.Connect the Android device to mac/windows machine.

5.Make sure developer option and USB debugging is enabled in connected android device.

6.To run the tests using visual studio 

		 On windows: Test => run => all Tests 
     
		 On mac: run test units. 

NOTE: All the configurable fields like email id, password are present in app.config file present in root directory.

# To open mobile screen on windows/mac machine follow below steps

1.Connect the Android device to mac/windows machine.

2.Make sure developer option and USB debugging is enabled in connected android device.

3.In windows/mac machine open chrome browser and open below url

		https://chrome.google.com/webstore?utm_source=chrome-ntp-icon

4.Search for vysor and install it as chrome extension.

5.Open visor from chrome and search for connected device and select view device.
