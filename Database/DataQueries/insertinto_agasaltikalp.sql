INSERT INTO "User" ("Id","Name", "SurName", "Email", "UserName", "PasswordHash")
VALUES  
		('1415926535','Pedro','Afonso','Afonsop@hotmail.com','Afonsop','s7etKRoKn0Dokhs2RXAM'),
		('8979323846','Maria','Anders','Andersm@hotmail.com','Andersm','UVmm8ycnxmybziiL1WGG'),
		('2643383279','Ana','Trujillo','Trujilloa@hotmail.com','Trujilloa','45NWrTtjJ3PpKHhNxj0d'),
		('5028841971','Antonio','Moreno','Morenoa@hotmail.com','Morenoa','0HZPL4KgW9HY5iXQKhaG'),
		('6939937510','Thomas','Hardy','Hardyt@hotmail.com','Hardyt','8BHRW3RRXTaWrJxFJ5U1'),
		('5820974944','Christina','Berglund','Berglundc@hotmail.com','Berglundc','9BLp9PoMijVGhM9xb99X'),
		('5923078164','Hanna','Moos','Moosh@hotmail.com','Moosh','7QuUyh8gdhbc3CeaHGHR'),
		('0628620899','Frédérique','Citeaux','Citeauxf@hotmail.com','Citeauxf','Dh945ot1mi06mLUX4wVL'),
		('8628034825','Martín','Sommer','Sommerm@hotmail.com','Sommerm','oZ0Camu9y5cehp3QK6Tn'),
		('3421170679','Laurence','Lebihans','Lebihansl@hotmail.com','Lebihansl','v1VCqNKMFtUvmjqe3Ant'),
		('8214808651','Elizabeth','Lincoln','Lincolne@hotmail.com','Lincolne','3tNW38sHFbCnEGCumxnQ'),
		('3282306647','Victoria','Ashworth','Ashworthv@hotmail.com','Ashworthv','Vuo83XFvtJ1U3PjrANVy'),
		('0938446095','Patricio','Simpson','Simpsonp@hotmail.com','Simpsonp','eev065ifezzoEqmsNrcH'),
		('5058223172','Francisco','Chang','Changf@hotmail.com','Changf','d5VFLfdG6zziJD930Gbg'),
		('5359408128','Yang','Wang','Wangy@hotmail.com','Wangy','9YEhTmaRvf7TThMiiAX2'),
		('4811174502','Elizabeth','Brown','Browne@hotmail.com','Browne','PR2uEefX2vRkxxE0X9gH');

INSERT INTO "Follow" ("FollowerID","FollowedID")
VALUES 
		('M2unxVt7-ZRM7-rdUM-rq9g-dNeTbt5uQ6Bc','KwWDb28a-ZZwg-PsaM-GmDt-5dyt4Tbt5uQ6'),
		('7Nr3EYBu-5LVY-XHEp-aVY0-yCuu8NAqFjy5','TfVPAwMF-3mnU-DAPE-vFxC-MXAC3sXnrKKN'),
		('NGJ0K62s-1Q30-bRjG-t54K-yb0nGRG9G5o2','1eU01QD7-h8t3-Qeja-03oY-KFuCvBMC0C3K'),
		('dA6fJyg9-HBAf-9YWq-RpGy-KzCckMhodEW3','nvqqT7qv-iqZP-WLLm-o8bW-GGckCQhoEwAP'),
		('maHkKw9r-B9mM-NJbs-b3Jv-2MLYh7G6jaUb','6ebM1mmb-96D9-zvNw-yuKd-NjTq1RvmLaJV'),
		('KwWDb28a-ZZwg-PsaM-GmDt-5dyt4Tbt5uQ6','TqRxQchj-RviN-ZXKj-1W2k-Lp383BcWE9kJ'),
		('TqRxQchj-RviN-ZXKj-1W2k-Lp383BcWE9kJ','u5oAmtTY-CQ88-QdJK-CNrp-ZAqYjmmsVG72'),
		('jdZWca8o-62LC-Rkri-MJuF-LkE5NVNfGpio','u5oAmtTY-CQ88-QdJK-CNrp-ZAqYjmmsVG72'),
		('FKRRyFGK-LXx8-ZJZu-YAAG-LidT7r9w1qt4','u5oAmtTY-CQ88-QdJK-CNrp-ZAqYjmmsVG72'),
		('RWPh8nhX-o4qi-3jiv-4uT9-4Ysjy8F5zVwr','7Nr3EYBu-5LVY-XHEp-aVY0-yCuu8NAqFjy5'),
		('u5oAmtTY-CQ88-QdJK-CNrp-ZAqYjmmsVG72','NGJ0K62s-1Q30-bRjG-t54K-yb0nGRG9G5o2'),
		('94F58rZj-s0nd-2zrn-MXAs-J86gWPyDo5N7','FKRRyFGK-LXx8-ZJZu-YAAG-LidT7r9w1qt4'),
		('6ebM1mmb-96D9-zvNw-yuKd-NjTq1RvmLaJV','TqRxQchj-RviN-ZXKj-1W2k-Lp383BcWE9kJ'),
		('TfVPAwMF-3mnU-DAPE-vFxC-MXAC3sXnrKKN','KwWDb28a-ZZwg-PsaM-GmDt-5dyt4Tbt5uQ6'),
		('nvqqT7qv-iqZP-WLLm-o8bW-GGckCQhoEwAP','NGJ0K62s-1Q30-bRjG-t54K-yb0nGRG9G5o2'),
		('1eU01QD7-h8t3-Qeja-03oY-KFuCvBMC0C3K','nvqqT7qv-iqZP-WLLm-o8bW-GGckCQhoEwAP');




INSERT INTO "Post" ("ID","Title","AuthorID")
VALUES 
		('9avdTPPigWqbsaqvt9','The Martin Luther King, Jr. Guide to Inspirational Writing','M2unxVt7-ZRM7-rdUM-rq9g-dNeTbt5uQ6Bc'),
		('acoJXDsGJuHcj9gzVU','Bored With Your Blog? These 10 Tips Will Make You Fall In Love Again','7Nr3EYBu-5LVY-XHEp-aVY0-yCuu8NAqFjy5'),
		('wDD7KqE8UWhQYHVKYb','The Martin Luther King, Jr. Guide to Inspirational Writing','NGJ0K62s-1Q30-bRjG-t54K-yb0nGRG9G5o2'),
		('SMKkSYY6sMG9DJSaKJ','How To Use Canva: An 8-Step Guide To Creating Visual Content','dA6fJyg9-HBAf-9YWq-RpGy-KzCckMhodEW3'),
		('X3ag3s65X5da7AtTfi','The 17 Best Tools For Spying On Your Competition','maHkKw9r-B9mM-NJbs-b3Jv-2MLYh7G6jaUb'),
		('crzP4MVuvazqpUCay6','16 Knockout Article Ideas: How to Write Regularly for Your Blog','KwWDb28a-ZZwg-PsaM-GmDt-5dyt4Tbt5uQ6'),
		('f8RZbVqLouT8ESycSP','5 Things No One Will Tell You About Your First Job','KwWDb28a-ZZwg-PsaM-GmDt-5dyt4Tbt5uQ6'),
		('BmtaiUhdeNmFgEP3RF','How To Get More Likes On Facebook Without Buying Fans','TqRxQchj-RviN-ZXKj-1W2k-Lp383BcWE9kJ'),
		('H4jzMxGBjFydjRdajQ', 'Why Successful People Plan Their Lives 90 Days At A Time','jdZWca8o-62LC-Rkri-MJuF-LkE5NVNfGpio'),
		('ZaV7dLt2PK7KeToDi2','Infographic: The Best Careers For Introverts And Extroverts','jdZWca8o-62LC-Rkri-MJuF-LkE5NVNfGpio'),
		('3A9EK7g3aAgkAZkMbP','How To Create The Perfect Thank You Page: An Epic Guide','FKRRyFGK-LXx8-ZJZu-YAAG-LidT7r9w1qt4'),
		('ApspF46HFudoLoPZMB','6 Things No One Tells You About Running a Business While Traveling Full Time','nvqqT7qv-iqZP-WLLm-o8bW-GGckCQhoEwAP'),
		('TxG5Q56hVkN3yrFZAF', 'What is Amazon KDP Publishing? (And How to Start)','u5oAmtTY-CQ88-QdJK-CNrp-ZAqYjmmsVG72'),
		('YZb5AFELifFTa5nCZd','Email Marketing and Why it is So Important [Infographic]','TfVPAwMF-3mnU-DAPE-vFxC-MXAC3sXnrKKN'),
		('ojb4MBUhm3NYxXUzPA','Want New Customers Faster? Avoid This Rookie Marketing Habit','6ebM1mmb-96D9-zvNw-yuKd-NjTq1RvmLaJV'),
		('8Gwj4ZrL8hL5yEwAw5','10 Mistakes I Made as a Successful First Time Kindle Author (So You Do not Have To)','6ebM1mmb-96D9-zvNw-yuKd-NjTq1RvmLaJV');


INSERT INTO "Block" ("BlockerID","BlockedID")
VALUES 
		('M2unxVt7-ZRM7-rdUM-rq9g-dNeTbt5uQ6Bc','KwWDb28a-ZZwg-PsaM-GmDt-5dyt4Tbt5uQ6'),
		('M2unxVt7-ZRM7-rdUM-rq9g-dNeTbt5uQ6Bc','TfVPAwMF-3mnU-DAPE-vFxC-MXAC3sXnrKKN'),
		('M2unxVt7-ZRM7-rdUM-rq9g-dNeTbt5uQ6Bc','1eU01QD7-h8t3-Qeja-03oY-KFuCvBMC0C3K'),
		('M2unxVt7-ZRM7-rdUM-rq9g-dNeTbt5uQ6Bc','nvqqT7qv-iqZP-WLLm-o8bW-GGckCQhoEwAP'),
		('M2unxVt7-ZRM7-rdUM-rq9g-dNeTbt5uQ6Bc','6ebM1mmb-96D9-zvNw-yuKd-NjTq1RvmLaJV'),
		('M2unxVt7-ZRM7-rdUM-rq9g-dNeTbt5uQ6Bc','TqRxQchj-RviN-ZXKj-1W2k-Lp383BcWE9kJ'),
		('TqRxQchj-RviN-ZXKj-1W2k-Lp383BcWE9kJ','M2unxVt7-ZRM7-rdUM-rq9g-dNeTbt5uQ6Bc'),
		('jdZWca8o-62LC-Rkri-MJuF-LkE5NVNfGpio','M2unxVt7-ZRM7-rdUM-rq9g-dNeTbt5uQ6Bc'),
		('FKRRyFGK-LXx8-ZJZu-YAAG-LidT7r9w1qt4','M2unxVt7-ZRM7-rdUM-rq9g-dNeTbt5uQ6Bc'),
		('RWPh8nhX-o4qi-3jiv-4uT9-4Ysjy8F5zVwr','M2unxVt7-ZRM7-rdUM-rq9g-dNeTbt5uQ6Bc'),
		('u5oAmtTY-CQ88-QdJK-CNrp-ZAqYjmmsVG72','NGJ0K62s-1Q30-bRjG-t54K-yb0nGRG9G5o2'),
		('u5oAmtTY-CQ88-QdJK-CNrp-ZAqYjmmsVG72','FKRRyFGK-LXx8-ZJZu-YAAG-LidT7r9w1qt4'),
		('u5oAmtTY-CQ88-QdJK-CNrp-ZAqYjmmsVG72','TqRxQchj-RviN-ZXKj-1W2k-Lp383BcWE9kJ'),
		('TfVPAwMF-3mnU-DAPE-vFxC-MXAC3sXnrKKN','u5oAmtTY-CQ88-QdJK-CNrp-ZAqYjmmsVG72'),
		('nvqqT7qv-iqZP-WLLm-o8bW-GGckCQhoEwAP','u5oAmtTY-CQ88-QdJK-CNrp-ZAqYjmmsVG72'),
		('1eU01QD7-h8t3-Qeja-03oY-KFuCvBMC0C3K','u5oAmtTY-CQ88-QdJK-CNrp-ZAqYjmmsVG72');



INSERT INTO "Category"("Title")
VALUES 
		('Business'),
		('Creativity'),
		('Culture'),
		('Entrepreneurship'),
		('Leadership'),
		('Productivity'),
		('Work'),
		('Marketing'),
		('Technology'),
		('Design'),
		('Personal Growth'),
		('Self Improvement'),
		('Writing'),
		('Education'),
		('Science'),
		('Health'),
		('Social Science'),
		('Politics'),
		('Society'),
		('Religion');



INSERT INTO "Comment"("ID","Text","UpdateDate","PostID", "ParentID", "AuthorID")
VALUES 
        ('z36CNarBkcVqmJbK5c','great','10/12/2022','9avdTPPigWqbsaqvt9','z36CNarBkcVqmJbK5c','nvqqT7qv-iqZP-WLLm-o8bW-GGckCQhoEwAP'),
        ('txCbXE99HbYvdqE7y2','Great article, and helpful. It would appear that as were evolving.','10/12/2022','SMKkSYY6sMG9DJSaKJ','txCbXE99HbYvdqE7y2','NGJ0K62s-1Q30-bRjG-t54K-yb0nGRG9G5o2'),
        ('WVRRdrRaP9bHhAtEhi','The way he delivered those words made all the difference.','10/12/2022','f8RZbVqLouT8ESycSP','WVRRdrRaP9bHhAtEhi','u5oAmtTY-CQ88-QdJK-CNrp-ZAqYjmmsVG72'),
        ('Y9EPoFoSjefoNjyphx','Thanks for the quick tip!','10/12/2022','BmtaiUhdeNmFgEP3RF','Y9EPoFoSjefoNjyphx','6ebM1mmb-96D9-zvNw-yuKd-NjTq1RvmLaJV'),
        ('n4YzorFkiZUEBGAK8V','Looks to be another good viral grammar post from Copyblogger!','11/12/2022','YZb5AFELifFTa5nCZd','n4YzorFkiZUEBGAK8V','NGJ0K62s-1Q30-bRjG-t54K-yb0nGRG9G5o2'),
        ('yVzgi2gacQ9fw3XNZh','Thank you so much for this very helpful post.You have put very useful words comparison.','11/12/2022','YZb5AFELifFTa5nCZd','yVzgi2gacQ9fw3XNZh','u5oAmtTY-CQ88-QdJK-CNrp-ZAqYjmmsVG72'),
        ('ByadKaCyqpDU5tqRj5','Thanks for this Interesting article.','13/12/2022','YZb5AFELifFTa5nCZd','ByadKaCyqpDU5tqRj5','6ebM1mmb-96D9-zvNw-yuKd-NjTq1RvmLaJV'),
        ('kaHaDuSGWbDT6MjkbF','Nice lil English lesson. Always a good refresher.','17/12/2022','8Gwj4ZrL8hL5yEwAw5','kaHaDuSGWbDT6MjkbF','1eU01QD7-h8t3-Qeja-03oY-KFuCvBMC0C3K');
        



INSERT INTO "Tag"("Name","ID")
VALUES 
		('Business','iqZP-WLLm-o8bW-GGckCQhoEwAP'),
		('Creativity','9G5o2-bRjG-t54K-yb0nGRG1Q30'),
		('Culture','h8t3-Qeja-03oY-KFuCvBMC0C3K'),
		('Entrepreneurship','96D9-zvNw-yuKd-NjTq1RvmLaJV'),
		('Leadership','CQ88-QdJK-CNrp-ZAqYjmmsVG72'),
		('Productivity','1Q30-bRjG-t54K-yb0nGRG9G5o2'),
		('Work','yuKd-96D9-zvNw-NjTq1RvmLaJV'),
		('Marketing','CNrp-QdJK-CQ88-ZAqYjmmsVG72'),
		('Technology','VFTu-QdJK-G5F5-ZYjAqmmsVG72'),
		('Design','CNrp-QdJK-CQ88-jmmsZAqYVG72'),
		('Personal Growth','87hf-cvTH-yuKd-NjTq1RvmLaJV'),
		('Self Improvement','76RH-zvNw-yuKd-NjTq1RvmLaJV'),
		('Writing','IUvl-WLLm-o8bW-GGckCQhoEwAP'),
		('Education','fk85-WLLm-o8bW-GGckCQhoEwAP'),
		('Science','GDal-QdJK-CNrp-ZAqYjmmsVG72'),
		('Health','JG8r-QdJK-CNrp-ZAqYjmmsVG72'),
		('Social Science','95Hy-bRjG-t54K-yb0nGRG9G5o2'),
		('Politics','5g8G-Tt54-KRw4-G9G5yb0nGRo2'),
		('Society','8Drf-96D9-zvNw-NjTq1RvmLaJV'),
		('Religion','oe8C-oi50-zvNw-RvmLaJVNjTq1');



INSERT INTO "Comment_Tag"("CommentID","TagID")
VALUES 
        ('txCbXE99HbYvdqE7y2','9G5o2-bRjG-t54K-yb0nGRG1Q30'),
        ('WVRRdrRaP9bHhAtEhi','h8t3-Qeja-03oY-KFuCvBMC0C3K'),
        ('Y9EPoFoSjefoNjyphx','96D9-zvNw-yuKd-NjTq1RvmLaJV'),
        ('n4YzorFkiZUEBGAK8V','CQ88-QdJK-CNrp-ZAqYjmmsVG72'),
        ('yVzgi2gacQ9fw3XNZh','1Q30-bRjG-t54K-yb0nGRG9G5o2'),
        ('ByadKaCyqpDU5tqRj5','yuKd-96D9-zvNw-NjTq1RvmLaJV'),
        ('kaHaDuSGWbDT6MjkbF','CNrp-QdJK-CQ88-ZAqYjmmsVG72'),    
        ('z36CNarBkcVqmJbK5c','iqZP-WLLm-o8bW-GGckCQhoEwAP');


INSERT INTO "Bookmark"("UserID","PostID")
VALUES 
		("M2unxVt7-ZRM7-rdUM-rq9g-dNeTbt5uQ6Bc", '9avdTPPigWqbsaqvt9'), 
		("7Nr3EYBu-5LVY-XHEp-aVY0-yCuu8NAqFjy5", 'acoJXDsGJuHcj9gzVU'), 
		("NGJ0K62s-1Q30-bRjG-t54K-yb0nGRG9G5o2", 'wDD7KqE8UWhQYHVKYb'), 
		("dA6fJyg9-HBAf-9YWq-RpGy-KzCckMhodEW3", 'SMKkSYY6sMG9DJSaKJ'), 
		("maHkKw9r-B9mM-NJbs-b3Jv-2MLYh7G6jaUb", 'X3ag3s65X5da7AtTfi'), 
		("KwWDb28a-ZZwg-PsaM-GmDt-5dyt4Tbt5uQ6", 'crzP4MVuvazqpUCay6'), 
		("TqRxQchj-RviN-ZXKj-1W2k-Lp383BcWE9kJ", 'f8RZbVqLouT8ESycSP'), 
		("jdZWca8o-62LC-Rkri-MJuF-LkE5NVNfGpio", 'BmtaiUhdeNmFgEP3RF'), 
		("FKRRyFGK-LXx8-ZJZu-YAAG-LidT7r9w1qt4", 'H4jzMxGBjFydjRdajQ'), 
		("RWPh8nhX-o4qi-3jiv-4uT9-4Ysjy8F5zVwr", 'ZaV7dLt2PK7KeToDi2'), 
		("u5oAmtTY-CQ88-QdJK-CNrp-ZAqYjmmsVG72", '3A9EK7g3aAgkAZkMbP'), 
		("94F58rZj-s0nd-2zrn-MXAs-J86gWPyDo5N7", 'ApspF46HFudoLoPZMB'), 
		("6ebM1mmb-96D9-zvNw-yuKd-NjTq1RvmLaJV", 'TxG5Q56hVkN3yrFZAF'), 
		("TfVPAwMF-3mnU-DAPE-vFxC-MXAC3sXnrKKN", 'YZb5AFELifFTa5nCZd');



INSERT INTO "Interact"(CommentID, UserID, Type)
VALUES 
	   ('z36CNarBkcVqmJbK5c', 'nvqqT7qv-iqZP-WLLm-o8bW-GGckCQhoEwAP', 'positive'),
       ('txCbXE99HbYvdqE7y2', 'NGJ0K62s-1Q30-bRjG-t54K-yb0nGRG9G5o2', 'positive'),
       ('WVRRdrRaP9bHhAtEhi', 'u5oAmtTY-CQ88-QdJK-CNrp-ZAqYjmmsVG72', 'positive'),
       ('Y9EPoFoSjefoNjyphx', '6ebM1mmb-96D9-zvNw-yuKd-NjTq1RvmLaJV', 'positive'),
       ('n4YzorFkiZUEBGAK8V', 'NGJ0K62s-1Q30-bRjG-t54K-yb0nGRG9G5o2', 'positive'),
       ('yVzgi2gacQ9fw3XNZh', 'u5oAmtTY-CQ88-QdJK-CNrp-ZAqYjmmsVG72', 'positive'),
       ('ByadKaCyqpDU5tqRj5', '6ebM1mmb-96D9-zvNw-yuKd-NjTq1RvmLaJV', 'positive'),
       ('kaHaDuSGWbDT6MjkbF', '1eU01QD7-h8t3-Qeja-03oY-KFuCvBMC0C3K', 'positive');



INSERT INTO "Post_Category" (PostID, Category) 
VALUES
		('9avdTPPigWqbsaqvt9', 'Writing'),
		('acoJXDsGJuHcj9gzVU', 'Education'),
		('wDD7KqE8UWhQYHVKYb', 'Self Improvement'),
		('SMKkSYY6sMG9DJSaKJ', 'Design'),
		('X3ag3s65X5da7AtTfi', 'Productivity'),
		('crzP4MVuvazqpUCay6', 'Writing'),
		('f8RZbVqLouT8ESycSP', 'Work'),
		('BmtaiUhdeNmFgEP3RF', 'Technology'),
		('H4jzMxGBjFydjRdajQ', 'Leadership'),
		('ZaV7dLt2PK7KeToDi2', 'Business'),
		('3A9EK7g3aAgkAZkMbP', 'Personal Growth'),
		('ApspF46HFudoLoPZMB', 'Entrepreneurship'),
		('TxG5Q56hVkN3yrFZAF', 'Entrepreneurship'),
		('YZb5AFELifFTa5nCZd', 'Marketing'),
		('ojb4MBUhm3NYxXUzPA', 'Marketing'),
		('8Gwj4ZrL8hL5yEwAw5', 'Writing');


