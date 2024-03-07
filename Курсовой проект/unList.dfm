object frmList: TfrmList
  Left = 163
  Top = 95
  Width = 998
  Height = 450
  Caption = #1041#1086#1083#1100#1085#1080#1095#1085#1099#1077' '#1083#1080#1089#1090#1099
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object DBGrid1: TDBGrid
    Left = 0
    Top = 0
    Width = 982
    Height = 352
    Align = alClient
    DataSource = frmDM.dsList
    TabOrder = 0
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'MS Sans Serif'
    TitleFont.Style = []
  end
  object Panel1: TPanel
    Left = 0
    Top = 352
    Width = 982
    Height = 60
    Align = alBottom
    TabOrder = 1
    object DBNavigator1: TDBNavigator
      Left = 1
      Top = 1
      Width = 980
      Height = 24
      DataSource = frmDM.dsList
      Align = alTop
      TabOrder = 0
    end
    object Button1: TButton
      Left = 903
      Top = 32
      Width = 75
      Height = 25
      Caption = #1047#1072#1082#1088#1099#1090#1100
      TabOrder = 1
      OnClick = Button1Click
    end
    object Button2: TButton
      Left = 824
      Top = 32
      Width = 75
      Height = 25
      Caption = #1055#1077#1095#1072#1090#1100
      TabOrder = 2
      OnClick = Button2Click
    end
  end
end
