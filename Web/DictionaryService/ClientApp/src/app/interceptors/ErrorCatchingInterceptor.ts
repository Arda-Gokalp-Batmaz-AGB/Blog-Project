import {Injectable} from '@angular/core';
import {HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {catchError, retry} from "rxjs/operators";

@Injectable()
export class ErrorCatchingInterceptor implements HttpInterceptor {

  constructor() {
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
     return next.handle(request)
           .pipe(
                retry(1),
                 catchError((error: HttpErrorResponse) => {
                    let errorDescriptionsList : string[] = []
                    if (error.error instanceof ErrorEvent) {
                       console.log('This is client side error');
                      // errorMsg = `Error: ${error.error.message}`;
                    } else {
                       console.log('This is server side error');
                       errorDescriptionsList = this.getServerSideErrorList(error);
                    }
                    return throwError(errorDescriptionsList);
                 })
           )
  }

  getServerSideErrorList(err : HttpErrorResponse) : string[]
  { // .NET TARAFINA ERROR HANDLING EKLE
    var obj;
    if(err.error instanceof Object && !(err.error instanceof String))
    {
      obj = [err.error]
    }
    else
    {
      obj = JSON.parse(JSON.parse(JSON.stringify(err.error)));
    }
    console.log(obj);
    if(obj == null)
    {
      return [`Error with ${err.status} code`];
    }
    if(obj['errors'] != undefined)
    {
      obj = obj['errors'];
    }
    let responseErrors : string[] = [];
    Object.values(obj).forEach((element : any) => {
      var el = JSON.parse(JSON.stringify(element));
      if(el['description'] != undefined)
      {
        responseErrors?.push(el["description"]);
      }
      else
      {
        responseErrors?.push(el[0]);
      }
    });
      return responseErrors;
  }

}
