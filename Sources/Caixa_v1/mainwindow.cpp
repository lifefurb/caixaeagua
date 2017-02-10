#include "mainwindow.h"
#include "ui_mainwindow.h"

#include <QKeyEvent>
#include <QString>
#include <QDesktopServices>

#include <stdio.h>
#include <stdlib.h>
#include<iostream>
#include <fstream>

using namespace std;

MainWindow::MainWindow(QWidget *parent) : QMainWindow(parent), ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    aula2 = new Aula_2;
    aula3 = new Aula_3;
    aula5 = new Aula_5;
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::keyPressEvent(QKeyEvent *e)
{
    const int tecla = int (e->key());

    //16777216 = esc
    if (tecla == 16777216) {
        QApplication::quit();
    }
}

void MainWindow::on_btn_aula_1_clicked() {
    toggleOpcoes(false);
    system("../auxs/SARndbox -uhm -fpv -rs 0.1");
    toggleOpcoes(true);
}

void MainWindow::on_btn_aula_2_clicked() {
    toggleOpcoes(false);
    aula2->show();
    toggleOpcoes(true);
}

void MainWindow::on_btn_aula_3_clicked() {
    toggleOpcoes(false);
    aula3->show();
    toggleOpcoes(true);
}

void MainWindow::on_btn_aula_4_clicked() {
    toggleOpcoes(false);
    system("../auxs/SARndbox -uhm -fpv -wo 20.0 -ws 3.0 30 -rs 0.1 -evr -0.002");
    toggleOpcoes(true);
}

void MainWindow::on_btn_aula_5_clicked() {
    toggleOpcoes(false);
    //aula5->show();
    system("../auxs/SARndbox -uhm -fpv -wo 20.0 -ws 3.0 30 -rs 0.1 -evr -0.002");
    toggleOpcoes(true);
}

void MainWindow::on_actionProjetor_triggered() {
    //toggleOpcoes(false);
    system("../auxs/CalibrateProjector");
    //toggleOpcoes(true);
}

void MainWindow::on_actionMundo_triggered() {
    toggleOpcoes(false);
    system("../auxs/CalibrarMundo");
    toggleOpcoes(true);
}

void MainWindow::on_actionKinect_triggered() {
    toggleOpcoes(false);
    system("../auxs/RawKinectViewer > ../config/boxLayoutTemp.txt");
    string texto = readBoxLayoutTemp("../config/boxLayoutTemp.txt");
    cout << texto << endl;
    writeFile("$HOME/src/SARndbox-1.6/etc/SARndbox-1.6/BoxLayout.txt", texto);
    toggleOpcoes(true);
}

void MainWindow::on_actionSite_do_Caixa_e_gua_triggered() {
    toggleOpcoes(false);
    QString link = "http://www.caixae-agua.blogspot.com";
    QDesktopServices::openUrl(QUrl(link));
    toggleOpcoes(true);
}

void MainWindow::toggleOpcoes(bool ativar) {
    ui->btn_aula_1->setEnabled(ativar);
    ui->btn_aula_2->setEnabled(ativar);
    ui->btn_aula_3->setEnabled(ativar);
    ui->btn_aula_4->setEnabled(ativar);
    ui->btn_aula_5->setEnabled(ativar);

    ui->actionAula_1->setEnabled(ativar);
    ui->actionAula_2->setEnabled(ativar);
    ui->actionAula_3->setEnabled(ativar);
    ui->actionAula_4->setEnabled(ativar);
    ui->actionAula_5->setEnabled(ativar);

    ui->actionKinect->setEnabled(ativar);
    ui->actionProjetor->setEnabled(ativar);
    ui->actionMundo->setEnabled(ativar);

    ui->actionSite_do_Caixa_e_gua->setEnabled(ativar);
    ui->actionPerguntas_Frequ_ntes->setEnabled(ativar);
    ui->actionCr_ditos->setEnabled(ativar);
}

int MainWindow::writeFile(string arquivo, string texto) {
    ofstream myfile;
    myfile.open(arquivo);

    myfile << texto;

    myfile.close();

    return 0;
}

string MainWindow::readBoxLayoutTemp(string arquivo) {

    string line;
    string texto = "";
    ifstream infile;
    infile.open(arquivo);

    getline(infile, line); //Descartando a primeira linha

    // Segunda linha
    getline(infile, line);
    bool concatena = false;

    for (int i = 0; i < (int)line.size(); i++) {

        if (line[i] == '=') {
            texto += ',';
        } else if (line[i] == '(') {
            texto += line[i];
            concatena = true;
        } else if (concatena) {
            texto += line[i];
        }
    }

    texto += '\n';

    while (!infile.eof()) {
        getline(infile, line);
        texto.append(line+"\n");
    }

    infile.close();
    return texto;
}
