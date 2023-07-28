import { Route, Routes } from 'react-router-dom';
import { StatsPage } from '../pages/Stats';
import { DefaultLayout } from '../layouts/DefaultLayout';
import { SurveyPage } from '../pages/Survey';
import { CustomerManagementPage } from '../pages/Customer/Management';

export function Router() {
  return (
    <Routes>
      <Route path="/" element={<DefaultLayout />}>
        <Route path="/" element={<StatsPage />}></Route>
        <Route path="/survey" element={<SurveyPage />}></Route>
        <Route
          path="/customer/management"
          element={<CustomerManagementPage />}
        ></Route>
      </Route>
    </Routes>
  );
}
