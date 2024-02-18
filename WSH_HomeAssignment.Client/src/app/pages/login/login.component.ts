import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/api-proxy-services/auth/auth.service';
import { ErrorDto, LoginDto } from 'src/app/api-proxy-services/models/types';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  errorMsg?:string[]
  loginModel:LoginDto={userName:"",password:""}
  submitDisabled:boolean=false
  
  constructor(private authService:AuthService,private router:Router){
  }

  async onSubmit(){
    try{
      this.submitDisabled=true
      await this.authService.login(this.loginModel);
      this.router.navigate(["/"])
    }catch(error){
      this.errorMsg=ErrorDto.CreateFromError(error)?.message
    }
    finally{
      this.submitDisabled=false
    }
  }
debug(){
  return JSON.stringify(this.loginModel)
}
}
