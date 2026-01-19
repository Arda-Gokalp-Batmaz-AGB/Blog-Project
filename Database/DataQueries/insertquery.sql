INSERT INTO "User"("Id","Name", "SurName", "Email", "UserName", "PasswordHash")
VALUES ('213asdsad','Ahmet','Batmaz','ahmet@hotmail.com','arananadam','arda123');


INSERT INTO "Follow"("FollowerID","FollowedID")
VALUES ('8080ff0e-e3dd-46a6-adb5-cdd331458e0c','a7532c47-b26f-4127-a1d6-e4ea72ec1b4e');
INSERT INTO "Follow"("FollowerID","FollowedID")
VALUES ('4e5d6457-f14e-46b3-9bd0-a2fce6cc1b01','a7532c47-b26f-4127-a1d6-e4ea72ec1b4e');
INSERT INTO "Post"("Title","AuthorID")
VALUES ('baska',1);

INSERT INTO "Category"("Title")
VALUES 
	('Eğitim'),
	('Yiyecek'),
	('Reklam');