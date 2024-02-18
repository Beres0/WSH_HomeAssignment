import { Pipe, PipeTransform,Injectable } from '@angular/core';
import { CustomFormat, DateDto } from '../api-proxy-services/models/types';

@Injectable({
  providedIn: 'root'
})
@Pipe({
  name: 'dtoToDate'
})
export class DtoToDatePipe implements PipeTransform {

  transform(value: DateDto|undefined, ...args: unknown[]): unknown {
    if(value==undefined|| value.year==undefined&&value.month==undefined&&value.day==undefined){
      return "not-date"
    }
    return value.year+"-"+String(value.month).padStart(2,"0")+"-"+String(value.day).padStart(2,"0")
  }

}
