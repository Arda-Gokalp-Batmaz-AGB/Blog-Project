(SELECT count(*)
FROM public."Follow"
	WHERE "FollowerID" = '1c3dfb97-6f9c-4cc7-84de-8b5f1ecb99bb' 
	AND "FollowedID" = '9d3699d8-9261-465a-b626-fa23e9c48b5d'
	GROUP BY "FollowedID")
	INTERSECT
(SELECT count(*)
FROM public."Follow"
	WHERE "FollowedID" = '1c3dfb97-6f9c-4cc7-84de-8b5f1ecb99bb' 
	AND "FollowerID" = '9d3699d8-9261-465a-b626-fa23e9c48b5d'
	GROUP BY "FollowedID");