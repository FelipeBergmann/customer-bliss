import axios from 'axios';
import { GetCustomer, GetCustomerRequest, Paginated } from './api.types';

const axiosInstance = axios.create({
  baseURL: 'https://localhost:44323/api',
});

axiosInstance.interceptors.response.use(
  (response) => response.data,
  (err) => {
    console.log(err);
    return Promise.reject(err);
  }
);

class api {
  getCustomer = async (
    data?: GetCustomerRequest
  ): Promise<Paginated<GetCustomer>> =>
    await axiosInstance.get('/v1/customer', { params: { ...data } });
}

export default new api();
