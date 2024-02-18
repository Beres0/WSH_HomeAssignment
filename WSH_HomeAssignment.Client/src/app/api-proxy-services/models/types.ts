export interface CustomFormat{
    getFormat():string
  }
  
  
   export type DateDto={
    year:number
    month:number
    day:number
  }
  export type CreateUpdateSavedDto={
    note?:string
  }
  export type PaginationArgs={
    skip?:number
    take?:number
  }
  export type PaginationDto<T>={
    totalCount:number
    resultCount:number
    args:PaginationArgs
    result:T[]
  }
  
  export type DailyExchangeRatesDto={
    date:DateDto
    exchangeRates:Map<string,ExchangeRateDto>
  }
  export type SavedDailyExchangeRatesDto={
    date:DateDto
    exchangeRates:Map<string,ExchangeRateDto>
    notes:Map<string,string|undefined>
  }
  export type SavedExchangeRateDto={
    date:DateDto
    currency:string
    unit:number
    value:number
    note?:string
  }
  export type ExchangeRateDto={
    currency:string
    unit:number
    value:number
  }
  export type ValidationDto={
    noteMaxLength:number
    unitMin:number
    valueMin:number
    passwordRequiredLength:number
    dateMin:DateDto
    currencyMaxLength:number
  }

  export type LoginDto={
    userName:string
    password:string
  }
  export type RegisterDto={
    userName:string
    password:string
    email:string
  }
  export type TokenDto={
    userId:string
    userName:string
    expiration:Date
    value:string
  }
 export class ErrorDto{

  static CreateFromError(errorResponse:any){
    const error=errorResponse.error
    if(error?.errors!=undefined){
      const dto=new ErrorDto()
      dto.statusCode=errorResponse.status
      const errorCollection:Array<string>=[]
      Object.values(error.errors).forEach(v=>{
        if(typeof v=="string"){
          errorCollection.push(v)
        }
        else if(Array.isArray(v)){
          errorCollection.push(...v.map(i=>String(i)))
        } 
      })
      dto.message=errorCollection
      return dto
    }
    else if(error!=undefined){
      const dto=new ErrorDto()
      dto.code=error.code
      dto.message=[error.message]
      dto.statusCode=error.statusCode
      return dto
    }
    return undefined
  }
  code?:number
  message?:string[]
  statusCode?:number
  }