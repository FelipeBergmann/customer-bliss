export type Paginated<T> = {
  page: number;
  totalRegisterQty: number;
  data: T;
};

export type Customer = {
  id: string;
  name: string;
  contactName: string;
  companyDocument: string;
  lastReviewScore: number;
  lastReviewDate: Date;
  category: string;
  initialDate: Date;
};

export type GetCustomer = {
  totalCustomerCount: number;
  customers: Customer[];
};

export type GetCustomerRequest = {
  page?: number;
  pageSize?: number;
  name?: string;
  orderByLastReviewDate?: boolean;
  orderByDesc?: boolean;
};
