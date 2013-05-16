-- Script Date: 31/03/2013 15:48  - ErikEJ.SqlCeScripting version 3.5.2.26
-- Database information:
-- Locale Identifier: 1037
-- Encryption Mode: 
-- Case Sensitive: False
-- Database: C:\Projects\iTestOutlookAddIn\TesterConsole\App_Data\iTestData.sdf
-- ServerVersion: 4.0.8854.1
-- DatabaseSize: 131072
-- Created: 31/03/2013 15:43

-- User Table information:
-- Number of tables: 1
-- Candidates: 87 row(s)

CREATE TABLE [Candidates] (
  [CandidateID] uniqueidentifier NOT NULL
, [RegistrationDate] datetime NULL
, [IdentityNumber] nvarchar(9) NULL
, [FirstName] nvarchar(100) NULL
, [LastName] nvarchar(100) NULL
, [DateOfBirth] datetime NULL
, [IsActive] bit NULL
, [Events] nvarchar(4000) NULL
, [ResumePath] nvarchar(500) NULL
, [Experience] smallint NULL
, [Areas] nvarchar(1000) NULL
, [Roles] nvarchar(200) NULL
, [Phone] nvarchar(100) NULL
, [Mobile] nvarchar(100) NULL
, [EMailAddress] nvarchar(1000) NULL
, [Status] nvarchar(100) NULL
, [SentToCompanies] nvarchar(1000) NULL
, [Former8200] bit NULL
, [CandidateNumber] int NULL
, [MailEntryID] nvarchar(500) NULL
, [Reference] nvarchar(500) NULL
);
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('5f7502a0-edd7-4155-b9cf-fdacdb510fca',{ts '2013-03-12 18:50:40.000'},N'',N'Michael ',N'Herman',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil Tahoma;}{\f1\fnil\fcharset177 Tahoma;}{\f2\fnil\fcharset0 Tahoma;}{\f3\fnil\fcharset177 Microsoft Sans Serif;}{\f4\fnil\fcharset0 Microsoft Sans Serif;}}
{\colortbl ;\red255\green0\blue0;\red0\green0\blue0;}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\cf1\f0\fs16\par
\par
\f1\rtlch\''f9\''e1\''fa 16 \''ee\''f8\''f5 2013\f2\ltrch\lang1033  : \par
\cf2\f3\rtlch\fs17\lang1037\''f0\''f9\''ec\''e7 \''ec\''e7\''e1\''f8\''fa \''e0\''e9\''f0\''f4\''e5\''f8\''ee\''e8\''e9\''f7\''e4\cf0\f4\ltrch\lang1033\par
}
',N'C:\iTest Resumes\Michael _Herman_1000.doc',0,N'Security,Security',N'Team Leader',N'(  )    -',N'(   )    -',N'koyaya@gmail.com',N'Interview Process',N'',1,1000,N'0000000013AA26FE0049AB4584723E24E2F9EC1BA4992700',NULL);
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('85f63fb2-e8cd-42ff-9ef2-1babe4e22e20',{ts '2013-03-12 13:02:57.000'},N'',N'motti ',N'bukai',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil Tahoma;}{\f1\fnil\fcharset177 Tahoma;}{\f2\fnil\fcharset0 Tahoma;}{\f3\fnil\fcharset177 Microsoft Sans Serif;}{\f4\fnil\fcharset0 Microsoft Sans Serif;}}
{\colortbl ;\red255\green0\blue0;\red0\green0\blue0;}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\cf1\f0\fs16\par
\par
\f1\rtlch\''f9\''e1\''fa 16 \''ee\''f8\''f5 2013\f2\ltrch\lang1033  : \par
\cf2\f1\rtlch\lang1037\''f0\''f9\''ec\''e7 \''ec\''e7\''e1\''f8\''fa \''e8\''f8\''f1\''e8\''e9\''f8\par
\''f0\''e7\''f9\''f3\cf1\f0\ltrch\par
\par
\f1\rtlch\''f9\''e1\''fa 16 \''ee\''f8\''f5 2013\f2\ltrch\lang1033  : \par
\cf2\f3\rtlch\fs17\lang1037\''f0\''f9\''ec\''e7 \''ec\''e7\''e1\''f8\''fa \''e0\''e9\''f0\''f7\''f4\''f1\''e5\''ec\''e4\cf0\f4\ltrch\lang1033\par
}
',N'C:\iTest Resumes\motti _bukai_1001.docx',2,N'Security,Security',N'Programmer',N'(  )    -',N'(   )    -',N'bmottib@gmail.com',N'Interview Process',N'',1,1001,N'0000000013AA26FE0049AB4584723E24E2F9EC1B04952700',NULL);
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('a2bb4b87-8502-4726-a45e-78d6f0a0002a',{ts '2013-03-16 19:11:18.000'},N'',N'dror ',N'levy',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\dror _levy_1002.doc',1,N'Industrial Management',N'Junior Programmer',N'(  )    -',N'(   )    -',N'dror1levy@gmail.com',N'Classification',N'',0,1002,N'0000000013AA26FE0049AB4584723E24E2F9EC1B24BA2700',N'Facebook');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('1ecc523c-5c9d-45d9-9e83-f9cf3c748ebc',{ts '2013-03-16 16:34:55.000'},N'',N'איילת ',N'אמיר',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\איילת _אמיר_1003.docx',0,N'Electricity Engeneering',N'Student',N'(  )    -',N'(   )    -',N'ayeletamir1@gmail.com',N'Classification',N'',0,1003,N'0000000013AA26FE0049AB4584723E24E2F9EC1B44B92700',NULL);
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('a24c1307-9f13-4a19-83f2-02cbba5f0f7a',{ts '2013-03-16 13:06:01.000'},N'',N'אבי',N'פולק',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\אבי_פולק_1004.doc',0,N'Electricity Engeneering',N'Junior Programmer',N'(  )    -',N'(   )    -',N'avipollak.a@gmail.com',N'Classification',N'',0,1004,N'0000000013AA26FE0049AB4584723E24E2F9EC1B24B82700',NULL);
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('09432a22-e409-4027-a854-f9399a01d012',{ts '2013-03-14 20:21:31.000'},N'',N'יגאל',N'גרנדלר',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\יגאל_גרנדלר_1005.doc',0,N'Electricity Engeneering',N'',N'(  )    -',N'(   )    -',N'igalgrender@gmail.com',N'Classification',N'',0,1005,N'0000000013AA26FE0049AB4584723E24E2F9EC1BC4B32700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('cc824d6b-dbf3-4ae8-99bb-0f0e9e0c3d58',{ts '2013-03-14 20:14:14.000'},N'',N'עמיחי ',N'בנון',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\עמיחי _בנון_1006.doc',0,N'Electricity Engeneering',N'',N'(  )    -',N'(   )    -',N'amihai.bennoon1@gmail.com',N'Classification',N'',0,1006,N'0000000013AA26FE0049AB4584723E24E2F9EC1BE4B22700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('affd368e-1cec-44f6-b79b-75dc737a20e1',{ts '2013-03-14 17:28:33.000'},N'',N'zahi ',N'gradstion',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\zahi _gradstion_1007.doc',3,N'Developing',N'Programmer',N'(  )    -',N'(   )    -',N'zahigrad@gmail.com',N'Classification',N'',0,1007,N'0000000013AA26FE0049AB4584723E24E2F9EC1BE4B12700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('be83568a-0aac-438b-98ea-47fb7065cde7',{ts '2013-03-14 13:34:34.000'},N'',N'שמעון',N'תולט',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\שמעון_תולט_1008.rtf',2,N'Developing',N'Programmer',N'(  )    -',N'(   )    -',N'microto@gmail.com',N'Classification',N'',0,1008,N'0000000013AA26FE0049AB4584723E24E2F9EC1B24AF2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('4aafe780-0543-403c-ac8d-c02fd530f2b4',{ts '2013-02-26 20:41:57.000'},N'',N'מתן ',N'כספי',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\מתן _כספי_1009.doc',1,N'Analist',N'',N'(  )    -',N'(   )    -',N'caspimatan@gmail.com',N'Interview Process',N'',0,1009,N'0000000013AA26FE0049AB4584723E24E2F9EC1B24012700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('e47ff5d8-b79f-4568-84dd-018ad1bd5e14',{ts '2013-02-17 12:17:27.000'},N'',N'natalie ',N'barzilai',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\natalie _barzilai_1010.doc',3,N'Analist',N'Programmer',N'(  )    -',N'(   )    -',N'nbarzila@gmail.com',N'Classification',N'',0,1010,N'0000000013AA26FE0049AB4584723E24E2F9EC1B84912600',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('4c522703-022a-4279-a1ce-2aa5119d166a',{ts '2012-12-30 17:54:06.000'},N'',N'יותם',N'כהן',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\יותם_כהן_1011.doc',2,N'Security',N'Junior Programmer',N'(  )    -',N'(   )    -',N'xdethx@gmail.com',N'Interview Process',N'Incapsula',0,1011,N'0000000013AA26FE0049AB4584723E24E2F9EC1B44A02400',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('ebeedf7c-5630-483c-8531-3544e0798eb1',{ts '2013-03-11 16:50:31.000'},N'',N'Dudi ',N'Rubinstein',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Dudi _Rubinstein_1012.docx',5,N'Support',N'Team Leader',N'(  )    -',N'(   )    -',N'daverub@gmail.com',N'Classification',N'',0,1012,N'0000000013AA26FE0049AB4584723E24E2F9EC1BC4892700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('715b5cc1-1698-4027-8eda-b31ed5cb22a0',{ts '2013-03-17 06:15:44.000'},N'',N'אופיר',N'גוטמן',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\אופיר_גוטמן_1013.doc',0,N'Industrial Management',N'',N'(  )    -',N'(   )    -',N'ophir3003@gmail.com',N'Classification',N'',0,1013,N'0000000013AA26FE0049AB4584723E24E2F9EC1B24BD2700',N'LinkedIn');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('0b9d5d81-d160-4a40-8360-a0259b4fce64',{ts '2013-03-17 06:11:25.000'},N'',N'ציון',N'מיכאלוב',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\ציון_מיכאלוב_1014.doc',0,N'Automation,Electricity Engeneering',N'',N'(  )    -',N'(   )    -',N'zion.michaelov@gmail.com',N'Classification',N'',0,1014,N'0000000013AA26FE0049AB4584723E24E2F9EC1B44BD2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('1495e9e3-3ba7-4c17-b138-ad8c639eae9d',{ts '2013-03-14 02:18:26.000'},N'',N'Nir ',N'noy',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Nir _noy_1015.doc',1,N'Developing',N'',N'(  )    -',N'(   )    -',N'nir.fuzz@gmail.com',N'Classification',N'',0,1015,N'0000000013AA26FE0049AB4584723E24E2F9EC1B44AA2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('8e8e4456-39d6-41d1-8c4a-351ceb27f3b0',{ts '2013-03-17 00:41:11.000'},N'',N'Liel',N'מאור',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset177 Microsoft Sans Serif;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\rtlch\fs17\''f0\''e9\''e4\''e5\''ec \''f4\''f8\''e5\''e9\''e9\''f7\''e8\''e9\''ed\f1\ltrch\lang1033\par
}
',N'C:\iTest Resumes\Liel_מאור_1016.doc',2,N'Management',N'',N'(  )    -',N'(   )    -',N'lielart@gmail.com',N'Classification',N'',0,1016,N'0000000013AA26FE0049AB4584723E24E2F9EC1B84BD2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('956e4352-1c5e-4213-8480-43167686a384',{ts '2013-03-17 00:16:54.000'},N'',N'Michael ',N'Frishman',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Michael _Frishman_1017.docx',2,N'Industrial Management',N'',N'(  )    -',N'(   )    -',N'michaelfrishman2@gmail.com',N'Classification',N'',0,1017,N'0000000013AA26FE0049AB4584723E24E2F9EC1BC4BD2700',N'Facebook');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('7aa51a92-2245-45aa-9864-d8d1040b30b9',{ts '2013-03-16 22:48:08.000'},N'',N'אבי ',N'מיכאלי',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\אבי _מיכאלי_1018.doc',1,N'',N'',N'(  )    -',N'(   )    -',N'michaelia29@walla.com',N'Classification',N'',0,1018,N'0000000013AA26FE0049AB4584723E24E2F9EC1B04BC2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('f7980ff8-3290-4e67-adfc-1c165487cf1e',{ts '2013-03-13 21:24:53.000'},N'',N'בוריס',N'הרצברג',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\בוריס_הרצברג_1020.doc',3,N'Media',N'',N'(  )    -',N'(   )    -',N'syntpowder@gmail.com',N'Classification',N'',0,1020,N'0000000013AA26FE0049AB4584723E24E2F9EC1B04A92700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('83ac0cf1-df5a-4987-a171-d5bb9e77fc7c',{ts '2013-03-17 13:13:49.000'},N'',N'Avi',N'shitrit',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Avi_shitrit_1021.doc',3,N'Security',N'',N'(  )    -',N'(   )    -',N'avishitrit@hotmail.com',N'Classification',N'',0,1021,N'0000000013AA26FE0049AB4584723E24E2F9EC1B04C22700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('0764cebc-d8bc-4dfb-9987-21b739a455a6',{ts '2013-03-17 13:01:24.000'},N'',N'Marina ',N'Kurtin',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Marina _Kurtin_1022.doc',0,N'Manual',N'Junior QA',N'(  )    -',N'(   )    -',N'kurtin.marina@gmail.com',N'Classification',N'',0,1022,N'0000000013AA26FE0049AB4584723E24E2F9EC1B84C12700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('f1c815f9-a8ca-45ff-a88c-7f8742c3077b',{ts '2013-03-17 12:31:45.000'},N'',N'Michael ',N'Grach',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Michael _Grach_1023.doc',0,N'Electricity Engeneering',N'',N'(  )    -',N'(   )    -',N'michaelgrach@gmail.com',N'Classification',N'',0,1023,N'0000000013AA26FE0049AB4584723E24E2F9EC1BC4C02700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('eba19494-3a52-4d3a-99c1-816448c25cb2',{ts '2013-03-17 11:29:10.000'},N'',N'Rony ',N'צ''פליק',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Rony _צ''פליק_1024.docx',6,N'QA,Manual',N'Team Leader',N'(  )    -',N'(   )    -',N'ronychaplik@gmail.com',N'Classification',N'',0,1024,N'0000000013AA26FE0049AB4584723E24E2F9EC1BC4BF2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('212be621-b015-405a-914f-d4c0286fe891',{ts '2013-03-13 13:16:02.000'},N'',N'Levan ',N'Giguashvili',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Levan _Giguashvili_1025.doc',3,N'Developing',N'',N'(  )    -',N'(   )    -',N'levangig@gmail.com',N'Classification',N'',0,1025,N'0000000013AA26FE0049AB4584723E24E2F9EC1B64A22700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('e52d87f2-f600-4535-bd44-e1d8bdc86fd6',{ts '2013-03-14 21:39:51.000'},N'',N'Shirley ',N'Swissa',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Shirley _Swissa_1026.docx',1,N'Developing',N'Junior Programmer',N'(  )    -',N'(   )    -',N'swissashirley@gmail.com',N'Classification',N'',0,1026,N'0000000013AA26FE0049AB4584723E24E2F9EC1B04B42700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('d7e834b6-8963-49d6-b8e4-73515d06d71d',{ts '2013-03-14 15:21:01.000'},N'',N'אהוד',N'ביבי',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\אהוד_ביבי_1027.doc',0,N'Industrial Management',N'',N'(  )    -',N'(   )    -',N'bibi.ehud.1979@gmail.com',N'Classification',N'',0,1027,N'0000000013AA26FE0049AB4584723E24E2F9EC1BC4AF2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('ffd3d01c-06e7-463c-895e-510da69abcbf',{ts '2013-03-14 14:25:02.000'},N'',N'elad ',N'maimon',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\elad _maimon_1028.doc',2,N'Automation',N'',N'(  )    -',N'(   )    -',N'eladmm@hotmail.com',N'Classification',N'',0,1028,N'0000000013AA26FE0049AB4584723E24E2F9EC1BA4AF2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('d1aaf382-484c-4d01-ad58-a46f51b01fe0',{ts '2013-03-17 16:10:59.000'},N'',N'גיורא',N'גורן',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\גיורא_גורן_1029.doc',3,N'Product',N'',N'(  )    -',N'(   )    -',N'giora.goren1@gmail.com',N'Classification',N'',0,1029,N'0000000013AA26FE0049AB4584723E24E2F9EC1B64C62700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('147fbec4-fc31-40b7-a4ab-23882f4d322f',{ts '2013-03-17 21:28:01.000'},N'',N'yossi ',N'gilad',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\yossi _gilad_1030.docx',1,N'Electricity Engeneering,Support',N'',N'(  )    -',N'(   )    -',N'yoss.gilad@gmail.com',N'Classification',N'',0,1030,N'0000000013AA26FE0049AB4584723E24E2F9EC1B04CB2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('078624bd-fa9f-4587-98aa-ca0200315880',{ts '2013-03-17 20:17:33.000'},N'',N'שוקי',N'צדוק',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\שוקי_צדוק_1031.doc',0,N'Algorithem,Electricity Engeneering',N'',N'(  )    -',N'(   )    -',N'szadok473@gmail.com',N'Classification',N'',0,1031,N'0000000013AA26FE0049AB4584723E24E2F9EC1BA4CA2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('9bf6a605-e822-4724-8297-7c15997d6246',{ts '2013-03-17 20:08:16.000'},N'',N'אביבית בינשטוק',N'זהבי',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\אביבית בינשטוק_זהבי_1032.doc',1,N'ERP',N'',N'(  )    -',N'(   )    -',N'avivitzb@gmail.com',N'Classification',N'',0,1032,N'0000000013AA26FE0049AB4584723E24E2F9EC1BC4CA2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('25cbd5f0-5b90-4445-8605-7d17b5e13eb1',{ts '2013-03-17 19:14:40.000'},N'',N'ofer ',N'segev',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\ofer _segev_1033.pdf',0,N'Industrial Management',N'',N'(  )    -',N'(   )    -',N'segevofer@gmail.com',N'Classification',N'',1,1033,N'0000000013AA26FE0049AB4584723E24E2F9EC1B84CA2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('613cee43-2270-4218-b898-e7434e268c93',{ts '2013-03-17 22:37:50.000'},N'',N'Suzana ',N'Keynan',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Suzana _Keynan_1034.doc',10,N'PMO',N'',N'(  )    -',N'(   )    -',N'suzykeynan@gmail.com',N'Classification',N'',0,1034,N'0000000013AA26FE0049AB4584723E24E2F9EC1B64CB2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('796e0667-8d34-4032-a745-020acba27617',{ts '2013-03-17 22:38:46.000'},N'',N'דורון',N'טובול',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\דורון_טובול_1035.docx',1,N'Media',N'',N'(  )    -',N'(   )    -',N'anatzilber@yahoo.com',N'Classification',N'',0,1035,N'0000000013AA26FE0049AB4584723E24E2F9EC1B44CB2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('e840c86e-a90e-43a8-85c6-48558c0f3505',{ts '2013-03-17 18:19:30.000'},N'',N'כפיר',N'משה',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\כפיר_משה_1036.doc',3,N'Electricity Engeneering,Support',N'',N'(  )    -',N'(   )    -',N'kfirjh2@gmail.com',N'Classification',N'',0,1036,N'0000000013AA26FE0049AB4584723E24E2F9EC1B24CA2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('e3620cf2-12f9-45d8-8ed7-ef7fc6e4605d',{ts '2013-03-17 18:14:49.000'},N'',N'awad',N'Muhamad',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\awad_Muhamad_1037.doc',3,N'',N'',N'(  )    -',N'(   )    -',N'awad.muhammad.ion@gmail.com',N'Classification',N'',0,1037,N'0000000013AA26FE0049AB4584723E24E2F9EC1B44CA2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('4718c7a8-daee-468b-b0bc-da9a5105af68',{ts '2013-03-18 09:31:14.000'},N'',N'קלאוז ',N'קלאוז גנאדי',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\קלאוז _קלאוז גנאדי_1038.doc',2,N'Industrial Management',N'',N'(  )    -',N'(   )    -',N'larisak83@gmail.com',N'Classification',N'',0,1038,N'0000000013AA26FE0049AB4584723E24E2F9EC1B44CF2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('7cff5c75-eb63-4213-8ef3-c710008a5931',{ts '2013-03-18 09:21:57.000'},N'',N'דני ',N'גיפש',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\דני _גיפש_1039.docx',2,N'Developing',N'',N'(  )    -',N'(   )    -',N'dani_gipsh@walla.com',N'Classification',N'',1,1039,N'0000000013AA26FE0049AB4584723E24E2F9EC1B44CE2700',N'Facebook');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('89cbf2f2-ac00-4e76-975b-c8b997eba9be',{ts '2013-03-18 06:14:07.000'},N'',N'גבי ',N'רובינשטיין',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\גבי _רובינשטיין_1040.doc',0,N'BI',N'',N'(  )    -',N'(   )    -',N'rubinstein.gabby@gmail.com',N'Classification',N'',0,1040,N'0000000013AA26FE0049AB4584723E24E2F9EC1B84CD2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('4557123d-3d2d-42b7-9aea-d5948ccca918',{ts '2013-03-18 06:11:33.000'},N'',N'נאיף',N'בוקאי',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\נאיף_בוקאי_1041.doc',0,N'Developing',N'',N'(  )    -',N'(   )    -',N'bokaie.nayef2@gmail.com',N'Classification',N'',0,1041,N'0000000013AA26FE0049AB4584723E24E2F9EC1BA4CD2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('637a7e77-5477-4283-9007-949262451cc1',{ts '2013-03-18 01:55:39.000'},N'',N'Igor ',N'ramaniok',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Igor _ramaniok_1042.doc',0,N'Developing',N'',N'(  )    -',N'(   )    -',N'igorigor87@gmail.com',N'Classification',N'',0,1042,N'0000000013AA26FE0049AB4584723E24E2F9EC1BC4CD2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('735ce9fa-69bd-4492-a687-e05214a81295',{ts '2013-03-18 13:06:52.000'},N'',N'Amit ',N'Eshel',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Amit _Eshel_1043.doc',7,N'Media',N'',N'(  )    -',N'(   )    -',N'mitmit76@gmail.com',N'Classification',N'',0,1043,N'0000000013AA26FE0049AB4584723E24E2F9EC1BA4D42700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('fb9a6b5b-1cef-46af-85b5-5efac855ed0b',{ts '2013-03-18 12:35:27.000'},N'',N'ליאור ',N'שרעבי',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\ליאור _שרעבי_1044.pdf',3,N'Sales',N'',N'(  )    -',N'(   )    -',N'liorush1984@gmail.com',N'Classification',N'',0,1044,N'0000000013AA26FE0049AB4584723E24E2F9EC1B44D42700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('e098221b-c2cc-4323-9e38-c86aa0c63daa',{ts '2013-03-18 15:36:54.000'},N'',N'יוסי ',N'מזרחי',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\יוסי _מזרחי_1045.doc',0,N'Security',N'',N'(  )    -',N'(   )    -',N'mizrachi.yosi@gmail.com',N'Classification',N'',0,1045,N'0000000013AA26FE0049AB4584723E24E2F9EC1BC4D62700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('b40e6d50-dc17-4beb-a592-85e587e93d64',{ts '2013-02-28 14:43:57.160'},N'',N'מיכאל',N'פודגורצב  ',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\מיכאל_פודגורצב  _1046.doc',0,N'Industrial Management',N'',N'(  )    -',N'(   )    -',N'ilana@itest.co.il',N'Classification',N'',0,1046,N'0000000013AA26FE0049AB4584723E24E2F9EC1B04152700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('dc19b4a5-ece5-4a5f-a63b-2a4cf11222c9',{ts '2013-03-18 12:21:43.000'},N'',N'Eliad ',N'Asis',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Eliad _Asis_1047.doc',0,N'Industrial Management',N'',N'(  )    -',N'(   )    -',N'eliadasis@gmail.com',N'Classification',N'',0,1047,N'0000000013AA26FE0049AB4584723E24E2F9EC1B64D42700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('ce4122b6-ad9b-49ec-869a-4135c5269fa3',{ts '2013-03-18 11:32:04.000'},N'',N'Hadas ',N'Shekhter',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Hadas _Shekhter_1048.doc',7,N'Media',N'',N'(  )    -',N'(   )    -',N'hadas.shekhter@gmail.com',N'Classification',N'',0,1048,N'0000000013AA26FE0049AB4584723E24E2F9EC1B64D22700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('bc5e7113-aa95-495b-8821-730e64775526',{ts '2013-03-18 10:36:59.000'},N'',N'גיא ',N'יצחק',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\גיא _יצחק_1049.rtf',0,N'Security',N'',N'(  )    -',N'(   )    -',N'guy6656@gmail.com',N'Classification',N'',0,1049,N'0000000013AA26FE0049AB4584723E24E2F9EC1B04D12700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('636ac89f-7577-4f74-b095-2c67a05d9861',{ts '2013-03-18 10:07:16.000'},N'',N'Rita ',N'Vaitman',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Rita _Vaitman_1050.doc',0,N'ERP',N'',N'(  )    -',N'(   )    -',N'ritavaitman@gmail.com',N'Classification',N'',0,1050,N'0000000013AA26FE0049AB4584723E24E2F9EC1B04D02700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('73df28c6-ad3f-4aa1-86f4-9a6a66d195e6',{ts '2013-03-19 10:53:21.000'},N'',N'yoav ',N'ravid',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\yoav _ravid_1051.doc',2,N'QA,Manual',N'',N'(  )    -',N'(   )    -',N'yoavravid@gmail.com',N'Classification',N'',0,1051,N'0000000013AA26FE0049AB4584723E24E2F9EC1B24DF2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('1dacb490-188f-4f22-8d17-7d9993d2e23d',{ts '2013-03-19 10:49:25.000'},N'',N'Avi ',N'Sahar',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Avi _Sahar_1052.docx',2,N'',N'',N'(  )    -',N'(   )    -',N'sahar18@gmail.com',N'Classification',N'',0,1052,N'0000000013AA26FE0049AB4584723E24E2F9EC1B44DF2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('07023178-9af0-46d4-8f1f-fb4fc373c7f1',{ts '2013-03-19 09:50:34.000'},N'',N'לינה',N'טב',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\לינה_טב_1053.docx',7,N'QA',N'',N'(  )    -',N'(   )    -',N'elina.kaminsky@gmail.com',N'Classification',N'',0,1053,N'0000000013AA26FE0049AB4584723E24E2F9EC1B84DE2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('989a0cd3-b810-4d8a-9af5-839fb2d89c5a',{ts '2013-03-19 03:02:20.000'},N'',N'שרית',N'שובל',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\שרית_שובל_1054.pdf',4,N'Management',N'',N'(  )    -',N'(   )    -',N'dvaisman@gmail.com',N'Classification',N'',0,1054,N'0000000013AA26FE0049AB4584723E24E2F9EC1BC4DD2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('fa3a0ff0-0780-4e75-bba5-34f6a27925ef',{ts '2013-03-19 00:02:16.000'},N'',N'eyal ',N'belkin',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\eyal _belkin_1055.docx',0,N'Developing',N'',N'(  )    -',N'(   )    -',N'eyal.belkin@gmail.com',N'Classification',N'',0,1055,N'0000000013AA26FE0049AB4584723E24E2F9EC1B84DD2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('28cde49d-82b6-49ae-914d-09bf48ddc585',{ts '2013-03-19 11:11:39.000'},N'',N'edi ',N'dondish',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\edi _dondish_1056.docx',0,N'Industrial Management',N'',N'(  )    -',N'(   )    -',N'edondish@gmail.com',N'Classification',N'',0,1056,N'0000000013AA26FE0049AB4584723E24E2F9EC1B04E02700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('c8fd0108-f1e9-4152-a15a-09e71e2c2a39',{ts '2013-03-18 20:24:40.000'},N'',N'Tamir ',N'Buchris',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Tamir _Buchris_1057.pdf',0,N'Developing',N'',N'(  )    -',N'(   )    -',N'stamirbu@gmail.com',N'Classification',N'',0,1057,N'0000000013AA26FE0049AB4584723E24E2F9EC1B24DB2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('97f4e7a5-122d-4594-8fbb-d084b8d5e568',{ts '2013-03-18 20:12:18.000'},N'',N'שחר',N'זגדון',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\שחר_זגדון_1058.doc',0,N'Hardware',N'',N'(  )    -',N'(   )    -',N'shahar.zigdon1@gmail.com',N'Classification',N'',0,1058,N'0000000013AA26FE0049AB4584723E24E2F9EC1BC4DA2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('4e7167f1-e4e8-4c79-ae31-df0def919cb7',{ts '2013-03-18 18:20:34.000'},N'',N'אבינועם',N'פלאי',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\אבינועם_פלאי_1059.doc',2,N'ERP',N'',N'(  )    -',N'(   )    -',N'avinoampilli2@gmail.com',N'Classification',N'',0,1059,N'0000000013AA26FE0049AB4584723E24E2F9EC1B44D92700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('e484c9b4-474b-44c7-9b1c-82ade4b9db6c',{ts '2013-03-18 18:15:50.000'},N'',N'דורון',N'בנימיני',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\דורון_בנימיני_1061.doc',0,N'Developing',N'',N'(  )    -',N'(   )    -',N'doron.biny@gmail.com',N'Classification',N'',0,1061,N'0000000013AA26FE0049AB4584723E24E2F9EC1B64D92700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('6ed6dee1-b07f-4a12-8dc8-c1633ab1d03f',{ts '2013-03-18 18:15:00.000'},N'',N'מערוף ',N'בגדאדי',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\מערוף _בגדאדי_1062.doc',0,N'Developing',N'',N'(  )    -',N'(   )    -',N'marouf.bag@gmail.com',N'Classification',N'',0,1062,N'0000000013AA26FE0049AB4584723E24E2F9EC1B84D92700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('4844e8cb-53d6-4e46-ab87-d73e2aec0adf',{ts '2013-03-18 18:11:26.000'},N'',N'מיכאל ',N'גילין',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\מיכאל _גילין_1063.doc',10,N'Developing',N'',N'(  )    -',N'(   )    -',N'michaelgilin33@gmail.com',N'Classification',N'',0,1063,N'0000000013AA26FE0049AB4584723E24E2F9EC1BC4D92700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('9ac7ef62-fdea-46a4-abd9-e5b723a5fd2d',{ts '2013-03-18 17:23:48.000'},N'',N'שהין',N'גסנוב',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\שהין_גסנוב_1064.doc',10,N'Developing',N'',N'(  )    -',N'(   )    -',N'gasanov.g.sh@gmail.com',N'Classification',N'',0,1064,N'0000000013AA26FE0049AB4584723E24E2F9EC1B04D92700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('d577334d-9c97-411f-bd20-43552b766f78',{ts '2013-03-18 16:39:38.000'},N'',N'Amit',N'sher',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Amit_sher_1065.doc',0,N'Developing',N'',N'(  )    -',N'(   )    -',N'amitshar86@gmail.com',N'Classification',N'',0,1065,N'0000000013AA26FE0049AB4584723E24E2F9EC1B44D82700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('8adb8949-1f13-4f02-af3a-f4f89e4b49d6',{ts '2013-03-18 20:20:08.000'},N'',N'אסף',N'לירן',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\אסף_לירן_1066.doc',5,N'Management,Product',N'',N'(  )    -',N'(   )    -',N'liran.assaf.mr@gmail.com',N'Classification',N'',0,1066,N'0000000013AA26FE0049AB4584723E24E2F9EC1BA4DA2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('19244479-6abf-407c-9a2a-001238647b32',{ts '2013-03-20 10:08:24.000'},N'',N'Ori ',N'Horev',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Ori _Horev_1067.doc',5,N'QA,Manual',N'Team Leader',N'(  )    -',N'(   )    -',N'orihorev@gmail.com',N'Classification',N'',0,1067,N'0000000013AA26FE0049AB4584723E24E2F9EC1BA4E72700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('cc5cb35e-9ab0-464a-b6b7-d364735be958',{ts '2013-03-21 07:58:56.000'},N'',N'Shay ',N'Lebel',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Shay _Lebel_1068.doc',0,N'Electricity Engeneering',N'',N'(  )    -',N'(   )    -',N'shay.lebel@gmail.com',N'Classification',N'',0,1068,N'0000000013AA26FE0049AB4584723E24E2F9EC1B64F02700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('46ef0e0c-fe31-47ef-8755-d16333326785',{ts '2013-03-20 20:42:07.000'},N'',N'Aleksey ',N'Orlov',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Aleksey _Orlov_1069.doc',2,N'Industrial Management',N'',N'(  )    -',N'(   )    -',N'slexor@mail.technion.ac.il',N'Classification',N'',0,1069,N'0000000013AA26FE0049AB4584723E24E2F9EC1B84EF2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('aa09a06c-ca8f-4d93-b1de-b0144a658b78',{ts '2013-03-20 20:17:38.000'},N'',N'דינה',N'חורי',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\דינה_חורי_1070.doc',0,N'Developing',N'',N'(  )    -',N'(   )    -',N'bhhir135@gmail.com',N'Classification',N'',0,1070,N'0000000013AA26FE0049AB4584723E24E2F9EC1BA4EC2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('449745bc-3aec-40e9-9117-da3e623f501f',{ts '2013-03-20 19:13:01.000'},N'',N'dolev ',N'עידן',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\dolev _עידן_1071.doc',5,N'Security,Developing',N'',N'(  )    -',N'(   )    -',N'idandl@013.net',N'Classification',N'',0,1071,N'0000000013AA26FE0049AB4584723E24E2F9EC1BE4EC2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('7baed78a-93d0-40e8-92fd-30b4d441c6aa',{ts '2013-03-20 18:16:13.000'},N'',N'אלעד',N'סופר',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\אלעד_סופר_1072.doc',3,N'Industrial Management',N'',N'(  )    -',N'(   )    -',N'elad.sofer4@gmail.com',N'Classification',N'',0,1072,N'0000000013AA26FE0049AB4584723E24E2F9EC1B64ED2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('cb8c46d1-f828-4ec0-af01-119a1bb39fb7',{ts '2013-03-20 18:15:13.000'},N'',N'ארז',N'טאובר',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\ארז_טאובר_1073.doc',0,N'Industrial Management',N'',N'(  )    -',N'(   )    -',N'ereztauber82@gmail.com',N'Classification',N'',0,1073,N'0000000013AA26FE0049AB4584723E24E2F9EC1B84ED2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('b7ab3381-85ab-4b23-90a8-5be3fe57380e',{ts '2013-03-20 17:57:16.000'},N'',N'Natalia ',N'Sverchkov',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Natalia _Sverchkov_1074.doc',10,N'Developing',N'',N'(  )    -',N'(   )    -',N'natalia_sverchkov@yahoo.com',N'Classification',N'',0,1074,N'0000000013AA26FE0049AB4584723E24E2F9EC1BC4ED2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('54087d56-859e-4741-9415-e0b7cfc61ab1',{ts '2013-03-20 17:47:11.000'},N'',N'stas ',N'gilman',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\stas _gilman_1075.doc',0,N'Industrial Management',N'',N'(  )    -',N'(   )    -',N'stasgilman@gmail.com',N'Classification',N'',0,1075,N'0000000013AA26FE0049AB4584723E24E2F9EC1B24EE2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('5efeb4c1-ee00-4a19-aeaa-5774ae9ddb9b',{ts '2013-03-20 17:40:45.000'},N'',N'Gali ',N'Riman',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Gali _Riman_1076.doc',1,N'',N'',N'(  )    -',N'(   )    -',N'galiariman@gmail.com',N'Classification',N'',0,1076,N'0000000013AA26FE0049AB4584723E24E2F9EC1B44EE2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('dc2b88e4-e05f-4616-a609-cfe6a23e0702',{ts '2013-03-20 17:38:06.000'},N'',N'tal ',N'lerman',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\tal _lerman_1077.doc',2,N'Industrial Management',N'',N'(  )    -',N'(   )    -',N'lermantal@gmail.com',N'Classification',N'',0,1077,N'0000000013AA26FE0049AB4584723E24E2F9EC1B64EE2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('652b007a-5fc6-435d-bdbb-f7f6d34a455d',{ts '2013-03-20 16:22:38.000'},N'',N'רוני ',N'אלאלוף',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\רוני _אלאלוף_1078.doc',5,N'Sales',N'',N'(  )    -',N'(   )    -',N'rony53ala@gmail.com',N'Classification',N'',0,1078,N'0000000013AA26FE0049AB4584723E24E2F9EC1BE4EE2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('b53f9023-ee6a-4af4-9eb0-59def77e213c',{ts '2013-03-20 16:15:33.000'},N'',N'חגי ',N'סולומון',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\חגי _סולומון_1079.doc',10,N'Sales',N'',N'(  )    -',N'(   )    -',N'hagaysolomon2@gmail.com',N'Classification',N'',0,1079,N'0000000013AA26FE0049AB4584723E24E2F9EC1B04EF2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('b9a5dd35-4d2c-4498-8c2c-9a30eebbe70b',{ts '2013-03-20 16:14:29.000'},N'',N'דודי',N'פצ''ניק',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\דודי_פצ''ניק_1080.doc',3,N'Industrial Management',N'',N'(  )    -',N'(   )    -',N'davidpechnic@gmail.com',N'Classification',N'',0,1080,N'0000000013AA26FE0049AB4584723E24E2F9EC1B24EF2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('a4cd0d86-320a-423c-99c5-2948f62cb503',{ts '2013-03-20 13:45:55.000'},N'',N'Hadas ',N'Shekhter',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Hadas _Shekhter_1081.doc',5,N'Media',N'',N'(  )    -',N'(   )    -',N'hadas.shekhter@gmail.com',N'Classification',N'',0,1081,N'0000000013AA26FE0049AB4584723E24E2F9EC1B44EB2700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('af663844-9a86-46ac-9daf-a9358b0f9726',{ts '2013-03-20 00:29:56.000'},N'',N'Tyron ',N'Rohland',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Tyron _Rohland_1082.doc',4,N'Security,Support',N'',N'(  )    -',N'(   )    -',N'tbone@totallyawesome.co.za',N'Classification',N'',0,1082,N'0000000013AA26FE0049AB4584723E24E2F9EC1BE4E62700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('a336f1c4-307a-41aa-8a93-0fba9e5ab52a',{ts '2013-03-19 22:59:32.000'},N'',N'Avital ',N'Lavie',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Avital _Lavie_1083.doc',10,N'Developing',N'',N'(  )    -',N'(   )    -',N'abbylavie@gmail.com',N'Classification',N'',1,1083,N'0000000013AA26FE0049AB4584723E24E2F9EC1B84E62700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('877cecea-464d-410b-8b17-fe3d783c2727',{ts '2013-03-19 22:31:51.000'},N'',N'michal ',N'anavim',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\michal _anavim_1084.doc',3,N'Analist',N'',N'(  )    -',N'(   )    -',N'michalana@gmail.com',N'Classification',N'',0,1084,N'0000000013AA26FE0049AB4584723E24E2F9EC1B64E62700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('aafbd77d-0802-4549-a848-3bdf197b8359',{ts '2013-03-19 21:17:26.000'},N'',N'Tzvika ',N'Furman',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Tzvika _Furman_1085.pdf',3,N'Support',N'',N'(  )    -',N'(   )    -',N'tzvikachu@gmail.com',N'Classification',N'',0,1085,N'0000000013AA26FE0049AB4584723E24E2F9EC1BA4E52700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('25d784b3-edb0-46fe-9ee6-2dccdc1ff405',{ts '2013-03-19 20:47:03.000'},N'',N'Sharon ',N'Abu',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\Sharon _Abu_1086.doc',4,N'Developing',N'Team Leader',N'(  )    -',N'(   )    -',N'sharon.abu@gmail.com',N'Classification',N'',0,1086,N'0000000013AA26FE0049AB4584723E24E2F9EC1B44E52700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('2cf8cbee-ff76-4c61-8ecd-8390068d5c4c',{ts '2013-03-19 19:18:20.000'},N'',N'asher ',N'tal',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\asher _tal_1087.doc',3,N'Developing',N'',N'(  )    -',N'(   )    -',N'asher_tal@yahoo.com',N'Classification',N'',0,1087,N'0000000013AA26FE0049AB4584723E24E2F9EC1B24E42700',N'');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference]) VALUES ('2b54891b-0edb-4eab-bcbf-d2112e160ad7',{ts '2013-03-19 18:21:18.000'},N'',N'יגאל',N'קריבושי',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\יגאל_קריבושי_1088.doc',0,N'Hardware',N'',N'(  )    -',N'(   )    -',N'igok27@gmail.com',N'Classification',N'',0,1088,N'0000000013AA26FE0049AB4584723E24E2F9EC1B84E32700',N'');
GO
ALTER TABLE [Candidates] ADD CONSTRAINT [PK_Candidates] PRIMARY KEY ([CandidateID]);
GO

