#ifndef PROFILING_H
#define PROFILING_H

#include <QtWidgets/QMainWindow>
#include "ui_qt_test_project.h"

class Qt_test_project : public QMainWindow
{
	Q_OBJECT

public:
	Qt_test_project(QWidget *parent = 0);
	~Qt_test_project();


	//protected:
	//	void contextMenuEvent(QContextMenuEvent *event);

	private slots:
	void on_pushButton_clicked();
	void on_lineEdit_clicked();
	void on_radioButtonSingleFile_clicked();
	void on_radioButtonMultipleFile_clicked();
	void on_pushButtonSelectSourceFile_clicked();
	void on_pushButtonSaveOutputFile_clicked();
	void on_pushButtonSelectSourceDir_clicked();
	void on_pushButtonSaveOutputDir_clicked();

private:
	Ui::profiling ui;
};

#endif // QT_TEST_PROJECT_H
