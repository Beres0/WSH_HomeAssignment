import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../api-proxy-services/auth/auth.service';

@Injectable({
    providedIn: 'root',
})
export class UnAuthGuard {
    constructor(private authService: AuthService, private router: Router) {}
    canActivate() {
        if (!this.authService.isLoggedIn()) {
            return true;
        } else {
            this.router.navigate(['../']);
        }
        return false;
    }
}
