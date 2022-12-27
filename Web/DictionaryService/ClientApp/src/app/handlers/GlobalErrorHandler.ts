
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandler, Injectable } from '@angular/core';

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {

  handleError(error : any) {
    if (!(error instanceof HttpErrorResponse)) {
      error = error.rejection; // get the error object
    }

    console.error('Error from global error handler', error);
  }
}
