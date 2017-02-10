#include "mywidget.h"
#include <QKeyEvent>

MyWidget::MyWidget(QWidget *parent) : QWidget(parent)
{

}
void MyWidget::keyPressEvent(QKeyEvent *e)
{
    //const int tecla = int (e->key());
    this->close();
}
