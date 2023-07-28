import { Route, Routes } from 'react-router-dom';
import { StatsPage } from '../pages/Stats';
import { DefaultLayout } from '../layouts/DefaultLayout';
import { SurveyPage } from '../pages/Survey';
import { CustomerManagement } from '../pages/customer';
import { CustomerRegistrationPage } from '../pages/customer/Registration';
import { Lookup } from '../pages/customer/Lookup';

export function Router() {
  return (
    <Routes>
      <Route path="/" element={<DefaultLayout />}>
        <Route path="/" element={<StatsPage />}></Route>
        <Route path="survey" element={<SurveyPage />}></Route>
        <Route path="customer" element={<CustomerManagement />}></Route>
        <Route
          path="customer/new"
          element={<CustomerRegistrationPage />}
        ></Route>
        <Route path="customer/find" element={<Lookup />}></Route>
      </Route>
    </Routes>
  );
}
