import { BrowserRouter, Route,Routes,Navigate } from "react-router-dom";
import AdminLayout from "./layouts/Admin";
import Client from "./layouts/Client";

function App() {
  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path="/admin/*" element={<AdminLayout />} />
          <Route path="/client/*" element={<Client />}/>
          <Route path="*" element={<Navigate to="/client/home" replace />} />
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;
