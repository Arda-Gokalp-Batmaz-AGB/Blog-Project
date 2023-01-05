SELECT "Id","UserName", follower_table.fCount AS "FollowerCount" 
FROM (SELECT "FollowedID" AS fID,Count(*) AS fCount
FROM "Follow" 
	GROUP BY "FollowedID") follower_table 
	RIGHT JOIN "User" ON follower_table.fID = "User"."Id"
	WHERE "UserName" = 'ArdaGokalp'
