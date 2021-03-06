#include "aula_2.h"
#include "ui_aula_2.h"
#include "mywidget.h"

#include <QKeyEvent>

#include <string.h>
#include <iostream>

QString imgFile = "../resources/modelos/modelo_1.png";

std::string imgSelecionada;

Aula_2::Aula_2(QWidget *parent) : QWidget(parent), ui(new Ui::Aula_2)
{
    ui->setupUi(this);
    wdgFullScreen = new MyWidget;
    imgFullScreen = new QLabel;
    imgSelecionada = "modelo_1.png";

}

Aula_2::~Aula_2()
{
    delete ui;    
    delete wdgFullScreen;
}

void Aula_2::keyPressEvent(QKeyEvent *e)
{
    const int tecla = int (e->key());

    if (tecla == 'F') {
        this->showImagemFullscreen();

    } else {
        //16777216 = esc
        if (tecla == 16777216 && !wdgFullScreen->isVisible()) {
            this->close();
        } else if (tecla == 16777216 && wdgFullScreen->isVisible()) {
            wdgFullScreen->close();
        }
    }
}

void Aula_2::on_btn_modelo_1_clicked()
{
    imgSelecionada = "modelo_1.png";
    TrocarImg();
}

void Aula_2::on_btn_modelo_2_clicked()
{
    imgSelecionada = "modelo_2.png";
    TrocarImg();
}

void Aula_2::on_btn_modelo_3_clicked()
{
    imgSelecionada = "modelo_3.png";
    TrocarImg();
}

void Aula_2::on_btn_modelo_4_clicked()
{
    imgSelecionada = "modelo_4.png";
    TrocarImg();
}

void Aula_2::on_btn_modelo_5_clicked()
{
    imgSelecionada = "modelo_5.png";
    TrocarImg();
}

void Aula_2::on_btn_modelo_6_clicked()
{
    imgSelecionada = "modelo_6.png";
    TrocarImg();
}

void Aula_2::on_btn_modelo_7_clicked()
{
    imgSelecionada = "modelo_7.png";
    TrocarImg();
}

void Aula_2::on_btn_modelo_8_clicked()
{
    imgSelecionada = "modelo_8.png";
    TrocarImg();
}

void Aula_2::on_btn_projetar_clicked()
{
    this->showImagemFullscreen();
}

void Aula_2::on_btn_visualizar_clicked()
{
    system("../auxs/SARndbox -uhm -fpv -wo 0");
}

void Aula_2::on_btn_validar_clicked()
{
    std::string captura = " ../resources/comparacoes/captura.png";

    //abrir sandbox
    system("../auxs/SARndbox -uhm -fpv &");

    //capturar a tela
    system("scrot -b -d 5 captura.png -e 'mv $f ../resources/comparacoes/'");

    //fechar SARndbox
    system("killall SARndbox");

    //comparar as imagens
    std::string comando = "./../auxs/ComparaImagens ";
    comando += imgFile.toStdString();
    comando += captura;

    int percentual = system(comando.c_str())/256;
    QString percentStr = QString::number(percentual);

    //salvando imagem selecionada
    QString strAux = imgFile;

    //exibir a imagem no label
    imgFile = "../resources/comparacoes/diferenca.png";
    QImage imagem(imgFile);
    ui->modelo->setPixmap(QPixmap::fromImage(imagem));
    ui->mensagem->setText("Você acertou "+percentStr+"%");

    //voltando ao modelo selecionado
    imgFile = strAux;
}

void Aula_2::TrocarImg()
{
    imgFile = "../resources/modelos/";
    imgFile.append(QString::fromStdString(imgSelecionada));

    QImage imagem(imgFile);
    ui->modelo->setPixmap(QPixmap::fromImage(imagem));
}

void Aula_2::showImagemFullscreen()
{

    // Exibe o QWidget
    wdgFullScreen = new MyWidget;
    wdgFullScreen->showFullScreen();
    // Habilita os eventos do mouse no label
    this->imgFullScreen->setMouseTracking(true);
    // Seta a imagem no label, inclusive a já validada
    this->imgFullScreen->setPixmap(QPixmap::fromImage (ui->modelo->pixmap()->toImage()));

    // Escala a imagem para o tamanho do label
    this->imgFullScreen->setScaledContents(true);

    QVBoxLayout* layout = new QVBoxLayout();
    layout->setContentsMargins(0, 0, 0, 0);
    layout->addWidget(this->imgFullScreen);
    wdgFullScreen->setLayout(layout);
    wdgFullScreen->setFocusPolicy(Qt::NoFocus);
}
