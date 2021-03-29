//Orders
export interface IOrder {
  orderId: number;
  orderNumber: string;
  orderDate: Date;
}

//OrderItems
export interface IOrderItem {
  productName: string;
  orderId: number;
  quantity: number;
  unitPrice: number;
  amount: number;
  color: string;
}
