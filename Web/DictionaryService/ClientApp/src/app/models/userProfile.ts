export class userProfile
{
  userName : string = "";
  name : string = "";
  surname : string = "";
  about : string = "";
  followers : string[] = [];
  followeds : string[] = [];
  id : string = "";
  dateCreated : string = "";

  constructor(id : string,userName : string,name : string, surname : string, about : string,
    followers : string[],followeds : string[], dateCreated : string)
    {
      this.id = id
      this.userName = userName
      this.name = name
      this.surname = surname
      this.about = about
      this.followers = followers
      this.followeds = followeds
      this.dateCreated = dateCreated
    }
}
