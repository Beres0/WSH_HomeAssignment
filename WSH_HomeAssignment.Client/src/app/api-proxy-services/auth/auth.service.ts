import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiService } from '../api.service';
import { LoginDto, RegisterDto, TokenDto } from '../models/types';
import{lastValueFrom}  from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends ApiService {

  private readonly tokenKey="api-token"
  override url:string="api/auth"
  cachedToken?:TokenDto
  
  constructor(http:HttpClient,private router:Router) {
    super(http)
   }
  
   private async authMethod<TInput>(endpoint:string,input?:TInput){
      const value=await lastValueFrom(this.http.post<TokenDto>(this.url+endpoint,input))
      localStorage.setItem(this.tokenKey, JSON.stringify(value))
      this.cachedToken=value
   }

    async login(input:LoginDto){
      return await this.authMethod("/login",input)
   }
   async register(input:RegisterDto){
    return await this.authMethod("/register",input)
   }
  async refreshToken(){
    return await this.authMethod("/refresh-token")
   }
   logout(){
    localStorage.removeItem(this.tokenKey)
    this.cachedToken=undefined
    this.router.navigate(["/login"])
   }
   isLoggedIn(){
    return this.getToken()!=undefined
   }

   getToken(){
    if(this.cachedToken==undefined){
      const stored=localStorage.getItem(this.tokenKey)
      if(stored==null){
        return undefined
      }
      const token=Object.assign({},JSON.parse(stored))
      this.cachedToken=token
    }
   
    const now=new Date().getTime()
    const expiration=new Date(this.cachedToken!.expiration).getTime()
    if(now>=expiration){
      this.logout()
      return undefined
    }
    return this.cachedToken;
   }
}
