//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unList.h"
#include "unDm.h"
#include "unMain.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TfrmList *frmList;
//---------------------------------------------------------------------------
__fastcall TfrmList::TfrmList(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TfrmList::Button1Click(TObject *Sender)
{
Close();        
}
//---------------------------------------------------------------------------
void __fastcall TfrmList::Button2Click(TObject *Sender)
{
int i, j;
String Path;

if (frmDM->tbList->RecordCount==0)
return;

// запускаем Excel, если он не запущен
frmMain->ExcelInit("");
frmMain->App.OlePropertySet("Visible", true);

frmMain->toExcelCell(2,2,String("Больничный лист № "+frmDM->tbList->FieldValues["Номер_БЛ"]));

j=2;
for (i=0;i<frmDM->tbList->FieldCount; i++)
  if (frmDM->tbList->FieldList->Fields[i]->Visible)
   frmMain->toExcelCell(4+i,j,String(frmDM->tbList->FieldList->Fields[i]->DisplayName));

j=3;
for (i=0;i<frmDM->tbList->FieldCount; i++)
  if (frmDM->tbList->FieldList->Fields[i]->Visible)
        if (!frmDM->tbList->FieldValues [String(frmDM->tbList->FieldList->Fields[i]->DisplayName)].IsNull())
   frmMain->toExcelCell(4+i,j,String(frmDM->tbList->FieldValues [String(frmDM->tbList->FieldList->Fields[i]->DisplayName)]));
      
// устанавливаем ширину столбца
 frmMain->App.OlePropertyGet("Columns").OlePropertyGet("Item",2).OleProcedure("AutoFit");
 frmMain->App.OlePropertyGet("Columns").OlePropertyGet("Item",3).OleProcedure("AutoFit");

Variant Rang; 
 Rang = frmMain->App.OlePropertyGet("Range", "b4:c9");
 Rang.OlePropertyGet("Borders").OlePropertySet("LineStyle", 1);


Path=ExtractFilePath(Application->ExeName)+ "Больничный лист № "+frmDM->tbList->FieldValues["Номер_БЛ"]+".xls";

try
{
frmMain->App.OlePropertyGet("WorkBooks",1).OleProcedure("SaveAs",Path.c_str());
}
catch (...)
{

}
}
//---------------------------------------------------------------------------

