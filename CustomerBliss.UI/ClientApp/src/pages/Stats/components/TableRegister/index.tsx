import { FormattedNumber } from 'react-intl';
import { Status } from './styles';

export interface ITableRegister {
  period: string;
  positive: number;
  neutral: number;
  negative: number;
}
export function TableRegister({
  period,
  positive,
  neutral,
  negative,
}: ITableRegister) {
  const totalPeople = positive + negative + neutral;
  const calculatedNPS = calculateNPS(positive, negative, totalPeople);

  function calculateNPS(
    positive: number,
    negative: number,
    totalPeople: number
  ): number {
    return ((positive - negative) / totalPeople) * 100;
  }

  function setNPSStatus(calculatedNPS: number): 'green' | 'yellow' | 'red' {
    if (calculatedNPS >= 80) return 'green';
    else if (calculatedNPS >= 60) return 'yellow';
    else return 'red';
  }

  return (
    <tr>
      <td>{period}</td>
      <td>{positive}</td>
      <td>{negative}</td>
      <td>{neutral}</td>
      <td>{totalPeople}</td>
      <td>
        <Status statusColor={setNPSStatus(calculatedNPS)} />
        <FormattedNumber
          value={calculatedNPS / 100}
          style="percent"
          minimumFractionDigits={2}
          maximumFractionDigits={2}
        />
      </td>
    </tr>
  );
}
