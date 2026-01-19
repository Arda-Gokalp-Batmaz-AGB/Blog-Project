DELETE FROM "Post" Where "Post"."ID" NOT IN (SELECT DISTINCT "P"."ID"
	FROM public."Post" "P" JOIN "Comment" "C" ON "C"."PostID" = "P"."ID");