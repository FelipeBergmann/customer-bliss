import { NavLink } from 'react-router-dom';
import { HeaderContainer } from './styles';
import { Binoculars, ChartPieSlice, Pinwheel, UserGear } from 'phosphor-react';

export function Header() {
  return (
    <HeaderContainer>
      <div>
        <Pinwheel size={32} />
      </div>
      <nav>
        <NavLink to="/">
          <ChartPieSlice size={32} />
          <span>Estatísticas</span>
        </NavLink>
        <NavLink to="/survey">
          <Binoculars size={32} />
          <span>Iniciar Pesquisa</span>
        </NavLink>
        <NavLink to="/customer">
          <UserGear size={32} />
          <span>Gerenciar Clientes</span>
        </NavLink>
      </nav>
    </HeaderContainer>
  );
}
