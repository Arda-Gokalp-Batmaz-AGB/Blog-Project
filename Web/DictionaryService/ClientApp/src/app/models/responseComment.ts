export class responseComment {
  id : number = -1;
  text : string = "";
  dateCreated : string = "";
  dateModified : string = "";
  postID : number = -1;
  parentID : number = -1;
  authorID : string = "";
  authorName : string = "";
  constructor(id : number, text : string, dateCreated : string, dateModified : string, postID : number, parentID : number, authorID : string, authorName : string)
  {
    this.id = id;
    this.text = text;
    this.dateCreated = dateCreated;
    this.dateModified = dateModified;
    this.postID = postID;
    this.parentID = parentID;
    this.authorID = authorID
    this.authorName = authorName
  }
}
