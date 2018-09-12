CREATE SCHEMA OneRoster;
GO

CREATE TABLE OneRoster.Base (
  SourcedId                             UNIQUEIDENTIFIER  NOT NULL CONSTRAINT DF_Base_SourcedId        DEFAULT NEWSEQUENTIALID(),
  ObjectType                            VARCHAR(15)       COLLATE Latin1_General_CS_AS NOT NULL,
  IsActive                              BIT               NOT NULL CONSTRAINT DF_Base_IsActive         DEFAULT 1,
  DateCreated                           DATETIME2         NOT NULL CONSTRAINT DF_Base_DateCreated      DEFAULT SYSUTCDATETIME(),
  DateLastModified                      DATETIME2         NOT NULL CONSTRAINT DF_Base_DateLastModified DEFAULT SYSUTCDATETIME(),

  CONSTRAINT PK_Base PRIMARY KEY ( SourcedId ),
  -- For foreign key purposes:
  CONSTRAINT UQ_Base_SourcedId_ObjectType UNIQUE ( SourcedId, ObjectType ),
  CONSTRAINT CK_Base_ObjectType CHECK ( ObjectType IN (
    'AcademicSession',
    'Category',
    'Course',
    'Class',
    'Demographics',
    'Enrollment',
    'Org',
    'Resource',
    'LineItem',
    'Result',
    'User'
  ))
);


CREATE TABLE OneRoster.Metadata (
  SourcedId                             UNIQUEIDENTIFIER  NOT NULL,
  [Key]                                 NVARCHAR(255)     NOT NULL,
  [Value]                               NVARCHAR(255)         NULL,

  CONSTRAINT PK_Metadata PRIMARY KEY ( SourcedId, [Key] ),
  CONSTRAINT UQ_Metadata_SourcedId_Key UNIQUE ( SourcedId, [Key] ),
  CONSTRAINT FK_Metadata_Base          FOREIGN KEY                          ( SourcedId )
                                       REFERENCES OneRoster.Base            ( SourcedId ),
);


CREATE TABLE OneRoster.AcademicSession (
  SourcedId                             UNIQUEIDENTIFIER  NOT NULL,
  ObjectType                            AS CAST('AcademicSession' AS VARCHAR(15)) COLLATE Latin1_General_CS_AS PERSISTED,
  ParentAcademicSessionSourcedId        UNIQUEIDENTIFIER      NULL,
  [Type]                                VARCHAR(13)       COLLATE Latin1_General_CS_AS NOT NULL,
  Title                                 NVARCHAR(255)     NOT NULL,
  StartDate                             DATETIME2         NOT NULL,
  EndDate                               DATETIME2         NOT NULL,
  SchoolYear                            SMALLINT          NOT NULL,

  CONSTRAINT PK_AcademicSession PRIMARY KEY ( SourcedId ),
  CONSTRAINT FK_AcademicSession_Base   FOREIGN KEY                          ( SourcedId, ObjectType )
                                       REFERENCES OneRoster.Base            ( SourcedId, ObjectType ),
  CONSTRAINT FK_AcademicSession_Parent FOREIGN KEY                          ( ParentAcademicSessionSourcedId )
                                       REFERENCES OneRoster.AcademicSession ( SourcedId ),
  CONSTRAINT CK_AcademicSession_Type CHECK ( [Type] IN (
    'gradingPeriod',
    'semester',
    'schoolYear',
    'term'
  )),
  CONSTRAINT CK_AcademicSession_SchoolYear CHECK ( SchoolYear >= 1000 AND SchoolYear <= 9999 )
);


CREATE TABLE OneRoster.Category (
  SourcedId                             UNIQUEIDENTIFIER  NOT NULL,
  ObjectType                            AS CAST('Category' AS VARCHAR(15)) COLLATE Latin1_General_CS_AS PERSISTED,
  Title                                 NVARCHAR(255)     NOT NULL,

  CONSTRAINT PK_Category PRIMARY KEY ( SourcedId ),
  CONSTRAINT FK_Category_Base          FOREIGN KEY                          ( SourcedId, ObjectType )
                                       REFERENCES OneRoster.Base            ( SourcedId, ObjectType ),
);


CREATE TABLE OneRoster.Course (
  SourcedId                             UNIQUEIDENTIFIER  NOT NULL,
  ObjectType                            AS CAST('Course' AS VARCHAR(15)) COLLATE Latin1_General_CS_AS PERSISTED,
  Title                                 NVARCHAR(255)     NOT NULL,
  SchoolYear                            SMALLINT              NULL,
  CourseCode                            NVARCHAR(255)         NULL,
  OrgSourcedId                          UNIQUEIDENTIFIER  NOT NULL,
  -- TODO: grades, subjects, subjectCodes, resources

  CONSTRAINT PK_Course PRIMARY KEY ( SourcedId ),
  CONSTRAINT FK_Course_Base            FOREIGN KEY                          ( SourcedId, ObjectType )
                                       REFERENCES OneRoster.Base            ( SourcedId, ObjectType ),
  CONSTRAINT CK_Course_SchoolYear CHECK ( SchoolYear >= 1000 AND SchoolYear <= 9999 )
);


CREATE TABLE OneRoster.Class (
  SourcedId                             UNIQUEIDENTIFIER  NOT NULL,
  ObjectType                            AS CAST('Class' AS VARCHAR(15)) COLLATE Latin1_General_CS_AS PERSISTED,
  Title                                 NVARCHAR(255)     NOT NULL,
  SchoolYear                            SMALLINT              NULL,
  ClassCode                             NVARCHAR(255)         NULL,
  [Type]                                VARCHAR(11)       COLLATE Latin1_General_CS_AS NULL, -- Spec requires 1 ClassType; intentionally violating spec.
  [Location]                            NVARCHAR(255)         NULL,
  CourseSourcedId                       UNIQUEIDENTIFIER  NOT NULL,
  SchoolOrgSourcedId                    UNIQUEIDENTIFIER  NOT NULL,
  -- TODO: grades, subjects, terms, subjectCodes, periods, resources

  CONSTRAINT PK_Class PRIMARY KEY ( SourcedId ),
  CONSTRAINT FK_Class_Base             FOREIGN KEY                          ( SourcedId, ObjectType )
                                       REFERENCES OneRoster.Base            ( SourcedId, ObjectType ),
  CONSTRAINT CK_Class_SchoolYear CHECK ( SchoolYear >= 1000 AND SchoolYear <= 9999 ),
  CONSTRAINT CK_Class_Type CHECK ( [Type] IS NULL OR [Type] IN ( 'homeroom', 'scheduled' ) ),
);


CREATE TABLE OneRoster.Demographics (
  SourcedId                             UNIQUEIDENTIFIER  NOT NULL,
  ObjectType                            AS CAST('Demographics' AS VARCHAR(15)) COLLATE Latin1_General_CS_AS PERSISTED,
  BirthDate                             DATE                  NULL,
  AmericanIndianOrAlaskaNative          BIT                   NULL,
  Asian                                 BIT                   NULL,
  BlackOrAfricanAmerican                BIT                   NULL,
  NativeHawaiianOrOtherPacificIslander  BIT                   NULL,
  White                                 BIT                   NULL,
  DemographicRaceTwoOrMoreRaces         BIT                   NULL,
  HispanicOrLatinoEthnicity             BIT                   NULL,
  Sex                                   NVARCHAR(255)         NULL,
  CountryOfBirthCode                    NVARCHAR(255)         NULL,
  StateOfBirthAbbreviation              NVARCHAR(255)         NULL,
  CityOfBirth                           NVARCHAR(255)         NULL,
  PublicSchoolResidenceStatus           NVARCHAR(255)         NULL,

  CONSTRAINT PK_Demographics PRIMARY KEY ( SourcedId ),
  CONSTRAINT FK_Demographics_Base      FOREIGN KEY                          ( SourcedId, ObjectType )
                                       REFERENCES OneRoster.Base            ( SourcedId, ObjectType ),
);


CREATE TABLE OneRoster.Enrollment (
  SourcedId                             UNIQUEIDENTIFIER  NOT NULL,
  ObjectType                            AS CAST('Enrollment' AS VARCHAR(15)) COLLATE Latin1_General_CS_AS PERSISTED,
  UserSourcedId                         UNIQUEIDENTIFIER  NOT NULL,
  ClassSourcedId                        UNIQUEIDENTIFIER  NOT NULL,
  [Role]                                VARCHAR(13)       COLLATE Latin1_General_CS_AS NOT NULL,
  [Primary]                             BIT                   NULL,
  BeginDate                             DATE                  NULL,
  EndDate                               DATE                  NULL,

  CONSTRAINT PK_Enrollment PRIMARY KEY ( SourcedId ),
  CONSTRAINT FK_Enrollment_Base      FOREIGN KEY                          ( SourcedId, ObjectType )
                                     REFERENCES OneRoster.Base            ( SourcedId, ObjectType ),
  CONSTRAINT CK_Enrollment_Role CHECK ( [Role] IN (
    -- Not allowed: aide, guardian, parent, relative.
    'administrator',
    'proctor',
    'student',
    'teacher'
  )),
  CONSTRAINT CK_Enrollment_Primary CHECK ( [Primary] IS NULL OR [Role] = 'teacher' )
);


CREATE TABLE OneRoster.Org (
  SourcedId                             UNIQUEIDENTIFIER  NOT NULL,
  ObjectType                            AS CAST('Org' AS VARCHAR(15)) COLLATE Latin1_General_CS_AS PERSISTED,
  ParentOrgSourcedId                    UNIQUEIDENTIFIER      NULL,
  Identifier                            NVARCHAR(255)         NULL,
  [Name]                                NVARCHAR(255)     NOT NULL,
  [Type]                                VARCHAR(10)       COLLATE Latin1_General_CS_AS NOT NULL,

  CONSTRAINT PK_Org PRIMARY KEY ( SourcedId ),
  CONSTRAINT FK_Org_Base             FOREIGN KEY                          ( SourcedId, ObjectType )
                                     REFERENCES OneRoster.Base            ( SourcedId, ObjectType ),
  CONSTRAINT CK_Org_Type CHECK ( [Type] IN ( 'department', 'school', 'district', 'local', 'state', 'national' )),
);


CREATE TABLE OneRoster.Resource (
  SourcedId                             UNIQUEIDENTIFIER  NOT NULL,
  ObjectType                            AS CAST('Resource' AS VARCHAR(15)) COLLATE Latin1_General_CS_AS PERSISTED,
  Title                                 NVARCHAR(255)         NULL,
  Importance                            VARCHAR(9)        COLLATE Latin1_General_CS_AS NULL,
  VendorResourceId                      NVARCHAR(255)     NOT NULL,
  VendorId                              NVARCHAR(255)         NULL,
  ApplicationId                         NVARCHAR(255)         NULL,
  -- TODO: roles

  CONSTRAINT PK_Resource PRIMARY KEY ( SourcedId ),
  CONSTRAINT FK_Resource_Base        FOREIGN KEY                          ( SourcedId, ObjectType )
                                     REFERENCES OneRoster.Base            ( SourcedId, ObjectType ),
  CONSTRAINT CK_Resource_Importance CHECK ( Importance IS NULL OR Importance IN ( 'primary', 'secondary' )),
);


CREATE TABLE OneRoster.LineItem (
  SourcedId                             UNIQUEIDENTIFIER  NOT NULL,
  ObjectType                            AS CAST('LineItem' AS VARCHAR(15)) COLLATE Latin1_General_CS_AS PERSISTED,
  Title                                 NVARCHAR(255)     NOT NULL,
  [Description]                         NVARCHAR(255)         NULL,
  AssignDate                            DATETIME2         NOT NULL,
  DueDate                               DATETIME2         NOT NULL,
  ClassSourcedId                        UNIQUEIDENTIFIER  NOT NULL,
  CategorySourcedId                     UNIQUEIDENTIFIER  NOT NULL,
  GradingPeriodSourcedId                UNIQUEIDENTIFIER  NOT NULL,
  ResultValueMin                        FLOAT             NOT NULL,
  ResultValueMax                        FLOAT             NOT NULL,

  CONSTRAINT PK_LineItem PRIMARY KEY ( SourcedId ),
  CONSTRAINT FK_LineItem_Base           FOREIGN KEY                          ( SourcedId, ObjectType )
                                        REFERENCES OneRoster.Base            ( SourcedId, ObjectType ),
  CONSTRAINT FK_LineItem_Class          FOREIGN KEY                          ( ClassSourcedId )
                                        REFERENCES OneRoster.Class           ( SourcedId ),
  CONSTRAINT FK_LineItem_Category       FOREIGN KEY                          ( CategorySourcedId )
                                        REFERENCES OneRoster.Category        ( SourcedId ),
  CONSTRAINT FK_LineItem_GradingPeriod  FOREIGN KEY                          ( GradingPeriodSourcedId )
                                        REFERENCES OneRoster.AcademicSession ( SourcedId ),
);


CREATE TABLE OneRoster.Result (
  SourcedId                             UNIQUEIDENTIFIER  NOT NULL,
  ObjectType                            AS CAST('Result' AS VARCHAR(15)) COLLATE Latin1_General_CS_AS PERSISTED,
  LineItemSourcedId                     UNIQUEIDENTIFIER  NOT NULL,
  StudentSourcedId                      UNIQUEIDENTIFIER  NOT NULL,
  ScoreStatus                           VARCHAR(16)       COLLATE Latin1_General_CS_AS NOT NULL,
  Score                                 FLOAT             NOT NULL,
  ScoreDate                             DATE              NOT NULL,
  Comment                               NVARCHAR(255)         NULL,

  CONSTRAINT PK_Result PRIMARY KEY ( SourcedId ),
  CONSTRAINT FK_Result_Base          FOREIGN KEY                          ( SourcedId, ObjectType )
                                     REFERENCES OneRoster.Base            ( SourcedId, ObjectType ),
  CONSTRAINT FK_Result_LineItem      FOREIGN KEY                          ( LineItemSourcedId )
                                     REFERENCES OneRoster.Class           ( SourcedId ),
  CONSTRAINT FK_Result_Student       FOREIGN KEY                          ( StudentSourcedId )
                                     REFERENCES OneRoster.Category        ( SourcedId ),
  CONSTRAINT CK_Result_ScoreStatus CHECK ( ScoreStatus IN (
    'exempt',
    'fully graded',
    'not submitted',
    'partially graded',
    'submitted'
  )),
);


CREATE TABLE OneRoster.[User] (
  SourcedId                             UNIQUEIDENTIFIER  NOT NULL,
  ObjectType                            AS CAST('User' AS VARCHAR(15)) COLLATE Latin1_General_CS_AS PERSISTED,
  Username                              NVARCHAR(255)     NOT NULL,
  [Password]                            NVARCHAR(255)         NULL,
  IsEnabled                             BIT               NOT NULL,
  GivenName                             NVARCHAR(255)     NOT NULL,
  MiddleName                            NVARCHAR(255)         NULL,
  FamilyName                            NVARCHAR(255)     NOT NULL,
  [Role]                                VARCHAR(13)       COLLATE Latin1_General_CS_AS NOT NULL,
  Identifier                            NVARCHAR(255)     NOT NULL,
  Email                                 NVARCHAR(255)     NOT NULL,
  Sms                                   NVARCHAR(255)     NOT NULL,
  Phone                                 NVARCHAR(255)     NOT NULL,
  -- TODO userIds, agents, orgs, grades

  CONSTRAINT PK_User PRIMARY KEY ( SourcedId ),
  CONSTRAINT FK_User_Base            FOREIGN KEY                          ( SourcedId, ObjectType )
                                     REFERENCES OneRoster.Base            ( SourcedId, ObjectType ),
  CONSTRAINT CK_User_Role CHECK ( [Role] IN (
    'administrator',
    'aide',
    'guardian',
    'parent',
    'proctor',
    'relative',
    'student',
    'teacher'
  )),
);
GO

--INSERT OneRoster.Base ( ObjectType ) VALUES ( 'Org' );
--DECLARE @SourcedId UNIQUEIDENTIFIER = (SELECT TOP 1 SourcedId FROM OneRoster.Base);
--INSERT OneRoster.Org ( SourcedId, [Name], [Type] ) VALUES ( @SourcedId, 'Questar', 'department' );

SELECT * FROM OneRoster.Base;
SELECT * FROM OneRoster.Metadata;
SELECT * FROM OneRoster.AcademicSession;
SELECT * FROM OneRoster.Category;
SELECT * FROM OneRoster.Course;
SELECT * FROM OneRoster.Class;
SELECT * FROM OneRoster.Demographics;
SELECT * FROM OneRoster.Enrollment;
SELECT * FROM OneRoster.Org;
SELECT * FROM OneRoster.Resource;
SELECT * FROM OneRoster.LineItem;
SELECT * FROM OneRoster.Result;
SELECT * FROM OneRoster.[User];
GO

DROP TABLE OneRoster.[User];
DROP TABLE OneRoster.Result;
DROP TABLE OneRoster.LineItem;
DROP TABLE OneRoster.Resource;
DROP TABLE OneRoster.Org;
DROP TABLE OneRoster.Enrollment;
DROP TABLE OneRoster.Demographics;
DROP TABLE OneRoster.Class;
DROP TABLE OneRoster.Course;
DROP TABLE OneRoster.Category;
DROP TABLE OneRoster.AcademicSession;
DROP TABLE OneRoster.Metadata;
DROP TABLE OneRoster.Base;
DROP SCHEMA OneRoster;
GO