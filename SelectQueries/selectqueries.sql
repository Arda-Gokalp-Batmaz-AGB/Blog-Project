
SELECT "ID","Username", follower_table.fCount AS "FollowerCount" 
FROM (SELECT "FollowedID" AS fID,Count(*) AS fCount
FROM "Blog"."Follow" 
	GROUP BY "FollowedID") follower_table 
	RIGHT JOIN "Blog"."User" ON follower_table.fID = "Blog"."User"."ID" ;