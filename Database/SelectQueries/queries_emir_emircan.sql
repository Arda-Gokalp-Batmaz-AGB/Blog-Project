-- Contact: Emir Cetin MEMIS & Emircan YAPRAK
-- Date: 12/27/2022
-- Note: The following queries that starts with "!!!" should be checked and fixed if needed. We are sure they should work, but not 100%.
-- Structure :
--		Arda's recommendations 		- 6 examples written.
--  	Some good examples 			- 5 examples written.
--  	Some complex examples 		- 5 examples written.
--  	Some real-life examples 	- 5 examples written.
--  	Some intermediate examples 	- 9 examples written.
--  	TOTAL						- 30 examples written.

-- To list the posts owned by a user.
SELECT * FROM Post WHERE UserId = '<user_id>';
-- To list the comments of a post.
SELECT * FROM Comment WHERE PostId = '<post_id>';
-- To list the users followed by a user.
SELECT FollowedID FROM Follow WHERE FollowerID = '<user_id>';
-- To list the top 10 posts with the most interaction.
SELECT * FROM Post ORDER BY Likes + Comments + Shares DESC LIMIT 10;
-- To list the comments made by a user.
SELECT * FROM Comment WHERE UserId = '<user_id>';
-- To list the users blocked by a user.
SELECT BlockedID FROM Block WHERE BlockerID = '<user_id>';