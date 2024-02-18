import { Component,Input } from '@angular/core';
import { ExchangeRatesService } from 'src/app/api-proxy-services/exchange-rates/exchange-rates.service';
import { DailyExchangeRatesDto, ExchangeRateDto, SavedDailyExchangeRatesDto } from 'src/app/api-proxy-services/models/types';
import { Observable,lastValueFrom } from 'rxjs';
import { bootstrapApplication } from '@angular/platform-browser';

@Component({
  selector: 'app-exchange-rate-table',
  templateUrl: './exchange-rate-table.component.html',
  styleUrls: ['./exchange-rate-table.component.scss']
})
export class ExchangeRateTableComponent {
 @Input() current?:DailyExchangeRatesDto
 @Input() savedCurrent?:SavedDailyExchangeRatesDto
 @Input() service?:ExchangeRatesService
 constructor() {
 }
 hasNote(currency:string){
  return this.savedCurrent?.notes!=undefined&&(this.savedCurrent.notes as any)[currency]!=undefined
 }
 getNote(currency:string){
  return ((this.savedCurrent?.notes as any)[currency]) as string
}

 savedContains(currency:string){
  return this.savedCurrent!=undefined&&(this.savedCurrent?.exchangeRates as any)[currency]!=undefined;
 }
 private set(map:any,key:string,value:any){
  map[key]=value
 }
 private remove(map:any,key:string){
  delete map[key]
 }

 async save(exchangeRate:ExchangeRateDto,button:HTMLButtonElement){
  try{
    button.setAttribute("disabled","true")
    await lastValueFrom(this.service!.createSaved(this.current?.date!,exchangeRate.currency,{note:undefined}))
    this.set(this.savedCurrent?.exchangeRates,exchangeRate.currency,exchangeRate)
    this.set(this.savedCurrent?.notes,exchangeRate.currency,undefined)
  }
  catch(error){
    console.log(error)
    window.location.reload()
  }
  finally{
    button.setAttribute("disabled","false")
  }
}
 async delete(exchangeRate:ExchangeRateDto,button:HTMLButtonElement){
  try{
    button.setAttribute("disabled","true")
    await lastValueFrom(this.service!.deleteSaved(this.current?.date!,exchangeRate.currency))
    this.remove(this.savedCurrent?.exchangeRates,exchangeRate.currency)
    this.remove(this.savedCurrent?.notes,exchangeRate.currency)
  }
  catch(error){
    console.log(error)
    window.location.reload()
  }
  finally{
    button.setAttribute("disabled","false")
  }
 }

}
