import React, { useState } from "react";
import "./App.css";

function App() {
  const [formData, setFormData] = useState({
    name: "",
    email: "",
  });

  const handleChange = (e) => {
    setFormData({ 

      ...formData, 
      [e.target.name]: e.target.value 
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log(formData);
    alert(`Name: ${formData.name}\nEmail: ${formData.email}`);
  };

  return (
    <div className="form-container">
      <h2>Simple Form</h2>

      <form onSubmit={handleSubmit}>
        <label>Name:</label>
        <input 
          type="text" 
          name="name"
          value={formData.name}
          onChange={handleChange}
          placeholder="Enter your name"
        />

        <label>Email:</label>
        <input 
          type="email" 
          name="email"
          value={formData.email}
          onChange={handleChange}
          placeholder="Enter your email"
        />

        <button type="submit">Submit</button>
      </form>
    </div>
  );
}

export default App;
