/********************************************************************************
** Form generated from reading UI file 'aula_3.ui'
**
** Created by: Qt User Interface Compiler version 5.6.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_AULA_3_H
#define UI_AULA_3_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QVBoxLayout>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_Aula_3
{
public:
    QWidget *verticalLayoutWidget;
    QVBoxLayout *verticalLayout;
    QPushButton *btn_jogo;
    QPushButton *btn_nascentes;

    void setupUi(QWidget *Aula_3)
    {
        if (Aula_3->objectName().isEmpty())
            Aula_3->setObjectName(QStringLiteral("Aula_3"));
        Aula_3->resize(222, 190);
        QIcon icon;
        icon.addFile(QStringLiteral("../resources/logos/icone.jpg"), QSize(), QIcon::Normal, QIcon::Off);
        Aula_3->setWindowIcon(icon);
        verticalLayoutWidget = new QWidget(Aula_3);
        verticalLayoutWidget->setObjectName(QStringLiteral("verticalLayoutWidget"));
        verticalLayoutWidget->setGeometry(QRect(20, 20, 181, 151));
        verticalLayout = new QVBoxLayout(verticalLayoutWidget);
        verticalLayout->setObjectName(QStringLiteral("verticalLayout"));
        verticalLayout->setContentsMargins(0, 0, 0, 0);
        btn_jogo = new QPushButton(verticalLayoutWidget);
        btn_jogo->setObjectName(QStringLiteral("btn_jogo"));
        QSizePolicy sizePolicy(QSizePolicy::Minimum, QSizePolicy::Minimum);
        sizePolicy.setHorizontalStretch(0);
        sizePolicy.setVerticalStretch(0);
        sizePolicy.setHeightForWidth(btn_jogo->sizePolicy().hasHeightForWidth());
        btn_jogo->setSizePolicy(sizePolicy);
        QFont font;
        font.setPointSize(14);
        font.setBold(true);
        font.setItalic(false);
        font.setWeight(75);
        btn_jogo->setFont(font);
        btn_jogo->setCursor(QCursor(Qt::PointingHandCursor));
        btn_jogo->setFlat(false);

        verticalLayout->addWidget(btn_jogo);

        btn_nascentes = new QPushButton(verticalLayoutWidget);
        btn_nascentes->setObjectName(QStringLiteral("btn_nascentes"));
        sizePolicy.setHeightForWidth(btn_nascentes->sizePolicy().hasHeightForWidth());
        btn_nascentes->setSizePolicy(sizePolicy);
        btn_nascentes->setFont(font);
        btn_nascentes->setCursor(QCursor(Qt::PointingHandCursor));
        btn_nascentes->setFlat(false);

        verticalLayout->addWidget(btn_nascentes);


        retranslateUi(Aula_3);

        QMetaObject::connectSlotsByName(Aula_3);
    } // setupUi

    void retranslateUi(QWidget *Aula_3)
    {
        Aula_3->setWindowTitle(QApplication::translate("Aula_3", "Aula 03", 0));
        btn_jogo->setText(QApplication::translate("Aula_3", "Jogo", 0));
        btn_jogo->setShortcut(QApplication::translate("Aula_3", "J", 0));
        btn_nascentes->setText(QApplication::translate("Aula_3", "Nascentes", 0));
        btn_nascentes->setShortcut(QApplication::translate("Aula_3", "N", 0));
    } // retranslateUi

};

namespace Ui {
    class Aula_3: public Ui_Aula_3 {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_AULA_3_H
