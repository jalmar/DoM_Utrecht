#include "profiling_ui.h"
#include <iostream>
#include <qfiledialog.h>

#include "transformations.h"
#include "info.h"
#include "convolution.h"

#ifdef __APPLE__
#include <OpenCL/opencl.h>
#else
#include <CL/cl.h>
//#include <CL/opencl.h>
#endif

using namespace std;

#define CL_CHECK(_expr)                                                         \
   do {                                                                         \
     cl_int _err = _expr;                                                       \
     if (_err == CL_SUCCESS)                                                    \
       break;                                                                   \
     fprintf(stderr, "OpenCL Error: '%s' returned %d!\n", #_expr, (int)_err);   \
     abort();                                                                   \
      } while (0)

#define CL_CHECK_ERR(_expr)                                                     \
   ({                                                                           \
     cl_int _err = CL_INVALID_VALUE;                                            \
     typeof(_expr) _ret = _expr;                                                \
     if (_err != CL_SUCCESS) {                                                  \
       fprintf(stderr, "OpenCL Error: '%s' returned %d!\n", #_expr, (int)_err); \
       abort();                                                                 \
	      }                                                                     \
     _ret;                                                                      \
   })

cl_platform_id platforms[2];
cl_device_id devices[4];

profiling_ui::profiling_ui(QWidget *parent)
	: QMainWindow(parent)
{
	ui.setupUi(this);
	
	cl_uint platforms_n = 0;
	CL_CHECK(clGetPlatformIDs(2, platforms, &platforms_n));

	for (int i = 0; i<platforms_n; i++)
	{
		char buffer[10240];
		CL_CHECK(clGetPlatformInfo(platforms[i], CL_PLATFORM_NAME, 10240, buffer, NULL));
		ui.comboBoxSelectPlatform->addItem(QIcon("d:\\openCL_logo.ico"), buffer);
	}

	cl_uint devices_n = 0;
	CL_CHECK(clGetDeviceIDs(platforms[ui.comboBoxSelectPlatform->currentIndex()], CL_DEVICE_TYPE_ALL, 100, devices, &devices_n));
	for (int i = 0; i < devices_n; i++)
	{
		char buffer[1024];
		CL_CHECK(clGetDeviceInfo(devices[i], CL_DEVICE_NAME, sizeof(buffer), buffer, NULL));
		ui.comboBoxSelectDevice->addItem(QIcon("d:\\gpu_icon_2.ico"), buffer);
	}
	
	//Set transformation bindings
	ui.comboBoxTransformationType->addItem(Transformations::EnumToString(TransformationType::Rigid));
	ui.comboBoxTransformationType->addItem(Transformations::EnumToString(TransformationType::Affine));
	
	//SET bindings
	QObject::connect(ui.actionExit, SIGNAL(triggered()), this, SLOT(close()));

	QObject::connect(ui.comboBoxSelectPlatform, SIGNAL(currentIndexChanged(QString)), this, SLOT(ComboBoxSelectPlatform_onCurrentIndexChanged()));
	QObject::connect(ui.comboBoxSelectDevice, SIGNAL(currentIndexChanged(QString)), this, SLOT(ComboBoxSelectDevice_onCurrentIndexChanged()));
	QObject::connect(ui.comboBoxTransformationType, SIGNAL(currentIndexChanged(QString)), this, SLOT(ComboBoxTransformationType_onCurrentIndexChanged()));
}

profiling_ui::~profiling_ui()
{

}

//Platform-dll -> on-changed -> retrieve-device-list(selected-platform-id) -> fill=device-dll
//PlatformCombox_SelectedIndexChanged

void GetDevicesByPlatform(cl_platform_id platform_id)
{

}

void profiling_ui::ComboBoxSelectPlatform_onCurrentIndexChanged()
{
	cout << "Selected platform : " << ui.comboBoxSelectPlatform->currentText().toStdString() << endl;
	
	int index = ui.comboBoxSelectPlatform->currentIndex();

	cl_uint devices_n = 0;

	CL_CHECK(clGetDeviceIDs(platforms[index], CL_DEVICE_TYPE_ALL, 100, devices, &devices_n));
	for (int i = 0; i < devices_n; i++)
	{
		char buffer[1024];
		CL_CHECK(clGetDeviceInfo(devices[i], CL_DEVICE_NAME, sizeof(buffer), buffer, NULL));
		ui.comboBoxSelectDevice->addItem(buffer);
	}

	//GetDevicesByPlatform(platforms[index]);
}

void profiling_ui::ComboBoxSelectDevice_onCurrentIndexChanged()
{
	cout << "Selected platform : " << ui.comboBoxSelectDevice->currentText().toStdString() << endl;
}

void profiling_ui::on_pushButtonPlatformListInfo_clicked()
{
	cout << "=== Platform info" << endl;
	
	cl_platform_id platform_id = platforms[ui.comboBoxSelectPlatform->currentIndex()];

	Info::ListPlatformInfo(platform_id);
}

void profiling_ui::on_pushButtonDeviceListInfo_clicked()
{
	cout << "=== Device info" << endl;
	
	cl_device_id device_id = devices[ui.comboBoxSelectDevice->currentIndex()];

	Info::ListDeviceInfo(device_id);
}

void profiling_ui::on_pushButtonCalculate_clicked()
{
	cout << "calculating..." << endl;
	float transformation[16] = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
	
	float dimensionX = ui.lineEditImageDimensionX->text().toFloat();
	float dimensionY = ui.lineEditImageDimensionY->text().toFloat();
	float dimensionZ = ui.lineEditImageDimensionZ->text().toFloat();

	float translationX = ui.lineEditTranslationX->text().toFloat();
	float translationY = ui.lineEditTranslationY->text().toFloat();
	float translationZ = ui.lineEditTranslationZ->text().toFloat();

	Transformations::GetTransformation(TransformationType::Affine, dimensionX, dimensionY, dimensionZ, translationX, translationY, translationZ, transformation);
	//TODO set transformation

	//TODO determine the ComputeContext
	//var context = new ComputeContext(_selectedComputeDevice.Type, new ComputeContextPropertyList(_selectedComputePlatform), null, IntPtr.Zero);
	new convolution(platforms[ui.comboBoxSelectPlatform->currentIndex()], devices[ui.comboBoxSelectDevice->currentIndex()], transformation);
	//CalculateConvolution();
}

void profiling_ui::ComboBoxTransformationType_onCurrentIndexChanged()
{
	QString current_text = ui.comboBoxTransformationType->currentText();
	cout << "TransformationType set too : " << current_text.toStdString() << endl;
}

void profiling_ui::on_pushButtonSelectSourceFile_clicked()
{
	QString filename = QFileDialog::getOpenFileName(
		NULL,
		"Open tiff data file",
		QDir::currentPath(),
		"Image data files (*.tif; *.tiff; *.TIF; *.TIFF)");
	
	ui.lineEditSelectSourceFile->setText(filename);
}

void profiling_ui::on_pushButtonSaveOutputFile_clicked()
{
	QString filename = QFileDialog::getSaveFileName(
		NULL,
		"Open tiff data file",
		QDir::currentPath(),
		"Image data files (*.tif; *.tiff; *.TIF; *.TIFF)");

	ui.lineEditSaveOutputFile->setText(filename);
}

void profiling_ui::on_pushButtonSelectSourceDir_clicked()
{
	QString dirname = QFileDialog::getExistingDirectory(
		this,
		"Select image data directory as source",
		QDir::currentPath());

	ui.lineEditSelectSourceDir->setText(dirname);
	
}

void profiling_ui::on_pushButtonSaveOutputDir_clicked()
{
	QString dirname = QFileDialog::getExistingDirectory(
		this,
		"Select image data directory for saving",
		QDir::currentPath());

	ui.lineEditSaveOutputDir->setText(dirname);
}

void profiling_ui::on_radioButtonSingleFile_clicked()
{
	ui.groupBoxMultipleFiles->setEnabled(false);
	ui.groupBoxSingleFiles->setEnabled(true);

	if (ui.radioButtonSingleFile->isChecked())
	{
		cout << "Single file mode selected" << endl;
	}
}

void profiling_ui::on_radioButtonMultipleFile_clicked()
{
	ui.groupBoxMultipleFiles->setEnabled(true);
	ui.groupBoxSingleFiles->setEnabled(false);

	if (ui.radioButtonMultipleFile->isChecked())
	{
		cout << "Multiple files mode selected" << endl;
	}
}