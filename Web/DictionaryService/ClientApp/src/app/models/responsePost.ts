import { responseComment } from "./responseComment";

export class responsePost {
  id : number = -1;
  title : string = "";
  authorID : string = "";
  comments : responseComment[] = []
  authorName : string = "";
  constructor(id : number,title : string, authorID : string, comments : responseComment[], authorName : string)
  {
    this.id = id;
    this.title = title;
    this.authorID = authorID;
    this.comments = comments;
    this.authorName = authorName;
  }
}
