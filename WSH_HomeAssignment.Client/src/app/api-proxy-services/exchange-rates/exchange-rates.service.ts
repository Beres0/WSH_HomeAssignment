import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { ApiService } from '../api.service';
import { DatePipe, getLocaleMonthNames } from '@angular/common';
import { CreateUpdateSavedDto, DailyExchangeRatesDto, DateDto, PaginationArgs, PaginationDto, SavedDailyExchangeRatesDto, SavedExchangeRateDto } from '../models/types';
import { DtoToDatePipe } from 'src/app/pipes/dtoToDate-pipe';

@Injectable({
  providedIn: 'root'
})
export class ExchangeRatesService extends ApiService {
  override url:string="api/exchange-rates"
  constructor(http:HttpClient,private datePipe:DtoToDatePipe) { 
    super(http)
  }

  getCurrent():Observable<DailyExchangeRatesDto>{
    return this.http.get<DailyExchangeRatesDto>(this.url+"/current")
  }
  getSavedCurrent(){
    return this.http.get<SavedDailyExchangeRatesDto>(this.url+"/saved/current")
  }
  getSavedList(args?:PaginationArgs){
    return this.http.get<PaginationDto<SavedExchangeRateDto>>(this.url+"/saved",
    {params: this.convertToQueryParams(args)})
  }
  private getSavedFullRoute(date:DateDto,currency:string){
    return this.url+"/saved/"+this.datePipe.transform(date)+"/"+currency
  } 

  getSaved(date:DateDto,currency:string){
    return this.http.get<SavedExchangeRateDto>(this.getSavedFullRoute(date,currency))
  }
  deleteSaved(date:DateDto,currency:string){
    return this.http.delete(this.getSavedFullRoute(date,currency))
  }
  createSaved(date:DateDto,currency:string,input:CreateUpdateSavedDto){
    return this.http.post(this.getSavedFullRoute(date,currency),input)
  }
  updateSaved(date:DateDto,currency:string,input:CreateUpdateSavedDto){
    return this.http.put(this.getSavedFullRoute(date,currency),input)
  }
}

