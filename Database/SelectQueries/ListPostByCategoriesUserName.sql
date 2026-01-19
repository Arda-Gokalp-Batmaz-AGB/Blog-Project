SELECT "PC"."Category", "U"."UserName","P"."Title"
FROM "Post" "P"
			JOIN "Post_Category" "PC" ON "P"."ID" = "PC"."PostID"
			JOIN "User" "U" ON "P"."AuthorID" = "U"."Id"
			ORDER BY "PC"."Category" DESC