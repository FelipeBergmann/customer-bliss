import { useForm } from 'react-hook-form';
import * as zod from 'zod';
import {
  CustomerRegistrationFormContainer,
  ErrorMessage,
  SubmitButton,
} from './styles';

export function CustomerRegistrationPage() {
  const customerFormValidationSchema = zod.object({
    companyName: zod.string().min(2).max(150),
    contactName: zod.string().min(2).max(150),
    companyDocument: zod.string().refine(
      (value) => {
        const cnpjRegex = /^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$/;
        return cnpjRegex.test(value);
      },
      { message: 'CNPJ inválido.' }
    ),
    registrationDate: zod.date(),
  });

  type CustomerFormType = zod.infer<typeof customerFormValidationSchema>;

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm<CustomerFormType>();
  const handleOnSubmit = (data: CustomerFormType) => {
    console.log(data);
    reset();
  };
  return (
    <form onSubmit={handleSubmit(handleOnSubmit)}>
      <CustomerRegistrationFormContainer>
        <div>
          <label>Nome do cliente (razão social ou nome fantasia)*:</label>
          <input {...register('companyName', { required: true })} />
          {errors.companyName && (
            <ErrorMessage>Este campo é obrigatório.</ErrorMessage>
          )}
        </div>

        <div>
          <label>Nome da pessoa de contato (responsável)*:</label>
          <input {...register('contactName', { required: true })} />
          {errors.contactName && (
            <ErrorMessage>Este campo é obrigatório.</ErrorMessage>
          )}
        </div>

        <div>
          <label>CNPJ*:</label>
          <input {...register('companyDocument', { required: true })} />
          {errors.companyDocument && (
            <ErrorMessage>Este campo é obrigatório.</ErrorMessage>
          )}
        </div>

        <div>
          <label>Data em que se tornou cliente*:</label>
          <input
            type="date"
            {...register('registrationDate', { required: true })}
          />
          {errors.registrationDate && (
            <ErrorMessage>Este campo é obrigatório.</ErrorMessage>
          )}
        </div>

        <div>
          <SubmitButton type="submit">Enviar</SubmitButton>
        </div>
      </CustomerRegistrationFormContainer>
    </form>
  );
}
