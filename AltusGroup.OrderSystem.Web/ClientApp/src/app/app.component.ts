import { Component, OnInit } from "@angular/core";
import { DataService } from "./shared/services/data.service";
import { IOrder, IOrderItem } from "./shared/interface";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
})
export class AppComponent implements OnInit {
  orders: IOrder[];
  orderItems: IOrderItem[]; 
  selectedOrder: IOrder;
  pagedOrderItems: IOrderItem[];
  orderTotal: number;

  page = 1;
  pageSize = 4;
  collectionSize = 0;

  constructor(private orderService: DataService) {}

  ngOnInit(): void {
    this.getOrderData();
  }

  private getOrderData(): void {
    this.orderService.getOrders().subscribe(
      (data) => {
        this.orders = data;
      },
      (error) => {
        console.log("Unable to fetch Orders...");
      }
    );
  }

  private getOrderItemData(orderId: number): void {
    this.orderService.getOrderItems(orderId).subscribe(
      (data) => {
        this.orderItems = data;
        this.collectionSize = this.orderItems.length;
        this.refreshOrderItems();
        this.calculateTotal();
      },
      (error) => {
        console.log("Unable to fetch Orders Details...");
      }
    );
  }

  refreshOrderItems(){
    this.pagedOrderItems = this.orderItems
    .map((item, i) => ({id: i + 1, ...item}))
    .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  }

  onOrderChange(event){
    this.orderItems = [];
    this.pagedOrderItems = [];
    this.collectionSize = 0;
    this.orderTotal = null;
    this.selectedOrder = event as IOrder;

    this.getOrderItemData(this.selectedOrder.orderId);
    this.page = 1;
    this.refreshOrderItems();
  }

  calculateTotal(){
    this.orderTotal = this.orderItems.map(a => a.amount).reduce(function(a, b)
    {
      return a + b;
    });
  }
}
