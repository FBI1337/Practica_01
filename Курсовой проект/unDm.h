//---------------------------------------------------------------------------

#ifndef unDmH
#define unDmH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ADODB.hpp>
#include <DB.hpp>
//---------------------------------------------------------------------------
class TfrmDM : public TDataModule
{
__published:	// IDE-managed Components
        TADOConnection *ADOConnection1;
        TADOTable *tbDiagnos;
        TADOTable *tbDoc;
        TDataSource *dsDoc;
        TADOTable *tbList;
        TDataSource *dsList;
        TDataSource *dsPatient;
        TADOTable *tbPatient;
        TDataSource *dsDiagnos;
        TAutoIncField *tbDiagnos_;
        TWideStringField *tbDiagnos_10;
        TWideStringField *tbDiagnosDSDesigner;
        TWideStringField *tbDiagnosDSDesigner2;
        TWideStringField *tbDiagnos_2;
        TAutoIncField *tbDoc_;
        TWideStringField *tbDoc_2;
        TWideStringField *tbDoc_3;
        TWideStringField *tbDoc_4;
        TWideStringField *tbDocDSDesigner;
        TWideStringField *tbDocDSDesigner2;
        TWideStringField *tbDocDSDesigner3;
        TAutoIncField *tbList_;
        TIntegerField *tbList_2;
        TIntegerField *tbList_3;
        TIntegerField *tbList_4;
        TDateTimeField *tbList_5;
        TDateTimeField *tbList_6;
        TDateTimeField *tbList_7;
        TStringField *tbListField;
        TStringField *tbListField2;
        TAutoIncField *tbPatient_;
        TWideStringField *tbPatient_2;
        TIntegerField *tbPatient_3;
        TWideStringField *tbPatient_4;
        TWideStringField *tbPatient_5;
        TWideStringField *tbPatient_6;
        TWideStringField *tbPatient_7;
        TWideStringField *tbPatient_8;
        TStringField *tbListField3;
private:	// User declarations
public:		// User declarations
        __fastcall TfrmDM(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmDM *frmDM;
//---------------------------------------------------------------------------
#endif
