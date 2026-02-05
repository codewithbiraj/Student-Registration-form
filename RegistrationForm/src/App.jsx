import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import StudentForm from './component/StudentForm';
import ViewDetails from './component/viewdetails';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<StudentForm />} />
        <Route path="/students" element={<ViewDetails />} />
       
      </Routes>
    </Router>
  );
}

export default App;
