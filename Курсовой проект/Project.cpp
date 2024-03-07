//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
//---------------------------------------------------------------------------
USEFORM("unMain.cpp", frmMain);
USEFORM("unDoc.cpp", frmDoc);
USEFORM("unPatient.cpp", frmPatient);
USEFORM("unList.cpp", frmList);
USEFORM("unDiagnnos.cpp", frmDiagnos);
USEFORM("unDm.cpp", frmDM); /* TDataModule: File Type */
//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
        try
        {
                 Application->Initialize();
                 Application->CreateForm(__classid(TfrmMain), &frmMain);
                 Application->CreateForm(__classid(TfrmDoc), &frmDoc);
                 Application->CreateForm(__classid(TfrmPatient), &frmPatient);
                 Application->CreateForm(__classid(TfrmList), &frmList);
                 Application->CreateForm(__classid(TfrmDiagnos), &frmDiagnos);
                 Application->CreateForm(__classid(TfrmDM), &frmDM);
                 Application->Run();
        }
        catch (Exception &exception)
        {
                 Application->ShowException(&exception);
        }
        catch (...)
        {
                 try
                 {
                         throw Exception("");
                 }
                 catch (Exception &exception)
                 {
                         Application->ShowException(&exception);
                 }
        }
        return 0;
}
//---------------------------------------------------------------------------
