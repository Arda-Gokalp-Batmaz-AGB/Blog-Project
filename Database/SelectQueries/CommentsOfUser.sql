SELECT "ID","UserName","Text","ParentID","PostID"
FROM public."Comment"
	JOIN "User" ON
	"Id" = "AuthorID"
	WHERE "UserName" = 'Emir'
	ORDER BY "Comment"."CreateDate" ASC
	LIMIT 5;