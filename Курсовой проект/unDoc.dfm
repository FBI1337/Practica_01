object frmDoc: TfrmDoc
  Left = 214
  Top = 110
  Width = 983
  Height = 437
  Caption = #1042#1088#1072#1095#1080
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
    Top = 278
    Width = 967
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
      Width = 965
      Height = 24
      DataSource = frmDM.dsDoc
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
      Text = #1060#1072#1084#1080#1083#1080#1103'_'#1074#1088#1072#1095#1072
      OnChange = Edit1Change
      Items.Strings = (
        #1060#1072#1084#1080#1083#1080#1103'_'#1074#1088#1072#1095#1072
        #1048#1084#1103'_'#1074#1088#1072#1095#1072
        #1054#1090#1095#1077#1089#1090#1074#1086'_'#1074#1088#1072#1095#1072
        #1050#1074#1072#1083#1080#1092#1080#1082#1072#1094#1080#1103
        #1050#1072#1073#1080#1085#1077#1090
        #1057#1090#1072#1078)
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
      Left = 890
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
    Width = 967
    Height = 278
    Align = alClient
    DataSource = frmDM.dsDoc
    TabOrder = 1
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'MS Sans Serif'
    TitleFont.Style = []
  end
end
