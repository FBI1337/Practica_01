//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unPatient.h"
#include "unDm.h"
#include "unMain.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TfrmPatient *frmPatient;
//---------------------------------------------------------------------------
__fastcall TfrmPatient::TfrmPatient(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TfrmPatient::Button1Click(TObject *Sender)
{
Close();        
}
//---------------------------------------------------------------------------
void __fastcall TfrmPatient::Edit1Change(TObject *Sender)
{
if (Edit1->Text.Length()!=0)
{
frmDM->tbPatient->Filter="["+ComboBox2->Text+"] LIKE "+"'*"+Edit1->Text+"*"+"'";
frmDM->tbPatient->Filtered=True;
}
else
frmDM->tbPatient->Filtered=False;           
}
//---------------------------------------------------------------------------
void __fastcall TfrmPatient::Button7Click(TObject *Sender)
{
Edit1->Clear();
frmDM->tbPatient->Active=False;
frmDM->tbPatient->Active=True;
frmDM->tbPatient->Filtered=False;           
}
//---------------------------------------------------------------------------
void __fastcall TfrmPatient::Button2Click(TObject *Sender)
{
int i, j;
String Path;
// ��������� Excel, ���� �� �� �������

// ��������� Excel, ���� �� �� �������
frmMain->ExcelInit("");
frmMain->App.OlePropertySet("Visible", true);

frmMain->toExcelCell(2,2,String("����������� �������� � "+frmDM->tbPatient->FieldValues["�����_��������"]));
   
j=2;
for (i=0;i<frmDM->tbPatient->FieldCount; i++)
  if (frmDM->tbPatient->FieldList->Fields[i]->Visible)
   frmMain->toExcelCell(4+i,j,String(frmDM->tbPatient->FieldList->Fields[i]->DisplayName));

j=3;
for (i=0;i<frmDM->tbPatient->FieldCount; i++)
  if (frmDM->tbPatient->FieldList->Fields[i]->Visible)
          if (!frmDM->tbPatient->FieldValues [String(frmDM->tbPatient->FieldList->Fields[i]->DisplayName)].IsNull())
   frmMain->toExcelCell(4+i,j,String(frmDM->tbPatient->FieldValues [String(frmDM->tbPatient->FieldList->Fields[i]->DisplayName)]));

// ������������� ������ �������
 frmMain->App.OlePropertyGet("Columns").OlePropertyGet("Item",2).OleProcedure("AutoFit");
 frmMain->App.OlePropertyGet("Columns").OlePropertyGet("Item",3).OleProcedure("AutoFit");
 //frmMain->App.OlePropertyGet("Columns").OlePropertyGet("Item",3).OlePropertySet("ColumnWidth", 16);

Variant Rang; 
 Rang = frmMain->App.OlePropertyGet("Range", "b4:c10");
 Rang.OlePropertyGet("Borders").OlePropertySet("LineStyle", 1);
  
 
Path=ExtractFilePath(Application->ExeName)+ "����������� �������� � "+frmDM->tbPatient->FieldValues["�����_��������"]+".xls";
try
{
frmMain->App.OlePropertyGet("WorkBooks",1).OleProcedure("SaveAs",Path.c_str());
}
catch (...)
{

}
}
//---------------------------------------------------------------------------

