CREATE TABLE "Role" (
    "Id" text NOT NULL,
    "Name" character varying(256) NULL,
    "NormalizedName" character varying(256) NULL,
    "ConcurrencyStamp" text NULL,
    CONSTRAINT "PK_Role" PRIMARY KEY ("Id")
);

CREATE TABLE "User" (
    "Id" text NOT NULL,
    "Name" character varying(30) NULL,
    "SurName" character varying(30) NULL,
    "DateCreated" timestamp with time zone NOT NULL,
    "DateModified" timestamp with time zone NOT NULL,
    "About" character varying(800) NULL,
    "Photo" text NULL,
    "UserName" character varying(256) NULL,
    "NormalizedUserName" character varying(256) NULL,
    "Email" character varying(256) NULL,
    "NormalizedEmail" character varying(256) NULL,
    "PasswordHash" text NULL,
    CONSTRAINT "PK_User" PRIMARY KEY ("Id")
);

CREATE TABLE "RoleClaim" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "RoleId" text NOT NULL,
    "ClaimType" text NULL,
    "ClaimValue" text NULL,
    CONSTRAINT "PK_RoleClaim" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_RoleClaim_Role_RoleId" FOREIGN KEY ("RoleId") REFERENCES "Role" ("Id") ON DELETE CASCADE
);

CREATE TABLE "UserClaim" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "UserId" text NOT NULL,
    "ClaimType" text NULL,
    "ClaimValue" text NULL,
    CONSTRAINT "PK_UserClaim" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_UserClaim_User_UserId" FOREIGN KEY ("UserId") REFERENCES "User" ("Id") ON DELETE CASCADE
);

CREATE TABLE "UserRole" (
    "UserId" text NOT NULL,
    "RoleId" text NOT NULL,
    CONSTRAINT "PK_UserRole" PRIMARY KEY ("UserId", "RoleId"),
    CONSTRAINT "FK_UserRole_Role_RoleId" FOREIGN KEY ("RoleId") REFERENCES "Role" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_UserRole_User_UserId" FOREIGN KEY ("UserId") REFERENCES "User" ("Id") ON DELETE CASCADE
);

CREATE UNIQUE INDEX "RoleNameIndex" ON "Role" ("NormalizedName");

CREATE INDEX "IX_RoleClaim_RoleId" ON "RoleClaim" ("RoleId");

CREATE INDEX "EmailIndex" ON "User" ("NormalizedEmail");

CREATE UNIQUE INDEX "UserNameIndex" ON "User" ("NormalizedUserName");

CREATE INDEX "IX_UserClaim_UserId" ON "UserClaim" ("UserId");

CREATE INDEX "IX_UserRole_RoleId" ON "UserRole" ("RoleId");


DROP TABLE IF EXISTS "Follow";
CREATE TABLE "Follow"
(
	"FollowerID" text NOT NULL,
	"FollowedID" text NOT NULL,
	"Date" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("FollowerID","FollowedID"),
	FOREIGN KEY("FollowerID") REFERENCES "User" ("Id"),
	FOREIGN KEY("FollowedID") REFERENCES "User" ("Id")
);

DROP TABLE IF EXISTS "Block";
CREATE TABLE "Block"
(
	"BlockerID" text NOT NULL,
	"BlockedID" text NOT NULL,
	"Date" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("BlockerID","BlockedID"),
	FOREIGN KEY("BlockerID") REFERENCES "User" ("Id"),
	FOREIGN KEY("BlockedID") REFERENCES "User" ("Id")
);

DROP TABLE IF EXISTS "Post" CASCADE;
CREATE TABLE "Post"
(
	"ID" SERIAL,
	"Title" VARCHAR(70) NOT NULL,
	"AuthorID" text NOT NULL,
	PRIMARY KEY("ID"),
	FOREIGN KEY("AuthorID") REFERENCES "User" ("Id"),
	UNIQUE ("Title")
);

DROP TABLE IF EXISTS "Category" CASCADE;
CREATE TABLE "Category"
(
	"Title" VARCHAR(70),
	PRIMARY KEY ("Title")
);

DROP TABLE IF EXISTS "Tag" CASCADE;
CREATE TABLE "Tag"
(
	"ID" SERIAL,
	"Name" VARCHAR(70),
	PRIMARY KEY("ID"),
	UNIQUE ("Name")
);

DROP TABLE IF EXISTS "Comment" CASCADE;
CREATE TABLE "Comment"
(
	"ID" SERIAL,
	"Text" TEXT NOT NULL,
	"CreateDate" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	"UpdateDate" TIMESTAMP NOT NULL,
	"PostID" INTEGER NOT NULL,
	"ParentID" INTEGER NOT NULL,
	"AuthorID" text NOT NULL,
	FOREIGN KEY("PostID") REFERENCES "Post" ("ID"),
	FOREIGN KEY("ParentID") REFERENCES "Comment" ("ID"),
	FOREIGN KEY("AuthorID") REFERENCES "User" ("Id"),
	PRIMARY KEY("ID")
);

DROP TABLE IF EXISTS "Post_Category";
CREATE TABLE "Post_Category"
(
	"PostID" INTEGER,
	"Category" VARCHAR(70),
	PRIMARY KEY("PostID","Category"),
	FOREIGN KEY("PostID") REFERENCES "Post" ("ID"),
	FOREIGN KEY("Category") REFERENCES "Category" ("Title")
);

DROP TABLE IF EXISTS "Comment_Tag";
CREATE TABLE "Comment_Tag"
(
	"CommentID" INTEGER,
	"TagID" INTEGER,
	PRIMARY KEY("CommentID","TagID"),
	FOREIGN KEY("CommentID") REFERENCES "Comment"("ID"),
	FOREIGN KEY("TagID") REFERENCES "Tag"("ID")
);

DROP TABLE IF EXISTS "Bookmark";
CREATE TABLE "Bookmark"
(
	"UserID" text,
	"PostID" INTEGER,
	"Date" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("UserID","PostID"),
	FOREIGN KEY("UserID") REFERENCES "User"("Id"),
	FOREIGN KEY("PostID") REFERENCES "Post"("ID")
);

DROP TABLE IF EXISTS "Interact";
CREATE TABLE "Interact"
(
	"CommentID" INTEGER,
	"UserID" text,
	"Type" VARCHAR(10) NOT NULL,
	"Date" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("CommentID","UserID"),
	FOREIGN KEY("CommentID") REFERENCES "Comment"("ID"),
	FOREIGN KEY("UserID") REFERENCES "User"("Id")
);