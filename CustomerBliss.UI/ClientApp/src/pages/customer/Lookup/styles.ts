import styled from 'styled-components';

export const LookupCustomerContainer = styled.div`
  display: flex;
  flex-direction: column;

  div {
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: flex-start;
    margin: 0.5rem;
    padding: 0.5rem;
    gap: 0.5rem;

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
      text-shadow: 0px 0px 5px rgba(66, 66, 66, 0.75);
    }
  }
`;

export const FindButton = styled.button`
  border: 0;
  padding: 0.5rem;
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

export const CustomerTable = styled.table`
  width: 100%;
  border-collapse: collapse;
  min-width: 600px;

  th {
    background-color: ${(props) => props.theme['blue-500']};
    padding: 1rem;
    text-align: left;
    color: ${(props) => props.theme['beige-100']};
    font-size: 0.875rem;
    line-height: 1.6;

    &:first-child {
      border-top-left-radius: 8px;
      padding-left: 1.5rem;
    }

    &:last-child {
      border-top-right-radius: 8px;
      padding-right: 1.5rem;
    }
  }

  tr {
    background-color: ${(props) => props.theme['blue-100']};
  }

  td {
    border-top: 2px solid ${(props) => props.theme['beige-200']};
    padding: 1rem;
    font-size: 0.875rem;
    line-height: 1.6;

    &:first-child {
      width: 50%;
      padding-left: 1.5rem;
    }

    &:last-child {
      padding-right: 1.5rem;
      display: flex;
      flex-direction: row;
      flex-wrap: nowrap;
      align-items: center;
      justify-content: space-around;
    }
  }

  tr:nth-child(odd) {
    background-color: ${(props) => props.theme['beige-200']};
  }

  tr:hover {
    background-color: ${(props) => props.theme['blue-200']};
  }
`;
