import styled from 'styled-components';

export const CustomerRegistrationFormContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: flex-start;

  div {
    width: 100%;
    display: flex;
    flex-direction: column;
    align-items: space-between;
    justify-content: flex-start;
    margin: 0.5rem;
    padding: 0.5rem;

    label {
      margin-bottom: 0.5rem;
    }

    input {
      padding: 5px;
      font-size: 16px;
      border-width: 0px;
      border-color: #cccccc;
      background-color: #ffffff;
      color: #000000;
      border-style: solid;
      border-radius: 8px;
      box-shadow: 0px 0px 5px rgba(66, 66, 66, 0.75);
    }
  }
`;

export const ErrorMessage = styled.span`
  color: ${(props) => props.theme['red-500']};
`;

export const SubmitButton = styled.button`
  width: 100%;
  border: 0;
  padding: 1rem;
  border-radius: 8px;

  display: flex;
  align-items: center;
  justify-content: center;

  gap: 0.5rem;
  font-weight: bold;

  cursor: pointer;

  color: ${(props) => props.theme['beige-100']};

  background: ${(props) => props.theme['green-500']};

  &:disabled {
    opacity: 0.7;
    cursor: not-allowed;
  }

  &:not(:disabled):hover {
    background: ${(props) => props.theme['green-700']};
  }
`;
