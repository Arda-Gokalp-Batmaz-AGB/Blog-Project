SELECT "P"."ID","Title","Text" 
FROM "Post" "P" 
	JOIN "Comment" "C" ON 
	"C"."PostID" = "P"."ID"
	WHERE "ParentID" IS NULL;