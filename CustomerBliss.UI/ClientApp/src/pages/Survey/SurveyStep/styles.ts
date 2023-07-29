import styled from 'styled-components';

export const SurveyStepContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: flex-start;
  gap: 0.5rem;
  margin: 0.5rem 0;
`;

export const ChildrenContainer = styled.div`
  display: flex;
  flex-direction: row;
`;

export const StepControlContainer = styled.div`
  display: flex;
  flex-direction: row;
  align-items: center;
  gap: 0.5rem;
`;

export const SurveyButton = styled.button`
  display: flex;
  align-items: center;

  gap: 0.5rem;
  background: ${(props) => props.theme['blue-500']};

  padding: 0.3rem;
  color: ${(props) => props.theme['beige-100']};
  border-radius: 8px;
  border: 0;
  transition: background 0.2s ease;
  cursor: pointer;
  &:hover {
    background: ${(props) => props.theme['blue-700']};
  }
`;
