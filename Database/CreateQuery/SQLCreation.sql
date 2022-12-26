CREATE TABLE "Blog"."User"
(
    "ID" SERIAL,
	"Name" VARCHAR(30) NOT NULL,
	"Surname" VARCHAR(30) NOT NULL,
	"Email" VARCHAR(50) NOT NULL,
	"Username" VARCHAR(20) NOT NULL,
	"Password" VARCHAR(32) NOT NULL,
	"About" VARCHAR(800),
	"Role" VARCHAR(20) NOT NULL,
	"Photo" VARCHAR(500),
    PRIMARY KEY ("ID"),
	UNIQUE("Username"),
	UNIQUE("Email")
);

CREATE TABLE "Blog"."Follow"
(
	"FollowerID" BIGINT NOT NULL,
	"FollowedID" BIGINT NOT NULL,
	"Date" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("FollowerID","FollowedID"),
	FOREIGN KEY("FollowerID") REFERENCES "Blog"."User" ("ID"),
	FOREIGN KEY("FollowedID") REFERENCES "Blog"."User" ("ID")
);

CREATE TABLE "Blog"."Block"
(
	"BlockerID" BIGINT NOT NULL,
	"BlockedID" BIGINT NOT NULL,
	"Date" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("BlockerID","BlockedID"),
	FOREIGN KEY("BlockerID") REFERENCES "Blog"."User" ("ID"),
	FOREIGN KEY("BlockedID") REFERENCES "Blog"."User" ("ID")
);

CREATE TABLE "Blog"."Post"
(
	"ID" SERIAL,
	"Title" VARCHAR(70) NOT NULL,
	"AuthorID" INTEGER NOT NULL,
	PRIMARY KEY("ID"),
	FOREIGN KEY("AuthorID") REFERENCES "Blog"."User" ("ID"),
	UNIQUE ("Title")
);

CREATE TABLE "Blog"."Category"
(
	"Title" VARCHAR(70),
	PRIMARY KEY ("Title")
);
CREATE TABLE "Blog"."Tag"
(
	"ID" SERIAL,
	"Name" VARCHAR(70),
	PRIMARY KEY("ID"),
	UNIQUE ("Name")
);

CREATE TABLE "Blog"."Comment"
(
	"ID" SERIAL,
	"Text" TEXT NOT NULL,
	"CreateDate" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	"UpdateDate" TIMESTAMP NOT NULL,
	"PostID" INTEGER NOT NULL,
	"ParentID" INTEGER NOT NULL,
	"AuthorID" INTEGER NOT NULL,
	FOREIGN KEY("PostID") REFERENCES "Blog"."Post" ("ID"),
	FOREIGN KEY("ParentID") REFERENCES "Blog"."Comment" ("ID"),
	FOREIGN KEY("AuthorID") REFERENCES "Blog"."User" ("ID"),
	PRIMARY KEY("ID")
);

CREATE TABLE "Blog"."Post_Category"
(
	"PostID" INTEGER,
	"Category" VARCHAR(70),
	PRIMARY KEY("PostID","Category"),
	FOREIGN KEY("PostID") REFERENCES "Blog"."Post" ("ID"),
	FOREIGN KEY("Category") REFERENCES "Blog"."Category" ("Title")
);

CREATE TABLE "Blog"."Comment_Tag"
(
	"CommentID" INTEGER,
	"TagID" INTEGER,
	PRIMARY KEY("CommentID","TagID"),
	FOREIGN KEY("CommentID") REFERENCES "Blog"."Comment"("ID"),
	FOREIGN KEY("TagID") REFERENCES "Blog"."Tag"("ID")
);

CREATE TABLE "Blog"."Bookmark"
(
	"UserID" INTEGER,
	"PostID" INTEGER,
	"Date" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("UserID","PostID"),
	FOREIGN KEY("UserID") REFERENCES "Blog"."User"("ID"),
	FOREIGN KEY("PostID") REFERENCES "Blog"."Post"("ID")
);

CREATE TABLE "Blog"."Interact"
(
	"CommentID" INTEGER,
	"UserID" INTEGER,
	"Type" VARCHAR(10) NOT NULL,
	"Date" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("CommentID","UserID"),
	FOREIGN KEY("CommentID") REFERENCES "Blog"."Comment"("ID"),
	FOREIGN KEY("UserID") REFERENCES "Blog"."User"("ID")
);
ALTER TABLE IF EXISTS "Blog"."User"
    OWNER to postgres;