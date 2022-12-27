export class responseUser {
    userName : string = "";
    email : string = "";
    dateCreated : string = "";
    token : string = "";
    constructor(userName : string, email : string, dateCreated : string, token : string)
    {
        this.userName = userName;
        this.email = email;
        this.dateCreated = dateCreated;
        this.token = token;
    }
  }
  