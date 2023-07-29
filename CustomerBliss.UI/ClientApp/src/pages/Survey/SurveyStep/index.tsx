import { ArrowLeft, ArrowRight } from 'phosphor-react';
import {
  ChildrenContainer,
  StepControlContainer,
  SurveyButton,
  SurveyStepContainer,
} from './styles';

export interface SurveryStepProps {
  children: React.ReactNode;
  nextStep: () => void;
  previousStep: () => void;
  hidden: boolean;
}

export function SurveyStep({
  children,
  hidden,
  nextStep,
  previousStep,
}: SurveryStepProps) {
  return hidden ? (
    <></>
  ) : (
    <SurveyStepContainer>
      <ChildrenContainer>{children}</ChildrenContainer>
      <StepControlContainer>
        <SurveyButton type="button" onClick={previousStep}>
          <ArrowLeft size={16} />
          Anterior
        </SurveyButton>
        <SurveyButton type="button" onClick={nextStep}>
          Próximo
          <ArrowRight size={16} />
        </SurveyButton>
      </StepControlContainer>
    </SurveyStepContainer>
  );
}
