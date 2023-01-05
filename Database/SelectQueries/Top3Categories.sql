SELECT "Category",count(*) AS "PostCount"
	FROM public."Post_Category"
	JOIN "Post" ON "Post"."ID" = "PostID"
	GROUP BY "Category"
	ORDER BY "PostCount" DESC
	LIMIT 3;