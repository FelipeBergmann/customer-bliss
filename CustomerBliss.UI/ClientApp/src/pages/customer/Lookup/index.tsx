import { CustomerTable, FindButton, LookupCustomerContainer } from './styles';

export function Lookup() {
  return (
    <LookupCustomerContainer>
      <div>
        <label htmlFor="customerName">Nome</label>
        <input type="text" name="" id="customerName" />
        <FindButton>Buscar</FindButton>
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
          <tr>
            <td>Nome do cliente</td>
            <td>Nome da pessoa de contato</td>
            <td>CNPJ</td>
            <td>Categoria</td>
          </tr>
          <tr>
            <td>Nome do cliente</td>
            <td>Nome da pessoa de contato</td>
            <td>CNPJ</td>
            <td>Categoria</td>
          </tr>
          <tr>
            <td>Nome do cliente</td>
            <td>Nome da pessoa de contato</td>
            <td>CNPJ</td>
            <td>Categoria</td>
          </tr>
        </tbody>
      </CustomerTable>
    </LookupCustomerContainer>
  );
}
