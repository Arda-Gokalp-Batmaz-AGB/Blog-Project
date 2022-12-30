export class responseComment {
  id : number = -1;
  text : string = "";
  dateCreated : string = "";
  dateModified : string = "";
  postID : number = -1;
  parentID : number = -1;
  authorID : string = "";
  authorName : string = "";
  likeCount : number = -1;
  dislikeCount : number = -1
  constructor(id : number, text : string, dateCreated : string, dateModified : string,
    postID : number, parentID : number, authorID : string, authorName : string,likeCount : number, dislikeCount : number)
  {
    this.id = id;
    this.text = text;
    this.dateCreated = dateCreated;
    this.dateModified = dateModified;
    this.postID = postID;
    this.parentID = parentID;
    this.authorID = authorID;
    this.authorName = authorName;
    this.likeCount = likeCount;
    this.dislikeCount = dislikeCount;
  }
}
