#include "aula_3.h"
#include "ui_aula_3.h"
#include "mywidget.h"

#include <stdio.h>
#include <string.h>
#include <iostream>

Aula_3::Aula_3(QWidget *parent) : QWidget(parent), ui(new Ui::Aula_3)
{
    ui->setupUi(this);
}

Aula_3::~Aula_3()
{
    delete ui;
}

void Aula_3::on_btn_jogo_clicked()
{
    system("../auxs/showFullScreen ../resources/modelos_com_marcadores/modelo_6.png");
}

void Aula_3::on_btn_nascentes_clicked()
{
    system("../auxs/SARndbox -uhm -fpv -wo 20.0 -rs 0.1 -evr -0.002");
}
