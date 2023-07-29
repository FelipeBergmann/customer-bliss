import styled from 'styled-components';

export const SurveyContainer = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
`;

export const SurveyCustomerContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;

  table {
    margin-top: 1rem;

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
        /* padding-left: 1.5rem; */
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
        display: flex;
        align-items: center;
        justify-content: center;
      }
    }

    tr:nth-child(odd) {
      background-color: ${(props) => props.theme['beige-200']};
    }

    tr:hover {
      background-color: ${(props) => props.theme['blue-200']};
    }
  }
`;
