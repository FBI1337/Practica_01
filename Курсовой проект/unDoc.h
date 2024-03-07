//---------------------------------------------------------------------------

#ifndef unDocH
#define unDocH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <DBCtrls.hpp>
#include <DBGrids.hpp>
#include <ExtCtrls.hpp>
#include <Grids.hpp>
//---------------------------------------------------------------------------
class TfrmDoc : public TForm
{
__published:	// IDE-managed Components
        TPanel *Panel1;
        TBevel *Bevel2;
        TLabel *Label2;
        TDBNavigator *DBNavigator1;
        TEdit *Edit1;
        TComboBox *ComboBox2;
        TButton *Button7;
        TButton *Button1;
        TDBGrid *DBGrid1;
        void __fastcall Button1Click(TObject *Sender);
        void __fastcall Edit1Change(TObject *Sender);
        void __fastcall Button7Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TfrmDoc(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmDoc *frmDoc;
//---------------------------------------------------------------------------
#endif
