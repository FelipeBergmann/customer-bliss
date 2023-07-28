import styled from 'styled-components';

export const HeaderContainer = styled.header`
  display: flex;
  align-items: center;
  justify-content: space-between;

  background: ${(props) => props.theme['blue-500']};
  color: ${(props) => props.theme['beige-100']};
  height: 4rem;
  padding: 0.31rem 2rem;

  nav {
    display: flex;
    gap: 1rem;

    a {
      text-decoration: none;
      color: ${(props) => props.theme['beige-100']};
      padding: 4px;
      display: flex;
      justify-content: center;
      align-items: center;
      gap: 0.5rem;

      border-top: 3px solid transparent;
      border-bottom: 3px solid transparent;

      &:hover {
        border-bottom: 3px solid ${(props) => props.theme['blue-100']};
        color: ${(props) => props.theme['blue-100']};
      }

      &.active {
        color: ${(props) => props.theme['blue-100']};
      }
    }
  }

  @media screen and (max-width: 700px) {
    nav a span {
      display: none;
    }
  }
`;
