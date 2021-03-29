import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ConfigService } from "../util/config.service";

import { IOrder, IOrderItem } from "../../shared/interface";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class DataService {
  private _baseUrl: string = "";

  constructor(private http: HttpClient, private configService: ConfigService) {
    this._baseUrl = configService.getApiUri();
  }

  getOrders() : Observable<IOrder[]>{
    return this.http.get<IOrder[]>( this._baseUrl + "order");
  }

  getOrderItems(id: number) : Observable<IOrderItem[]>{
    return this.http.get<IOrderItem[]>(this._baseUrl + "order/" + id);
  }
}
