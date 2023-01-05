SELECT "UserName" FROM public."Follow"
	JOIN "User" ON "Id" = "FollowerID"
	WHERE "FollowedID" = '4e5d6457-f14e-46b3-9bd0-a2fce6cc1b01'