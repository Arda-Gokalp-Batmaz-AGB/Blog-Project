SELECT "ID","UserName","Text","ParentID","PostID"
FROM public."Comment"
	JOIN "User" ON
	"Id" = "AuthorID"
	WHERE "UserName" = 'ArdaGokalp'
	ORDER BY "Comment"."CreateDate" DESC
	LIMIT 5;