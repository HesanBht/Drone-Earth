After Cloning the repository in order to be able to use it you need to take a few steps: 

1.	you need to import Cesium to your Unity project by:
going to “Edit>Project setting> Package Manager” and adding the following:
Name: Cesium
URL: https://unity.pkg.cesium.com
Scope(s): com.cesium.unity
2.	Goto “Windows>Package Manager> My Registries” and install “Cesium for Unity”
3.	Goto “Cesium>Cesium” and connect to your Cesium account
4.	In the token section click on Specify a token and insert your Google API
5.	In the Cesium Click on Add Blank 3D tiles tileset
6.	In the Hierarchy under CesiumGeoreference, go to Cesium3DTileset, Under Tileset Source Use “From URL” option, copy and paste the following URL and after the Key= use your Google API 
https://tile.googleapis.com/v1/3dtiles/root.json?key=YourAPI 
7.	You can insert the coordinates under CesiumGeoreference in the hierarchy or using the set location section in the top right corner in play time.

ENJOY 
