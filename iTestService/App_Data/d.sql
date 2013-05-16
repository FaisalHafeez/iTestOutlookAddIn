-- Script Date: 31/03/2013 15:38  - ErikEJ.SqlCeScripting version 3.5.2.26
-- Database information:
-- Locale Identifier: 1037
-- Encryption Mode: 
-- Case Sensitive: False
-- Database: C:\Projects\iTestOutlookAddIn\iTestService\App_Data\iTestData.sdf
-- ServerVersion: 4.0.8854.1
-- DatabaseSize: 131072
-- Created: 22/03/2013 19:53

-- User Table information:
-- Number of tables: 2
-- Candidates: 6 row(s)
-- Resume: 0 row(s)

CREATE TABLE [Resume] (
  [ResumeID] uniqueidentifier NOT NULL
, [FileName] nvarchar(100) NULL
, [MimeType] nvarchar(100) NULL
, [FileContent] image NULL
);
GO
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
, [Username] nvarchar(100) NULL
);
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference],[Username]) VALUES ('e10d812d-9957-452e-92c7-ca460d3bd868',{ts '2013-03-20 14:26:20.000'},N'',N'Oren Gal',N'',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\f0\fs17\par
}
',N'C:\iTest Resumes\Oren Gal__1003.rar',0,N'',N'',N'(  )    -',N'(   )    -',N'oren.gal@gmail.com',N'Classification',N'',0,1003,N'000000006F4DC4873CEB6640850BFCE270D00786043C2A00',N'',N'ilana');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference],[Username]) VALUES ('85f63fb2-e8cd-42ff-9ef2-1babe4e22e20',{ts '2013-03-12 13:02:57.000'},N'',N'motti ',N'bukai',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil Tahoma;}{\f1\fnil\fcharset177 Tahoma;}{\f2\fnil\fcharset0 Tahoma;}{\f3\fnil\fcharset177 Microsoft Sans Serif;}{\f4\fnil\fcharset0 Microsoft Sans Serif;}}
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
',N'C:\iTest Resumes\motti _bukai_1001.docx',2,N'Security,Security',N'Programmer',N'(  )    -',N'(   )    -',N'bmottib@gmail.com',N'Interview Process',N'',1,1001,N'0000000013AA26FE0049AB4584723E24E2F9EC1B04952700',NULL,N'ilana');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference],[Username]) VALUES ('a2bb4b87-8502-4726-a45e-78d6f0a0002a',{ts '2013-03-16 19:11:18.000'},N'',N'dror ',N'levy',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\fbidis\ansi\ansicpg1255\deff0\nouicompat\deflang1037{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\ltrpar\f0\fs17\lang1033\par
}
',N'C:\iTest Resumes\dror _levy_1002.doc',1,N'Industrial Management',N'Junior Programmer',N'(  )    -',N'(   )    -',N'dror1levy@gmail.com',N'Classification',N'',0,1002,N'0000000013AA26FE0049AB4584723E24E2F9EC1B24BA2700',NULL,N'ilana');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference],[Username]) VALUES ('a99fbcf2-12d8-4768-b5a6-65a9c69e44b8',{ts '2013-01-31 11:56:30.000'},N'',N'מנשה גרשון',N'',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\f0\fs17\par
}
',N'C:\iTest Resumes\מנשה גרשון__1004.pps',0,N'',N'',N'(  )    -',N'(   )    -',N'meng@bezeqint.net',N'Classification',N'',0,1004,N'000000006F4DC4873CEB6640850BFCE270D00786A41A2000',N'',N'ilana');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference],[Username]) VALUES ('b07a82ab-526b-4218-b51d-4ec6f6046948',{ts '2013-02-12 10:01:36.000'},N'',N'Shaul FELDINGER',N'',{ts '2013-03-24 00:00:00.000'},NULL,N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\f0\fs17\par
}
',N'C:\iTest Resumes\Shaul FELDINGER__1005.pps',9,N'Hardware',N'Director',N'(  )    -',N'(   )    -',N'shaul@dcbr.ro',N'Classification',N'',0,1005,N'000000006F4DC4873CEB6640850BFCE270D0078604132000',N'',N'ilana');
GO
INSERT INTO [Candidates] ([CandidateID],[RegistrationDate],[IdentityNumber],[FirstName],[LastName],[DateOfBirth],[IsActive],[Events],[ResumePath],[Experience],[Areas],[Roles],[Phone],[Mobile],[EMailAddress],[Status],[SentToCompanies],[Former8200],[CandidateNumber],[MailEntryID],[Reference],[Username]) VALUES ('f3e656fc-8ec6-49fe-93e5-1ff5fc5608d0',{ts '2013-03-23 21:29:42.000'},N'',N'meir',N'',{ts '1900-01-01 00:00:00.000'},NULL,N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
{\*\generator Riched20 14.0.6015.1000;}{\*\mmathPr\mwrapIndent1440}\viewkind4\uc1
\pard\f0\fs17\par
}
',N'C:\iTest Resumes\meir__1007.pdf',0,N'',N'',N'(  )    -',N'(   )    -',N'meir-li@bezeqint.net',N'Classification',N'',0,1007,N'000000006F4DC4873CEB6640850BFCE270D00786044C2A00',N'',N'ilana');
GO
ALTER TABLE [Resume] ADD CONSTRAINT [PK_Resume] PRIMARY KEY ([ResumeID]);
GO
ALTER TABLE [Candidates] ADD CONSTRAINT [PK_Candidates] PRIMARY KEY ([CandidateID]);
GO
CREATE UNIQUE INDEX [UQ__Resume__0000000000000040] ON [Resume] ([ResumeID] ASC);
GO

