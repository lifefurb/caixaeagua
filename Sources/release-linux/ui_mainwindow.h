/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created by: Qt User Interface Compiler version 5.6.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QHBoxLayout>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenu>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QAction *actionAula_1;
    QAction *actionAula_2;
    QAction *actionAula_3;
    QAction *actionAula_4;
    QAction *actionAula_5;
    QAction *actionSite_do_Caixa_e_gua;
    QAction *actionPerguntas_Frequ_ntes;
    QAction *actionCr_ditos;
    QAction *actionProjetor;
    QAction *actionMundo;
    QAction *actionKinect;
    QWidget *centralWidget;
    QWidget *verticalLayoutWidget;
    QHBoxLayout *horizontalLayout;
    QPushButton *btn_aula_1;
    QPushButton *btn_aula_2;
    QPushButton *btn_aula_3;
    QPushButton *btn_aula_4;
    QPushButton *btn_aula_5;
    QLabel *imagem;
    QMenuBar *menuBar;
    QMenu *menuCalibrar;
    QMenu *menuSobre;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName(QStringLiteral("MainWindow"));
        MainWindow->resize(650, 545);
        MainWindow->setMinimumSize(QSize(650, 545));
        MainWindow->setMaximumSize(QSize(650, 545));
        QIcon icon;
        icon.addFile(QStringLiteral("../resources/logos/icone.jpg"), QSize(), QIcon::Normal, QIcon::On);
        MainWindow->setWindowIcon(icon);
        MainWindow->setIconSize(QSize(48, 48));
        actionAula_1 = new QAction(MainWindow);
        actionAula_1->setObjectName(QStringLiteral("actionAula_1"));
        actionAula_2 = new QAction(MainWindow);
        actionAula_2->setObjectName(QStringLiteral("actionAula_2"));
        actionAula_3 = new QAction(MainWindow);
        actionAula_3->setObjectName(QStringLiteral("actionAula_3"));
        actionAula_4 = new QAction(MainWindow);
        actionAula_4->setObjectName(QStringLiteral("actionAula_4"));
        actionAula_5 = new QAction(MainWindow);
        actionAula_5->setObjectName(QStringLiteral("actionAula_5"));
        actionSite_do_Caixa_e_gua = new QAction(MainWindow);
        actionSite_do_Caixa_e_gua->setObjectName(QStringLiteral("actionSite_do_Caixa_e_gua"));
        actionPerguntas_Frequ_ntes = new QAction(MainWindow);
        actionPerguntas_Frequ_ntes->setObjectName(QStringLiteral("actionPerguntas_Frequ_ntes"));
        actionCr_ditos = new QAction(MainWindow);
        actionCr_ditos->setObjectName(QStringLiteral("actionCr_ditos"));
        actionProjetor = new QAction(MainWindow);
        actionProjetor->setObjectName(QStringLiteral("actionProjetor"));
        actionMundo = new QAction(MainWindow);
        actionMundo->setObjectName(QStringLiteral("actionMundo"));
        actionKinect = new QAction(MainWindow);
        actionKinect->setObjectName(QStringLiteral("actionKinect"));
        centralWidget = new QWidget(MainWindow);
        centralWidget->setObjectName(QStringLiteral("centralWidget"));
        verticalLayoutWidget = new QWidget(centralWidget);
        verticalLayoutWidget->setObjectName(QStringLiteral("verticalLayoutWidget"));
        verticalLayoutWidget->setGeometry(QRect(10, 460, 631, 52));
        horizontalLayout = new QHBoxLayout(verticalLayoutWidget);
        horizontalLayout->setSpacing(6);
        horizontalLayout->setContentsMargins(11, 11, 11, 11);
        horizontalLayout->setObjectName(QStringLiteral("horizontalLayout"));
        horizontalLayout->setContentsMargins(0, 0, 0, 0);
        btn_aula_1 = new QPushButton(verticalLayoutWidget);
        btn_aula_1->setObjectName(QStringLiteral("btn_aula_1"));
        QSizePolicy sizePolicy(QSizePolicy::Preferred, QSizePolicy::Preferred);
        sizePolicy.setHorizontalStretch(0);
        sizePolicy.setVerticalStretch(0);
        sizePolicy.setHeightForWidth(btn_aula_1->sizePolicy().hasHeightForWidth());
        btn_aula_1->setSizePolicy(sizePolicy);
        btn_aula_1->setMinimumSize(QSize(0, 50));
        QPalette palette;
        QBrush brush(QColor(110, 110, 110, 255));
        brush.setStyle(Qt::SolidPattern);
        palette.setBrush(QPalette::Active, QPalette::WindowText, brush);
        palette.setBrush(QPalette::Active, QPalette::Text, brush);
        palette.setBrush(QPalette::Active, QPalette::ButtonText, brush);
        palette.setBrush(QPalette::Active, QPalette::ToolTipText, brush);
        palette.setBrush(QPalette::Inactive, QPalette::WindowText, brush);
        palette.setBrush(QPalette::Inactive, QPalette::Text, brush);
        palette.setBrush(QPalette::Inactive, QPalette::ButtonText, brush);
        palette.setBrush(QPalette::Inactive, QPalette::ToolTipText, brush);
        QBrush brush1(QColor(190, 190, 190, 255));
        brush1.setStyle(Qt::SolidPattern);
        palette.setBrush(QPalette::Disabled, QPalette::WindowText, brush1);
        palette.setBrush(QPalette::Disabled, QPalette::Text, brush1);
        palette.setBrush(QPalette::Disabled, QPalette::ButtonText, brush1);
        palette.setBrush(QPalette::Disabled, QPalette::ToolTipText, brush);
        btn_aula_1->setPalette(palette);
        QFont font;
        font.setFamily(QStringLiteral("Sans Serif"));
        font.setPointSize(16);
        font.setBold(true);
        font.setItalic(false);
        font.setWeight(75);
        btn_aula_1->setFont(font);
        btn_aula_1->setCursor(QCursor(Qt::PointingHandCursor));
        btn_aula_1->setToolTipDuration(-1);

        horizontalLayout->addWidget(btn_aula_1);

        btn_aula_2 = new QPushButton(verticalLayoutWidget);
        btn_aula_2->setObjectName(QStringLiteral("btn_aula_2"));
        sizePolicy.setHeightForWidth(btn_aula_2->sizePolicy().hasHeightForWidth());
        btn_aula_2->setSizePolicy(sizePolicy);
        btn_aula_2->setMinimumSize(QSize(0, 50));
        QPalette palette1;
        palette1.setBrush(QPalette::Active, QPalette::ButtonText, brush);
        palette1.setBrush(QPalette::Inactive, QPalette::ButtonText, brush);
        palette1.setBrush(QPalette::Disabled, QPalette::ButtonText, brush1);
        btn_aula_2->setPalette(palette1);
        btn_aula_2->setFont(font);
        btn_aula_2->setCursor(QCursor(Qt::PointingHandCursor));

        horizontalLayout->addWidget(btn_aula_2);

        btn_aula_3 = new QPushButton(verticalLayoutWidget);
        btn_aula_3->setObjectName(QStringLiteral("btn_aula_3"));
        sizePolicy.setHeightForWidth(btn_aula_3->sizePolicy().hasHeightForWidth());
        btn_aula_3->setSizePolicy(sizePolicy);
        btn_aula_3->setMinimumSize(QSize(0, 50));
        QPalette palette2;
        palette2.setBrush(QPalette::Active, QPalette::ButtonText, brush);
        palette2.setBrush(QPalette::Inactive, QPalette::ButtonText, brush);
        palette2.setBrush(QPalette::Disabled, QPalette::ButtonText, brush1);
        btn_aula_3->setPalette(palette2);
        btn_aula_3->setFont(font);
        btn_aula_3->setCursor(QCursor(Qt::PointingHandCursor));

        horizontalLayout->addWidget(btn_aula_3);

        btn_aula_4 = new QPushButton(verticalLayoutWidget);
        btn_aula_4->setObjectName(QStringLiteral("btn_aula_4"));
        sizePolicy.setHeightForWidth(btn_aula_4->sizePolicy().hasHeightForWidth());
        btn_aula_4->setSizePolicy(sizePolicy);
        btn_aula_4->setMinimumSize(QSize(0, 50));
        QPalette palette3;
        palette3.setBrush(QPalette::Active, QPalette::ButtonText, brush);
        palette3.setBrush(QPalette::Inactive, QPalette::ButtonText, brush);
        palette3.setBrush(QPalette::Disabled, QPalette::ButtonText, brush1);
        btn_aula_4->setPalette(palette3);
        btn_aula_4->setFont(font);
        btn_aula_4->setCursor(QCursor(Qt::PointingHandCursor));

        horizontalLayout->addWidget(btn_aula_4);

        btn_aula_5 = new QPushButton(verticalLayoutWidget);
        btn_aula_5->setObjectName(QStringLiteral("btn_aula_5"));
        sizePolicy.setHeightForWidth(btn_aula_5->sizePolicy().hasHeightForWidth());
        btn_aula_5->setSizePolicy(sizePolicy);
        btn_aula_5->setMinimumSize(QSize(0, 50));
        QPalette palette4;
        palette4.setBrush(QPalette::Active, QPalette::ButtonText, brush);
        palette4.setBrush(QPalette::Inactive, QPalette::ButtonText, brush);
        palette4.setBrush(QPalette::Disabled, QPalette::ButtonText, brush1);
        btn_aula_5->setPalette(palette4);
        btn_aula_5->setFont(font);
        btn_aula_5->setCursor(QCursor(Qt::PointingHandCursor));

        horizontalLayout->addWidget(btn_aula_5);

        imagem = new QLabel(centralWidget);
        imagem->setObjectName(QStringLiteral("imagem"));
        imagem->setGeometry(QRect(10, 0, 631, 451));
        imagem->setPixmap(QPixmap(QString::fromUtf8("../resources/logos/LOGO ICONE.png")));
        imagem->setScaledContents(true);
        MainWindow->setCentralWidget(centralWidget);
        menuBar = new QMenuBar(MainWindow);
        menuBar->setObjectName(QStringLiteral("menuBar"));
        menuBar->setGeometry(QRect(0, 0, 650, 20));
        QSizePolicy sizePolicy1(QSizePolicy::MinimumExpanding, QSizePolicy::Minimum);
        sizePolicy1.setHorizontalStretch(0);
        sizePolicy1.setVerticalStretch(0);
        sizePolicy1.setHeightForWidth(menuBar->sizePolicy().hasHeightForWidth());
        menuBar->setSizePolicy(sizePolicy1);
        menuCalibrar = new QMenu(menuBar);
        menuCalibrar->setObjectName(QStringLiteral("menuCalibrar"));
        menuSobre = new QMenu(menuBar);
        menuSobre->setObjectName(QStringLiteral("menuSobre"));
        MainWindow->setMenuBar(menuBar);

        menuBar->addAction(menuCalibrar->menuAction());
        menuBar->addAction(menuSobre->menuAction());
        menuCalibrar->addAction(actionKinect);
        menuCalibrar->addAction(actionMundo);
        menuCalibrar->addAction(actionProjetor);
        menuSobre->addAction(actionSite_do_Caixa_e_gua);
        menuSobre->addAction(actionPerguntas_Frequ_ntes);
        menuSobre->addAction(actionCr_ditos);

        retranslateUi(MainWindow);

        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QApplication::translate("MainWindow", "Caixa e-\303\201gua", 0));
        actionAula_1->setText(QApplication::translate("MainWindow", "Aula 1", 0));
        actionAula_2->setText(QApplication::translate("MainWindow", "Aula 2", 0));
#ifndef QT_NO_TOOLTIP
        actionAula_2->setToolTip(QApplication::translate("MainWindow", "Bacia Hidrogr\303\241fica", 0));
#endif // QT_NO_TOOLTIP
        actionAula_3->setText(QApplication::translate("MainWindow", "Aula 3", 0));
        actionAula_4->setText(QApplication::translate("MainWindow", "Aula 4", 0));
        actionAula_5->setText(QApplication::translate("MainWindow", "Aula 5", 0));
        actionSite_do_Caixa_e_gua->setText(QApplication::translate("MainWindow", "Site do Caixa e-\303\201gua", 0));
        actionPerguntas_Frequ_ntes->setText(QApplication::translate("MainWindow", "Perguntas Frequentes", 0));
        actionCr_ditos->setText(QApplication::translate("MainWindow", "Cr\303\251ditos", 0));
        actionProjetor->setText(QApplication::translate("MainWindow", "Projetor", 0));
        actionProjetor->setShortcut(QApplication::translate("MainWindow", "P", 0));
        actionMundo->setText(QApplication::translate("MainWindow", "Mundo", 0));
        actionMundo->setShortcut(QApplication::translate("MainWindow", "M", 0));
        actionKinect->setText(QApplication::translate("MainWindow", "Kinect", 0));
        actionKinect->setShortcut(QApplication::translate("MainWindow", "K", 0));
#ifndef QT_NO_TOOLTIP
        btn_aula_1->setToolTip(QApplication::translate("MainWindow", "<html><head/><body><p align=\"center\"><span style=\" font-size:10pt; font-family: 'Comic Sans MS'; \">Inicia a aula 1</span></p></body></html>", 0));
#endif // QT_NO_TOOLTIP
#ifndef QT_NO_WHATSTHIS
        btn_aula_1->setWhatsThis(QString());
#endif // QT_NO_WHATSTHIS
        btn_aula_1->setText(QApplication::translate("MainWindow", "Aula 1", 0));
        btn_aula_1->setShortcut(QApplication::translate("MainWindow", "1", 0));
#ifndef QT_NO_TOOLTIP
        btn_aula_2->setToolTip(QApplication::translate("MainWindow", "<html><head/><body><p align=\"center\"><span style=\" font-size:10pt; font-family: 'Comic Sans MS'; \">Inicia a aula 2</span></p></body></html>", 0));
#endif // QT_NO_TOOLTIP
        btn_aula_2->setText(QApplication::translate("MainWindow", "Aula 2", 0));
        btn_aula_2->setShortcut(QApplication::translate("MainWindow", "2", 0));
#ifndef QT_NO_TOOLTIP
        btn_aula_3->setToolTip(QApplication::translate("MainWindow", "<html><head/><body><p align=\"center\"><span style=\" font-size:10pt; font-family: 'Comic Sans MS'; \">Inicia a aula 3</span></p></body></html>", 0));
#endif // QT_NO_TOOLTIP
        btn_aula_3->setText(QApplication::translate("MainWindow", "Aula 3", 0));
        btn_aula_3->setShortcut(QApplication::translate("MainWindow", "3", 0));
#ifndef QT_NO_TOOLTIP
        btn_aula_4->setToolTip(QApplication::translate("MainWindow", "<html><head/><body><p align=\"center\"><span style=\" font-family:'Comic Sans MS'; font-size:10pt;\">Inicia a aula 4</span></p></body></html>", 0));
#endif // QT_NO_TOOLTIP
        btn_aula_4->setText(QApplication::translate("MainWindow", "Aula 4", 0));
        btn_aula_4->setShortcut(QApplication::translate("MainWindow", "4", 0));
#ifndef QT_NO_TOOLTIP
        btn_aula_5->setToolTip(QApplication::translate("MainWindow", "<html><head/><body><p align=\"center\"><span style=\" font-family:'Comic Sans MS'; font-size:10pt;\">Inicia a aula 5</span></p></body></html>", 0));
#endif // QT_NO_TOOLTIP
        btn_aula_5->setText(QApplication::translate("MainWindow", "Aula 5", 0));
        btn_aula_5->setShortcut(QApplication::translate("MainWindow", "5", 0));
        imagem->setText(QString());
        menuCalibrar->setTitle(QApplication::translate("MainWindow", "Calibrar", 0));
        menuSobre->setTitle(QApplication::translate("MainWindow", "Sobre", 0));
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
