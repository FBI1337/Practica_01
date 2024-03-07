//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unMain.h"
#include "unDm.h"
#include "unDiagnnos.h"
#include "unDoc.h"
#include "unList.h"
#include "unPatient.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TfrmMain *frmMain;

void __fastcall TfrmMain::ExcelInit(String File)
{
  // если Excel запущен - подключиться к нему 
  try {
   App=Variant::GetActiveObject("Excel.Application");
  } catch(...) {
     // Excel не запущен - запустить его
     try { App=Variant::CreateObject("Excel.Application"); } catch (...) {
      Application->MessageBox("Невозможно открыть Microsoft Excel!"
      "Возможно Excel не установлен на компьютере.","Ошибка",MB_OK+MB_ICONERROR);
  } }
  try {
    if(File!="")
     App.OlePropertyGet("WorkBooks").OleProcedure("Open",File.c_str());
    else
     App.OlePropertyGet("WorkBooks").OleProcedure("add");

    Sh=App.OlePropertyGet("WorkSheets",1);
  } catch(...) {
    Application->MessageBox("Ошибка открытия книги Microsoft Excel!",
                                         "Ошибка",MB_OK+MB_ICONERROR);
  }
}/* ExcelInit() */

void __fastcall TfrmMain::toExcelCell(int Row,int Column, AnsiString data)
{
  try {
    Variant cur = Sh.OlePropertyGet("Cells", Row,Column);
    cur.OlePropertySet("Value", data.c_str());
  } catch(...) { ; }
}/* toExcelCell() */

//---------------------------------------------------------------------------
__fastcall TfrmMain::TfrmMain(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::N4Click(TObject *Sender)
{
Close();        
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::N8Click(TObject *Sender)
{
    frmDM->tbDiagnos->Active=True;
    frmDM->tbDiagnos->Active=False;
    frmDiagnos->Show();
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::N9Click(TObject *Sender)
{
frmDM->tbDoc->Active=False;
frmDM->tbDoc->Active=True;
frmDoc->Show();        
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::N7Click(TObject *Sender)
{
frmDM->tbDiagnos->Active=False;
frmDM->tbDiagnos->Active=True;
frmDM->tbPatient->Active=False;
frmDM->tbPatient->Active=True;
frmDM->tbDoc->Active=False;
frmDM->tbDoc->Active=True;
frmDM->tbList->Active=False;
frmDM->tbList->Active=True;
frmList->Show();
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::N5Click(TObject *Sender)
{
frmDM->tbPatient->Active=False;
frmDM->tbPatient->Active=True;
frmPatient->Show();
}
//---------------------------------------------------------------------------
