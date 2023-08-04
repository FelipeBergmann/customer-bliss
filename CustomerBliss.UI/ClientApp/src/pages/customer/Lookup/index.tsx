import { useEffect, useState } from 'react';
import { Customer } from '../../../services/api.types';
import { CustomerTable, FindButton, LookupCustomerContainer } from './styles';
import api from '../../../services/api';

export function Lookup() {
  const [customers, setCustomers] = useState<Customer[]>([] as Customer[]);
  const [searchCustomerName, setSearchCustomerName] = useState('');
  useEffect(() => {
    async function initialLoad() {
      const customerResponse = await api
        .getCustomer()
        .then((response) => response.data.customers);
      setCustomers(customerResponse);
    }

    initialLoad();
  }, []);

  async function loadCustomers() {
    const response = await api
      .getCustomer({
        name: searchCustomerName,
      })
      .then((response) => {
        return response.data.customers;
      });

    setCustomers(response);
  }

  function handleCustomerSearch() {
    loadCustomers();
  }

  function transformCategory(category: string): string {
    switch (category) {
      case 'Promoter':
        return 'Promotor';
      case 'Neutral':
        return 'Neutro';
      case 'Detrator':
        return 'Detrator';
      default:
        return 'Nenhum';
    }
  }

  const handleSearchNameInputChange = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setSearchCustomerName(event.target.value);
  };

  return (
    <LookupCustomerContainer>
      <div>
        <label htmlFor="customerName">Nome</label>
        <input
          type="text"
          name=""
          id="customerName"
          value={searchCustomerName}
          onChange={handleSearchNameInputChange}
        />
        <FindButton onClick={handleCustomerSearch}>Buscar</FindButton>
      </div>

      <CustomerTable>
        <thead>
          <tr>
            <th>Nome do cliente</th>
            <th>Nome da pessoa de contato</th>
            <th>CNPJ</th>
            <th>Categoria</th>
          </tr>
        </thead>
        <tbody>
          {customers.map((customer) => (
            <tr key={customer.id}>
              <td>{customer.name}</td>
              <td>{customer.contactName}</td>
              <td>{customer.companyDocument}</td>
              <td>{transformCategory(customer.category)}</td>
            </tr>
          ))}
        </tbody>
      </CustomerTable>
    </LookupCustomerContainer>
  );
}
