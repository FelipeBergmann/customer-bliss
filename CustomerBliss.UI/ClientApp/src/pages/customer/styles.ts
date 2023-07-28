import styled from 'styled-components';

export const CustomerManagementContainer = styled.div`
  display: flex;
  flex-direction: row;
  align-items: center;
  gap: 2rem;
`;

export const RedirectButton = styled.a`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 1rem;
  background: ${(props) => props.theme['blue-500']};
  font-weight: bold;
  font-size: 1.5rem;
  padding: 2rem;
  color: ${(props) => props.theme['beige-100']};
  border-radius: 8px;
  text-decoration: none;
  transition: background 0.2s ease;
  cursor: pointer;
  &:hover {
    background: ${(props) => props.theme['blue-700']};
  }
`;
