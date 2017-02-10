/****************************************************************************
** Meta object code from reading C++ file 'aula_5.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.1)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "aula_5.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'aula_5.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.1. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_Aula_5_t {
    QByteArrayData data[13];
    char stringdata0[282];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_Aula_5_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_Aula_5_t qt_meta_stringdata_Aula_5 = {
    {
QT_MOC_LITERAL(0, 0, 6), // "Aula_5"
QT_MOC_LITERAL(1, 7, 25), // "on_btn_visualizar_clicked"
QT_MOC_LITERAL(2, 33, 0), // ""
QT_MOC_LITERAL(3, 34, 23), // "on_btn_modelo_1_clicked"
QT_MOC_LITERAL(4, 58, 23), // "on_btn_modelo_2_clicked"
QT_MOC_LITERAL(5, 82, 23), // "on_btn_modelo_3_clicked"
QT_MOC_LITERAL(6, 106, 23), // "on_btn_modelo_4_clicked"
QT_MOC_LITERAL(7, 130, 23), // "on_btn_modelo_5_clicked"
QT_MOC_LITERAL(8, 154, 23), // "on_btn_modelo_6_clicked"
QT_MOC_LITERAL(9, 178, 23), // "on_btn_modelo_7_clicked"
QT_MOC_LITERAL(10, 202, 23), // "on_btn_modelo_8_clicked"
QT_MOC_LITERAL(11, 226, 32), // "on_btn_visualizar_relevo_clicked"
QT_MOC_LITERAL(12, 259, 22) // "on_btn_validar_clicked"

    },
    "Aula_5\0on_btn_visualizar_clicked\0\0"
    "on_btn_modelo_1_clicked\0on_btn_modelo_2_clicked\0"
    "on_btn_modelo_3_clicked\0on_btn_modelo_4_clicked\0"
    "on_btn_modelo_5_clicked\0on_btn_modelo_6_clicked\0"
    "on_btn_modelo_7_clicked\0on_btn_modelo_8_clicked\0"
    "on_btn_visualizar_relevo_clicked\0"
    "on_btn_validar_clicked"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_Aula_5[] = {

 // content:
       7,       // revision
       0,       // classname
       0,    0, // classinfo
      11,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       0,       // signalCount

 // slots: name, argc, parameters, tag, flags
       1,    0,   69,    2, 0x08 /* Private */,
       3,    0,   70,    2, 0x08 /* Private */,
       4,    0,   71,    2, 0x08 /* Private */,
       5,    0,   72,    2, 0x08 /* Private */,
       6,    0,   73,    2, 0x08 /* Private */,
       7,    0,   74,    2, 0x08 /* Private */,
       8,    0,   75,    2, 0x08 /* Private */,
       9,    0,   76,    2, 0x08 /* Private */,
      10,    0,   77,    2, 0x08 /* Private */,
      11,    0,   78,    2, 0x08 /* Private */,
      12,    0,   79,    2, 0x08 /* Private */,

 // slots: parameters
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,

       0        // eod
};

void Aula_5::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        Aula_5 *_t = static_cast<Aula_5 *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->on_btn_visualizar_clicked(); break;
        case 1: _t->on_btn_modelo_1_clicked(); break;
        case 2: _t->on_btn_modelo_2_clicked(); break;
        case 3: _t->on_btn_modelo_3_clicked(); break;
        case 4: _t->on_btn_modelo_4_clicked(); break;
        case 5: _t->on_btn_modelo_5_clicked(); break;
        case 6: _t->on_btn_modelo_6_clicked(); break;
        case 7: _t->on_btn_modelo_7_clicked(); break;
        case 8: _t->on_btn_modelo_8_clicked(); break;
        case 9: _t->on_btn_visualizar_relevo_clicked(); break;
        case 10: _t->on_btn_validar_clicked(); break;
        default: ;
        }
    }
    Q_UNUSED(_a);
}

const QMetaObject Aula_5::staticMetaObject = {
    { &QWidget::staticMetaObject, qt_meta_stringdata_Aula_5.data,
      qt_meta_data_Aula_5,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *Aula_5::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *Aula_5::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_Aula_5.stringdata0))
        return static_cast<void*>(const_cast< Aula_5*>(this));
    return QWidget::qt_metacast(_clname);
}

int Aula_5::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QWidget::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 11)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 11;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 11)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 11;
    }
    return _id;
}
QT_END_MOC_NAMESPACE
