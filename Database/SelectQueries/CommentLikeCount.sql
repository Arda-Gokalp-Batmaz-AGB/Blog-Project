SELECT "ID",Count(*) as LikeCount
FROM "Comment"
	LEFT JOIN "Interact" ON "ID" = "CommentID"
	WHERE "Type" = 'like'
	GROUP BY "ID";
