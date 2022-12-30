import { createComment } from "./createComment"
import { responseComment } from "./responseComment"

export interface createPost
{
  AuthorID : string
  Title : string
  FirstComment : createComment
}
