SELECT "P"."Title",count(*)+CommentCounts."CC"-1 AS "Interaction_Count"
FROM "Post" "P"
	JOIN "Comment" "C" ON 
	"C"."PostID" = "P"."ID"
	JOIN "Interact" "I" ON
	"C"."ID" = "I"."CommentID"
	JOIN (SELECT "Title",count(*) AS "CC" FROM "Post" "P" 
				JOIN "Comment" "C" ON
				"C"."PostID" = "P"."ID"
				GROUP BY "Title") CommentCounts ON
	CommentCounts."Title" = "P"."Title"	
	GROUP BY "P"."Title",CommentCounts."CC"
	ORDER BY "Interaction_Count" DESC
	LIMIT 10;