#include <tiffio.h>
#include <vector>
#include <iostream>

using namespace std;

TIFF* Load_image()
{
	//	TIFF* MultiPageTiff = TIFFOpen("E:\\storm_data\\test.tif", "r");
	//	TIFF* MultiPageTiff = TIFFOpen("F:\\Projects\\Project_Storm\\data\\spots_snr_5_matlab.tif", "r");
	TIFF* MultiPageTiff = TIFFOpen("F:\\Projects\\project_storm_data\\SD_2.2\\spots_snr_9.tif", "r");
	
	if (MultiPageTiff == NULL)
		return NULL;

	uint32 imagelength, imagewidth;

	uint16 i = 0;
	uint16 j = 0;

	j = TIFFCurrentDirectory(MultiPageTiff);
	cout << "current directory = " << j << endl;
		
	TIFFGetField(MultiPageTiff, TIFFTAG_IMAGEWIDTH, &imagewidth);
	cout << "imagewidth = " << imagewidth << endl;
	TIFFGetField(MultiPageTiff, TIFFTAG_IMAGELENGTH, &imagelength);
	cout << "imageheight = " << imagelength << endl;
	
	// TIFFNumberOfDirectories() does not work properly at all times, tested with different datasets
	int dircount = 0;
	do
	{
	    dircount++;
	} while (TIFFReadDirectory(MultiPageTiff));
	cout << "amount directories = " << dircount << endl;
	
	return MultiPageTiff;
}