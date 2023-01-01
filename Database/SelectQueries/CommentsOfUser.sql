SELECT "ID","UserName","Text","ParentID","PostID"
	FROM public."Comment"
	JOIN "User" ON
	"Id" = "AuthorID"
	WHERE "UserName" = 'Arda'
	LIMIT 5;