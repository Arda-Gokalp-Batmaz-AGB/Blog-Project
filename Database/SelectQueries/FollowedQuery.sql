SELECT "UserName" FROM public."Follow"
	JOIN "User" ON "Id" = "FollowedID"
	WHERE "FollowerID" = '8080ff0e-e3dd-46a6-adb5-cdd331458e0c';