import { UserList, UserPlus } from 'phosphor-react';
import { CustomerManagementContainer, RedirectButton } from './styles';

export function CustomerManagement() {
  return (
    <CustomerManagementContainer>
      <RedirectButton href="/customer/new">
        <UserPlus size={32} />
        Cadastrar
      </RedirectButton>

      <RedirectButton href="/customer/find">
        <UserList size={32} />
        Consultar
      </RedirectButton>
    </CustomerManagementContainer>
  );
}
