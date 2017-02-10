#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QKeyEvent>
#include "aula_2.h"
#include "aula_3.h"
#include "aula_5.h"

#include <stdlib.h>
#include<iostream>
#include<string>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

protected:
    void keyPressEvent(QKeyEvent *e);

private slots:
    void on_btn_aula_2_clicked();

    void on_actionProjetor_triggered();

    void on_actionMundo_triggered();

    void on_actionKinect_triggered();

    void on_btn_aula_1_clicked();

    void on_actionSite_do_Caixa_e_gua_triggered();

    void on_btn_aula_3_clicked();

    void on_btn_aula_4_clicked();

    void on_btn_aula_5_clicked();

private:
    Ui::MainWindow *ui;
    Aula_2 *aula2;
    Aula_3 *aula3;
    Aula_5 *aula5;

    void toggleOpcoes(bool ativar);
    std::string readBoxLayoutTemp(std::string arquivo);
    int writeFile(std::string arquivo, std::string texto);
};

#endif // MAINWINDOW_H
