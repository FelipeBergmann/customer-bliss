import { TableRegister } from './components/TableRegister';
import { StatsContainer } from './styles';

export function StatsPage() {
  const data = [
    {
      period: 'jan/23',
      positive: 81,
      neutral: 19,
      negative: 0,
    },
    {
      period: 'fev/23',
      positive: 80,
      neutral: 20,
      negative: 0,
    },
    {
      period: 'mar/23',
      positive: 79,
      neutral: 21,
      negative: 0,
    },
    {
      period: 'abr/23',
      positive: 78,
      neutral: 3,
      negative: 19,
    },
    {
      period: 'mai/23',
      positive: 79,
      neutral: 2,
      negative: 19,
    },
  ];
  return (
    <StatsContainer>
      <table>
        <thead>
          <tr>
            <th>Período</th>
            <th>Promotores</th>
            <th>Neutros</th>
            <th>Detratores</th>
            <th>Total</th>
            <th>NPS</th>
          </tr>
        </thead>
        <tbody>
          {data.map((item) => (
            <TableRegister
              key={item.period}
              positive={item.positive}
              neutral={item.neutral}
              negative={item.negative}
              period={item.period}
            />
          ))}
        </tbody>
      </table>
    </StatsContainer>
  );
}
