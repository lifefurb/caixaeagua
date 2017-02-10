/********************************************************************************
** Form generated from reading UI file 'aula_5.ui'
**
** Created by: Qt User Interface Compiler version 5.6.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_AULA_5_H
#define UI_AULA_5_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QHBoxLayout>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QVBoxLayout>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_Aula_5
{
public:
    QWidget *horizontalLayoutWidget;
    QHBoxLayout *layout_btns_inf;
    QPushButton *btn_visualizar;
    QPushButton *btn_visualizar_relevo;
    QPushButton *btn_validar;
    QWidget *verticalLayoutWidget_2;
    QVBoxLayout *layout_btns_dir;
    QPushButton *btn_modelo_5;
    QPushButton *btn_modelo_6;
    QPushButton *btn_modelo_7;
    QPushButton *btn_modelo_8;
    QLabel *modelo;
    QWidget *verticalLayoutWidget;
    QVBoxLayout *layout_btns_esq;
    QPushButton *btn_modelo_1;
    QPushButton *btn_modelo_2;
    QPushButton *btn_modelo_3;
    QPushButton *btn_modelo_4;
    QLabel *mensagem;

    void setupUi(QWidget *Aula_5)
    {
        if (Aula_5->objectName().isEmpty())
            Aula_5->setObjectName(QStringLiteral("Aula_5"));
        Aula_5->resize(1024, 768);
        horizontalLayoutWidget = new QWidget(Aula_5);
        horizontalLayoutWidget->setObjectName(QStringLiteral("horizontalLayoutWidget"));
        horizontalLayoutWidget->setGeometry(QRect(27, 660, 971, 101));
        layout_btns_inf = new QHBoxLayout(horizontalLayoutWidget);
        layout_btns_inf->setObjectName(QStringLiteral("layout_btns_inf"));
        layout_btns_inf->setContentsMargins(0, 0, 0, 0);
        btn_visualizar = new QPushButton(horizontalLayoutWidget);
        btn_visualizar->setObjectName(QStringLiteral("btn_visualizar"));
        QSizePolicy sizePolicy(QSizePolicy::Preferred, QSizePolicy::Preferred);
        sizePolicy.setHorizontalStretch(0);
        sizePolicy.setVerticalStretch(0);
        sizePolicy.setHeightForWidth(btn_visualizar->sizePolicy().hasHeightForWidth());
        btn_visualizar->setSizePolicy(sizePolicy);
        btn_visualizar->setMinimumSize(QSize(0, 75));
        QPalette palette;
        QBrush brush(QColor(111, 111, 111, 255));
        brush.setStyle(Qt::SolidPattern);
        palette.setBrush(QPalette::Active, QPalette::ButtonText, brush);
        palette.setBrush(QPalette::Inactive, QPalette::ButtonText, brush);
        QBrush brush1(QColor(190, 190, 190, 255));
        brush1.setStyle(Qt::SolidPattern);
        palette.setBrush(QPalette::Disabled, QPalette::ButtonText, brush1);
        btn_visualizar->setPalette(palette);
        QFont font;
        font.setFamily(QStringLiteral("Sans Serif"));
        font.setPointSize(18);
        font.setBold(true);
        font.setWeight(75);
        btn_visualizar->setFont(font);
        btn_visualizar->setCursor(QCursor(Qt::PointingHandCursor));

        layout_btns_inf->addWidget(btn_visualizar);

        btn_visualizar_relevo = new QPushButton(horizontalLayoutWidget);
        btn_visualizar_relevo->setObjectName(QStringLiteral("btn_visualizar_relevo"));
        sizePolicy.setHeightForWidth(btn_visualizar_relevo->sizePolicy().hasHeightForWidth());
        btn_visualizar_relevo->setSizePolicy(sizePolicy);
        btn_visualizar_relevo->setMinimumSize(QSize(0, 75));
        QPalette palette1;
        palette1.setBrush(QPalette::Active, QPalette::ButtonText, brush);
        palette1.setBrush(QPalette::Inactive, QPalette::ButtonText, brush);
        palette1.setBrush(QPalette::Disabled, QPalette::ButtonText, brush1);
        btn_visualizar_relevo->setPalette(palette1);
        btn_visualizar_relevo->setFont(font);
        btn_visualizar_relevo->setCursor(QCursor(Qt::PointingHandCursor));

        layout_btns_inf->addWidget(btn_visualizar_relevo);

        btn_validar = new QPushButton(horizontalLayoutWidget);
        btn_validar->setObjectName(QStringLiteral("btn_validar"));
        sizePolicy.setHeightForWidth(btn_validar->sizePolicy().hasHeightForWidth());
        btn_validar->setSizePolicy(sizePolicy);
        btn_validar->setMinimumSize(QSize(0, 75));
        QPalette palette2;
        palette2.setBrush(QPalette::Active, QPalette::ButtonText, brush);
        palette2.setBrush(QPalette::Inactive, QPalette::ButtonText, brush);
        palette2.setBrush(QPalette::Disabled, QPalette::ButtonText, brush1);
        btn_validar->setPalette(palette2);
        btn_validar->setFont(font);
        btn_validar->setCursor(QCursor(Qt::PointingHandCursor));

        layout_btns_inf->addWidget(btn_validar);

        verticalLayoutWidget_2 = new QWidget(Aula_5);
        verticalLayoutWidget_2->setObjectName(QStringLiteral("verticalLayoutWidget_2"));
        verticalLayoutWidget_2->setGeometry(QRect(810, 10, 214, 641));
        layout_btns_dir = new QVBoxLayout(verticalLayoutWidget_2);
        layout_btns_dir->setObjectName(QStringLiteral("layout_btns_dir"));
        layout_btns_dir->setContentsMargins(0, 0, 0, 0);
        btn_modelo_5 = new QPushButton(verticalLayoutWidget_2);
        btn_modelo_5->setObjectName(QStringLiteral("btn_modelo_5"));
        btn_modelo_5->setMinimumSize(QSize(0, 150));
        btn_modelo_5->setMaximumSize(QSize(16777215, 150));
        btn_modelo_5->setCursor(QCursor(Qt::PointingHandCursor));
        QIcon icon;
        icon.addFile(QStringLiteral("../resources/modelos/modelo_5.png"), QSize(), QIcon::Normal, QIcon::Off);
        btn_modelo_5->setIcon(icon);
        btn_modelo_5->setIconSize(QSize(200, 150));
        btn_modelo_5->setFlat(true);

        layout_btns_dir->addWidget(btn_modelo_5);

        btn_modelo_6 = new QPushButton(verticalLayoutWidget_2);
        btn_modelo_6->setObjectName(QStringLiteral("btn_modelo_6"));
        btn_modelo_6->setMinimumSize(QSize(0, 150));
        btn_modelo_6->setMaximumSize(QSize(16777215, 150));
        btn_modelo_6->setCursor(QCursor(Qt::PointingHandCursor));
        QIcon icon1;
        icon1.addFile(QStringLiteral("../resources/modelos/modelo_6.png"), QSize(), QIcon::Normal, QIcon::Off);
        btn_modelo_6->setIcon(icon1);
        btn_modelo_6->setIconSize(QSize(200, 150));
        btn_modelo_6->setFlat(true);

        layout_btns_dir->addWidget(btn_modelo_6);

        btn_modelo_7 = new QPushButton(verticalLayoutWidget_2);
        btn_modelo_7->setObjectName(QStringLiteral("btn_modelo_7"));
        btn_modelo_7->setMinimumSize(QSize(0, 150));
        btn_modelo_7->setMaximumSize(QSize(16777215, 150));
        btn_modelo_7->setCursor(QCursor(Qt::PointingHandCursor));
        QIcon icon2;
        icon2.addFile(QStringLiteral("../resources/modelos/modelo_7.png"), QSize(), QIcon::Normal, QIcon::Off);
        btn_modelo_7->setIcon(icon2);
        btn_modelo_7->setIconSize(QSize(200, 150));
        btn_modelo_7->setFlat(true);

        layout_btns_dir->addWidget(btn_modelo_7);

        btn_modelo_8 = new QPushButton(verticalLayoutWidget_2);
        btn_modelo_8->setObjectName(QStringLiteral("btn_modelo_8"));
        btn_modelo_8->setMinimumSize(QSize(0, 150));
        btn_modelo_8->setMaximumSize(QSize(16777215, 150));
        btn_modelo_8->setCursor(QCursor(Qt::PointingHandCursor));
        QIcon icon3;
        icon3.addFile(QStringLiteral("../resources/modelos/modelo_8.png"), QSize(), QIcon::Normal, QIcon::Off);
        btn_modelo_8->setIcon(icon3);
        btn_modelo_8->setIconSize(QSize(200, 150));
        btn_modelo_8->setFlat(true);

        layout_btns_dir->addWidget(btn_modelo_8);

        modelo = new QLabel(Aula_5);
        modelo->setObjectName(QStringLiteral("modelo"));
        modelo->setGeometry(QRect(220, 10, 584, 471));
        modelo->setPixmap(QPixmap(QString::fromUtf8("../resources/modelos/modelo_1.png")));
        modelo->setScaledContents(true);
        verticalLayoutWidget = new QWidget(Aula_5);
        verticalLayoutWidget->setObjectName(QStringLiteral("verticalLayoutWidget"));
        verticalLayoutWidget->setGeometry(QRect(0, 10, 214, 641));
        layout_btns_esq = new QVBoxLayout(verticalLayoutWidget);
        layout_btns_esq->setObjectName(QStringLiteral("layout_btns_esq"));
        layout_btns_esq->setContentsMargins(0, 0, 0, 0);
        btn_modelo_1 = new QPushButton(verticalLayoutWidget);
        btn_modelo_1->setObjectName(QStringLiteral("btn_modelo_1"));
        btn_modelo_1->setMinimumSize(QSize(0, 150));
        btn_modelo_1->setMaximumSize(QSize(16777215, 150));
        btn_modelo_1->setCursor(QCursor(Qt::PointingHandCursor));
        QIcon icon4;
        icon4.addFile(QStringLiteral("../resources/modelos/modelo_1.png"), QSize(), QIcon::Normal, QIcon::Off);
        btn_modelo_1->setIcon(icon4);
        btn_modelo_1->setIconSize(QSize(200, 150));
        btn_modelo_1->setFlat(true);

        layout_btns_esq->addWidget(btn_modelo_1);

        btn_modelo_2 = new QPushButton(verticalLayoutWidget);
        btn_modelo_2->setObjectName(QStringLiteral("btn_modelo_2"));
        btn_modelo_2->setMinimumSize(QSize(0, 150));
        btn_modelo_2->setMaximumSize(QSize(16777215, 150));
        btn_modelo_2->setCursor(QCursor(Qt::PointingHandCursor));
        QIcon icon5;
        icon5.addFile(QStringLiteral("../resources/modelos/modelo_2.png"), QSize(), QIcon::Normal, QIcon::Off);
        btn_modelo_2->setIcon(icon5);
        btn_modelo_2->setIconSize(QSize(200, 150));
        btn_modelo_2->setFlat(true);

        layout_btns_esq->addWidget(btn_modelo_2);

        btn_modelo_3 = new QPushButton(verticalLayoutWidget);
        btn_modelo_3->setObjectName(QStringLiteral("btn_modelo_3"));
        btn_modelo_3->setMinimumSize(QSize(0, 150));
        btn_modelo_3->setMaximumSize(QSize(16777215, 150));
        btn_modelo_3->setCursor(QCursor(Qt::PointingHandCursor));
        QIcon icon6;
        icon6.addFile(QStringLiteral("../resources/modelos/modelo_3.png"), QSize(), QIcon::Normal, QIcon::Off);
        btn_modelo_3->setIcon(icon6);
        btn_modelo_3->setIconSize(QSize(200, 150));
        btn_modelo_3->setFlat(true);

        layout_btns_esq->addWidget(btn_modelo_3);

        btn_modelo_4 = new QPushButton(verticalLayoutWidget);
        btn_modelo_4->setObjectName(QStringLiteral("btn_modelo_4"));
        btn_modelo_4->setMinimumSize(QSize(0, 150));
        btn_modelo_4->setMaximumSize(QSize(16777215, 150));
        btn_modelo_4->setCursor(QCursor(Qt::PointingHandCursor));
        QIcon icon7;
        icon7.addFile(QStringLiteral("../resources/modelos/modelo_4.png"), QSize(), QIcon::Normal, QIcon::Off);
        btn_modelo_4->setIcon(icon7);
        btn_modelo_4->setIconSize(QSize(200, 150));
        btn_modelo_4->setFlat(true);

        layout_btns_esq->addWidget(btn_modelo_4);

        mensagem = new QLabel(Aula_5);
        mensagem->setObjectName(QStringLiteral("mensagem"));
        mensagem->setGeometry(QRect(220, 520, 581, 131));
        QFont font1;
        font1.setFamily(QStringLiteral("Sans Serif"));
        font1.setPointSize(22);
        font1.setBold(true);
        font1.setWeight(75);
        mensagem->setFont(font1);
        mensagem->setAlignment(Qt::AlignCenter);

        retranslateUi(Aula_5);

        QMetaObject::connectSlotsByName(Aula_5);
    } // setupUi

    void retranslateUi(QWidget *Aula_5)
    {
        Aula_5->setWindowTitle(QApplication::translate("Aula_5", "Form", 0));
        btn_visualizar->setText(QApplication::translate("Aula_5", "Projetar Bacia", 0));
        btn_visualizar->setShortcut(QApplication::translate("Aula_5", "Ctrl+F", 0));
        btn_visualizar_relevo->setText(QApplication::translate("Aula_5", "Visualizar Relevo", 0));
        btn_visualizar_relevo->setShortcut(QApplication::translate("Aula_5", "Ctrl+P", 0));
        btn_validar->setText(QApplication::translate("Aula_5", "Validar Relevo", 0));
        btn_validar->setShortcut(QApplication::translate("Aula_5", "Ctrl+V", 0));
        btn_modelo_5->setText(QString());
        btn_modelo_5->setShortcut(QApplication::translate("Aula_5", "5", 0));
        btn_modelo_6->setText(QString());
        btn_modelo_6->setShortcut(QApplication::translate("Aula_5", "6", 0));
        btn_modelo_7->setText(QString());
        btn_modelo_7->setShortcut(QApplication::translate("Aula_5", "7", 0));
        btn_modelo_8->setText(QString());
        btn_modelo_8->setShortcut(QApplication::translate("Aula_5", "8", 0));
        modelo->setText(QString());
        btn_modelo_1->setText(QString());
        btn_modelo_1->setShortcut(QApplication::translate("Aula_5", "1", 0));
        btn_modelo_2->setText(QString());
        btn_modelo_2->setShortcut(QApplication::translate("Aula_5", "2", 0));
        btn_modelo_3->setText(QString());
        btn_modelo_3->setShortcut(QApplication::translate("Aula_5", "3", 0));
        btn_modelo_4->setText(QString());
        btn_modelo_4->setShortcut(QApplication::translate("Aula_5", "4", 0));
#ifndef QT_NO_TOOLTIP
        mensagem->setToolTip(QApplication::translate("Aula_5", "Percentual de acerto da bacia", 0));
#endif // QT_NO_TOOLTIP
        mensagem->setText(QString());
    } // retranslateUi

};

namespace Ui {
    class Aula_5: public Ui_Aula_5 {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_AULA_5_H
