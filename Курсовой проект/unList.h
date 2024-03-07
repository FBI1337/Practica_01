//---------------------------------------------------------------------------

#ifndef unListH
#define unListH
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
class TfrmList : public TForm
{
__published:	// IDE-managed Components
        TDBGrid *DBGrid1;
        TPanel *Panel1;
        TDBNavigator *DBNavigator1;
        TButton *Button1;
        TButton *Button2;
        void __fastcall Button1Click(TObject *Sender);
        void __fastcall Button2Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TfrmList(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmList *frmList;
//---------------------------------------------------------------------------
#endif
