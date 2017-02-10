#ifndef AULA_5_H
#define AULA_5_H

#include <QWidget>
#include <QLabel>
#include <QKeyEvent>

namespace Ui {
class Aula_5;
}

class Aula_5 : public QWidget
{
    Q_OBJECT

public:
    explicit Aula_5(QWidget *parent = 0);
    ~Aula_5();

protected:
    void keyPressEvent(QKeyEvent *e);


private slots:
    void on_btn_visualizar_clicked();

    void on_btn_modelo_1_clicked();

    void on_btn_modelo_2_clicked();

    void on_btn_modelo_3_clicked();

    void on_btn_modelo_4_clicked();

    void on_btn_modelo_5_clicked();

    void on_btn_modelo_6_clicked();

    void on_btn_modelo_7_clicked();

    void on_btn_modelo_8_clicked();

    void on_btn_visualizar_relevo_clicked();

    void on_btn_validar_clicked();

private:
    Ui::Aula_5 *ui;

    QWidget *wdgFullScreen;
    QLabel *imgFullScreen;

    QString imgFile = "../resources/modelos/modelo_1.png";
    std::string imgSelecionada;
    std::string n_imgSelecionada;

    void TrocarImg();
    void showImagemFullscreen();
};

#endif // AULA_5_H
