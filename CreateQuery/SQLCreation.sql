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
ALTER TABLE IF EXISTS "Blog"."User"
    OWNER to postgres;