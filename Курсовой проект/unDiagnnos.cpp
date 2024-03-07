//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unDiagnnos.h"
#include "unDm.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TfrmDiagnos *frmDiagnos;
//---------------------------------------------------------------------------
__fastcall TfrmDiagnos::TfrmDiagnos(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TfrmDiagnos::Edit1Change(TObject *Sender)
{
if (Edit1->Text.Length()!=0)
{
frmDM->tbDiagnos->Filter="["+ComboBox2->Text+"] LIKE "+"'*"+Edit1->Text+"*"+"'";
frmDM->tbDiagnos->Filtered=True;
}
else
frmDM->tbDiagnos->Filtered=False;
}
//---------------------------------------------------------------------------
void __fastcall TfrmDiagnos::Button7Click(TObject *Sender)
{
Edit1->Clear();
frmDM->tbDiagnos->Active=False;
frmDM->tbDiagnos->Active=True;
frmDM->tbDiagnos->Filtered=False;           
}
//---------------------------------------------------------------------------
void __fastcall TfrmDiagnos::Button1Click(TObject *Sender)
{
Close();          
}
//---------------------------------------------------------------------------
