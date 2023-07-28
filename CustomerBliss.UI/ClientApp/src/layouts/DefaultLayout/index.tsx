import { Outlet } from 'react-router-dom';
import { ContentContainer, LayoutContainer } from './styles';
import { Header } from '../../components/Header';

export function DefaultLayout() {
  return (
    <LayoutContainer>
      <Header />
      <ContentContainer>
        <Outlet />
      </ContentContainer>
    </LayoutContainer>
  );
}
