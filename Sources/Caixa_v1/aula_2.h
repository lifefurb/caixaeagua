#ifndef AULA_2_H
#define AULA_2_H

#include <QWidget>
#include <QLabel>
#include <QKeyEvent>

namespace Ui {
class Aula_2;
}

class Aula_2 : public QWidget
{
    Q_OBJECT

public:
    explicit Aula_2(QWidget *parent = 0);
    ~Aula_2();

protected:
    void keyPressEvent(QKeyEvent *e);

private slots:
    void on_btn_modelo_1_clicked();

    void on_btn_modelo_2_clicked();

    void on_btn_modelo_3_clicked();

    void on_btn_modelo_4_clicked();

    void on_btn_modelo_5_clicked();

    void on_btn_modelo_6_clicked();

    void on_btn_modelo_7_clicked();

    void on_btn_modelo_8_clicked();

    void on_btn_projetar_clicked();

    void on_btn_visualizar_clicked();

    void on_btn_validar_clicked();

private:
    Ui::Aula_2 *ui;

    QWidget *wdgFullScreen;
    QLabel *imgFullScreen;

    void TrocarImg();
    void showImagemFullscreen();
};

#endif // AULA_2_H
