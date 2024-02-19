import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/api-proxy-services/auth/auth.service';
import { ErrorDto, RegisterDto } from 'src/app/api-proxy-services/models/types';

@Component({
    selector: 'app-registration',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.scss'],
})
export class RegistrationComponent {
    errorMsg?: string[];
    registerModel: RegisterDto = { userName: '', email: '', password: '' };
    submitting: boolean = false;
    confirmedPassword: string = '';
    constructor(private authService: AuthService, private router: Router) {}
    submitDisabled() {
        return (
            this.submitting ||
            this.confirmedPassword != this.registerModel.password
        );
    }

    async onSubmit() {
        try {
            this.submitting = true;
            await this.authService.register(this.registerModel);
            this.router.navigate(['/']);
        } catch (error) {
            this.errorMsg = ErrorDto.CreateFromError(error)?.message;
        } finally {
            this.submitting = false;
        }
    }
}
