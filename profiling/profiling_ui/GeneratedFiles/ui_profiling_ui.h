/********************************************************************************
** Form generated from reading UI file 'profiling_ui.ui'
**
** Created by: Qt User Interface Compiler version 5.3.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_PROFILING_UI_H
#define UI_PROFILING_UI_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QComboBox>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenu>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QRadioButton>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_profiling_uiClass
{
public:
    QAction *actionAbout;
    QAction *actionExit;
    QAction *actionAsdasd;
    QWidget *centralWidget;
    QGroupBox *groupBox;
    QLabel *labelImageDimensions;
    QLabel *labelPixelSize;
    QLabel *labelTranslation;
    QComboBox *comboBoxTransformationType;
    QLineEdit *lineEditImageDimensionX;
    QLineEdit *lineEditPixelSize;
    QLineEdit *lineEditImageDimensionY;
    QLineEdit *lineEditImageDimensionZ;
    QLabel *labelImageDimensionsX;
    QLabel *labelImageDimensionsY;
    QLabel *labelImageDimensionsZ;
    QLineEdit *lineEditTranslationX;
    QLineEdit *lineEditTranslationY;
    QLineEdit *lineEditTranslationZ;
    QLabel *labelTranslationX;
    QLabel *labelTranslationY;
    QLabel *labelTranslationZ;
    QLabel *labelTransformationType;
    QGroupBox *groupBoxMultipleFiles;
    QPushButton *pushButtonSelectSourceDir;
    QPushButton *pushButtonSaveOutputDir;
    QLineEdit *lineEditSelectSourceDir;
    QLineEdit *lineEditSaveOutputDir;
    QLabel *labelSelectDevice;
    QComboBox *comboBoxSelectPlatform;
    QLabel *labelSelectPlatform;
    QGroupBox *groupBoxSingleFiles;
    QPushButton *pushButtonSelectSourceFile;
    QPushButton *pushButtonSaveOutputFile;
    QLineEdit *lineEditSelectSourceFile;
    QLineEdit *lineEditSaveOutputFile;
    QComboBox *comboBoxSelectDevice;
    QGroupBox *groupBoxRadioButtons;
    QRadioButton *radioButtonSingleFile;
    QRadioButton *radioButtonMultipleFile;
    QPushButton *pushButtonDeviceListInfo;
    QPushButton *pushButtonPlatformListInfo;
    QPushButton *pushButtonCalculate;
    QStatusBar *statusBar;
    QMenuBar *menuBar;
    QMenu *menuFile;

    void setupUi(QMainWindow *profiling_uiClass)
    {
        if (profiling_uiClass->objectName().isEmpty())
            profiling_uiClass->setObjectName(QStringLiteral("profiling_uiClass"));
        profiling_uiClass->resize(600, 680);
        profiling_uiClass->setMinimumSize(QSize(600, 680));
        profiling_uiClass->setMaximumSize(QSize(600, 680));
        actionAbout = new QAction(profiling_uiClass);
        actionAbout->setObjectName(QStringLiteral("actionAbout"));
        actionExit = new QAction(profiling_uiClass);
        actionExit->setObjectName(QStringLiteral("actionExit"));
        actionAsdasd = new QAction(profiling_uiClass);
        actionAsdasd->setObjectName(QStringLiteral("actionAsdasd"));
        centralWidget = new QWidget(profiling_uiClass);
        centralWidget->setObjectName(QStringLiteral("centralWidget"));
        groupBox = new QGroupBox(centralWidget);
        groupBox->setObjectName(QStringLiteral("groupBox"));
        groupBox->setGeometry(QRect(10, 160, 551, 191));
        labelImageDimensions = new QLabel(groupBox);
        labelImageDimensions->setObjectName(QStringLiteral("labelImageDimensions"));
        labelImageDimensions->setGeometry(QRect(20, 20, 131, 16));
        labelPixelSize = new QLabel(groupBox);
        labelPixelSize->setObjectName(QStringLiteral("labelPixelSize"));
        labelPixelSize->setGeometry(QRect(180, 20, 101, 16));
        labelTranslation = new QLabel(groupBox);
        labelTranslation->setObjectName(QStringLiteral("labelTranslation"));
        labelTranslation->setGeometry(QRect(180, 80, 121, 16));
        comboBoxTransformationType = new QComboBox(groupBox);
        comboBoxTransformationType->setObjectName(QStringLiteral("comboBoxTransformationType"));
        comboBoxTransformationType->setGeometry(QRect(368, 50, 160, 23));
        lineEditImageDimensionX = new QLineEdit(groupBox);
        lineEditImageDimensionX->setObjectName(QStringLiteral("lineEditImageDimensionX"));
        lineEditImageDimensionX->setGeometry(QRect(40, 50, 70, 23));
        lineEditPixelSize = new QLineEdit(groupBox);
        lineEditPixelSize->setObjectName(QStringLiteral("lineEditPixelSize"));
        lineEditPixelSize->setGeometry(QRect(220, 50, 71, 23));
        lineEditImageDimensionY = new QLineEdit(groupBox);
        lineEditImageDimensionY->setObjectName(QStringLiteral("lineEditImageDimensionY"));
        lineEditImageDimensionY->setGeometry(QRect(40, 80, 70, 23));
        lineEditImageDimensionZ = new QLineEdit(groupBox);
        lineEditImageDimensionZ->setObjectName(QStringLiteral("lineEditImageDimensionZ"));
        lineEditImageDimensionZ->setGeometry(QRect(40, 110, 70, 23));
        labelImageDimensionsX = new QLabel(groupBox);
        labelImageDimensionsX->setObjectName(QStringLiteral("labelImageDimensionsX"));
        labelImageDimensionsX->setGeometry(QRect(30, 50, 16, 16));
        labelImageDimensionsY = new QLabel(groupBox);
        labelImageDimensionsY->setObjectName(QStringLiteral("labelImageDimensionsY"));
        labelImageDimensionsY->setGeometry(QRect(30, 80, 16, 16));
        labelImageDimensionsZ = new QLabel(groupBox);
        labelImageDimensionsZ->setObjectName(QStringLiteral("labelImageDimensionsZ"));
        labelImageDimensionsZ->setGeometry(QRect(30, 110, 16, 16));
        lineEditTranslationX = new QLineEdit(groupBox);
        lineEditTranslationX->setObjectName(QStringLiteral("lineEditTranslationX"));
        lineEditTranslationX->setGeometry(QRect(220, 100, 70, 23));
        lineEditTranslationY = new QLineEdit(groupBox);
        lineEditTranslationY->setObjectName(QStringLiteral("lineEditTranslationY"));
        lineEditTranslationY->setGeometry(QRect(220, 130, 70, 23));
        lineEditTranslationZ = new QLineEdit(groupBox);
        lineEditTranslationZ->setObjectName(QStringLiteral("lineEditTranslationZ"));
        lineEditTranslationZ->setGeometry(QRect(220, 160, 70, 23));
        labelTranslationX = new QLabel(groupBox);
        labelTranslationX->setObjectName(QStringLiteral("labelTranslationX"));
        labelTranslationX->setGeometry(QRect(200, 100, 16, 16));
        labelTranslationY = new QLabel(groupBox);
        labelTranslationY->setObjectName(QStringLiteral("labelTranslationY"));
        labelTranslationY->setGeometry(QRect(200, 130, 16, 16));
        labelTranslationZ = new QLabel(groupBox);
        labelTranslationZ->setObjectName(QStringLiteral("labelTranslationZ"));
        labelTranslationZ->setGeometry(QRect(200, 160, 16, 16));
        labelTransformationType = new QLabel(groupBox);
        labelTransformationType->setObjectName(QStringLiteral("labelTransformationType"));
        labelTransformationType->setGeometry(QRect(360, 20, 111, 16));
        groupBoxMultipleFiles = new QGroupBox(centralWidget);
        groupBoxMultipleFiles->setObjectName(QStringLiteral("groupBoxMultipleFiles"));
        groupBoxMultipleFiles->setEnabled(false);
        groupBoxMultipleFiles->setGeometry(QRect(60, 470, 501, 81));
        pushButtonSelectSourceDir = new QPushButton(groupBoxMultipleFiles);
        pushButtonSelectSourceDir->setObjectName(QStringLiteral("pushButtonSelectSourceDir"));
        pushButtonSelectSourceDir->setGeometry(QRect(20, 20, 111, 23));
        pushButtonSaveOutputDir = new QPushButton(groupBoxMultipleFiles);
        pushButtonSaveOutputDir->setObjectName(QStringLiteral("pushButtonSaveOutputDir"));
        pushButtonSaveOutputDir->setGeometry(QRect(20, 50, 111, 23));
        lineEditSelectSourceDir = new QLineEdit(groupBoxMultipleFiles);
        lineEditSelectSourceDir->setObjectName(QStringLiteral("lineEditSelectSourceDir"));
        lineEditSelectSourceDir->setGeometry(QRect(140, 20, 340, 23));
        lineEditSelectSourceDir->setStyleSheet(QStringLiteral(""));
        lineEditSaveOutputDir = new QLineEdit(groupBoxMultipleFiles);
        lineEditSaveOutputDir->setObjectName(QStringLiteral("lineEditSaveOutputDir"));
        lineEditSaveOutputDir->setGeometry(QRect(140, 50, 340, 23));
        labelSelectDevice = new QLabel(centralWidget);
        labelSelectDevice->setObjectName(QStringLiteral("labelSelectDevice"));
        labelSelectDevice->setGeometry(QRect(20, 70, 81, 16));
        comboBoxSelectPlatform = new QComboBox(centralWidget);
        comboBoxSelectPlatform->setObjectName(QStringLiteral("comboBoxSelectPlatform"));
        comboBoxSelectPlatform->setGeometry(QRect(30, 40, 400, 23));
        labelSelectPlatform = new QLabel(centralWidget);
        labelSelectPlatform->setObjectName(QStringLiteral("labelSelectPlatform"));
        labelSelectPlatform->setGeometry(QRect(20, 20, 81, 16));
        groupBoxSingleFiles = new QGroupBox(centralWidget);
        groupBoxSingleFiles->setObjectName(QStringLiteral("groupBoxSingleFiles"));
        groupBoxSingleFiles->setEnabled(true);
        groupBoxSingleFiles->setGeometry(QRect(60, 360, 501, 101));
        pushButtonSelectSourceFile = new QPushButton(groupBoxSingleFiles);
        pushButtonSelectSourceFile->setObjectName(QStringLiteral("pushButtonSelectSourceFile"));
        pushButtonSelectSourceFile->setGeometry(QRect(20, 30, 110, 23));
        pushButtonSaveOutputFile = new QPushButton(groupBoxSingleFiles);
        pushButtonSaveOutputFile->setObjectName(QStringLiteral("pushButtonSaveOutputFile"));
        pushButtonSaveOutputFile->setGeometry(QRect(20, 60, 110, 23));
        lineEditSelectSourceFile = new QLineEdit(groupBoxSingleFiles);
        lineEditSelectSourceFile->setObjectName(QStringLiteral("lineEditSelectSourceFile"));
        lineEditSelectSourceFile->setGeometry(QRect(140, 30, 340, 23));
        lineEditSaveOutputFile = new QLineEdit(groupBoxSingleFiles);
        lineEditSaveOutputFile->setObjectName(QStringLiteral("lineEditSaveOutputFile"));
        lineEditSaveOutputFile->setGeometry(QRect(140, 60, 340, 23));
        comboBoxSelectDevice = new QComboBox(centralWidget);
        comboBoxSelectDevice->setObjectName(QStringLiteral("comboBoxSelectDevice"));
        comboBoxSelectDevice->setGeometry(QRect(30, 100, 400, 23));
        groupBoxRadioButtons = new QGroupBox(centralWidget);
        groupBoxRadioButtons->setObjectName(QStringLiteral("groupBoxRadioButtons"));
        groupBoxRadioButtons->setGeometry(QRect(10, 360, 41, 191));
        radioButtonSingleFile = new QRadioButton(groupBoxRadioButtons);
        radioButtonSingleFile->setObjectName(QStringLiteral("radioButtonSingleFile"));
        radioButtonSingleFile->setGeometry(QRect(10, 40, 16, 17));
        radioButtonSingleFile->setChecked(true);
        radioButtonMultipleFile = new QRadioButton(groupBoxRadioButtons);
        radioButtonMultipleFile->setObjectName(QStringLiteral("radioButtonMultipleFile"));
        radioButtonMultipleFile->setGeometry(QRect(10, 140, 16, 17));
        pushButtonDeviceListInfo = new QPushButton(centralWidget);
        pushButtonDeviceListInfo->setObjectName(QStringLiteral("pushButtonDeviceListInfo"));
        pushButtonDeviceListInfo->setGeometry(QRect(450, 100, 75, 23));
        pushButtonPlatformListInfo = new QPushButton(centralWidget);
        pushButtonPlatformListInfo->setObjectName(QStringLiteral("pushButtonPlatformListInfo"));
        pushButtonPlatformListInfo->setGeometry(QRect(450, 40, 75, 23));
        pushButtonCalculate = new QPushButton(centralWidget);
        pushButtonCalculate->setObjectName(QStringLiteral("pushButtonCalculate"));
        pushButtonCalculate->setGeometry(QRect(460, 580, 101, 51));
        profiling_uiClass->setCentralWidget(centralWidget);
        statusBar = new QStatusBar(profiling_uiClass);
        statusBar->setObjectName(QStringLiteral("statusBar"));
        statusBar->setEnabled(true);
        statusBar->setMinimumSize(QSize(600, 20));
        statusBar->setMaximumSize(QSize(600, 20));
        statusBar->setSizeGripEnabled(false);
        profiling_uiClass->setStatusBar(statusBar);
        menuBar = new QMenuBar(profiling_uiClass);
        menuBar->setObjectName(QStringLiteral("menuBar"));
        menuBar->setGeometry(QRect(0, 0, 600, 21));
        menuFile = new QMenu(menuBar);
        menuFile->setObjectName(QStringLiteral("menuFile"));
        profiling_uiClass->setMenuBar(menuBar);

        menuBar->addAction(menuFile->menuAction());
        menuFile->addAction(actionExit);

        retranslateUi(profiling_uiClass);
        QObject::connect(pushButtonPlatformListInfo, SIGNAL(clicked()), pushButtonPlatformListInfo, SLOT(update()));

        QMetaObject::connectSlotsByName(profiling_uiClass);
    } // setupUi

    void retranslateUi(QMainWindow *profiling_uiClass)
    {
        profiling_uiClass->setWindowTitle(QApplication::translate("profiling_uiClass", "Convolve & Transform  Fluorophores", 0));
        actionAbout->setText(QApplication::translate("profiling_uiClass", "About", 0));
        actionAbout->setShortcut(QApplication::translate("profiling_uiClass", "Ctrl+A", 0));
        actionExit->setText(QApplication::translate("profiling_uiClass", "Exit", 0));
        actionExit->setShortcut(QApplication::translate("profiling_uiClass", "Ctrl+Q", 0));
        actionAsdasd->setText(QApplication::translate("profiling_uiClass", "asdasd", 0));
        groupBox->setTitle(QApplication::translate("profiling_uiClass", "Parameters", 0));
        labelImageDimensions->setText(QApplication::translate("profiling_uiClass", "Image dimensions (pixels)", 0));
        labelPixelSize->setText(QApplication::translate("profiling_uiClass", "Pixel size (nm)", 0));
        labelTranslation->setText(QApplication::translate("profiling_uiClass", "Translation (pixels)", 0));
#ifndef QT_NO_TOOLTIP
        comboBoxTransformationType->setToolTip(QApplication::translate("profiling_uiClass", "Select transformation type", 0));
#endif // QT_NO_TOOLTIP
#ifndef QT_NO_STATUSTIP
        comboBoxTransformationType->setStatusTip(QApplication::translate("profiling_uiClass", "Select transformation type", 0));
#endif // QT_NO_STATUSTIP
        lineEditImageDimensionX->setText(QApplication::translate("profiling_uiClass", "128", 0));
        lineEditPixelSize->setText(QApplication::translate("profiling_uiClass", "64", 0));
        lineEditImageDimensionY->setText(QApplication::translate("profiling_uiClass", "128", 0));
        lineEditImageDimensionZ->setText(QApplication::translate("profiling_uiClass", "1", 0));
        labelImageDimensionsX->setText(QApplication::translate("profiling_uiClass", "x", 0));
        labelImageDimensionsY->setText(QApplication::translate("profiling_uiClass", "y", 0));
        labelImageDimensionsZ->setText(QApplication::translate("profiling_uiClass", "z", 0));
        lineEditTranslationX->setText(QApplication::translate("profiling_uiClass", "0", 0));
        lineEditTranslationY->setText(QApplication::translate("profiling_uiClass", "0", 0));
        lineEditTranslationZ->setText(QApplication::translate("profiling_uiClass", "0", 0));
        labelTranslationX->setText(QApplication::translate("profiling_uiClass", "x", 0));
        labelTranslationY->setText(QApplication::translate("profiling_uiClass", "y", 0));
        labelTranslationZ->setText(QApplication::translate("profiling_uiClass", "z", 0));
        labelTransformationType->setText(QApplication::translate("profiling_uiClass", "Transformation Type", 0));
        groupBoxMultipleFiles->setTitle(QApplication::translate("profiling_uiClass", "Multiple files", 0));
#ifndef QT_NO_TOOLTIP
        pushButtonSelectSourceDir->setToolTip(QApplication::translate("profiling_uiClass", "Select output dir", 0));
#endif // QT_NO_TOOLTIP
#ifndef QT_NO_STATUSTIP
        pushButtonSelectSourceDir->setStatusTip(QApplication::translate("profiling_uiClass", "Select output dir", 0));
#endif // QT_NO_STATUSTIP
        pushButtonSelectSourceDir->setText(QApplication::translate("profiling_uiClass", "Select source dir", 0));
#ifndef QT_NO_TOOLTIP
        pushButtonSaveOutputDir->setToolTip(QApplication::translate("profiling_uiClass", "Save output dir", 0));
#endif // QT_NO_TOOLTIP
#ifndef QT_NO_STATUSTIP
        pushButtonSaveOutputDir->setStatusTip(QApplication::translate("profiling_uiClass", "Save output dir", 0));
#endif // QT_NO_STATUSTIP
        pushButtonSaveOutputDir->setText(QApplication::translate("profiling_uiClass", "Save ouput dir", 0));
        labelSelectDevice->setText(QApplication::translate("profiling_uiClass", "Select Device", 0));
#ifndef QT_NO_TOOLTIP
        comboBoxSelectPlatform->setToolTip(QApplication::translate("profiling_uiClass", "Select platform", 0));
#endif // QT_NO_TOOLTIP
#ifndef QT_NO_STATUSTIP
        comboBoxSelectPlatform->setStatusTip(QApplication::translate("profiling_uiClass", "Select platform", 0));
#endif // QT_NO_STATUSTIP
        labelSelectPlatform->setText(QApplication::translate("profiling_uiClass", "Select Platform", 0));
        groupBoxSingleFiles->setTitle(QApplication::translate("profiling_uiClass", "Single file", 0));
#ifndef QT_NO_TOOLTIP
        pushButtonSelectSourceFile->setToolTip(QApplication::translate("profiling_uiClass", "Select source file", 0));
#endif // QT_NO_TOOLTIP
#ifndef QT_NO_STATUSTIP
        pushButtonSelectSourceFile->setStatusTip(QApplication::translate("profiling_uiClass", "Select source file", 0));
#endif // QT_NO_STATUSTIP
        pushButtonSelectSourceFile->setText(QApplication::translate("profiling_uiClass", "Select souce file", 0));
#ifndef QT_NO_TOOLTIP
        pushButtonSaveOutputFile->setToolTip(QApplication::translate("profiling_uiClass", "Save output file", 0));
#endif // QT_NO_TOOLTIP
#ifndef QT_NO_STATUSTIP
        pushButtonSaveOutputFile->setStatusTip(QApplication::translate("profiling_uiClass", "Save output file", 0));
#endif // QT_NO_STATUSTIP
        pushButtonSaveOutputFile->setText(QApplication::translate("profiling_uiClass", "Save output file", 0));
#ifndef QT_NO_TOOLTIP
        comboBoxSelectDevice->setToolTip(QApplication::translate("profiling_uiClass", "Select device", 0));
#endif // QT_NO_TOOLTIP
#ifndef QT_NO_STATUSTIP
        comboBoxSelectDevice->setStatusTip(QApplication::translate("profiling_uiClass", "Select device", 0));
#endif // QT_NO_STATUSTIP
        groupBoxRadioButtons->setTitle(QString());
        radioButtonSingleFile->setText(QString());
        radioButtonMultipleFile->setText(QString());
#ifndef QT_NO_TOOLTIP
        pushButtonDeviceListInfo->setToolTip(QApplication::translate("profiling_uiClass", "List info", 0));
#endif // QT_NO_TOOLTIP
#ifndef QT_NO_STATUSTIP
        pushButtonDeviceListInfo->setStatusTip(QApplication::translate("profiling_uiClass", "List info", 0));
#endif // QT_NO_STATUSTIP
        pushButtonDeviceListInfo->setText(QApplication::translate("profiling_uiClass", "List info", 0));
        pushButtonPlatformListInfo->setText(QApplication::translate("profiling_uiClass", "List info", 0));
        pushButtonCalculate->setText(QApplication::translate("profiling_uiClass", "Calculate", 0));
        menuFile->setTitle(QApplication::translate("profiling_uiClass", "File", 0));
    } // retranslateUi

};

namespace Ui {
    class profiling_uiClass: public Ui_profiling_uiClass {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_PROFILING_UI_H
