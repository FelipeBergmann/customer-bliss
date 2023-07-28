import styled from 'styled-components';

export const StatsContainer = styled.main`
  /* flex: 1;
  overflow: auto; */

  table {
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
  }
`;
