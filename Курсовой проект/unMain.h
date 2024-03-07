//---------------------------------------------------------------------------

#ifndef unMainH
#define unMainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
#include <jpeg.hpp>
#include <Menus.hpp>
//---------------------------------------------------------------------------
class TfrmMain : public TForm
{
__published:	// IDE-managed Components
        TImage *Image1;
        TMainMenu *MainMenu1;
        TMenuItem *N1;
        TMenuItem *N8;
        TMenuItem *N9;
        TMenuItem *N2;
        TMenuItem *N7;
        TMenuItem *N3;
        TMenuItem *N4;
        TMenuItem *N5;
        void __fastcall N4Click(TObject *Sender);
        void __fastcall N8Click(TObject *Sender);
        void __fastcall N9Click(TObject *Sender);
        void __fastcall N7Click(TObject *Sender);
        void __fastcall N5Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
Variant App,Sh;
void __fastcall ExcelInit(String File);
void __fastcall toExcelCell(int c1,int c2, String data);
        __fastcall TMain(TComponent* Owner);
        __fastcall TfrmMain(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmMain *frmMain;
//---------------------------------------------------------------------------
#endif
