object frmDiagnos: TfrmDiagnos
  Left = 192
  Top = 114
  Width = 792
  Height = 450
  Caption = #1044#1080#1072#1075#1085#1086#1079#1099
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Panel1: TPanel
    Left = 0
    Top = 291
    Width = 776
    Height = 121
    Align = alBottom
    TabOrder = 0
    object Bevel2: TBevel
      Left = 4
      Top = 29
      Width = 257
      Height = 88
    end
    object Label2: TLabel
      Left = 12
      Top = 35
      Width = 79
      Height = 13
      Caption = #1055#1086#1080#1089#1082' '#1087#1086' '#1087#1086#1083#1102':'
    end
    object DBNavigator1: TDBNavigator
      Left = 1
      Top = 1
      Width = 774
      Height = 24
      DataSource = frmDM.dsDiagnos
      Align = alTop
      TabOrder = 0
    end
    object Edit1: TEdit
      Left = 140
      Top = 58
      Width = 117
      Height = 21
      TabOrder = 1
      OnChange = Edit1Change
    end
    object ComboBox2: TComboBox
      Left = 12
      Top = 58
      Width = 125
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      ItemIndex = 0
      TabOrder = 2
      Text = #1050#1086#1076#1052#1050#1041'_10'
      OnChange = Edit1Change
      Items.Strings = (
        #1050#1086#1076#1052#1050#1041'_10'
        #1044#1080#1072#1075#1085#1086#1079
        #1054#1089#1086#1073#1077#1085#1085#1086#1089#1090#1080
        #1057#1088#1086#1082#1080'_'#1042#1053)
    end
    object Button7: TButton
      Left = 180
      Top = 86
      Width = 75
      Height = 25
      Caption = #1054#1095#1080#1089#1090#1080#1090#1100
      TabOrder = 3
      OnClick = Button7Click
    end
    object Button1: TButton
      Left = 698
      Top = 94
      Width = 75
      Height = 25
      Caption = #1047#1072#1082#1088#1099#1090#1100
      TabOrder = 4
      OnClick = Button1Click
    end
  end
  object DBGrid1: TDBGrid
    Left = 0
    Top = 0
    Width = 776
    Height = 291
    Align = alClient
    DataSource = frmDM.dsDiagnos
    TabOrder = 1
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'MS Sans Serif'
    TitleFont.Style = []
  end
end
