import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AutorizadoGuard implements CanActivate {

  Autenticado() : boolean{
    if (localStorage.getItem("token")) {
      return true
    }
    return false
  }

  constructor(private router : Router){}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if (this.Autenticado()) {
      return true;
    }
    this.router.navigate(["/login"])
    return false
  }

}
