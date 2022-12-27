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
-- FINAL COMMIT - 30 examples written.
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- To list the top 10 posts with the most interaction and that were created within the last week.
SELECT * FROM Post
WHERE DateCreated BETWEEN NOW() - INTERVAL '7' DAY AND NOW()
ORDER BY Likes + Comments + Shares DESC LIMIT 10;
-- To list the users who have commented on a post and also followed the user who created the post.
SELECT u.* FROM User u
JOIN Comment c ON c.UserId = u.Id
JOIN Follow f ON f.FollowerId = u.Id AND f.FollowedId = c.UserId
WHERE c.PostId = '<post_id>';
-- !!! To list the users who have followed a user, but have not been followed back.
SELECT f.FollowerId FROM Follow f
LEFT JOIN Follow f2 ON f2.FollowerId = f.FollowedId AND f2.FollowedId = f.FollowerId
WHERE f2.FollowerId IS NULL AND f.FollowedId = '<user_id>';
-- To list the users who have commented on a post, but have not liked the post.
SELECT c.UserId FROM Comment c
LEFT JOIN Like l ON l.UserId = c.UserId AND l.PostId = c.PostId
WHERE l.UserId IS NULL AND c.PostId = '<post_id>';
-- To list the users who have been blocked by at least 3 other users.
SELECT b.BlockedId FROM Block b
GROUP BY b.BlockedId
HAVING COUNT(b.BlockerId) >= 3;
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- To list the users who have commented on a post, along with their comments and the number of likes on each comment.
SELECT u.*, c.*, COUNT(l.Id) AS Likes FROM User u
JOIN Comment c ON c.UserId = u.Id
LEFT JOIN Like l ON l.CommentId = c.Id
WHERE c.PostId = '<post_id>'
GROUP BY u.Id, c.Id
ORDER BY c.DateCreated ASC;
-- !!! To list the users who have followed a user, along with the number of posts and followers they have.
SELECT u.*, COUNT(p.Id) AS NumPosts, COUNT(f.Id) AS NumFollowers FROM User u
JOIN Follow f ON f.FollowedId = u.Id
LEFT JOIN Post p ON p.UserId = u.Id
WHERE f.FollowerId = '<user_id>'
GROUP BY u.Id;
-- To list the users who have commented on a post and also liked at least one of the comments on the post.
SELECT u.* FROM User u
JOIN Comment c ON c.UserId = u.Id
JOIN Like l ON l.CommentId = c.Id
WHERE c.PostId = '<post_id>'
GROUP BY u.Id
HAVING COUNT(DISTINCT l.Id) > 0;
-- !!! To list the users who have not been followed by a user, along with the number of posts they have created and the number of users they are following.
SELECT u.*, COUNT(p.Id) AS NumPosts, COUNT(f.Id) AS NumFollowed FROM User u
LEFT JOIN Follow f ON f.FollowedId = u.Id
LEFT JOIN Post p ON p.UserId = u.Id
WHERE u.Id NOT IN (SELECT FollowedId FROM Follow WHERE FollowerId = '<user_id>')
GROUP BY u.Id;
-- !!! To list the users who have liked a post and also commented on at least one of the other posts created by the user who created the original post.
SELECT l.UserId FROM Like l
JOIN Post p ON p.Id = l.PostId
JOIN Comment c ON c.PostId = p.Id
WHERE p.UserId = '<user_id>'
GROUP BY l.UserId
HAVING COUNT(DISTINCT c.PostId) > 0;
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- To list the top 5 users who have created the most posts in the past month.
SELECT u.Id, u.Username, COUNT(p.Id) AS NumPosts FROM User u
JOIN Post p ON p.UserId = u.Id
WHERE p.DateCreated BETWEEN NOW() - INTERVAL '1' MONTH AND NOW()
GROUP BY u.Id, u.Username
ORDER BY NumPosts DESC
LIMIT 5;
-- To list the users who have commented on a post in the past week, along with the number of comments they have made.
SELECT u.Id, u.Username, COUNT(c.Id) AS NumComments FROM User u
JOIN Comment c ON c.UserId = u.Id
WHERE c.DateCreated BETWEEN NOW() - INTERVAL '7' DAY AND NOW()
GROUP BY u.Id, u.Username
ORDER BY NumComments DESC;
-- To list the users who have followed a user in the past day, along with the number of followers they have.
SELECT u.Id, u.Username, COUNT(f.Id) AS NumFollowers FROM User u
JOIN Follow f ON f.FollowedId = u.Id
WHERE f.Date BETWEEN NOW() - INTERVAL '1' DAY AND NOW()
GROUP BY u.Id, u.Username
ORDER BY NumFollowers DESC;
-- To list the users who have liked a post in the past hour, along with the number of likes they have given to other posts.
SELECT u.Id, u.Username, COUNT(l.Id) AS NumLikes FROM User u
JOIN Like l ON l.UserId = u.Id
WHERE l.Date BETWEEN NOW() - INTERVAL '1' HOUR AND NOW()
GROUP BY u.Id, u.Username
ORDER BY NumLikes DESC;
-- To list the users who have been blocked by a user in the past minute, along with the number of users they have blocked.
SELECT u.Id, u.Username, COUNT(b.Id) AS NumBlocked FROM User u
JOIN Block b ON b.BlockedId = u.Id
WHERE b.Date BETWEEN NOW() - INTERVAL '1' MINUTE AND NOW()
GROUP BY u.Id, u.Username
ORDER BY NumBlocked DESC;
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- To list the users who have commented on a post.
SELECT u.* FROM User u
JOIN Comment c ON c.UserId = u.Id
WHERE c.PostId = '<post_id>';
-- To list the users who have followed a user.
SELECT u.* FROM User u
JOIN Follow f ON f.FollowedId = u.Id
WHERE f.FollowerId = '<user_id>';
-- To list the users who have liked a post.
SELECT u.* FROM User u
JOIN Like l ON l.UserId = u.Id
WHERE l.PostId = '<post_id>';
-- To list the users who have been blocked by a user.
SELECT u.* FROM User u
JOIN Block b ON b.BlockedId = u.Id
WHERE b.BlockerId = '<user_id>';
-- To list the comments on a post.
SELECT * FROM Comment WHERE PostId = '<post_id>';
-- To list the posts created by a user.
SELECT * FROM Post WHERE UserId = '<user_id>';
-- To list the likes on a post.
SELECT * FROM Like WHERE PostId = '<post_id>';
-- To list the follows involving a user.
SELECT * FROM Follow WHERE FollowerId = '<user_id>' OR FollowedId = '<user_id>';
-- To list the blocks involving a user.
SELECT * FROM Block WHERE BlockerId = '<user_id>' OR BlockedId = '<user_id>';
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------