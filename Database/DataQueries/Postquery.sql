SELECT "Username","Title" FROM "Blog"."Post" Post
	JOIN "Blog"."User" "Author" ON Post."ID" = "Author"."ID";
