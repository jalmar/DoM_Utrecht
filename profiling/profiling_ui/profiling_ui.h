#ifndef PROFILING_UI_H
#define PROFILING_UI_H

#include <QtWidgets/QMainWindow>
#include "ui_profiling_ui.h"
#include <CL/cl.h>

class profiling_ui : public QMainWindow
{
	Q_OBJECT

public:
	profiling_ui(QWidget *parent = 0);
	~profiling_ui();

private slots:
	void on_radioButtonSingleFile_clicked();
	void on_radioButtonMultipleFile_clicked();
	
	void on_pushButtonSelectSourceFile_clicked();
	void on_pushButtonSaveOutputFile_clicked();
	void on_pushButtonSelectSourceDir_clicked();
	void on_pushButtonSaveOutputDir_clicked();
	void on_pushButtonPlatformListInfo_clicked();
	void on_pushButtonDeviceListInfo_clicked();
	
	void ComboBoxSelectPlatform_onCurrentIndexChanged();
	void ComboBoxSelectDevice_onCurrentIndexChanged();
	void ComboBoxTransformationType_onCurrentIndexChanged();
	
	void on_pushButtonCalculate_clicked();

private:
	Ui::profiling_uiClass ui;
	void initBindings(Ui::profiling_uiClass ui);

};

#endif // PROFILING_UI_H
