Select pc.category, u.name, u.surname, p.title from post p join post_category pc on p.ID=pc.postID 
                                                           join user u on p.authorID = u.ID 
                                                           order by pc.category;

