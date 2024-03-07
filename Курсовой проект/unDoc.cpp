//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unDoc.h"
#include "unDm.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TfrmDoc *frmDoc;
//---------------------------------------------------------------------------
__fastcall TfrmDoc::TfrmDoc(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TfrmDoc::Button1Click(TObject *Sender)
{
Close();        
}
//---------------------------------------------------------------------------
void __fastcall TfrmDoc::Edit1Change(TObject *Sender)
{
if (Edit1->Text.Length()!=0)
{
frmDM->tbDoc->Filter="["+ComboBox2->Text+"] LIKE "+"'*"+Edit1->Text+"*"+"'";
frmDM->tbDoc->Filtered=True;
}
else
frmDM->tbDoc->Filtered=False;        
}
//---------------------------------------------------------------------------
void __fastcall TfrmDoc::Button7Click(TObject *Sender)
{
Edit1->Clear();
frmDM->tbDoc->Active=False;
frmDM->tbDoc->Active=True;
frmDM->tbDoc->Filtered=False;          
}
//---------------------------------------------------------------------------
