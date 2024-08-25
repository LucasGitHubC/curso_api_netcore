DECLARE
V_COUNT INTEGER;
BEGIN
SELECT COUNT(TABLE_NAME) INTO V_COUNT from USER_TABLES where TABLE_NAME = '__EFMigrationsHistory';
IF V_COUNT = 0 THEN
Begin
BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"__EFMigrationsHistory" (
    "MigrationId" NVARCHAR2(150) NOT NULL,
    "ProductVersion" NVARCHAR2(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
)';
END;

End;

END IF;
EXCEPTION
WHEN OTHERS THEN
    IF(SQLCODE != -942)THEN
        RAISE;
    END IF;
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"User" (
    "Id" RAW(16) NOT NULL,
    "Name" NVARCHAR2(60) NOT NULL,
    "Email" NVARCHAR2(100),
    "CrateAt" TIMESTAMP(7),
    "UpdateAt" TIMESTAMP(7),
    CONSTRAINT "PK_User" PRIMARY KEY ("Id")
)';
END;
/

CREATE UNIQUE INDEX "IX_User_Email" ON "User" ("Email")
/

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES (N'20240821220057_DBmigration', N'8.0.8')
/

