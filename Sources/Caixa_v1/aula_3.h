#ifndef AULA_3_H
#define AULA_3_H

#include <QWidget>
#include <QLabel>

namespace Ui {
class Aula_3;
}

class Aula_3 : public QWidget
{
    Q_OBJECT

public:
    explicit Aula_3(QWidget *parent = 0);
    ~Aula_3();

private slots:
    void on_btn_jogo_clicked();

    void on_btn_nascentes_clicked();

private:
    Ui::Aula_3 *ui;
};

#endif // AULA_3_H
