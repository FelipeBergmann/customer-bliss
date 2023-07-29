import { useState } from 'react';
import { SurveyStep } from './SurveyStep';
import { SurveyContainer, SurveyCustomerContainer } from './styles';
import { useNavigate } from 'react-router-dom';
import { Confetti } from 'phosphor-react';

export function SurveyPage() {
  const navigate = useNavigate();
  const [currentStep, setCurrentStep] = useState(0);
  const maxStep = 4;

  const customers = [
    {
      id: 1,
      name: 'Empresa 1',
      cnpj: '00.000.000/0000-00',
      category: 'Detrator',
      lastSurvey: '01/01/2021',
      lastScore: 10,
    },
    {
      id: 1,
      name: 'Empresa 1',
      cnpj: '00.000.000/0000-00',
      category: 'Detrator',
      lastSurvey: '01/01/2021',
      lastScore: 10,
    },
    {
      id: 1,
      name: 'Empresa 1',
      cnpj: '00.000.000/0000-00',
      category: 'Detrator',
      lastSurvey: '01/01/2021',
      lastScore: 10,
    },
  ];

  function handleNextStep() {
    if (currentStep < maxStep - 1) {
      setCurrentStep((prevState) => prevState + 1);
    } else {
      navigate('/');
    }
  }

  function handlePreviousStep() {
    if (currentStep > 0) {
      setCurrentStep((prevState) => prevState - 1);
    }
  }

  return (
    <SurveyContainer>
      <SurveyStep
        nextStep={handleNextStep}
        previousStep={handlePreviousStep}
        hidden={currentStep != 0}
      >
        <label htmlFor="period">Informe o mês/ano de referência</label>
        <input type="month" />
      </SurveyStep>

      <SurveyStep
        nextStep={handleNextStep}
        previousStep={handlePreviousStep}
        hidden={currentStep != 1}
      >
        <SurveyCustomerContainer>
          <h2>Escolha os clientes que fazem parte da pesquisa</h2>
          <table>
            <thead>
              <tr>
                <th>Selecionar</th>
                <th>Nome</th>
                <th>CNPJ</th>
                <th>Categoria</th>
                <th>Última Pesquisa</th>
                <th>Última nota</th>
              </tr>
            </thead>
            <tbody>
              {customers.map((customer) => {
                return (
                  <tr key={customer.id}>
                    <td>
                      <input type="checkbox" />
                    </td>
                    <td>{customer.name}</td>
                    <td>{customer.cnpj}</td>
                    <td>{customer.category}</td>
                    <td>{customer.lastSurvey}</td>
                    <td>{customer.lastScore}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </SurveyCustomerContainer>
      </SurveyStep>

      <SurveyStep
        nextStep={handleNextStep}
        previousStep={handlePreviousStep}
        hidden={currentStep != 2}
      >
        <SurveyCustomerContainer>
          <h2>Atribua uma nota para cada cliente</h2>
          <p>
            Em uma escala de 0 a 10, qual a probabilidade de você recomendar
            nosso produto/serviço a um amigo/conhecido?
          </p>
          <table>
            <thead>
              <tr>
                <th>Nome</th>
                <th>CNPJ</th>
                <th>Nota</th>
                <th>Motivo</th>
              </tr>
            </thead>
            <tbody>
              {customers.map((customer) => {
                return (
                  <tr key={customer.id}>
                    <td>{customer.name}</td>
                    <td>{customer.cnpj}</td>
                    <td>
                      <input type="number" min={0} max={10} />
                    </td>
                    <td>
                      <input type="text" />
                    </td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </SurveyCustomerContainer>
      </SurveyStep>

      <SurveyStep
        nextStep={handleNextStep}
        previousStep={handlePreviousStep}
        hidden={currentStep != 3}
      >
        <SurveyCustomerContainer>
          <h2>
            Parabéns! Você finalizou a pesquisa
            <Confetti size={32} />
          </h2>
          <p>Clique no botão abaixo para enviar os dados</p>
        </SurveyCustomerContainer>
      </SurveyStep>
    </SurveyContainer>
  );
}
