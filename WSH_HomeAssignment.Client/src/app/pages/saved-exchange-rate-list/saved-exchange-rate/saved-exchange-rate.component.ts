import { ThisReceiver } from '@angular/compiler';
import { Component,Input,Output,EventEmitter } from '@angular/core';
import { SavedExchangeRateDto } from 'src/app/api-proxy-services/models/types';

@Component({
  selector: 'app-saved-exchange-rate',
  templateUrl: './saved-exchange-rate.component.html',
  styleUrls: ['./saved-exchange-rate.component.scss']
})
export class SavedExchangeRateComponent {
  @Input() editModel?:SavedExchangeRateDto
  @Input() item?:SavedExchangeRateDto
  @Input() noteMaxLength?:number
  @Output() onDelete:EventEmitter<SavedExchangeRateDto>=new EventEmitter()
  @Output() onConfirm:EventEmitter<SavedExchangeRateDto>=new EventEmitter()
  editing:boolean=false

  
  startEdit(){
    this.editing=true
    this.editModel={} as any
    Object.keys(this.item!).forEach(k=>{
      (this.editModel as any)[k]=(this.item as any)[k]
    })
  }
  confirmEdit(){
    try{
      if(this.editModel?.note!=this.item?.note){
        this.item=this.editModel
        this.onConfirm.emit(this.editModel)
      }
    }
    finally{
      this.editing=false
    }
  }

  delete(){
    this.onDelete.emit(this.item)
  }
  closeEdit(){
    this.editing=false
  }
}
