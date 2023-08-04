import { useForm } from 'react-hook-form';
import * as zod from 'zod';
import {
  CustomerRegistrationFormContainer,
  ErrorMessage,
  SubmitButton,
} from './styles';
import { zodResolver } from '@hookform/resolvers/zod';
import { format } from 'date-fns';
import api from '../../../services/api';

export function CustomerRegistrationPage() {
  const customerFormValidationSchema = zod.object({
    companyName: zod.string().min(2).max(150),
    contactName: zod.string().min(2).max(150),
    companyDocument: zod.string(),
    registrationDate: zod
      .string()
      .transform((str) =>
        str == 'dd/mm/aaaa' ? null : format(new Date(str), 'yyyy-MM-dd')
      ),
  });

  type CustomerFormType = zod.infer<typeof customerFormValidationSchema>;

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm<CustomerFormType>({
    resolver: zodResolver(customerFormValidationSchema),
  });

  const handleOnSubmit = (data: CustomerFormType) => {
    api
      .postCustomer({
        name: data.companyName,
        contactName: data.contactName,
        companyDocument: data.companyDocument,
        intialDate: customerFormValidationSchema.safeParse(data).success
          ? data.registrationDate
          : null,
      })
      .then(() => {
        reset();
      });
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
          <label>CNPJ:</label>
          <input {...register('companyDocument', { required: false })} />
        </div>

        <div>
          <label>Data em que se tornou cliente:</label>
          <input
            type="date"
            value={format(new Date(), 'yyyy-MM-dd')}
            {...register('registrationDate', { required: false })}
          />
        </div>

        <div>
          <SubmitButton type="submit">Enviar</SubmitButton>
        </div>
      </CustomerRegistrationFormContainer>
    </form>
  );
}
