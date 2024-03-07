object frmDM: TfrmDM
  OldCreateOrder = False
  Left = 311
  Top = 115
  Height = 351
  Width = 550
  object ADOConnection1: TADOConnection
    Connected = True
    ConnectionString = 
      'Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source=db.md' +
      'b;Mode=Share Deny None;Extended Properties="";Persist Security I' +
      'nfo=False;Jet OLEDB:System database="";Jet OLEDB:Registry Path="' +
      '";Jet OLEDB:Database Password="";Jet OLEDB:Engine Type=5;Jet OLE' +
      'DB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;J' +
      'et OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Passw' +
      'ord="";Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt ' +
      'Database=False;Jet OLEDB:Don'#39't Copy Locale on Compact=False;Jet ' +
      'OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False'
    LoginPrompt = False
    Mode = cmShareDenyNone
    Provider = 'Microsoft.Jet.OLEDB.4.0'
    Left = 44
    Top = 8
  end
  object tbDiagnos: TADOTable
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    TableName = #1044#1080#1072#1075#1085#1086#1079
    Left = 136
    Top = 16
    object tbDiagnos_: TAutoIncField
      FieldName = #1053#1086#1084#1077#1088'_'#1076#1080#1072#1075#1085#1086#1079#1072
      ReadOnly = True
      Visible = False
    end
    object tbDiagnos_10: TWideStringField
      DisplayWidth = 30
      FieldName = #1050#1086#1076#1052#1050#1041'_10'
      Size = 255
    end
    object tbDiagnosDSDesigner: TWideStringField
      DisplayWidth = 30
      FieldName = #1044#1080#1072#1075#1085#1086#1079
      Size = 100
    end
    object tbDiagnosDSDesigner2: TWideStringField
      DisplayWidth = 30
      FieldName = #1054#1089#1086#1073#1077#1085#1085#1086#1089#1090#1080
      Size = 255
    end
    object tbDiagnos_2: TWideStringField
      DisplayWidth = 30
      FieldName = #1057#1088#1086#1082#1080'_'#1042#1053
      Size = 255
    end
  end
  object tbDoc: TADOTable
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    TableName = #1042#1088#1072#1095
    Left = 184
    Top = 16
    object tbDoc_: TAutoIncField
      FieldName = #1053#1086#1084#1077#1088'_'#1074#1088#1072#1095#1072
      ReadOnly = True
      Visible = False
    end
    object tbDoc_3: TWideStringField
      DisplayWidth = 25
      FieldName = #1060#1072#1084#1080#1083#1080#1103'_'#1074#1088#1072#1095#1072
      Size = 50
    end
    object tbDoc_2: TWideStringField
      DisplayWidth = 25
      FieldName = #1048#1084#1103'_'#1074#1088#1072#1095#1072
      Size = 50
    end
    object tbDoc_4: TWideStringField
      DisplayWidth = 25
      FieldName = #1054#1090#1095#1077#1089#1090#1074#1086'_'#1074#1088#1072#1095#1072
      Size = 50
    end
    object tbDocDSDesigner: TWideStringField
      DisplayWidth = 25
      FieldName = #1050#1074#1072#1083#1080#1092#1080#1082#1072#1094#1080#1103
      Size = 255
    end
    object tbDocDSDesigner2: TWideStringField
      DisplayWidth = 25
      FieldName = #1050#1072#1073#1080#1085#1077#1090
      Size = 255
    end
    object tbDocDSDesigner3: TWideStringField
      DisplayWidth = 25
      FieldName = #1057#1090#1072#1078
      Size = 255
    end
  end
  object dsDoc: TDataSource
    DataSet = tbDoc
    Left = 184
    Top = 64
  end
  object tbList: TADOTable
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    TableName = #1041#1086#1083#1100#1085#1080#1095#1085#1099#1081'_'#1083#1080#1089#1090
    Left = 232
    Top = 16
    object tbListField: TStringField
      DisplayWidth = 25
      FieldKind = fkLookup
      FieldName = #1042#1088#1072#1095
      LookupDataSet = tbDoc
      LookupKeyFields = #1053#1086#1084#1077#1088'_'#1074#1088#1072#1095#1072
      LookupResultField = #1060#1072#1084#1080#1083#1080#1103'_'#1074#1088#1072#1095#1072
      KeyFields = #1053#1086#1084#1077#1088'_'#1074#1088#1072#1095#1072
      Size = 40
      Lookup = True
    end
    object tbListField2: TStringField
      DisplayWidth = 50
      FieldKind = fkLookup
      FieldName = #1044#1080#1072#1075#1085#1086#1079
      LookupDataSet = tbDiagnos
      LookupKeyFields = #1053#1086#1084#1077#1088'_'#1076#1080#1072#1075#1085#1086#1079#1072
      LookupResultField = #1044#1080#1072#1075#1085#1086#1079
      KeyFields = #1053#1086#1084#1077#1088'_'#1076#1080#1072#1075#1085#1086#1079#1072
      Size = 80
      Lookup = True
    end
    object tbListField3: TStringField
      DisplayWidth = 25
      FieldKind = fkLookup
      FieldName = #1055#1072#1094#1080#1077#1085#1090
      LookupDataSet = tbPatient
      LookupKeyFields = #1053#1086#1084#1077#1088'_'#1087#1072#1094#1080#1077#1085#1090#1072
      LookupResultField = #1060#1072#1084#1080#1083#1080#1103'_'#1087#1072#1094#1080#1077#1085#1090#1072
      KeyFields = #1053#1086#1084#1077#1088'_'#1087#1072#1094#1080#1077#1085#1090#1072
      Size = 40
      Lookup = True
    end
    object tbList_5: TDateTimeField
      FieldName = #1044#1072#1090#1072'_'#1074#1099#1076#1072#1095#1080
    end
    object tbList_6: TDateTimeField
      FieldName = #1044#1072#1090#1072'_'#1079#1072#1082#1088#1099#1090#1080#1103
    end
    object tbList_7: TDateTimeField
      FieldName = #1044#1072#1090#1072'_'#1087#1088#1080#1077#1084#1072
    end
    object tbList_4: TIntegerField
      FieldName = #1053#1086#1084#1077#1088'_'#1087#1072#1094#1080#1077#1085#1090#1072
      Visible = False
    end
    object tbList_3: TIntegerField
      FieldName = #1053#1086#1084#1077#1088'_'#1076#1080#1072#1075#1085#1086#1079#1072
      Visible = False
    end
    object tbList_2: TIntegerField
      FieldName = #1053#1086#1084#1077#1088'_'#1074#1088#1072#1095#1072
      Visible = False
    end
    object tbList_: TAutoIncField
      FieldName = #1053#1086#1084#1077#1088'_'#1041#1051
      ReadOnly = True
      Visible = False
    end
  end
  object dsList: TDataSource
    DataSet = tbList
    Left = 232
    Top = 64
  end
  object dsPatient: TDataSource
    DataSet = tbPatient
    Left = 280
    Top = 64
  end
  object tbPatient: TADOTable
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    TableName = #1055#1072#1094#1080#1077#1085#1090
    Left = 280
    Top = 16
    object tbPatient_2: TWideStringField
      DisplayWidth = 15
      FieldName = #1053#1086#1084#1077#1088'_'#1087#1086#1083#1080#1089#1072
      Size = 50
    end
    object tbPatient_3: TIntegerField
      DisplayWidth = 15
      FieldName = #1053#1086#1084#1077#1088'_'#1091#1095#1072#1089#1090#1082#1072
    end
    object tbPatient_5: TWideStringField
      DisplayWidth = 30
      FieldName = #1060#1072#1084#1080#1083#1080#1103'_'#1087#1072#1094#1080#1077#1085#1090#1072
      Size = 50
    end
    object tbPatient_4: TWideStringField
      DisplayWidth = 30
      FieldName = #1048#1084#1103'_'#1087#1072#1094#1080#1077#1085#1090#1072
      Size = 50
    end
    object tbPatient_6: TWideStringField
      DisplayWidth = 30
      FieldName = #1054#1090#1095#1077#1089#1090#1074#1086'_'#1087#1072#1094#1080#1077#1085#1090#1072
      Size = 50
    end
    object tbPatient_7: TWideStringField
      DisplayWidth = 40
      FieldName = #1040#1076#1088#1077#1089'_'#1087#1072#1094#1080#1077#1085#1090#1072
      Size = 50
    end
    object tbPatient_8: TWideStringField
      DisplayWidth = 40
      FieldName = #1052#1077#1089#1090#1086'_'#1088#1072#1073#1086#1090#1099
      Size = 50
    end
    object tbPatient_: TAutoIncField
      FieldName = #1053#1086#1084#1077#1088'_'#1087#1072#1094#1080#1077#1085#1090#1072
      ReadOnly = True
      Visible = False
    end
  end
  object dsDiagnos: TDataSource
    DataSet = tbDiagnos
    Left = 136
    Top = 64
  end
end
