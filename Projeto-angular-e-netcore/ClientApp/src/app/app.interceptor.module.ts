import { Injectable, NgModule } from '@angular/core';

import {
  HttpEvent,
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
} from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable()
export class HttpsRequestInterceptor implements HttpInterceptor {

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler,
  ): Observable<HttpEvent<any>> {

    const userLoggedString = localStorage.getItem('user_logged');
    var _user;
    
    if (userLoggedString !== null) {
      _user = JSON.parse(userLoggedString);
    }

    const dupReq = req.clone({
      headers: req.headers.set('authorization', (_user && _user.token) ? 'Bearer ' + _user.token : ''),
    });
    return next.handle(dupReq);

  }

}


@NgModule({
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpsRequestInterceptor,
      multi: true,
    },
  ],
})

export class Interceptor { }
