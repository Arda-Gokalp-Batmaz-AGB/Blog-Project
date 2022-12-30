SELECT "ID",Count(*) as LikeCount
FROM "Comment"
	LEFT JOIN "Interact" ON "ID" = "CommentID"
	WHERE "Type" = 'Like'
	GROUP BY "ID";
