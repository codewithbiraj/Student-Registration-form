import axios from 'axios';
import React, {useEffect, useState} from 'react';
import { useNavigate } from 'react-router-dom';



import {addressType, feeCategory, interest, programeType, scholarshipType, subjectType, timeSlot, transportationMethod,} from '../enums/enum';

const StudentForm = () => {
  const navigate = useNavigate();


  const [student, setStudent] = useState({
    firstName: '',
    lastName: '',
    dateOfBirth: '',
    placeOfBirth: '',
    nationality: '',
    citizenshipNumber: '',
    citizenshipIssueDate: '',
    citizenshipIssueDistrict: '',
    email: '',
    alternativeEmail: '',
    phoneNumber: '',
    secondaryPhoneNumber: '',
    emergencyContactNumber: '',
    emergencyContactRelation: '',
    bloodGroup: '',
    maritalStatus: '',
    religion: '',
    ethnicity: '',
    disability: '',
    gender: '',
    address: {
      province: '',
      municipality: '',
      wardNumber: '',
      tole: '',
      addressType: '',

    },
    parentdetails: {
      fatherName: '',
      fatherOccupation: '',
      fatherPhoneNumber: '',
      motherName: '',
      motherOccupation: '',
      motherPhoneNumber: '',
      guardianName: '',
      guardianOccupation: '',
      guardianPhoneNumber: '',
    },
    academicdetails: {
      previousSchool: '',
      previousGrade: '',
      yearOfCompletion: '',
      percentage: '',
      programeType: '',
      subjectType: '',
    },
    financialdetails: {
      scholarshipType: '',
      feeCategory: '',

    },
    extraCurricular:{
     interest: '',
     timeSlot: '',
     transportationMethod: '',
    },
  });

  const [errors, setErrors] = useState({});
  useEffect(() => {
    getStudentsData();
  }, []);

  
  const onlyString = (value) => value.replace(/[^a-zA-Z\s]/g, '');
  const onlyNumber = (value, max = 10) =>
    value.replace(/\D/g, '').slice(0, max);

  const handleChange = (section, field, value) => {
    debugger
    if (section) {
      setStudent((prev) => ({
        ...prev,
        [section]: { ...prev[section], [field]: value },
      }));
    } else {
        debugger
      setStudent((prev) => ({ ...prev, [field]: value }));
    
    }
    console.log(student)
  };

  
  const validateForm = () => {
    let temp = {};

    if (!student.firstName.trim())
      temp.firstName = 'First Name is required';

    if (!student.lastName.trim())
      temp.lastName = 'Last Name is required';
    if (!student.email.trim())
      temp.email = 'Email is required';
    if (!student.alternativeEmail.trim())
      temp.alternativeEmail = 'AlternativeEmail is required';


    if (!student.gender)
      temp.gender = 'Gender is required';

    if (!student.phoneNumber)
      temp.phoneNumber = 'Phone number is required';
    else if (student.phoneNumber.length !== 10)
      temp.phoneNumber = 'Phone number must be 10 digits';

    if (!student.address.province)
      temp.province = 'Province is required';

    if (!student.academicdetails.previousSchool)
      temp.previousSchool = 'Previous school is required';

    if (!student.financialdetails.feeCategory)
      temp.feeCategory = 'Fee category is required';

    

    setErrors(temp);
    return Object.keys(temp).length === 0;
  };
  


  const handleSubmit = async (e) => {
    e.preventDefault();
    // if (!validateForm()) return;
  console.log(student)
    try {
      const response = await axios.post(
        'http://localhost:5135/api/Student',
        student, 
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      );
  
      console.log('Student saved:', response.data);
      alert('Student registered successfully!');
    } catch (error) {
      console.error('API Error:', error.response?.data || error.message);
      alert('Error submitting form');
    }
  };
  
     const getStudentsData = async () => {
      try {
        const res = await axios.get('http://localhost:5135/api/Student');
        console.log(res.data);
      } catch (err) {
        console.error(err);
      }
    };
  




  
  return (
    <form onSubmit={handleSubmit} className='max-w-6xl mx-auto p-6 space-y-6'>

      
      <div className='border p-4 rounded'>
        <h2 className='font-semibold mb-3'>Basic Information</h2>

        <input
          className="border p-2 w-full"
          placeholder="First Name"
          value={student.firstName}
          onChange={(e) =>
            handleChange(null, "firstName", onlyString(e.target.value))
          }
        />
        {errors.firstName && <p className='text-red-500 text-sm'>{errors.firstName}</p>}

        <input
          className="border p-2 w-full mt-2"
          placeholder="Last Name"
          value={student.lastName}
          onChange={(e) =>
            handleChange(null, "lastName", onlyString(e.target.value))
          }
        />
        {errors.lastName && <p className='text-red-500 text-sm'>{errors.lastName}</p>}

        <input className="border p-2 w-full mt-2" placeholder="Gender" onChange={e=>handleChange(null,"gender",e.target.value)} />
        {errors.gender && <p className='text-red-500 text-sm'>{errors.gender}</p>}
       <div><input type="date" className="border p-2 w-full mt-2" onChange={e=>handleChange(null,"dateOfBirth",e.target.value)} /></div> 

        <input className="border p-2 w-full mt-2 " placeholder="Place of Birth" onChange={e=>handleChange(null,"placeOfBirth",e.target.value)} />
        <input className='border p-2 w-full mt-2' placeholder='Nationality' onChange={e=>handleChange(null,'nationality',e.target.value)} />
        <input className="border p-2 w-full mt-2" placeholder="Citizenship Number" onChange={e=>handleChange(null,"citizenshipNumber",e.target.value)} />
      <input className="border p-2 w-full mt-2" placeholder="Citizenship Issue District" onChange={e=>handleChange(null,"citizenshipIssueDistrict",e.target.value)} />
        <input type='date' className='border p-2 w-full mt-2' onChange={e=>handleChange(null,'citizenshipIssueDate',e.target.value)} />

        <input
          className="border p-2 w-full mt-2"
          placeholder="Email"
          value={student.email}
          onChange={(e) =>
            handleChange(null, "email", e.target.value)
          }
        />
        {errors.email && <p className='text-red-500 text-sm'>{errors.email}</p>}

        <input
          className="border p-2 w-full mt-2"
          placeholder="alternativeEmail"
          value={student.alternativeEmail}
          onChange={(e) =>
            handleChange(null, "alternativeEmail", e.target.value)
          }
        />
        {errors.alternativeEmail && <p className='text-red-500 text-sm'>{errors.alternativeEmail}</p>}
        <input className="border p-2 w-full mt-2" placeholder="phoneNumber" onChange={e=>handleChange(null,"phoneNumber",onlyNumber(e.target.value))} />
        <input className='border p-2 w-full mt-2' placeholder='SecondaryPhoneNumber' onChange={e=>handleChange(null,'secondaryPhoneNumber',e.target.value)} />
        <input className="border p-2 w-full mt-2" placeholder="EmergencyContactNumber" onChange={e=>handleChange(null,"emergencyContactNumber",e.target.value)} />
        <input className='border p-2 w-full mt-2' placeholder='EmergencyContactName' onChange={e=>handleChange(null,'emergencyContactName',e.target.value)} />
        <input className='border p-2 w-full mt-2' placeholder='EmergencyContactRelation' onChange={e=>handleChange(null,'emergencyContactRelation',e.target.value)} />
        <input className="border p-2 w-full mt-2" placeholder="BloodGroup" onChange={e=>handleChange(null,"bloodGroup",e.target.value)} />
        <input className='border p-2 w-full mt-2' placeholder='maritalStatus' onChange={e=>handleChange(null,'maritalStatus',e.target.value)} />
        <input className="border p-2 w-full mt-2" placeholder="Religion" onChange={e=>handleChange(null,"religion",e.target.value)} />
        <input className='border p-2 w-full mt-2' placeholder='Ethnicity' onChange={e=>handleChange(null,'ethnicity',e.target.value)} />
        <input className="border p-2 w-full mt-2" placeholder="Disability" onChange={e=>handleChange(null,"disability",e.target.value)} />
      </div>

      
      <div className="border p-4 rounded">
  <h2 className="font-semibold mb-3">Address</h2>

  <input
    className='border p-2 w-full'
    placeholder='Province'
    value={student.address.province}
    onChange={(e) => handleChange('address', 'province', e.target.value)}
  />
  {errors.province && <p className="text-red-500 text-sm">{errors.province}</p>}

  <input
    className='border p-2 w-full mt-2'
    placeholder='Municipality'
    value={student.address.municipality}
    onChange={(e) => handleChange('address', 'municipality', e.target.value)}
  />

  <input
    className="border p-2 w-full mt-2"
    placeholder="Tole"
    value={student.address.tole}
    onChange={(e) => handleChange("address", "tole", e.target.value)}
  />

  <select
    className='border p-2 w-full mt-2'
    value={student.address.addressType}
    onChange={(e) => handleChange('address', 'addressType', e.target.value)}
  >
    <option value=''>address Type</option>
    {addressType.map((a) => (
      <option key={a} value={a}>{a}</option>
    ))}
  </select>
</div>

      
      <div className='border p-4 rounded'>
        <h2 className=' font-semibold mb-3'>Parent / Guardian Details</h2>
        
          <input className="border p-2 w-full mt-2" placeholder="Father Name" onChange={e=>handleChange("parentdetails","fatherName",e.target.value)} />
          <input className='border p-2 w-full mt-2' placeholder='Father Occupation' onChange={e=>handleChange('parentdetails','fatherOccupation',e.target.value)} />
          <input className="border p-2 w-full mt-2" placeholder="Father Phone" onChange={e=>handleChange("parentdetails","fatherPhoneNumber",e.target.value)} />

          <input className='border p-2 w-full mt-2' placeholder='Mother Name' onChange={e=>handleChange('parentdetails','motherName',e.target.value)} />
          <input className="border p-2 w-full mt-2" placeholder="Mother Occupation" onChange={e=>handleChange("parentdetails","motherOccupation",e.target.value)} />
          <input className='border p-2 w-full mt-2' placeholder='Mother Phone' onChange={e=>handleChange('parentdetails','motherPhoneNumber',e.target.value)} />

          <input className="border p-2 w-full mt-2" placeholder="Guardian Name" onChange={e=>handleChange("parentdetails","guardianName",e.target.value)} />
          <input className='border p-2 w-full mt-2' placeholder='Guardian Occupation' onChange={e=>handleChange('parentdetails','guardianOccupation',e.target.value)} />
          <input className="border p-2 w-full mt-2" placeholder="Guardian Phone" onChange={e=>handleChange("parentdetails","guardianPhoneNumber",e.target.value)} />
          
          
      </div>

      
      <div className="border p-4 rounded">
        <h2 className="font-semibold mb-3">Academic</h2>
        <input
          className='border p-2 w-full'
          placeholder='Previous School'
          onChange={(e) =>
            handleChange('academicdetails', 'previousSchool', e.target.value)
          }
        />
        {errors.previousSchool && <p className="text-red-500 text-sm">{errors.previousSchool}</p>}
        <input className='border p-2 w-full mt-2' placeholder='PreviousGrade' onChange={e=>handleChange('academicdetails','previousGrade',e.target.value)} />
        <input className="border p-2 w-full mt-2" placeholder="yearofCompletion" onChange={e=>handleChange("academicdetails","yearOfCompletion",e.target.value)} />
        <input className='border p-2 w-full mt-2' placeholder='Percentage' onChange={e=>handleChange('academicdetails','percentage',e.target.value)} />
        <select className="border p-2 w-full mt-2" onChange={e=>handleChange("academicdetails","programeType",e.target.value)}>
            <option value="">programe Type</option>
            {programeType.map(a => <option key={a}>{a}</option>)}
          </select>
          <select className='border p-2 w-full mt-2' onChange={e=>handleChange('academicdetails','subjectType',e.target.value)}>
            <option value=''>subject Type</option>
            {subjectType.map(a => <option key={a}>{a}</option>)}
          </select>

      </div>

      
      <div className='border p-4 rounded'>
        <h2 className='font-semibold mb-3'>Financial</h2>
        <select className="border p-2 w-full mt-2" onChange={e=>handleChange("financialdetails","scholarshipType",e.target.value)}>
            <option value="">scholarship Type</option>
            {scholarshipType.map(a => <option key={a}>{a}</option>)}
          </select> 
        <select
          className='border p-2 w-full'
          onChange={(e) =>
            handleChange('financialdetails', 'feeCategory', e.target.value)
          }
        >
          <option value=''>Fee Category</option>
          {feeCategory.map((f) => (
            <option key={f}>{f}</option>
          ))}
        </select>
        {errors.feeCategory && <p className="text-red-500 text-sm">{errors.feeCategory}</p>}
      </div>

       
       <div className="border p-4 rounded-lg">
        <h2 className="text-xl font-semibold mb-4">Extra Curricular Activities</h2>
        <div className='grid grid-cols-3 gap-4'>
          <select className='border p-2' onChange={e=>handleChange('extraCurricular','interest',e.target.value)}>
            <option value=''>interest</option>
            {interest.map(i => <option key={i}>{i}</option>)}
          </select>

          <select className="border p-2" onChange={e=>handleChange("extraCurricular","timeSlot",e.target.value)}>
            <option value="">time Slot</option>
            {timeSlot.map(t => <option key={t}>{t}</option>)}
          </select>

          <select className='border p-2' onChange={e=>handleChange('extraCurricular','transportationMethod',e.target.value)}>
            <option value=''>transportation</option>
            {transportationMethod.map(t => <option key={t}>{t}</option>)}
          </select>
        </div>
      </div>
`      <div className="flex gap-4">
  <button className="bg-blue-600 text-white px-6 py-2 rounded" onSubmit={handleSubmit}>
        Submit
      </button>

      <button
    type="button"
    className="bg-blue-600 text-white px-6 py-2 rounded"
    onClick={() => navigate('/students')}
  >
    View Details
  </button>
  
  </div>`
      

    </form>
    
  );
};

export default StudentForm;
