(SELECT "U"."UserName"
FROM "User" "U"
	JOIN "Post" "P" ON "P"."AuthorID" = "U"."Id"
	GROUP BY "U"."UserName"
	HAVING count(*) > 0)
	
	INTERSECT
	
(SELECT "U"."UserName"
FROM "User" "U"
	JOIN "Comment" "C" ON "C"."AuthorID" = "U"."Id"
	GROUP BY "U"."UserName"
	HAVING count(*) > 0);
	