import { Component,ViewChildren,QueryList,ElementRef,AfterViewInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { AuthService } from '../api-proxy-services/auth/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  @ViewChildren("navItem") items?:QueryList<ElementRef<HTMLAnchorElement>>
  constructor(private authService:AuthService,private router:Router, activatedRoute:ActivatedRoute){
  router.events.subscribe(e=>{
    if(e instanceof NavigationEnd){
      console.log(this.items)
     const a=this.items?.find(i=>i.nativeElement.getAttribute("href")==e.url)
     a?.nativeElement.setAttribute("data-current","")
    }
  
  })
  }
 
  logout(){
    this.authService.logout();
  }
}
