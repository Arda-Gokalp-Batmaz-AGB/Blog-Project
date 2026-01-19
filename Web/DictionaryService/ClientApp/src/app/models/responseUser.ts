export class responseUser {
    id : string = "";
    userName : string = "";
    email : string = "";
    dateCreated : string = "";
    token : string = "";
    constructor(id : string,userName : string, email : string, dateCreated : string, token : string)
    {
        this.id = id
        this.userName = userName;
        this.email = email;
        this.dateCreated = dateCreated;
        this.token = token;
    }
  }
