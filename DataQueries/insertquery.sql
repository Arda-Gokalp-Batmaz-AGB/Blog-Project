INSERT INTO "Blog"."User"("Name", "Surname", "Email", "Username", "Password", "Role")
VALUES ('Ahmet','Batmaz','ahmet@hotmail.com','arananadam','arda123','User');


INSERT INTO "Blog"."Follow"("FollowerID","FollowedID")
VALUES (3,7);

INSERT INTO "Blog"."Post"("Title","AuthorID")
VALUES ('baska',1);

INSERT INTO  "Blog"."Category"("Title")
VALUES 
	('Eğitim'),
	('Yiyecek'),
	('Reklam');